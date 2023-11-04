using Microsoft.AspNetCore.Mvc;

namespace Fiverr_Sample.Authentication
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignIn() 
        {
            return View();
        }
    }
}
