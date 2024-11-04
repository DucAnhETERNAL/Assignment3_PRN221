﻿// <auto-generated />
using System;
using Assignment2_ShoppingWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ShoppingWeb.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assignment2_ShoppingWeb.Models.Account", b =>
                {
                    b.Property<int>("AccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountID"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountID");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountID = 1,
                            FullName = "Staff Member 1",
                            Password = "staff123",
                            Type = 1,
                            UserName = "staff1"
                        },
                        new
                        {
                            AccountID = 2,
                            FullName = "User One",
                            Password = "user123",
                            Type = 2,
                            UserName = "user1"
                        },
                        new
                        {
                            AccountID = 3,
                            FullName = "User Two",
                            Password = "user456",
                            Type = 2,
                            UserName = "user2"
                        });
                });

            modelBuilder.Entity("Assignment2_ShoppingWeb.Models.Categories", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Electronics",
                            Description = "Electronic gadgets and devices"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Books",
                            Description = "Books and reading materials"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Clothing",
                            Description = "Clothing and apparel"
                        });
                });

            modelBuilder.Entity("Assignment2_ShoppingWeb.Models.Customers", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerID = 1,
                            Address = "789 Oak Street",
                            ContactName = "Alice Johnson",
                            Password = "password789",
                            Phone = "5555555555"
                        },
                        new
                        {
                            CustomerID = 2,
                            Address = "123 Main Street",
                            ContactName = "John Doe",
                            Password = "password123",
                            Phone = "1234567890"
                        },
                        new
                        {
                            CustomerID = 3,
                            Address = "456 Elm Street",
                            ContactName = "Jane Smith",
                            Password = "password456",
                            Phone = "0987654321"
                        });
                });

            modelBuilder.Entity("Assignment2_ShoppingWeb.Models.Order_Details", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("Order_Details");

                    b.HasData(
                        new
                        {
                            OrderID = 1,
                            ProductID = 1,
                            Quantity = 1,
                            UnitPrice = 299.99m
                        },
                        new
                        {
                            OrderID = 1,
                            ProductID = 3,
                            Quantity = 2,
                            UnitPrice = 19.99m
                        },
                        new
                        {
                            OrderID = 2,
                            ProductID = 2,
                            Quantity = 1,
                            UnitPrice = 999.99m
                        });
                });

            modelBuilder.Entity("Assignment2_ShoppingWeb.Models.Orders", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<decimal>("Freight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RequiredDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShipAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ShippedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderID = 1,
                            CustomerID = 2,
                            Freight = 10.99m,
                            OrderDate = new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RequiredDate = new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShipAddress = "123 Main Street",
                            ShippedDate = new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            OrderID = 2,
                            CustomerID = 3,
                            Freight = 12.99m,
                            OrderDate = new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RequiredDate = new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShipAddress = "456 Elm Street"
                        });
                });

            modelBuilder.Entity("Assignment2_ShoppingWeb.Models.Products", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("ProductImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuantityPerUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupplierID")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("SupplierID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            CategoryID = 1,
                            ProductImage = "smartphone.jpg",
                            ProductName = "Smartphone",
                            QuantityPerUnit = "1 unit",
                            SupplierID = 1,
                            UnitPrice = 299.99m
                        },
                        new
                        {
                            ProductID = 2,
                            CategoryID = 1,
                            ProductImage = "laptop.jpg",
                            ProductName = "Laptop",
                            QuantityPerUnit = "1 unit",
                            SupplierID = 1,
                            UnitPrice = 999.99m
                        },
                        new
                        {
                            ProductID = 3,
                            CategoryID = 2,
                            ProductImage = "novel.jpg",
                            ProductName = "Novel Book",
                            QuantityPerUnit = "1 book",
                            SupplierID = 2,
                            UnitPrice = 19.99m
                        });
                });

            modelBuilder.Entity("Assignment2_ShoppingWeb.Models.Suppliers", b =>
                {
                    b.Property<int>("SupplierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierID");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            SupplierID = 1,
                            Address = "123 Tech Street",
                            CompanyName = "Tech Supplier Inc.",
                            Phone = "555-1234"
                        },
                        new
                        {
                            SupplierID = 2,
                            Address = "456 Book Avenue",
                            CompanyName = "Book Distributor Ltd.",
                            Phone = "555-5678"
                        });
                });

            modelBuilder.Entity("Assignment2_ShoppingWeb.Models.Order_Details", b =>
                {
                    b.HasOne("Assignment2_ShoppingWeb.Models.Orders", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment2_ShoppingWeb.Models.Products", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Assignment2_ShoppingWeb.Models.Orders", b =>
                {
                    b.HasOne("Assignment2_ShoppingWeb.Models.Customers", "customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");
                });

            modelBuilder.Entity("Assignment2_ShoppingWeb.Models.Products", b =>
                {
                    b.HasOne("Assignment2_ShoppingWeb.Models.Categories", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment2_ShoppingWeb.Models.Suppliers", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Assignment2_ShoppingWeb.Models.Categories", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Assignment2_ShoppingWeb.Models.Customers", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Assignment2_ShoppingWeb.Models.Orders", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Assignment2_ShoppingWeb.Models.Products", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Assignment2_ShoppingWeb.Models.Suppliers", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
