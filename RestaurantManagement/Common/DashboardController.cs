using Microsoft.AspNetCore.Mvc;

namespace RestaurantManagement.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}