using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KalaMarket.Core.Service.Interface;
using KalaMarket.DataLayer.Entities;

namespace KalaMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly IMainSliderService _mainSliderService;

        public SliderController(IMainSliderService mainSliderService)
        {
            _mainSliderService = mainSliderService;
        }

        public IActionResult Index()
        {
            var sliders = _mainSliderService.ShowAllSliders();
            return View(sliders);
        }

        [HttpGet]
        public IActionResult AddMainSlider()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMainSlider(MainSlider slider)
        {
            if (ModelState.IsValid)
            {
                int res = _mainSliderService.AddSlider(slider);
                return RedirectToAction(nameof(Index)); 
            }
            else
            {
                return View(slider);
            }
        }
    }
}