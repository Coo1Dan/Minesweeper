using System;

namespace Minesweeper.Models.User
{
    public class RegisterModel
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
