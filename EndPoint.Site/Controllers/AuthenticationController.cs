using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Bugeto_Store.Application.Services.Users.Commands.RgegisterUser;
using Bugeto_Store.Application.Services.Users.Commands.UserLogin;
using Bugeto_Store.Common.Dto;
using Bugeto_Store.Domain.Entities.Users;
using Bugeto_Store.Persistence.Contexts;
using EndPoint.Site.Models.ViewModels.AuthenticationViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
    public class AuthenticationController : Controller
    {

        private readonly IRegisterUserService _registerUserService;
        private readonly IUserLoginService _userLoginService;


        private readonly UserManager<UserApp> _userManager;
        private readonly DataBaseContext _context;
        private readonly SignInManager<UserApp> _signInManager;

        public AuthenticationController(IRegisterUserService registerUserService , IUserLoginService userLoginService)
        {
            _registerUserService = registerUserService;
            _userLoginService = userLoginService;
            //_userManager = userManager;
            //_context = context;
            //_signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(SignupViewModel request)
        {
            if (string.IsNullOrWhiteSpace(request.FullName) ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.RePassword))
            {
                return Json(new ResultDto { IsSuccess = false, Message = "لطفا تمامی موارد رو ارسال نمایید" });
            }

            if (User.Identity.IsAuthenticated == true)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "شما به حساب کاربری خود وارد شده اید! و در حال حاضر نمیتوانید ثبت نام مجدد نمایید" });
            }
            if (request.Password != request.RePassword)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "رمز عبور و تکرار آن برابر نیست" });
            }
            if (request.Password.Length < 8)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "رمز عبور باید حداقل 8 کاراکتر باشد" });
            }

            string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";

            var match = Regex.Match(request.Email, emailRegex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return Json(new ResultDto { IsSuccess = true, Message = "ایمیل خودرا به درستی وارد نمایید" });
            }


            var signeupResult = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = request.Email,
                FullName = request.FullName,
                Password = request.Password,
                RePasword = request.RePassword,
                roles = new List<RolesInRegisterUserDto>()
                {
                     new RolesInRegisterUserDto { Id = 2},
                     new RolesInRegisterUserDto { Id = 1},
                     new RolesInRegisterUserDto { Id = 3},
                }
            });

            if (signeupResult.IsSuccess == true)
            {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,signeupResult.Data.UserId.ToString()),
                new Claim(ClaimTypes.Email, request.Email),
                new Claim(ClaimTypes.Name, request.FullName),
                new Claim(ClaimTypes.Role, "Customer"),
            };


                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, properties);

            }
            return Json(signeupResult);
        }

        [HttpGet]
        public IActionResult Signin(string ReturnUrl = "/")
        {
            ViewBag.url = ReturnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Signin(string Email, string Password, string url = "/")
        {
            var signupResult = _userLoginService.Execute(Email, Password);
            if (signupResult.IsSuccess == true)
            {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,signupResult.Data.UserId.ToString()),
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Name, signupResult.Data.Name),

            };
                foreach (var item in signupResult.Data.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                }

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5),
                };
                HttpContext.SignInAsync(principal, properties);

            }
            return Json(signupResult);
        }



        //[HttpPost("/logOut")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> LogOut()
        //{
        //    if (User.Identity is { IsAuthenticated: true })
        //    {
        //        await _signInManager.SignOutAsync();
        //    }

        //    return Redirect("/login");

        //}

        //[HttpPost("/Signup")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Signup(RegisterUserViewModel model, string returnUrl = "/Admin")
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (await UserExist(model.PhoneNumber))
        //        {
        //            ModelState.AddModelError("PhoneNumber", "کاربری با این شماره تماس ثبت نام کرده است!");
        //            return View(model);
        //        }

        //        var loginCode = new Random().Next(100000, 999999);
        //        var registerResult = await _userManager.CreateAsync(new UserApp()
        //        {
        //            Name = model.Name,
        //            Family = model.Family,
        //            PhoneNumber = model.PhoneNumber,
        //            UserName = model.PhoneNumber,
        //            LoginCode = loginCode.ToString(),
        //            ExpireLoginCode = DateTime.Now.AddMinutes(1)
        //        }, loginCode.ToString());


        //        if (registerResult.Succeeded)
        //        {
        //            // send confrim code message for phone number
        //            //await _smsService.SendPattern(model.PhoneNumber, loginCode.ToString());

        //            if (Url.IsLocalUrl(returnUrl))
        //            {
        //                return Redirect(returnUrl);
        //            }

        //            return Redirect("/Admincp");
        //            //return View(model);

        //            //return Ok(new ResultDto<string>()
        //            //{
        //            //    Message = "کاربر گرامی کد فعال سازی برای شما ارسال شد!",
        //            //    IsSuccess = true,
        //            //    Data = loginCode.ToString()
        //            //});
        //        }
        //        //return View(model);
        //    }
        //    ModelState.AddModelError("PhoneNumber", "کاربر گرامی خطایی رخ داد!");
        //    return View(model);
        //}

        //[HttpPost("/Login")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(AdminLoginViewModel model, string returnUrl = "/Admincp")
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var loginResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, true);
        //        if (loginResult.Succeeded)
        //        {
        //            if (Url.IsLocalUrl(returnUrl))
        //            {
        //                return Redirect(returnUrl);
        //            }

        //            return Redirect("/");
        //        }

        //        ModelState.AddModelError("Password", "نام کاربری یا کلمه عبور اشتباه است");
        //        return View(model);
        //    }

        //    return View(model);
        //}



        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
