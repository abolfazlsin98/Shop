using Bugeto_Store.Application.Services.Blog.Commands.AddBlog;
using Bugeto_Store.Application.Services.Blog.Queries.GetAllBlogs;
using Bugeto_Store.Application.Services.Blog.Queries.GetAllCategorieBlogs;
using Bugeto_Store.Common.Dto;
using Bugeto_Store.Domain.Entities.Blog;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Blog
{
    public interface IBlogService
    {

        ResultDto<List<AllBlogsDto>> GetAllBlog();

        ResultDto<List<AllBlogCategoriesDto>> GetAllBlogCategory();

        ResultDto AddBlog(RequestAddBlogDto request);

        ResultDto AddBlogCategory(string name);
    }

    public class RequestAddBlogDto
    {
        [DisplayName("عنوان مقاله")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }


        [DisplayName("عکس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public List< IFormFile> Images { get; set; }


        [DisplayName("محتوی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Content { get; set; }


        [DisplayName("نام دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string BlogCategoryName { get; set; }


        public long AuthorId { get; set; }

        [DisplayName("تگ ها")]

        public ICollection<BlogInTagsDto> BlogInTags { get; set; }

    }

    public class BlogInTagsDto
    {
        public string Name { get; set; }
    }

}
