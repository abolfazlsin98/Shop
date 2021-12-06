using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugeto_Store.Application.Services.Blog.Commands.AddBlog;
using Bugeto_Store.Common.Dto;

namespace Bugeto_Store.Application.Services.Blog.Commands.AddBlogCategory
{
    public interface IAddBlogCategoryService
    {
        ResultDto Execute(string name);
    }

}
