 using Microsoft.EntityFrameworkCore;
using WebApplication3.Domain.Models;
using System.Collections.Generic;
using System;

namespace WebApplication3.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> Options) : base(Options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Company>().ToTable("Companies");
            builder.Entity<Company>().HasKey(p => p.Id);
            builder.Entity<Company>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Company>().Property(p => p.NomeFantasia).IsRequired().HasMaxLength(30);
            builder.Entity<Company>().Property(p => p.NomeFantasia).IsRequired().HasMaxLength(30);
            builder.Entity<Company>().Property(p => p.CNPJ).IsRequired();
            builder.Entity<Company>().HasMany(p => p.Products).WithOne(p => p.Company).HasForeignKey(p => p.CompanyID);

            builder.Entity<Company>().HasData
            (
                new Company { Id = 100, NomeFantasia = "Green World", RazaoSocial = "Green World", CNPJ = 41054870000120 }, //Id set manually due to In-memory provider
                new Company { Id = 101, NomeFantasia = "Super Cleaner", RazaoSocial = "Super Cleaner", CNPJ = 41054870000120}
            );



            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.Description).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.Value).IsRequired();
            builder.Entity<Product>().Property(p => p.Observation).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.CompanyID).IsRequired();

            builder.Entity<Product>().HasData
            (
               new Product { Id = 100, Name = "Apple", Description = "Tasty Apples planted in our own farms", Value = 1.99, Observation = "Due to the harvest, the product may differ in taste and in appearance compared to the image in the package.", CompanyID = 100 }
            );



            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Login).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(10);
            builder.Entity<User>().Property(p => p.CPF).IsRequired();

            builder.Entity<User>().HasData
            (
                new User { 
                    Id = 101,
                    Name = "John",
                    Login = "John",
                    Password = "123",
                    CPF = 1234567890
                }
            );

            DateTime dat = new DateTime(2021, 03, 09);

            builder.Entity<Purchase>().ToTable("Purchases");
            builder.Entity<Purchase>().HasKey(p => p.Id);
            builder.Entity<Purchase>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Purchase>().Property(p => p.TotalValue).IsRequired();
            builder.Entity<Purchase>().Property(p => p.PaymentMethod).IsRequired();
            builder.Entity<Purchase>().Property(p => p.Date).IsRequired();
            builder.Entity<Purchase>().Property(p => p.Status).IsRequired();
            builder.Entity<Purchase>().Property(p => p.Observation).IsRequired().HasMaxLength(60);
            builder.Entity<Purchase>().Property(p => p.Cep).IsRequired().HasMaxLength(8);
            builder.Entity<Purchase>().Property(p => p.Address).IsRequired().HasMaxLength(50);

            builder.Entity<Purchase>().HasData
            (
                new Purchase { Id = 100, TotalValue = 99.99, PaymentMethod = Domain.Helpers.EPaymentMethod.Boleto, Date = dat, Status = Domain.Helpers.EPurchaseStatus.processing, Observation = "all items in good condition", Cep = "88888888", Address = "Rua Costa Barros 915 - Aldeota CE "}
            ) ; 
            ;
        }
    }
}
