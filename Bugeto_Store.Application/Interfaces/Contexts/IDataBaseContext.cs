using Bugeto_Store.Domain.Entities.Carts;
using Bugeto_Store.Domain.Entities.Finances;
using Bugeto_Store.Domain.Entities.HomePages;
using Bugeto_Store.Domain.Entities.Orders;
using Bugeto_Store.Domain.Entities.Products;
using Bugeto_Store.Domain.Entities.Users;
using Bugeto_Store.Domain.Entities.Blog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Interfaces.Contexts
{
    public interface IDataBaseContext
    {
          DbSet<User> Users { get; set; }
          DbSet<Role> Roles { get; set; }
          DbSet<UserInRole> UserInRoles { get; set; }
          DbSet<Category> Categories { get; set; }
          DbSet<Product> Products { get; set; }
          DbSet<ProductImages> ProductImages { get; set; }
          DbSet<ProductFeatures> ProductFeatures { get; set; }
          DbSet<Slider>  Sliders { get; set; }
          DbSet<HomePageImages>   HomePageImages { get; set; }
          DbSet<Cart>    Carts { get; set; }
          DbSet<CartItem>     CartItems { get; set; }
          DbSet<RequestPay>      RequestPays { get; set; }
          DbSet<Order> Orders { get; set; }
          DbSet<OrderDetail>  OrderDetails { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogInTags> BlogInTags { get; set; }
        public DbSet<Tags> Tags { get; set; }

        public DbSet<Comment> Comments { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }
}
