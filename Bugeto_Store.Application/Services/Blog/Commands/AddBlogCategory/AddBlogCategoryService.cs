using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;
using Bugeto_Store.Domain.Entities.Blog;

namespace Bugeto_Store.Application.Services.Blog.Commands.AddBlogCategory
{
    public class AddBlogCategoryService : IAddBlogCategoryService
    {

        private readonly IDataBaseContext _context;
        public AddBlogCategoryService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "نام دسته بندی را وارد نمایید",
                };
            }

            var blogCategory = _context.BlogCategories.FirstOrDefault(b => b.Name == Name);

            if (blogCategory != null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = $"دسته بندی {Name} وجود دارد",
                };
            }
            BlogCategory category = new BlogCategory()
            {
                Name = Name,
            };
            _context.BlogCategories.Add(category);
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت اضافه شد",
            };
        }
    }
}
