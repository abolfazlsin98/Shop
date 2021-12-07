using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Application.Services.Common.Queries.GetHomePageImages;
using Bugeto_Store.Application.Services.HomePages.AddHomePageImages;
using Bugeto_Store.Application.Services.Products.Commands.AddNewProduct;
using Bugeto_Store.Domain.Entities.HomePages;
using Bugeto_Store.Common.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Common.HomePageImages
{
    public class HomePageImagesService : IHomePageImagesService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;

        public HomePageImagesService(IDataBaseContext context, IHostingEnvironment hosting)
        {
            _context = context;
            _environment = hosting;
        }


        //public ResultDto Add(requestAddHomePageImagesDto request)
        //{
        //    var resultUpload = UploadFile(request.file);

        //    HomePageImages homePageImages = new HomePageImages()
        //    {
        //        link = request.Link,
        //        Src = resultUpload.FileNameAddress,
        //        ImageLocation = request.ImageLocation,
        //    };
        //    _context.HomePageImages.Add(homePageImages);
        //    _context.SaveChanges();
        //    return new ResultDto()
        //    {
        //        IsSuccess = true,
        //    };
        //}


        public ResultDto Delete(long id)
        {
            var img = _context.HomePageImages.Find(id);

            if(img == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "عکس پیدا نشد"
                };
            }

            _context.HomePageImages.Remove(img);

            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "عکس با موفقیت حذف شد"
            };

        }

        public ResultDto<List<HomePageImagesDto>> GetAll()
        {
            var images = _context.HomePageImages.OrderByDescending(p => p.Id)
               .Select(p => new HomePageImagesDto
               {
                   Id = p.Id,
                   ImageLocation = p.ImageLocation,
                   Link = p.link,
                   Src = p.Src,
               }).ToList();
            return new ResultDto<List<HomePageImagesDto>>()
            {
                Data = images,
                IsSuccess = true,
            };

        }

        public ResultDto Update(HomePageImagesDto homePageImagesDto)
        {
            var img = _context.HomePageImages.Find(homePageImagesDto.Id);

            if (img == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "عکس پیدا نشد"
                };

            }
            _context.HomePageImages.Update(img);
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "عکس با موفقیت به روز رسانی شد"
            };
        }

        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\HomePages\Slider\";
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
    }
}
