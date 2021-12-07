using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bugeto_Store.Application.Services.Common.Queries.GetSlider;
using Bugeto_Store.Application.Services.Common.Sliders;
using Bugeto_Store.Application.Services.HomePages.AddNewSlider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {
        private readonly IAddNewSliderService _addNewSliderService;
        private readonly IGetSliderService _getSliderService;

        private readonly ISliderService _sliderService;


        public SlidersController(IAddNewSliderService addNewSliderService, IGetSliderService getSliderService , ISliderService sliderService)
        {
            _addNewSliderService = addNewSliderService;
            _getSliderService= getSliderService;

            _sliderService = sliderService;

        }
        //[Route("")]
        //[Route("/Index")]
        public IActionResult Index()
        {
            return View(_getSliderService.Execute().Data);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(IFormFile file, string link)
        {
            _addNewSliderService.Execute(file, link);
            return RedirectToAction("Index","admin/sliders");
        }

        [HttpDelete]
        public IActionResult DeleteSlider(long id)
        {
            //return View();

           return Json(_sliderService.Delete(id)) ;
        }
    }
}
