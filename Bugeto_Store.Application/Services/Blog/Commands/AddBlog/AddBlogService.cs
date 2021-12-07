using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;
using Bugeto_Store.Domain.Entities.Blog;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Blog.Commands.AddBlog
{
    public class AddBlogService : IAddBlogService
    {
        private readonly IDataBaseContext _context;

        public AddBlogService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(RequestAddBlogDto request)
        {
            try
            {
                var blogCategory = _context.BlogCategories.FirstOrDefault(b=>b.Name ==   request.BlogCategoryName);
                long addad = 1;
                var author = _context.Authors.Find(addad);
                BlogPost blogPost = new BlogPost()
                {
                    Author = author,
                    BlogCategory = blogCategory,
                    Content = request.Content,
                    Title = request.Title,
                };

                _context.BlogPosts.Add(blogPost);
                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "بلاگ با موفقیت پست شد",
                };


            }
            catch (Exception ex)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "خطایی رخ داد ",
                };
            }
        }
    }


    public class RequestAddBlogDto
    {
        [Required]
        public string Title { get; set; }

         //[Required]
         //public List< IFormFile> Images { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string BlogCategoryName { get; set; }
       // [Required]
        public long AuthorId { get; set; }

    }
}
