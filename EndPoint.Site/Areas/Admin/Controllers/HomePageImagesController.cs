using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bugeto_Store.Application.Services.Common.HomePageImages;
using Bugeto_Store.Application.Services.HomePages.AddHomePageImages;
using Bugeto_Store.Domain.Entities.HomePages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomePageImagesController : Controller
    {
        private readonly IAddHomePageImagesService _addHomePageImagesService;


        private readonly IHomePageImagesService _homePageImagesService;
        public HomePageImagesController(IAddHomePageImagesService addHomePageImagesService , IHomePageImagesService homePageImagesService)
        {
            _addHomePageImagesService = addHomePageImagesService;

            _homePageImagesService = homePageImagesService;
        }
        public IActionResult Index()
        {
           
            return View(_homePageImagesService.GetAll().Data);
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(IFormFile file, string link , ImageLocation imageLocation)
        {
            _addHomePageImagesService.Execute(new requestAddHomePageImagesDto
            {
                file = file,
                ImageLocation = imageLocation,
                Link = link,
            });
            return View();
        }


        [HttpDelete]
        public IActionResult Delete(long id)
        {

            return Json(_homePageImagesService.Delete(id));

        }

    }
}
