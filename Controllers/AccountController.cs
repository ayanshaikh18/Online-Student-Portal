using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using StudentPortal.Models;
using StudentPortal.ViewModels;

namespace StudentPortal.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> _userManager,
            SignInManager<AppUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string role)
        {
            if (role == "Student")
            {
                return View("StudentRegister");
            }
            return View("FacultyRegister");
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> StudentRegister(StudentRegisterViewModel model)
        {
                if (ModelState.IsValid)
                {
                    // Copy data from RegisterViewModel to IdentityUser
                    var user = new AppUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        Name = model.Name,
                        PhoneNumber = model.PhoneNumber,
                        BirthDate = model.BirthDate,
                        Address = model.Address,
                        Gender = model.Gender,
                        Caste = model.Caste,
                        Branch = model.Branch,
                        HscBoard = model.HscBoard,
                        BoardResult = model.BoardResult,
                        IsStudent=true
                    };
                    // Store user data in AspNetUsers database table
                    var result = await userManager.CreateAsync(user, model.Password);
                    // If user is successfully created, sign-in the user using
                    // SignInManager and redirect to index action of HomeController
                    if (result.Succeeded)
                    {

                        await signInManager.SignInAsync(user, isPersistent: false);
                        var user1 = await userManager.FindByEmailAsync(model.Email);
                        var result1 = await userManager.AddToRoleAsync(user1, "Student");
                        if (result1.Succeeded)
                        {
                            await signInManager.SignOutAsync();
                            await signInManager.SignInAsync(user1, false);
                            return RedirectToAction("index", "student");
                        }
                        foreach(var error in result1.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                    // If there are any errors, add them to the ModelState object
                    // which will be displayed by the validation summary tag helper
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                return View("StudentRegister",model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> FacultyRegister(FacultyRegisterViewModel model)
        {
                if (ModelState.IsValid)
                {
                    // Copy data from RegisterViewModel to IdentityUser
                    var user = new AppUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        Name = model.Name,
                        PhoneNumber = model.PhoneNumber,
                        BirthDate = model.BirthDate,
                        Address = model.Address,
                        Gender = model.Gender,
                        Caste = model.Caste,
                        Branch = model.Branch,
                        Degree = model.Degree,
                        IsFaculty = true
                    };
                    // Store user data in AspNetUsers database table
                    var result = await userManager.CreateAsync(user, model.Password);
                    // If user is successfully created, sign-in the user using
                    // SignInManager and redirect to index action of HomeController
                    if (result.Succeeded)
                    {

                        await signInManager.SignInAsync(user, isPersistent: false);
                        var user1 = await userManager.FindByEmailAsync(model.Email);
                        var result1 = await userManager.AddToRoleAsync(user1, "Faculty");
                        if (result1.Succeeded)
                        {
                            await signInManager.SignOutAsync();
                            await signInManager.SignInAsync(user1, false);
                            return RedirectToAction("index", "faculty");
                        }
                        foreach (var error in result1.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                    // If there are any errors, add them to the ModelState object
                    // which will be displayed by the validation summary tag helper
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                return View("FacultyRegister", model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string msg)
        {
            if (msg == "reset")
                ViewBag.msg = "Password is reset successfully";
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task <IActionResult> Login(LoginViewModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email,model.Password,model.RememberMe,false);
                if (result.Succeeded)
                {
                    var user = await userManager.FindByEmailAsync(model.Email);
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        await signInManager.SignInAsync(user,isPersistent: model.RememberMe);
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        await signInManager.SignInAsync(user,isPersistent: model.RememberMe);
                        if (user.IsStudent)
                            return RedirectToAction("index","student");
                        else if (user.IsFaculty)
                            return RedirectToAction("index", "faculty");
                        return RedirectToAction("index","admin");
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var resetPasswordLink = Url.Action("ResetPassword","Account",
                                         new {email=model.Email,token = token },Request.Scheme );

                    var msg = new MimeMessage();
                    msg.From.Add(new MailboxAddress("Admin", "mahammadayan18@gmail.com"));
                    msg.To.Add(new MailboxAddress(user.Name, model.Email));
                    msg.Subject = "Reset Password of your Student Portal Account";
                    msg.Body = new TextPart("plain")
                    {
                        Text = "To reset your password, use the provided link\n\n " + resetPasswordLink
                    };
                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("mahammadayan18@gmail.com", "*********");
                        client.Send(msg);
                        client.Disconnect(true);
                    }
                }
                return View("ConfirmForgotPassword", "account");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ResetPassword(string token,string email)
        {
            if (token == null || email == null)
                ModelState.AddModelError("", "Invalid Attempt");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.email);
                if (user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, model.token, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("login","account",new { msg = "reset"});
                    }
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
                else
                    ModelState.AddModelError("", "Something Went Wrong");
            }
            return View(model);
        }

        
    }

}
