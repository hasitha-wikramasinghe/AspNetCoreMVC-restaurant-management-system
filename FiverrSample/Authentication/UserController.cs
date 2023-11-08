using Fiverr_Sample.Authentication.Models;
using Fiverr_Sample.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Fiverr_Sample.Authentication
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly ApplicationDbContext _context;

        public UserController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signinManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var users = await _context.ApplicationUser
                .Where(user => user.IsDeleted == false || user.IsDeleted == null)
                .OrderBy(user => user.FirstName)
                .ToListAsync(); 
            return View(users);
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
            applicationUser.IsActive = true;
            applicationUser.CreatedOn = DateTime.UtcNow;
            applicationUser.CreatedBy = User.Identity?.Name;

            var result = await _userManager.CreateAsync(applicationUser, "Hotelio@123");

            if (result.Succeeded)
            {
                return RedirectToAction("Signin", "Authentication");
            }

            return RedirectToAction("Create", "User");
        }

        [HttpGet("Update/{Id}")]
        public async Task<IActionResult> Update([FromRoute]string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return View(user);
        }

        [HttpGet("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute]string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            user.IsDeleted = true;
            _context.ApplicationUser.Update(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
