using Interfaces;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class GameDAL : IGameDAL
    {
        private readonly List<Game> games = new List<Game>() { };

        public Game GetByID(int id)
        {
            return games.FirstOrDefault(item => item.ID == id);
        }

        public Game GetByUserID(int UserId)
        {
            return games.FirstOrDefault(item => item.UserID == UserId);
        }

        public void PutGame(Game game)
        {
            games.Add(game);
        }
    }
}
