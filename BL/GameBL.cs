using Interfaces;
using Entities;

namespace BL
{
    public class GameBL : IGameBL
    {
        private readonly IGameDAL _dal;

        public GameBL(IGameDAL dal)
        {
            _dal = dal;
        }
        public Game GetByUserID(int UserId)
        {
            return _dal.GetByUserID(UserId);
        }

        public void PutGame(Game game)
        {
            _dal.PutGame(game);
        }
    }
}