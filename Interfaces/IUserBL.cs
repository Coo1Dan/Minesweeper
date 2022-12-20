using Entities;

namespace Interfaces
{
    public interface IUserBL
    {
        User GetByID(int id);
        User GetByLogin(string login);
        void PutUser(User user);
    }
}
