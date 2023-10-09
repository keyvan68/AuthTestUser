using AuthTestUser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthTestUser.IRepositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        public IQueryable<User> GetAll();
        //bool ExistUser(string User_FullName);

        //bool Login(string User_FullName, string Password);

        //bool PasswordIsCorrect(string User_FullName, string Password);
    }
}
