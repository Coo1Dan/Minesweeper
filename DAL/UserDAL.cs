using Entities;
using Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class UserDAL : IUserDAL
    {
        private readonly List<User> users = new List<User>() { };

        public User GetByID(int id)
        {
            return users.FirstOrDefault(item => item.ID == id);
        }
        public User GetByLogin(string login)
        {
            return users.FirstOrDefault(item => item.Name == login);
        }
        public void PutUser(User user)
        {
            users.Add(user);
        }
    }
}

