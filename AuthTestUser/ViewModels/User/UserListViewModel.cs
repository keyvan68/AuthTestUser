using AuthTestUser.Classes;
using AuthTestUser.Repository;
using AuthTestUser.Context;
using AuthTestUser.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.User
{
    public class UserListViewModel
    {
        //public ResultClass<List<UserViewModel>> getData()
        //{
        //    ApplicationDbContext applicationDbContext = new();
        //    IUserRepository userRepository = new UserRepository(applicationDbContext);

        //    var user =  userRepository.GetAll();
        //    ResultClass<List<UserViewModel>> RC = new ResultClass<List<UserViewModel>>();
        //    RC.Result = user.ToList();

        //}

    }
}
