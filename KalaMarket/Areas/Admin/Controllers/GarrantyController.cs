using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalaMarket.Core.Service.Interface;
using KalaMarket.DataLayer.Entities.Product;

namespace KalaMarket.Areas.Admin.Controllers
{
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
            return RedirectToAction(nameof(Index));
        }
    }
}
