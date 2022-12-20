using Entities;
using Interfaces;

namespace BL
{
    public class UserBL : IUserBL
    {
        private readonly IUserDAL _dal;

        public UserBL(IUserDAL dal)
        {
            _dal = dal;
        }

        public User GetByLogin(string login)
        {
            return _dal.GetByLogin(login);
        }

        public User GetByID(int id)
        {
            return _dal.GetByID(id);
        }

        public void PutUser(User user)
        {
            _dal.PutUser(user);
        }

    }
}

