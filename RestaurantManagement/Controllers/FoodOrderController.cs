using Microsoft.AspNetCore.Mvc;

namespace RestaurantManagement.Controllers
{
    public class FoodOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}