using Entities;

namespace Interfaces
{
    public interface IGameDAL
    {
        Game GetByUserID(int UserId);
        void PutGame(Game game);
    }
}

