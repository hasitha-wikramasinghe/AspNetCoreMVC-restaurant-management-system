﻿using Fiverr_Sample.Authentication.Models;
using Fiverr_Sample.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fiverr_Sample.Authentication
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;

        public AuthenticationController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signinManager)
        {
            _userManager = userManager;
            _signinManager = signinManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignIn() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel signInModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(signInModel.Email);
            if (user is null) 
            {
                return BadRequest($"Cannot find a user for email {signInModel.Email}");
            }

            var signinResult = await _signinManager.PasswordSignInAsync(user, signInModel.Password, true, false);

            if (signinResult.Succeeded)
            {
                return RedirectToAction("Index", "User");
            }

            return RedirectToAction("SignIn");
        }
    }
}
