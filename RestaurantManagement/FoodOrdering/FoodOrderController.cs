using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.DataAccess;
using RestaurantManagement.FoodOrdering.Models;

namespace RestaurantManagement.FoodOrdering
{
    public class FoodOrderController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public FoodOrderController(
            ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var orders = await (from foodOrder in _dbContext.FoodOrder
                                join foodOrderStatus in _dbContext.FoodOrderStatus on foodOrder.FoodOrderStatusId equals foodOrderStatus.Id into tempFoodOrderStatus
                                from tFoodOrderStatus in tempFoodOrderStatus.DefaultIfEmpty()
                                join customer in _dbContext.Customer on foodOrder.CustomerId equals customer.Id into tempCustomer
                                from tCustomer in tempCustomer.DefaultIfEmpty()
                                select new FoodOrderDTO()
                                {
                                    Id = foodOrder.Id,
                                    OrderCodeString = $"#ORD_{foodOrder.OrderCode}",
                                    TotalPrice = foodOrder.TotalPrice,
                                    CustomerId = foodOrder.CustomerId,
                                    FoodOrderStatusId = foodOrder.FoodOrderStatusId,
                                    CustomerName = tCustomer != null ? tCustomer.Name : string.Empty,
                                    FoodOrderStatusName = tFoodOrderStatus != null ? tFoodOrderStatus.StatusName : string.Empty,
                                }).ToListAsync();

            return View(orders);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            FoodOrderDTO foodOrderDTO = new FoodOrderDTO();

            foodOrderDTO.FoodOrderTypes = await _dbContext.FoodOrderType.ToListAsync();
            foodOrderDTO.DiningTables = await _dbContext.DiningTable.ToListAsync();
            foodOrderDTO.Products = await _dbContext.Product.ToListAsync();

            return View(foodOrderDTO);
        }

        // TODO:: Use this function to build food order when implementing new food order saving/updating part
        private async Task<FoodOrder> BuildFoodOrder()
        {
            FoodOrder foodOrder = new FoodOrder();

            foodOrder.CustomerId = null;
            foodOrder.FoodOrderStatusId = (int)FoodOrderStatusEnum.KOTPending;
            foodOrder.OrderCode = await GetOrderCodeAsync();

            foodOrder.CreatedOn = DateTime.UtcNow;
            foodOrder.CreatedBy = User.Identity?.Name;

            return foodOrder;
        }

        private async Task<int> GetOrderCodeAsync()
        {
            var latestFoodOrder = await _dbContext
                .FoodOrder
                .OrderByDescending(o => o.Id)
                .FirstOrDefaultAsync();

            return latestFoodOrder?.Id != null ? (latestFoodOrder.OrderCode + 1) : 00000001;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(FoodOrderDTO foodOrderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingFoodOrder = await _dbContext.FoodOrder.Where(order => order.Id == foodOrderDto.Id).FirstOrDefaultAsync();

            if (existingFoodOrder is null)
            {
                await CreateFoodOrder(foodOrderDto);
            }
            else
            {
                await UpdateFoodOrder(existingFoodOrder, foodOrderDto);
            }

            // TODO:: Implement food order line items list

            return RedirectToAction("Index");
        }

        private async Task<int> CreateFoodOrder(FoodOrderDTO foodOrderDto)
        {
            foodOrderDto.CustomerId = await SaveOrRetrieveCustomerAsync(foodOrderDto);
            var foodOrder = _mapper.Map<FoodOrder>(foodOrderDto);

            _dbContext.FoodOrder.Add(foodOrder);
            return await _dbContext.SaveChangesAsync();
        }

        private async Task<int?> SaveOrRetrieveCustomerAsync(FoodOrderDTO foodOrderDto)
        {
            if (!ValidateCustomer(foodOrderDto))
            {
                return null;
            }
            var existingCustomer = await _dbContext.Customer.Where(cus => cus.PhoneNumber == foodOrderDto.CustomerPhoneNumber).FirstOrDefaultAsync();
            var customer = _mapper.Map<Customer>(foodOrderDto);

            if (existingCustomer is null)
            {
                _dbContext.Customer.Add(customer);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                var updatedCustomer = new Customer
                {
                    Id = existingCustomer.Id,
                    Name = foodOrderDto.CustomerName != null ? foodOrderDto.CustomerName : existingCustomer.Name,
                    Email = foodOrderDto.CustomerEmail != null ? foodOrderDto.CustomerEmail : existingCustomer.Email,
                    NIC = foodOrderDto.CustomerNIC != null ? foodOrderDto.CustomerNIC : existingCustomer.NIC,
                    PhoneNumber = foodOrderDto.CustomerPhoneNumber != null ? foodOrderDto.CustomerPhoneNumber.Value : existingCustomer.PhoneNumber,
                    ModifiedBy = User.Identity?.Name,
                    ModifiedOn = DateTime.UtcNow
                };

                _dbContext.Customer.Update(updatedCustomer);
                return await _dbContext.SaveChangesAsync();
            }
        }

        private bool ValidateCustomer(FoodOrderDTO foodOrderDTO)
        {
            if (foodOrderDTO.CustomerName is not null ||
                foodOrderDTO.CustomerEmail is not null ||
                foodOrderDTO.CustomerNIC is not null ||
                foodOrderDTO.CustomerPhoneNumber is not null)
            {
                return true;
            }
            return false;
        }

        private async Task<int> UpdateFoodOrder(FoodOrder existingFoodOrder, FoodOrderDTO foodOrderDto)
        {
            var updatedFoodOrder = new FoodOrder
            {
                Id = existingFoodOrder.Id,
                TotalPrice = foodOrderDto.TotalPrice != decimal.Zero ? foodOrderDto.TotalPrice : existingFoodOrder.TotalPrice,
                FoodOrderStatusId = foodOrderDto.FoodOrderStatusId != null ? foodOrderDto.FoodOrderStatusId : existingFoodOrder.FoodOrderStatusId,
                ModifiedBy = User.Identity?.Name,
                ModifiedOn = DateTime.UtcNow
            };

            _dbContext.FoodOrder.Update(updatedFoodOrder);
            return await _dbContext.SaveChangesAsync();
        }

        [HttpGet]
        public IActionResult CreateNewLineItem()
        {
            return PartialView("_NewLineItemPartial");
        }
    }
}