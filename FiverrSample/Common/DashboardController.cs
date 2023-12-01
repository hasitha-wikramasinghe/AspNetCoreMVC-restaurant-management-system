using Microsoft.AspNetCore.Mvc;

<<<<<<<< HEAD:FiverrSample/Common/DashboardController.cs
namespace Fiverr_Sample.Common
========
namespace RestaurantManagement.Controllers
>>>>>>>> b13ed6f6ccb4377d53a015408730e073c5ce44f5:RestaurantManagement/Controllers/FoodOrderController.cs
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}