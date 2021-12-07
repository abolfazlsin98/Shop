using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Application.Services.Common.Queries.GetSlider;
using Bugeto_Store.Application.Services.Products.Commands.AddNewProduct;
using Bugeto_Store.Common.Dto;
using Bugeto_Store.Domain.Entities.HomePages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Common.Sliders
{
    public class SliderService : ISliderService
    {
        private readonly IHostingEnvironment _environment;
        private readonly IDataBaseContext _context;

        public SliderService(IHostingEnvironment environment, IDataBaseContext context)
        {
            _environment = environment;
            _context = context;
        }

        public ResultDto Add(IFormFile file, string Link)
        {
            var resultUpload = UploadFile(file);


            Slider slider = new Slider()
            {
                link = Link,
                Src = resultUpload.FileNameAddress,
            };
            _context.Sliders.Add(slider);
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "اسلایدر با موفقیت اضافه شد"
            };
        }

        public ResultDto Delete(long id)
        {
           var slider = _context.Sliders.Find(id);

            if(slider != null)
            {
                _context.Sliders.Remove(slider);
                _context.SaveChanges();

                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "اسلایدر با موفقیت حذف شد"
                };
            }
            return new ResultDto()
            {
                IsSuccess = false,
                Message = "اسلایدر پیدا نشد"
            };
        }

        public ResultDto<List<SliderDto>> GetAll()
        {
            var sliders = _context.Sliders.OrderByDescending(p => p.Id).ToList().Select(
                p => new SliderDto
                {
                    Id = p.Id,
                    Link = p.link,
                    Src = p.Src,
                }).ToList();

            return new ResultDto<List<SliderDto>>()
            {
                Data = sliders,
                IsSuccess = true,
            };

        }

        public ResultDto Update(SliderDto sliderDto)
        {
            var slider = _context.Sliders.Find(sliderDto.Id);

            if(slider == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "اسلایدر پیدا نشد"
                };

            }
            _context.Sliders.Update(slider);
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "اسلایدر با موفقیت به روز رسانی شد"
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
