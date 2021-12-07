using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Bugeto_Store.Persistence.Contexts;
using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Application.Services.Users.Queries.GetUsers;
using Bugeto_Store.Application.Services.Users.Queries.GetRoles;
using Bugeto_Store.Application.Services.Users.Commands.RgegisterUser;
using Bugeto_Store.Application.Services.Users.Commands.RemoveUser;
using Bugeto_Store.Application.Services.Users.Commands.UserLogin;
using Bugeto_Store.Application.Services.Users.Commands.UserSatusChange;
using Bugeto_Store.Application.Services.Users.Commands.EditUser;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Bugeto_Store.Application.Interfaces.FacadPatterns;
using Bugeto_Store.Application.Services.Products.FacadPattern;
using Bugeto_Store.Application.Services.Common.Queries.GetMenuItem;
using Bugeto_Store.Application.Services.Common.Queries.GetCategory;
using Bugeto_Store.Application.Services.HomePages.AddNewSlider;
using Microsoft.Extensions.Hosting.Internal;
using Bugeto_Store.Application.Services.Common.Queries.GetSlider;
using Bugeto_Store.Application.Services.HomePages.AddHomePageImages;
using Bugeto_Store.Application.Services.Common.Queries.GetHomePageImages;
using Bugeto_Store.Application.Services.Carts;
using Bugeto_Store.Application.Services.Fainances.Commands.AddRequestPay;
using Bugeto_Store.Common.Roles;
using Bugeto_Store.Application.Services.Fainances.Queries.GetRequestPayService;
using Bugeto_Store.Application.Services.Orders.Commands.AddNewOrder;
using Bugeto_Store.Application.Services.Orders.Queries.GetUserOrders;
using Bugeto_Store.Application.Services.Orders.Queries.GetOrdersForAdmin;
using Bugeto_Store.Application.Services.Fainances.Queries.GetRequestPayForAdmin;
using Bugeto_Store.Application.Services.Blog.Commands.AddBlog;
using Bugeto_Store.Application.Services.Blog.Commands.AddBlogCategory;
using Bugeto_Store.Application.Services.Blog.Queries.GetAllCategorieBlogs;
using Bugeto_Store.Application.Services.Common.Sliders;
using Bugeto_Store.Application.Services.Common.HomePageImages;
using Bugeto_Store.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EndPoint.Site
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("develop")));
            services.AddHttpClient();
            services.AddIdentity<UserApp, IdentityRole>(options =>
            {
                options.Password.RequiredUniqueChars = 0;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;

            })
                .AddEntityFrameworkStores<DataBaseContext>().AddDefaultTokenProviders().AddDefaultUI();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(UserRoles.Admin, policy => policy.RequireRole(UserRoles.Admin));
                options.AddPolicy(UserRoles.Customer, policy => policy.RequireRole(UserRoles.Customer));
                options.AddPolicy(UserRoles.Operator, policy => policy.RequireRole(UserRoles.Operator));
            });



            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

          // Adding Jwt Bearer  
          .AddJwtBearer(options =>
          {
              options.SaveToken = true;
              options.RequireHttpsMetadata = false;
              options.TokenValidationParameters = new TokenValidationParameters()
              {
                  ValidateIssuer = true,
                  ValidateAudience = true,
                  ValidateLifetime = true,
                  ValidateIssuerSigningKey = true,
                  ValidAudience = Configuration["JWT:ValidAudience"],
                  ValidIssuer = Configuration["JWT:ValidIssuer"],
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
              };
          });


            

            //services.AddSwaggerGen(c =>
            //{
            //    c.IgnoreObsoleteActions();
            //    c.SwaggerDoc("v1", new OpenApiInfo()
            //    {
            //        Title = "CarOnline api",
            //        Version = "v1",
            //        Description = "CarOnline api develop by Asp.net core 5 \r\n\r\n  identity \r\n\r\n  ef core ",
            //        Contact =
            //            new OpenApiContact()
            //            {
            //                Email = "MostafaHosseini9310@gmail.com",
            //                Url = new Uri("https://Mostafa-h.ir"),
            //                Name = "Mostafa Hosseini"
            //            }
            //    });
            //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //    {
            //        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
            //          Enter 'Bearer' [space] and then your token in the text input below.
            //          \r\n\r\nExample: 'Bearer 12345abcdef'",
            //        Name = "Authorization",
            //        In = ParameterLocation.Header,
            //        Type = SecuritySchemeType.ApiKey,
            //        Scheme = "Bearer"
            //    });

            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            //    {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference
            //                {
            //                    Type = ReferenceType.SecurityScheme,
            //                    Id = "Bearer"
            //                },
            //                Scheme = "oauth2",
            //                Name = "Bearer",
            //                In = ParameterLocation.Header,
            //            },
            //            new List<string>()
            //        }
            //    });
            //});




            services.AddCors(o => o.AddPolicy("AllowAllPolicy", builder =>
            {
                builder
                    .AllowAnyHeader()
                    .AllowAnyOrigin();
            }));


            services.AddScoped<IDataBaseContext, DataBaseContext>();
            services.AddScoped<IGetUsersService, GetUsersService>();
            services.AddScoped<IGetRolesService, GetRolesService>();
            services.AddScoped<IRegisterUserService, RegisterUserService>();
            services.AddScoped<IRemoveUserService, RemoveUserService>();
            services.AddScoped<IUserLoginService, UserLoginService>();
            services.AddScoped<IUserSatusChangeService, UserSatusChangeService>();
            services.AddScoped<IEditUserService, EditUserService>();

            //FacadeInject
            services.AddScoped<IProductFacad, ProductFacad>();


            //------------------
            services.AddScoped<IGetMenuItemService, GetMenuItemService>();
            services.AddScoped<IGetCategoryService, GetCategoryService>();
            services.AddScoped<IAddNewSliderService, AddNewSliderService>();
            services.AddScoped<IGetSliderService, GetSliderService>();
            services.AddScoped<IAddHomePageImagesService, AddHomePageImagesService>();
            services.AddScoped<IGetHomePageImagesService, GetHomePageImagesService>();
            services.AddScoped<IAddBlogService, AddBlogService>();
            services.AddScoped<IAddBlogCategoryService, AddBlogCategoryService>();
            services.AddScoped<IGetAllCategorieBlogs, GetAllCategorieBlogs>();

            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IAddRequestPayService, AddRequestPayService>();
            services.AddScoped<IGetRequestPayService, GetRequestPayService>();
            services.AddScoped<IAddNewOrderService, AddNewOrderService>();
            services.AddScoped<IGetUserOrdersService, GetUserOrdersService>();
            services.AddScoped<IGetOrdersForAdminService, GetOrdersForAdminService>();
            services.AddScoped<IGetRequestPayForAdminService, GetRequestPayForAdminService>();


            // news
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<IHomePageImagesService, HomePageImagesService>();



            //string contectionString = @"Data Source=DESKTOP-ILQ6NEU\MSSQLSERVER2019; Initial Catalog=Bugeto_StoreDb; Integrated Security=True;";
            //services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(Configuration.GetConnectionString("develop")));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseStatusCodePagesWithReExecute("/Home/HandleError/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStatusCodePages();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                   name: "areas",
                    pattern: "{area:exists}/{controller=Users}/{action=Index}/{id?}");

            });
            //app.Run(context =>
            //{
            //    context.Response.StatusCode = 404;
            //    return Task.FromResult(0);
            //});

        }
    }
}
