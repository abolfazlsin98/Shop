﻿using Bugeto_Store.Application.Services.Blog;
using Bugeto_Store.Application.Services.Blog.Commands.AddBlog;
using Bugeto_Store.Application.Services.Blog.Commands.AddBlogCategory;
using Bugeto_Store.Application.Services.Blog.Queries.GetAllCategorieBlogs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EndPoint.Site.Areas.Admin.Controllers
{

    [Area("Admin")]

    public class BlogController : Controller
    {
        public IAddBlogService _addBlog { get; set; }
        public IAddBlogCategoryService _addBlogCategory { get; set; }
        public IGetAllCategorieBlogs _getAllCategorieBlogs { get; set; }

        public IBlogService _blogService { get; set; }

        public BlogController(IAddBlogService addBlog, IAddBlogCategoryService addBlogCategory, IGetAllCategorieBlogs getAllCategorieBlogs, IBlogService blogService)
        {
            _addBlog = addBlog;
            _addBlogCategory = addBlogCategory;
            _getAllCategorieBlogs = getAllCategorieBlogs;

            _blogService = blogService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddNewBlog()
        {
            ViewBag.Categories = new SelectList(_getAllCategorieBlogs.Execute().Data, "Id", "Name");
            return View();
        }


        [HttpPost]
        public IActionResult AddNewBlog(RequestAddBlogDto requestAddBlogDto)
        {
            if (ModelState.IsValid)
            {

                List<IFormFile> images = new List<IFormFile>();
                for (int i = 0; i < Request.Form.Files.Count; i++)
                {
                    var file = Request.Form.Files[i];
                    images.Add(file);
                }
                requestAddBlogDto.Images = images;
                var result = _blogService.AddBlog(requestAddBlogDto);

                //if (result.IsSuccess)
                //{
                //    return RedirectToAction("Index");
                //}

                return View(requestAddBlogDto);

            }
            return View(requestAddBlogDto);
        }


        public IActionResult AddNewBlogCategory()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddNewBlogCategory(string name)
        {
            RedirectToAction("Index");
            return Json(_addBlogCategory.Execute(name));
        }

    }
}
