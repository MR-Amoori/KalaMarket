using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KalaMarket.Core.Service.Interface;
using KalaMarket.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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
        public IActionResult AddMainSlider(MainSlider slider, int id)
        {
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    slider.SliderId = id;
                    return RedirectToAction("EditMainSliderAction", slider);
                }

                int res = _mainSliderService.AddSlider(slider);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(slider);
            }
        }

        [HttpGet]
        public IActionResult EditMainSlider(int id)
        {
            ViewData["Id"] = id;
            var model = _mainSliderService.FindSliderBy(id);
            if (model != null)
                return View("AddMainSlider", model);
            else
                return NotFound();
        }


        public IActionResult EditMainSliderAction(MainSlider mainSlider)
        {
            if (ModelState.IsValid)
            {
                bool res = _mainSliderService.UpdateSlider(mainSlider);
                if (res)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("AddMainSlider", mainSlider);
                }
            }

            return View("AddMainSlider", mainSlider);
        }

        public IActionResult DeleteMainSlider(int id)
        {
            var result = _mainSliderService.DeleteSlider(id);
            if (result)
                return RedirectToAction(nameof(Index));
            else
                return NotFound();
        }

    }
}