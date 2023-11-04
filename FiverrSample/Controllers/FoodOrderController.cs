using Microsoft.AspNetCore.Mvc;

namespace Fiverr_Sample.Controllers
{
    public class FoodOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
