using Bugeto_Store.Application.Services.Blog.Commands.AddBlog;
using Bugeto_Store.Application.Services.Blog.Commands.AddBlogCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize("Operator")]

    public class BlogController : Controller
    {
        public IAddBlogService _addBlog { get; set; }
        public BlogController(IAddBlogService addBlog)
        {
            _addBlog = addBlog;

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddNewBlog()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddNewBlog(RequestAddBlogDto requestAddBlogDto)
        {
            if (ModelState.IsValid)
            {
                return Json(_addBlog.Execute(requestAddBlogDto));
                RedirectToAction("Index");

                
            }

            return View();
        }


       public IActionResult AddNewCategory()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddNewCategory(RequestAddCategoryBlogDto requestAddCategoryBlogDto)
        {
            return View();
        }

    }
}
