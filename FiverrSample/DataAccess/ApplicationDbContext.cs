using Fiverr_Sample.Authentication.Models;
using Fiverr_Sample.FoodOrdering.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Fiverr_Sample.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FoodOrderLineItem>()
            .HasKey(op => new { op.OrderId, op.ProductId });

            builder.Entity<FoodOrderLineItem>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            builder.Entity<FoodOrderLineItem>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<FoodOrder> FoodOrder { get; set; }
        public DbSet<FoodOrderLineItem> FoodOrderLineItem { get; set; }
        public DbSet<FoodOrderStatus> FoodOrderStatus { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<DiningTable> DiningTable { get; set; }
        public DbSet<FoodOrderType> FoodOrderType { get; set; }

    }
}
