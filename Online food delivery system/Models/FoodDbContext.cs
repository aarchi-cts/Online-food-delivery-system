﻿using Microsoft.EntityFrameworkCore;

namespace Online_food_delivery_system.Models
{
        
    public class FoodDbContext : DbContext
        {
            public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options)
            {
            }

            public DbSet<Customer> Customers { get; set; }
            public DbSet<Restaurant> Restaurants { get; set; }
            public DbSet<MenuItem> MenuItems { get; set; }
            public DbSet<Agent> Agents { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<Delivery> Deliveries { get; set; }
            public DbSet<Payment> Payments { get; set; }
            public DbSet<User> Users { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Customer has one-to-many relationship with Orders
                modelBuilder.Entity<Order>()
                    .HasOne(o => o.Customer)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(o => o.CustomerID)
                    .OnDelete(DeleteBehavior.Restrict); // Specify OnDelete behavior

                // Restaurant has one-to-many relationship with MenuItems
                modelBuilder.Entity<MenuItem>()
                    .HasOne(m => m.Restaurant)
                    .WithMany(r => r.MenuItems)
                    .HasForeignKey(m => m.RestaurantID)
                    .OnDelete(DeleteBehavior.Restrict); // Specify OnDelete behavior

                // Order has one-to-one relationship with Delivery
                modelBuilder.Entity<Delivery>()
                    .HasOne(d => d.Order)
                    .WithOne(o => o.Delivery)
                    .HasForeignKey<Delivery>(d => d.OrderID)
                    .OnDelete(DeleteBehavior.Restrict); // Specify OnDelete behavior

                // Agent has one-to-many relationship with Deliveries
                modelBuilder.Entity<Delivery>()
                    .HasOne(d => d.Agent)
                    .WithMany(a => a.Deliveries)
                    .HasForeignKey(d => d.AgentID)
                    .OnDelete(DeleteBehavior.Restrict); // Specify OnDelete behavior

                // Order has one-to-one relationship with Payment
                modelBuilder.Entity<Payment>()
                    .HasOne(p => p.Order)
                    .WithOne(o => o.Payment)
                    .HasForeignKey<Payment>(p => p.OrderID)
                    .OnDelete(DeleteBehavior.Restrict); // Specify OnDelete behavior

                // Delivery has one-to-one relationship with Payment
                modelBuilder.Entity<Delivery>()
                    .HasOne(d => d.Payment)
                    .WithOne(p => p.Delivery)
                    .HasForeignKey<Delivery>(d => d.OrderID)
                    .OnDelete(DeleteBehavior.Restrict); // Specify OnDelete behavior

                // Define primary keys
                modelBuilder.Entity<Customer>().HasKey(c => c.CustomerID);
                modelBuilder.Entity<Restaurant>().HasKey(r => r.RestaurantID);
                modelBuilder.Entity<MenuItem>().HasKey(m => m.ItemID);
                modelBuilder.Entity<Agent>().HasKey(a => a.AgentID);
                modelBuilder.Entity<Order>().HasKey(o => o.OrderID);
                modelBuilder.Entity<Delivery>().HasKey(d => d.DeliveryID);
                modelBuilder.Entity<Payment>().HasKey(p => p.PaymentID);
            }
    }
}
