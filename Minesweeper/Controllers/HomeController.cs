using Interfaces;
using Entities;
using Minesweeper.Models;
using Minesweeper.Models.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace Minesweeper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUserBL _userBL;
        private IGameBL _gameBL;

        public HomeController(ILogger<HomeController> logger, IUserBL usersBl, IGameBL gameBl)
        {
            _logger = logger;
            _userBL = usersBl;
            _gameBL = gameBl;
        }

        [Authorize]
        public IActionResult Index(int id, string name)
        {
            TempData["Success"] = "Success";

            if (User.Identity.IsAuthenticated)
            {
                var userName = User.Identity.Name;
            }

            return View("Index");
        }

        public IActionResult Privacy()
        {
            return Json(new { Id = 007, Name = "Danila" });
        }


        public IActionResult Info()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestID = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [Authorize]
        public IActionResult StartGame()
        {
            Game newGame = new Game();
            GameModel gameModel = new GameModel()
            {
                Score = 0,
                GameDate = DateTime.Now,
                UserID = _userBL.GetByLogin(User.Identity.Name).ID
            };
            return View(gameModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult SaveGame(int score)
        {
            Game game = new Game()
            {
                Score = score,
                GameDate = DateTime.Now,
                UserID = _userBL.GetByLogin(User.Identity.Name).ID
            };
            _gameBL.PutGame(game);

            return RedirectToAction("StartGame", "Home");
        }
    }
}
