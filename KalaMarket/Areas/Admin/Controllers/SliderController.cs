using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KalaMarket.Core.ExtensionMethod;
using KalaMarket.Core.Service.Interface;
using KalaMarket.DataLayer.Entities;
using Microsoft.AspNetCore.Http;
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
        public IActionResult AddMainSlider(MainSlider slider, IFormFile file, int id)
        {
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    slider.SliderId = id;
                    string imgNameUpload = "";
                    if (file != null)
                    {
                        imgNameUpload = UploadImg.CreateImage(file);
                    }

                    if (imgNameUpload == "false")
                    {
                        TempData["Result"] = "ErrorUploadImg";
                        return RedirectToAction(nameof(Index));
                    }
                    else if (imgNameUpload != "")
                    {
                        var resultDeleteI = UploadImg.DeleteImg("slider-main", slider.SliderImage);
                        slider.SliderImage = imgNameUpload;
                    }

                    return RedirectToAction("EditMainSliderAction", slider);
                }

                if (file == null)
                {
                    ModelState.AddModelError("SliderImage", "* لطفا برای اسلایدر تصویر انتخاب کنید");
                    return View(slider);
                }

                string imgName = UploadImg.CreateImage(file);
                if (imgName == "false")
                {
                    TempData["Result"] = "ErrorUploadImg";
                    return RedirectToAction(nameof(Index));
                }

                slider.SliderImage = imgName;
                int res = _mainSliderService.AddSlider(slider);
                TempData["Result"] = "AddSlider";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                if (id > 0)
                {
                    return RedirectToAction("EditMainSlider", slider);
                }

                TempData["Result"] = "Error";
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
            {
                return RedirectToAction(nameof(Index));
            }
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
            else
            {
                return View("AddMainSlider", mainSlider);
            }
        }

        public IActionResult DeleteMainSlider(int id)
        {
            var slider = _mainSliderService.FindSliderBy(id);
            var result = _mainSliderService.DeleteSlider(slider);
            var resultDeleteI = UploadImg.DeleteImg("slider-main", slider.SliderImage);
            if (result)
            {
                TempData["Result"] = "Deleted";
                return RedirectToAction(nameof(Index));
            }
            else
                return NotFound();
        }
    }
}