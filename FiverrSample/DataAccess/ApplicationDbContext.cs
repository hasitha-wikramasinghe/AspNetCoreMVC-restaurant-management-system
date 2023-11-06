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

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<FoodOrder> FoodOrders { get; set; }
        public DbSet<FoodOrderLineItem> FoodOrderLineItems { get; set; }
        public DbSet<FoodOrderStatusList> FoodOrderStatusLists { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}
