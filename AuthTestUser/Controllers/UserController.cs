using Application;
using AuthTestUser.Classes;
using Application.ViewModels.User;
using AuthTestUser.Classes;
using AuthTestUser.Enums;
using AuthTestUser.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Net.WebSockets;
using System.Security.AccessControl;
using AuthTestUser.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using AuthTestUser.Entities;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;


    public UserController(ILogger<UserController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _signInManager = signInManager;
        _userManager = userManager;
    }



    [HttpGet, Route("initNew")]
    public ResultClass<UserViewModel> initNew()
    {
        try
        {
            UserViewModel UserViewModel = new UserViewModel();
            var obj = UserViewModel.initNew();

            return obj;
        }
        catch (Exception Ex)
        {

            ResultClass<UserViewModel> resultClass = new AuthTestUser.Classes.ResultClass<UserViewModel>();
            resultClass.Errors.Add(ExceptionHandlerClass.GetPersianMessage(Ex));

            return resultClass;
        }
    }


    [HttpGet, Route("Edit")]
    public async Task<ResultClass<UserViewModel>> Edit(Guid id)
    {
        try
        {
            UserViewModel UserViewModel = new UserViewModel();
            var obj = UserViewModel.LoadData(id);

            return obj;
        }
        catch (Exception Ex)
        {
            ResultClass<UserViewModel> resultClass = new ResultClass<UserViewModel>();
            resultClass.Errors.Add(ExceptionHandlerClass.GetPersianMessage(Ex));

            return resultClass;
        }

    }


    [HttpPost, Route("StoreData")]
    public ResultClass<Boolean> StoreData(UserViewModel UserViewModel)
    {


        try
        {
            ResultClass<Boolean> res = new ResultClass<bool>();

            if (ModelState.IsValid)
            {
                var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
                res = UserViewModel.StoreData();
            }
            else
            {
                var errors = ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                                    .Select(m => m.ErrorMessage).ToList();
                res.SetError(errors);

            }

            return res;


        }
        catch (Exception Ex)
        {
            ResultClass<Boolean> resultClass = new ResultClass<Boolean>();
            resultClass.Errors.Add(ExceptionHandlerClass.GetPersianMessage(Ex));

            return resultClass;
        }



    }

    [HttpDelete, Route("Delete")]
    public ResultClass<Boolean> Delete(Guid id)
    {
        try
        {
            UserViewModel UserViewModel = new UserViewModel();
            var res = UserViewModel.Delete(id);

            return res;
        }
        catch (Exception Ex)
        {
            ResultClass<Boolean> resultClass = new ResultClass<Boolean>();
            resultClass.Errors.Add(ExceptionHandlerClass.GetPersianMessage(Ex));

            return resultClass;
        }


    }

    [HttpGet, Route("InitGetList")]
    public ResultClass<UserListCondViewModel> InitGetList()
    {
        try
        {
            ResultClass<UserListCondViewModel> resultClass = new ResultClass<UserListCondViewModel>();

            UserListCondViewModel UserViewModel = new UserListCondViewModel();
            UserViewModel.New();
            resultClass.SetDefualtSuccessSystem();

            return resultClass;


        }
        catch (Exception Ex)
        {
            ResultClass<UserListCondViewModel> resultClass = new ResultClass<UserListCondViewModel>();
            resultClass.Errors.Add(ExceptionHandlerClass.GetPersianMessage(Ex));

            return resultClass;
        }

    }

    [HttpPost, Route("GetList")]
    public ResultClass<List<UserListCondViewModel.UserListClass>> GetList(UserListCondViewModel UserViewModel)
    {
        // 
        try
        {
            var user = UserViewModel.GetAll();
            return user;

        }
        catch (Exception Ex)
        {
            ResultClass<List<UserListCondViewModel.UserListClass>> resultClass = new ResultClass<List<UserListCondViewModel.UserListClass>>();
            resultClass.Errors.Add(ExceptionHandlerClass.GetPersianMessage(Ex));

            return resultClass;
        }
    }

    [HttpPost, Route("Login")]
    public ResultClass<Boolean> Login(LoginViewModel VM)
    {
        try
        {
            ResultClass<Boolean> Res = new ResultClass<bool>();
            
            Res.Result = VM.Login();
            if (Res.Result)
            {
                Res.SetDefualtSuccessSystem();
            } else
            {
                Res.Errors.Add("کاربری با این مشخصات پیدا نشد");
            }
            

            return Res;

        }
        catch (Exception Ex)
        {
            ResultClass<Boolean> resultClass = new ResultClass<Boolean>();
            resultClass.Errors.Add(ExceptionHandlerClass.GetPersianMessage(Ex));

            return resultClass;
        }


    }
    [HttpPost, Route("LoginV2")]
    public async Task<ResultClass<Boolean>> LoginV2(LoginViewModel VM)
    {
        try
        {
            ResultClass<Boolean> Res = new ResultClass<bool>();
            var result = await VM.Login1(VM);
            if (Res.Result)
            {
                Res.SetDefualtSuccessSystem();
                var user = await _userManager.FindByEmailAsync(VM.User_Code);
                var roles = await _userManager.GetRolesAsync(user);
            }
            else
            {
                Res.Errors.Add("کاربری با این مشخصات پیدا نشد");
            }


            return Res;

        }
        catch (Exception Ex)
        {
            ResultClass<Boolean> resultClass = new ResultClass<Boolean>();
            resultClass.Errors.Add(ExceptionHandlerClass.GetPersianMessage(Ex));

            return resultClass;
        }


    }

    [HttpGet, Route("Logout")]
    public ResultClass<Boolean> Logout()
    {
        try
        {
            ResultClass<Boolean> Res = new ResultClass<bool>();
            Res.Result = true;
            Res.SetDefualtSuccessSystem();

            return Res;

        }
        catch (Exception Ex)
        {
            ResultClass<Boolean> resultClass = new ResultClass<Boolean>();
            resultClass.Errors.Add(ExceptionHandlerClass.GetPersianMessage(Ex));

            return resultClass;
        }


    }



}
