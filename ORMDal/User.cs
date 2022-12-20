using System;
using System.Collections.Generic;

namespace ORMDAL
{
    public partial class User
    {
        public User()
        {
            Game = new HashSet<Game>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public virtual ICollection<Game> Game { get; set; }
    }
}

