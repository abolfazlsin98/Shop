﻿using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;
using Bugeto_Store.Domain.Entities.Blog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Blog.Commands.AddBlog
{
    public class AddBlogService : IAddBlogService
    {
        private readonly IDataBaseContext _context;

        private readonly IHostingEnvironment _environment;

        public AddBlogService(IDataBaseContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;
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


                List<BlogImage> blogImages = new List<BlogImage>();
                foreach (var item in request.Images)
                {
                    var uploadedResult = UploadFile(item);
                    blogImages.Add(new BlogImage
                    {
                        BlogPost = blogPost,
                        Src = uploadedResult.FileNameAddress,
                    });
                }


                _context.BlogImages.AddRange(blogImages);

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

        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\BlogImages\";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }

        public class UploadDto
        {
            public long Id { get; set; }
            public bool Status { get; set; }
            public string FileNameAddress { get; set; }
        }

    }
  
}
