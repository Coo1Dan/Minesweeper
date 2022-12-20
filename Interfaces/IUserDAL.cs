using Entities;

namespace Interfaces
{
    public interface IUserDAL
    {
        User GetByID(int id);
        User GetByLogin(string login);
        void PutUser(User user);
    }
}