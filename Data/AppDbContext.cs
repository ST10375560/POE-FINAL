using AgriEnergyConnectWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnectWebApp.Data
{
    public class AppDbContext : DbContext
    {
        // Constructor receives options and passes them to the base DbContext
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Table representing farmers in the database
        // This method was adapted from: https://learn.microsoft.com/en-us/ef/core/modeling/inheritance
        // Author: AndriySvyryd
        // Website name: learn.microsoft.com
        public DbSet<Farmer> Farmers { get; set; }

        // Table representing products associated with farmers
        public DbSet<Product> Products { get; set; }

        // Table representing employees of the platform
        public DbSet<Employee> Employees { get; set; }

        // Override used to configure entity relationships and rules
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure a cascade delete behavior:
            // When a Farmer is deleted, all associated Products are also deleted automatically
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Farmer)
                .WithMany() // Farmer can have many products
                .HasForeignKey(p => p.FarmerId)
                .OnDelete(DeleteBehavior.Cascade); // Enables cascade deletion
        }
    }
}

