using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalaMarket.Core.Service.Interface;

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
    }
}
