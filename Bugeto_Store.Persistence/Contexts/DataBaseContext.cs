using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Roles;
using Bugeto_Store.Domain.Entities.Blog;
using Bugeto_Store.Domain.Entities.Carts;
using Bugeto_Store.Domain.Entities.Finances;
using Bugeto_Store.Domain.Entities.HomePages;
using Bugeto_Store.Domain.Entities.Orders;
using Bugeto_Store.Domain.Entities.Products;
using Bugeto_Store.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Bugeto_Store.Persistence.Contexts
{
    public class DataBaseContext : DbContext , IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<ProductFeatures> ProductFeatures { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<HomePageImages> HomePageImages { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<RequestPay> RequestPays { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogInTags> BlogInTags { get; set; }
        public DbSet<Tags> Tags { get; set; }


        public DbSet<BlogImage> BlogImages { get; set; }



        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
          

            modelBuilder.Entity<Order>()
                .HasOne(p => p.User)
                .WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(p => p.RequestPay)
                .WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Comment>().HasOne(c => c.BlogPost)
            .WithMany(b => b.Comments)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>().HasOne(c => c.User)
          .WithMany(u => u.Comments).HasForeignKey(c => c.UserId)
          .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<BlogPost>()
            //  .HasOne(p => p.BlogCategoriy)
            //  .WithMany(p => p.BlogPosts)
            //  .OnDelete(DeleteBehavior.NoAction);


            //modelBuilder.Entity<Author>()
            //  .HasOne(p => p.User)
            //  .WithMany(p => p.)
            //  .OnDelete(DeleteBehavior.NoAction);

            //Seed Data
            SeedData(modelBuilder);


            // اعمال ایندکس بر روی فیلد ایمیل
            // اعمال عدم تکراری بودن ایمیل
           // modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            //-- عدم نمایش اطلاعات حذف شده
            ApplyQueryFilter(modelBuilder);
        }

        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<UserInRole>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<ProductImages>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<ProductFeatures>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Slider>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<HomePageImages>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Cart>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<CartItem>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<RequestPay>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Order>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<OrderDetail>().HasQueryFilter(p => !p.IsRemoved);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = nameof(UserRoles.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = nameof(UserRoles.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = nameof(UserRoles.Customer) });


            modelBuilder.Entity<HomePageImages>().HasData(new HomePageImages { Id = 1, Src = @"images\HomePages\Slider\637742949830874456637316263744270286sm-1.jpg", ImageLocation = ImageLocation.L1 },
                new HomePageImages { Id = 2, Src = @"images\HomePages\Slider\637742949941898292637316430621882982a-4.jpg", ImageLocation = ImageLocation.L2 },
                new HomePageImages { Id = 3, Src = @"images\HomePages\Slider\637316430895780623a-4.jpg", ImageLocation = ImageLocation.R1 },
                new HomePageImages { Id = 4, Src = @"images\HomePages\Slider\637316430895780623a-4.jpg", ImageLocation = ImageLocation.G2 },
                new HomePageImages { Id = 5, Src = @"images\HomePages\Slider\637316277407677837sm-3.jpg", ImageLocation = ImageLocation.CenterFullScreen },
                new HomePageImages { Id = 6, Src = @"images\HomePages\Slider\637316430895780623a-4.jpg", ImageLocation = ImageLocation.G1 });



            //modelBuilder.Entity<Category>().HasData(new Category { Id = 1, IsRemoved = false, Name = "لب تاب" },
            //    new Category { Id = 1, IsRemoved = false, Name = "دوربین" },
            //    new Category { Id = 1, IsRemoved = false, Name = "یخچال" },
            //    new Category { Id = 1, IsRemoved = false, Name = "موبایل" },
            //    new Category { Id = 1, IsRemoved = false, Name = "اجاق گاز" },
            //    new Category { Id = 1, IsRemoved = false, Name = "سامسونگ" , ParentCategoryId = 6},
            //    new Category { Id = 1, IsRemoved = false, Name = "شیائومی", ParentCategoryId = 6 },
            //    new Category { Id = 1, IsRemoved = false, Name = "LG", ParentCategoryId = 5 },
            //    new Category { Id = 1, IsRemoved = false, Name = "سامسونگ", ParentCategoryId = 5 },
            //    new Category { Id = 1, IsRemoved = false, Name = "Asus", ParentCategoryId = 1 },
            //    new Category { Id = 1, IsRemoved = false, Name = "msi", ParentCategoryId = 1 },
            //    new Category { Id = 1, IsRemoved = false, Name = "کانن", ParentCategoryId = 2 },
            //    new Category { Id = 1, IsRemoved = false, Name = "نیکون", ParentCategoryId = 2 }
            //    );

            //modelBuilder.Entity<Product>().HasData(new Product
            //{
            //    Id = 1,
            //    Name = "Thinkpad p50",
            //    Brand = "Thinkpad p50",
            //    Price = 21000000,
            //    Inventory = 54,
            //    ViewCount = 6,
            //    CategoryId = 3,
            //},
            //new Product
            //{
            //    Id = 2,
            //    Name = "یخچال1",
            //    Brand = "سامسونگ",
            //    Price = 20000000,
            //    Inventory = 21,
            //    ViewCount = 0,
            //    CategoryId = 16,
            //},
            //new Product
            //{
            //    Id = 3,
            //    Name = "Galaxy A30",
            //    Brand = "سامسونگ",
            //    Price = 1400000,
            //    Inventory = 89,
            //    ViewCount = 1,
            //    CategoryId = 7,
            //},
            //new Product
            //{
            //    Id = 4,
            //    Name = "دوربین 1",
            //    Brand = "کانن",
            //    Price = 34000000,
            //    Inventory = 42,
            //    ViewCount = 1,
            //    CategoryId = 14,
            //}, new Product
            //{
            //    Id = 5,
            //    Name = "s 21",
            //    Brand = "سامسونگ",
            //    Price = 20000000,
            //    Inventory = 78,
            //    ViewCount = 1,
            //    CategoryId = 7,
            //}, new Product
            //{
            //    Id = 1,
            //    Name = "یخچال 3",
            //    Brand = "سامسونگ",
            //    Price = 23000000,
            //    Inventory = 32,
            //    ViewCount = 0,
            //    CategoryId = 16,
            //});

        }
    }


    public class DataBaseContextFactory : IDesignTimeDbContextFactory<DataBaseContext>
    {
        public DataBaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
            string contectionString = "Server=.;Database=Shop;User Id=sa;Password=19901990;MultipleActiveResultSets=true;";
            optionsBuilder.UseSqlServer(contectionString);

            return new DataBaseContext(optionsBuilder.Options);
        }
    }




}
