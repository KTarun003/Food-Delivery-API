using Microsoft.EntityFrameworkCore;
using Zinger_API.Models;

namespace Zinger_API.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
		{
		}

		public DbSet<Agent> Agents { get; set; }

		public DbSet<ApplicationUser> Users { get; set; }

		public DbSet<Customer> Customers { get; set; }

		public DbSet<MenuItem> MenuItems { get; set; }

		public DbSet<Order> Orders { get; set; }

		public DbSet<OrderItem> OrderItems { get; set; }

		public DbSet<Restaurant> Restaurants { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Agent>()
				.HasKey(a => a.AgentId);
			
			modelBuilder.Entity<ApplicationUser>()
				.HasKey(a => a.UserId);
			
			modelBuilder.Entity<Customer>()
				.HasKey(c => c.CustomerId);
			
			modelBuilder.Entity<MenuItem>()
				.HasKey(m => m.ItemId);
			
			modelBuilder.Entity<Order>()
				.HasKey(o => o.OrderId);
			
			modelBuilder.Entity<OrderItem>()
				.HasKey(o => o.ItemId);
			
			modelBuilder.Entity<Restaurant>()
				.HasKey(r => r.RestaurantId);
			
			modelBuilder.Entity<Order>()
				.HasOne<Agent>(o => o.Agent)
				.WithMany(a => a.Orders)
				.HasForeignKey(o => o.AgentId);
			
			modelBuilder.Entity<Order>()
				.HasOne<Customer>(o => o.Customer)
				.WithMany(c => c.Orders)
				.HasForeignKey(o => o.CustomerId);
			
			modelBuilder.Entity<Order>()
				.HasOne<Restaurant>(o => o.Restaurant)
				.WithMany(r => r.Orders)
				.HasForeignKey(o => o.RestaurantId);
			
			modelBuilder.Entity<OrderItem>()
				.HasOne<Order>(o => o.Order)
				.WithMany(o => o.Items)
				.HasForeignKey(o => o.OrderId);
			
			modelBuilder.Entity<MenuItem>()
				.HasOne<Restaurant>(m => m.Restaurant)
				.WithMany(r => r.Items)
				.HasForeignKey(m => m.RestaurantId);
			
			modelBuilder.Entity<OrderItem>()
				.HasOne<MenuItem>(o => o.Item)
				.WithMany(m => m.OrderItems)
				.HasForeignKey(o => o.ItemId);
		}
	}
}