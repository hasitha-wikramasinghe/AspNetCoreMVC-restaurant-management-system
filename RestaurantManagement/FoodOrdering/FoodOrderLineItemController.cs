using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.DataAccess;
using RestaurantManagement.FoodOrdering.Models;

namespace RestaurantManagement.FoodOrdering
{
    public class FoodOrderLineItemController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public FoodOrderLineItemController(
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FoodOrderLineItemDTO foodOrderLineItemDto)
        {
            if (foodOrderLineItemDto == null || foodOrderLineItemDto?.ProductId == null || foodOrderLineItemDto?.Quantity == null)
            {
                return new BadRequestResult();
            }

            int newOrderId = 0;
            if (foodOrderLineItemDto.OrderId is null)
            {
                newOrderId = await BuildNewFoodOrder();
            }

            var relatedProduct = await _dbContext.Product.Where(p => p.Id == foodOrderLineItemDto.ProductId).FirstOrDefaultAsync() 
                ?? throw new ApplicationException($"Cannot find a product for id {foodOrderLineItemDto.ProductId}");

            var foodOrderLineItem = new FoodOrderLineItem()
            {
                OrderId = foodOrderLineItemDto.OrderId is not null ? foodOrderLineItemDto.OrderId.Value : newOrderId,
                ProductId = foodOrderLineItemDto.ProductId,
                Quantity = foodOrderLineItemDto.Quantity,
                SubPrice = relatedProduct.Price * foodOrderLineItemDto.Quantity
            };

            _dbContext.FoodOrderLineItem.Add(foodOrderLineItem);
            await _dbContext.SaveChangesAsync();

            return new JsonResult(foodOrderLineItem);
        }

        private async Task<int> BuildNewFoodOrder()
        {
            var order = new FoodOrder()
            {
                CreatedBy = User.Identity?.Name,
                CreatedOn = DateTime.UtcNow
            };

            _dbContext.FoodOrder.Add(order);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
