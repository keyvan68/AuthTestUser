using System.ComponentModel.DataAnnotations;
using AuthTestUser.Repository;
using AuthTestUser.Context;
using AuthTestUser.IRepositories;
using AuthTestUser.Entities;
using Microsoft.AspNetCore.Identity;

namespace AuthTestUser.ViewModels.User
{
    public class LoginViewModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        
        public LoginViewModel()
        {

        }

        public LoginViewModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string User_Pass { get; set; }

        public string User_Code { get; set; }


        public Boolean Login()
        {
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();

            IUserRepository userRepository = new UserRepository(applicationDbContext);
            var Res = userRepository.GetAll().Where(x => string.Compare(x.User_Code, this.User_Code) == 0 && string.Compare(x.User_Pass, this.User_Pass) == 0).Any();

            return Res;
        }
        public async Task<SignInResult> Login1(LoginViewModel VM)
        {
            var result = await _signInManager.PasswordSignInAsync(VM.User_Code, VM.User_Pass,true, false);

            return result;
        }
    }
}
