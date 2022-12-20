using Entities;
using Interfaces;
using Minesweeper.Models.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Minesweeper.Controllers
{
    public class UserController : Controller
    {
        private IUserBL _bl;
        public UserController(IUserBL bl)
        {
            _bl = bl;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = _bl.GetByLogin(loginModel.Login);

            if (user != null && user.Password == loginModel.Password)
            {
                var identity = new CustomUserIdentity(user);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            }
            return RedirectToAction("StartGame", "Home");
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegisterModel regModel)
        {
            User newUser = new User()
            {
                Name = regModel.FIO,
                Login = regModel.Login,
                Password = regModel.Password,
                RegisterDate = DateTime.Now
            };
            _bl.PutUser(newUser);
            var identity = new CustomUserIdentity(newUser);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            return RedirectToAction("StartGame", "Home");
        }


        public IActionResult Get(int id)
        {
            var user = _bl.GetByID(id);

            if (user != null)
            {
                return View(new UserModel() { ID = user.ID, FullName = $"{user.Name}" });
            }
            else
            {
                return View();
            }
        }

    }
}

