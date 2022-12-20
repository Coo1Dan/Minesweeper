using System;

namespace Entities
{
    public class Game
    {
        public int ID { get; set; }
        public DateTime? GameDate { get; set; }
        public int? UserID { get; set; }
        public int Score { get; set; }
    }
}
