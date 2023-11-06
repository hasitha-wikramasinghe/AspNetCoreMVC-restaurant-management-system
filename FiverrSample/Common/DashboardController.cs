using Microsoft.AspNetCore.Mvc;

namespace Fiverr_Sample.Common
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
