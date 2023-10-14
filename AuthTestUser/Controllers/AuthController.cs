using AuthTestUser.Context;
using AuthTestUser.Entities;
using AuthTestUser.IRepositories;
using AuthTestUser.Repository;
using AuthTestUser.ViewModels;
using AuthTestUser.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AuthTestUser.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.User_Code);
            ApplicationDbContext applicationDbContext= new ApplicationDbContext();
            IUserRepository userRepository = new UserRepository(applicationDbContext);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(model.User_Code, model.User_Pass, false, false);
                if (result.Succeeded)
                {
                    // ورود موفقیت‌آمیز بود.

                    // بررسی نقش‌های کاربر
                    var roles = await _userManager.GetRolesAsync(user);

                    if (roles.Contains("Admin"))
                    {
                        // کاربر نقش Admin دارد، می‌توانید عملیات مرتبط با نقش Admin را انجام دهید.
                    }
                    else if (roles.Contains("User"))
                    {
                        // کاربر نقش User دارد، می‌توانید عملیات مرتبط با نقش User را انجام دهید.
                    }

                    return Ok(new { message = "ورود موفقیت‌آمیز بود." });
                }
            }
            // ورود ناموفق بود.
            return BadRequest(new { message = "ورود ناموفق بود." });
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            var user = new ApplicationUser();
            //EnumViewModel enumView = new EnumViewModel()
            if (model.User_Role.Any())
            {
                user = new ApplicationUser
                {
                    Id=Guid.NewGuid(),
                    UserName = model.User_Code,
                    Users = new User()
                    {
                        User_ID = user.Id,
                        User_Code = model.User_Code,
                        User_Pass = model.User_Pass,
                        User_FullName = model.User_FullName,
                        User_Role = model.User_Role
                    }

                };
            }

            var result = await _userManager.CreateAsync(user, model.User_Pass);
            if (result.Succeeded)
            {
            //    // ثبت‌نام موفقیت‌آمیز بود.

            //    // ایجاد نقش مورد نظر (مثلاً "User") اگر وجود نداشت
            //    var roleExists = await _roleManager.RoleExistsAsync("User");
            //    if (!roleExists)
            //    {
            //        var newRole = new IdentityRole<Guid>("User");
            //        await _roleManager.CreateAsync(newRole);
            //    }

                // اختصاص نقش به کاربر
                await _userManager.AddToRoleAsync(user, model.User_Role);

                return Ok(new { message = "ثبت‌نام موفقیت‌آمیز بود." });
            }
            // خطا در ثبت‌ نام.
            return BadRequest(new { message = "خطا در ثبت‌ نام." });
        }
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { message = "‌خروج موفقیت‌آمیز بود." });
        }

    }
}
