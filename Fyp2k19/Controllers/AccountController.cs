using Fyp2k19.Data;
using Fyp2k19.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fyp2k19.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                 var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                string userId = signInManager

                if (result.Succeeded)
                {
                    return RedirectToAction("LoginRoute", new { returnUrl });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignOff()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
        private IActionResult LoginRoute(string returnUrl)  //this method is new
        {
            if (String.IsNullOrWhiteSpace(returnUrl))
            {
                if (User.IsInRole("Student"))
                {
                    return RedirectToLocal("/Home");
                }
                else if (User.IsInRole("Admin"))
                {
                    return RedirectToLocal("/Home");
                }
                else if (User.IsInRole("Teacher"))
                {
       

                    
                   
                    return RedirectToLocal("/Home");
                }

            }
            else
            {
                return RedirectToLocal(returnUrl);
            }
            return RedirectToLocal(returnUrl);
        }

    }

}
