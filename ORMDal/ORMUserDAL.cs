using Interfaces;
using System.Linq;


namespace ORMDAL
{
    public class ORMUserDAL : IUserDAL
    {
        public Entities.User GetByLogin(string login)
        {
            var context = new DefaultDBContext();
            try
            {
                var user = context.User.FirstOrDefault(item => item.Login == login);

                if (user == null)
                {
                    return null;
                }
                var entity = new Entities.User()
                {
                    ID = user.ID,
                    Name = user.Name,
                    Password = user.Password,
                    Login = user.Login,
                    RegisterDate = user.RegisterDate
                };
                return entity;
            }
            finally
            {
                context.Dispose();
            }
        }

        public Entities.User GetByID(int id)
        {
            var context = new DefaultDBContext();
            try
            {
                var user = context.User.FirstOrDefault(item => item.ID == id);

                if (user == null)
                {
                    return null;
                }
                var entity = new Entities.User()
                {
                    ID = user.ID,
                    Name = user.Name,
                    Password = user.Password,
                    Login = user.Login,
                    RegisterDate = user.RegisterDate
                };
                return entity;
            }
            finally
            {
                context.Dispose();
            }

        }

        public void PutUser(Entities.User user)
        {
            var context = new DefaultDBContext();
            try
            {
                context.User.Add(new User()
                {
                    Name = user.Name,
                    Password = user.Password,
                    Login = user.Login,
                    RegisterDate = user.RegisterDate
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
