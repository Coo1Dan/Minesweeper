using System;

namespace ORMDAL
{
    public partial class Game
    {
        public int ID { get; set; }
        public DateTime? GameDate { get; set; }
        public int? UserID { get; set; }
        public int Score { get; set; }
        public virtual User User { get; set; }
    }
}
