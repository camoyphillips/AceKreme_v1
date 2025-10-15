using AceKreme_v1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AceKreme_v1.Data
{
    /// <summary>
    /// Application database context configured with Identity support
    /// and domain entities for the AceKreme_v1 project.
    /// </summary>
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext(options)
    {
        // Domain entities
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<CustomerOrder> CustomerOrders => Set<CustomerOrder>();

        /// <summary>
        /// Configure relationships, constraints, and seed data.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Important: Keeps Identity schema

            // CustomerOrder relationships
            modelBuilder.Entity<CustomerOrder>()
                .HasOne(co => co.Customer)
                .WithMany(c => c.CustomerOrders)
                .HasForeignKey(co => co.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CustomerOrder>()
                .HasOne(co => co.Order)
                .WithMany(o => o.CustomerOrders)
                .HasForeignKey(co => co.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Optional seed data
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Classic Mattress",
                    Price = 499.99m,
                    Stock = 12,
                    Description = "Queen size mattress"
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Memory Foam Pillow",
                    Price = 59.99m,
                    Stock = 50,
                    Description = "Comfort pillow"
                }
            );
        }
    }
}
