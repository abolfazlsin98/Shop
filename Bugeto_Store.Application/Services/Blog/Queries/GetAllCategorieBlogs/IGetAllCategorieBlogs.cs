using System.Collections.Generic;
using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;

using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Blog.Queries.GetAllCategorieBlogs
{
    public interface IGetAllCategorieBlogs
    {
        ResultDto<List<AllBlogCategoriesDto>> Execute();
    }


    public class GetAllCategorieBlogs : IGetAllCategorieBlogs
    {
        private readonly IDataBaseContext _context;

        public GetAllCategorieBlogs(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<AllBlogCategoriesDto>> Execute()
        {
            var blogCategories = _context.BlogCategories.Select(p => new AllBlogCategoriesDto
            {
                Id = p.Id,
                Name = p.Name,
            }).ToList();


            return new ResultDto<List<AllBlogCategoriesDto>>
            {
                Data = blogCategories,
                IsSuccess = false,
                Message = "",
            };


        }
    }


    public class AllBlogCategoriesDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}