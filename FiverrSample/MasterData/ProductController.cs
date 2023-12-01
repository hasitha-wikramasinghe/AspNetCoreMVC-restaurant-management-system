using Fiverr_Sample.DataAccess;
using Fiverr_Sample.MasterData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiverr_Sample.MasterData
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductController(
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ICollection<Product>> GetAllProducts()
        {
            return await _dbContext.Product.ToListAsync();
        }
    }
}
