using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalaMarket.Core.Service.Interface;
using KalaMarket.DataLayer.Entities.Product;
using Microsoft.CodeAnalysis.FlowAnalysis;

namespace KalaMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GarrantyController : Controller
    {
        private readonly IGarrantyService _garrantyService;

        public GarrantyController(IGarrantyService garrantyService)
        {
            _garrantyService = garrantyService;
        }

        public IActionResult Index()
        {
            return View(_garrantyService.ShowAllGarranties());
        }

        [HttpGet]
        public IActionResult AddGarranty()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGarranty(ProductGarranty garranty)
        {
            if (!ModelState.IsValid) return View(garranty);

            if (_garrantyService.AddGarranty(garranty) > 0)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(garranty);
        }
    }
}
