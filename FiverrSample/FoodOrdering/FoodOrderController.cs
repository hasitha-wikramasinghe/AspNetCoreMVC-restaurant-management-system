using Fiverr_Sample.DataAccess;
using Fiverr_Sample.FoodOrdering.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace Fiverr_Sample.FoodOrdering
{
    public class FoodOrderController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public FoodOrderController(
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _dbContext.FoodOrders.ToListAsync();
            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            FoodOrder foodOrder = new FoodOrder();
            foodOrder.CreatedOn = DateTime.UtcNow;
            if (User.Identity.IsAuthenticated)
            {
                foodOrder.CreatedBy = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            foodOrder.CustomerId = null;

            _dbContext.FoodOrders.Add(foodOrder);
            await _dbContext.SaveChangesAsync();
            return View(foodOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FoodOrder foodOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingFoodOrder = await _dbContext.FoodOrders.Where(order => order.Id == foodOrder.Id).FirstOrDefaultAsync()
                ?? throw new ApplicationException($"Food order cannot find for id {foodOrder.Id}");

            // TODO:: Implement food order line items list
            //List<FoodOrderLineItem> foodOrderLineItems = new List<FoodOrderLineItem>();
            //foodOrderLineItems.Add(foodOrder.FoodOrderLineItem.or)

            // TODO:: Implement customer details save part

            _dbContext.FoodOrders.Update(existingFoodOrder);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
