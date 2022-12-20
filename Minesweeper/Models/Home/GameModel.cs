using System;

namespace Minesweeper.Models.Home
{
    public class GameModel
    {
        public int ID { get; set; }
        public DateTime GameDate { get; set; }
        public int UserID { get; set; }
        public int Score { get; set; }

    }
}
