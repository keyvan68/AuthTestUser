using AuthTestUser.Classes;
using Azure.Core;
using AuthTestUser.Repository;
using AuthTestUser.Context;
using AuthTestUser.Entities;
using AuthTestUser.Enums;
using AuthTestUser.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthTestUser.ViewModels.User
{
    public class UserViewModel
    {
        

        public Guid User_ID { get; set; }
        [Required(ErrorMessage =" کد کاربری اجبای است")]
        public string User_Code { get; set; }
        [Required(ErrorMessage = " رمز کاربری اجبای است")]
        public string User_Pass { get; set; }
        [Required(ErrorMessage = " نام کاربری اجبای است")]
        public string User_FullName { get; set; }

        public string User_Role { get; set; }





        public UserViewModel()
        {
           
        }


        public ResultClass<UserViewModel> initNew()
        {


            ResultClass<UserViewModel> RC = new ResultClass<UserViewModel>();


            ApplicationDbContext applicationDbContext = new();
            IUserRepository userRepository = new UserRepository(applicationDbContext);

            RC.Result = new UserViewModel();
            RC.Result.User_ID = Guid.NewGuid();
          


            return RC;
        }


        public ResultClass<bool> StoreData()
        {
            ResultClass<bool> RC = new ResultClass<bool>();


            ApplicationDbContext applicationDbContext = new();

            IUserRepository userRepository = new UserRepository(applicationDbContext);
            var user = userRepository.Find(this.User_ID);
            if (user == null)
            {
                user = new AuthTestUser.Entities.User();
                user.User_ID = this.User_ID;

                userRepository.Add(user);
              


            }
            else
            {
                userRepository.Update(user);
            }
            user.User_FullName = this.User_FullName;
            user.User_Pass = this.User_Pass;
            user.User_Code = this.User_Code;
            user.User_Role = this.User_Role;



            if (RC.isSuccsed == false) return RC;


            int C = applicationDbContext.SaveChanges();
            if (C == 0)
            {
                RC.SetDefualtErrorSystem();
            }
            else
            {
                RC.SetDefualtSuccessSystem();
            }



            return RC;
        }


        public ResultClass<UserViewModel> LoadData(Guid id)
        {
            ResultClass<UserViewModel> RC = new ResultClass<UserViewModel>();
           ApplicationDbContext applicationDbContext = new();
            IUserRepository userRepository = new UserRepository(applicationDbContext);
           

            var user = userRepository.Find(id);
            RC.Result = new UserViewModel
            {
                User_Code = user.User_Code,
                User_FullName = user.User_FullName,
                User_ID = user.User_ID,
                User_Pass = user.User_Pass,
                User_Role=user.User_Role

            };


          
          

            return RC;
        }

        public ResultClass<bool> Delete(Guid id)
        {
            ResultClass<bool> RC = new ResultClass<bool>();
            ApplicationDbContext applicationDbContext = new();

            IUserRepository userRepository = new UserRepository(applicationDbContext);
            var user = userRepository.Find(id);
            if (user != null)
            {
                userRepository.Remove(id);
            }

            int C = applicationDbContext.SaveChanges();
            if (C == 0)
            {
                RC.SetDefualtErrorSystem();
            }
            else
            {
                RC.SetDefualtSuccessSystem();
            }

            return RC;
        }
        
}
}
