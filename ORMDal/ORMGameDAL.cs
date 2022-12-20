using Interfaces;
using System.Linq;


namespace ORMDAL
{
    public class ORMGameDAL : IGameDAL
    {
        public Entities.Game GetByUserID(int UserId)
        {
            var context = new DefaultDBContext();
            try
            {
                var game = context.Game.FirstOrDefault(item => item.UserID == UserId);
                if (game == null)
                {
                    return null;
                }
                return new Entities.Game()
                {
                    ID = game.ID,
                    Score = game.Score,
                    GameDate = game.GameDate,
                    UserID = game.UserID
                };
            }
            finally
            {
                context.Dispose();
            }
        }

        public void PutGame(Entities.Game game)
        {
            var context = new DefaultDBContext();
            try
            {
                context.Game.Add(new Game()
                {
                    Score = game.Score,
                    GameDate = game.GameDate,
                    UserID = game.UserID
                });
                context.SaveChanges();
            }
            finally
            {
                context.Dispose();
            }
        }
    }
}

