using Microsoft.EntityFrameworkCore;
using Assignment2_ShoppingWeb.Models;

namespace Assignment2_ShoppingWeb.Models
{
	public class ApplicationDBContext :DbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) 
		:base(options)
		{ }
		public DbSet<Account> Accounts { get; set; }
		public DbSet<Categories> Categories { get; set; }
		public DbSet<Orders> Orders { get; set; }
		public DbSet <Products> Products { get; set; }
		public DbSet <Suppliers> Suppliers { get; set; }
		public DbSet <Order_Details > Order_Details { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			// Cấu hình cho bảng Orders
			modelBuilder.Entity<Orders>()
				.Property(o => o.Freight)
				.HasColumnType("decimal(18,2)");

			// Cấu hình cho bảng Order_Details
			modelBuilder.Entity<Order_Details>()
				.Property(od => od.UnitPrice)
				.HasColumnType("decimal(18,2)");

			// Cấu hình cho bảng Products
			modelBuilder.Entity<Products>()
				.Property(p => p.UnitPrice)
				.HasColumnType("decimal(18,2)");
			// Cấu hình quan hệ giữa Orders và Customers
			modelBuilder.Entity<Orders>()
				.HasOne(o => o.customer)
				.WithMany(c => c.Orders)
				.HasForeignKey(o => o.CustomerID);

			// Cấu hình quan hệ giữa OrderDetails và Orders, Products
			modelBuilder.Entity<Order_Details>()
				.HasKey(od => new { od.OrderID, od.ProductID });

			modelBuilder.Entity<Order_Details>()
				.HasOne(od => od.Order)
				.WithMany(o => o.OrderDetails)
				.HasForeignKey(od => od.OrderID);

			modelBuilder.Entity<Order_Details>()
				.HasOne(od => od.Product)
				.WithMany(p => p.OrderDetails)
				.HasForeignKey(od => od.ProductID);

			// Các cấu hình khác tùy theo yêu cầu
			modelBuilder.Entity<Products>()
				.HasOne(p => p.Supplier)
				.WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierID);
			modelBuilder.Entity<Products>()
	        .HasOne(p => p.Category)
        	.WithMany(c => c.Products)
	        .HasForeignKey(p => p.CategoryID);

			modelBuilder.Entity<Account>().HasData(
		new Account { AccountID = 1, UserName = "staff1", Password = "staff123", FullName = "Staff Member 1", Type = 1 }, // Staff
		new Account { AccountID = 2, UserName = "user1", Password = "user123", FullName = "User One", Type = 2 }, // Normal User
		new Account { AccountID = 3, UserName = "user2", Password = "user456", FullName = "User Two", Type = 2 }  // Normal User
	);

			// Seed data cho bảng Categories
			modelBuilder.Entity<Categories>().HasData(
				new Categories { CategoryID = 1, CategoryName = "Electronics", Description = "Electronic gadgets and devices" },
				new Categories { CategoryID = 2, CategoryName = "Books", Description = "Books and reading materials" },
				new Categories { CategoryID = 3, CategoryName = "Clothing", Description = "Clothing and apparel" }
			);
			modelBuilder.Entity<Customers>().HasData(
	new Customers
	{
		CustomerID = 1,
		ContactName = "Alice Johnson",
		Password = "password789",
		Address = "789 Oak Street",
		Phone = "5555555555"
	},
	new Customers
	{
		CustomerID = 2,
		ContactName = "John Doe",
		Password = "password123",
		Address = "123 Main Street",
		Phone = "1234567890"
	},
	new Customers
	{
		CustomerID = 3,
		ContactName = "Jane Smith",
		Password = "password456",
		Address = "456 Elm Street",
		Phone = "0987654321"
	}
);


			// Seed data cho bảng Suppliers
			modelBuilder.Entity<Suppliers>().HasData(
				new Suppliers { SupplierID = 1, CompanyName = "Tech Supplier Inc.", Address = "123 Tech Street", Phone = "555-1234" },
				new Suppliers { SupplierID = 2, CompanyName = "Book Distributor Ltd.", Address = "456 Book Avenue", Phone = "555-5678" }
			);

			// Seed data cho bảng Products
			modelBuilder.Entity<Products>().HasData(
				new Products { ProductID = 1, ProductName = "Smartphone", SupplierID = 1, CategoryID = 1, QuantityPerUnit = "1 unit", UnitPrice = 299.99m, ProductImage = "smartphone.jpg" },
				new Products { ProductID = 2, ProductName = "Laptop", SupplierID = 1, CategoryID = 1, QuantityPerUnit = "1 unit", UnitPrice = 999.99m, ProductImage = "laptop.jpg" },
				new Products { ProductID = 3, ProductName = "Novel Book", SupplierID = 2, CategoryID = 2, QuantityPerUnit = "1 book", UnitPrice = 19.99m, ProductImage = "novel.jpg" }
			);

			// Seed data cho bảng Orders
			modelBuilder.Entity<Orders>().HasData(
				new Orders { OrderID = 1, CustomerID = 2, OrderDate = new DateTime(2024, 10, 10), RequiredDate = new DateTime(2024, 10, 15), ShippedDate = new DateTime(2024, 10, 12), Freight = 10.99m, ShipAddress = "123 Main Street" },
				new Orders { OrderID = 2, CustomerID = 3, OrderDate = new DateTime(2024, 10, 11), RequiredDate = new DateTime(2024, 10, 16), ShippedDate = null, Freight = 12.99m, ShipAddress = "456 Elm Street" }
			);

			// Seed data cho bảng Order_Details
			modelBuilder.Entity<Order_Details>().HasData(
				new Order_Details { OrderID = 1, ProductID = 1, UnitPrice = 299.99m, Quantity = 1},
				new Order_Details { OrderID = 1, ProductID = 3, UnitPrice = 19.99m, Quantity = 2 },
				new Order_Details { OrderID = 2, ProductID = 2, UnitPrice = 999.99m, Quantity = 1 }
			);

		}
		public DbSet<Assignment2_ShoppingWeb.Models.Customers> Customers { get; set; } = default!;
	}
}
