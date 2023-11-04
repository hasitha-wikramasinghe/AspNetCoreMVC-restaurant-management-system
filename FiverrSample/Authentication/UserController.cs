using Fiverr_Sample.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fiverr_Sample.Authentication
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;

        public UserController(
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationUser applicationUser)
        {
            // ATM using email as the user name 
            applicationUser.UserName = applicationUser.Email;
            applicationUser.EmailConfirmed = true;

            var result = await _userManager.CreateAsync(applicationUser, "Hotelio@123");

            if (result.Succeeded)
            {
                return RedirectToAction("Signin", "Authentication");
            }

            return RedirectToAction("Create", "User");
        }
    }
}
