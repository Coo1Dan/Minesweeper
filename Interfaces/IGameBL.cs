using Entities;

namespace Interfaces
{
    public interface IGameBL
    {
        Game GetByUserID(int UserId);
        void PutGame(Game game);
    }
}
