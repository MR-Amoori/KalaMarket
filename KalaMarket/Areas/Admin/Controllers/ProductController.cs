using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalaMarket.Core.Service.Interface;
using KalaMarket.DataLayer.Entities.Product;

namespace KalaMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }


        #region Product Color

        public IActionResult ShowAllColor()
        {
            return View(_productService.ShowAllColors());
        }

        [HttpGet]
        public IActionResult AddColor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddColor(ProductColor color)
        {
            if (!ModelState.IsValid)
            {
                return View(color);
            }

            int colorId = _productService.AddColor(color);
            TempData["Result"] = colorId > 0 ? "added" : "error";
            return RedirectToAction(nameof(ShowAllColor));
        }

        [HttpGet]
        public IActionResult EditColor(int id)
        {
            var color = _productService.FindColorBy(id);
            if (color != null)
            {
                return View(color);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditColor(ProductColor color)
        {
            if (_productService.UpdateColor(color))
            {
                TempData["Result"] = "edited";
                return RedirectToAction(nameof(ShowAllColor));
            }
            TempData["Result"] = "error";
            return RedirectToAction(nameof(ShowAllColor));
        }

        public IActionResult DeleteColor(int id)
        {
            if (_productService.DeleteColor(id))
            {
                TempData["Result"] = "deleted";
                return RedirectToAction(nameof(ShowAllColor));
            }
            TempData["Result"] = "error";
            return RedirectToAction(nameof(ShowAllColor));
        }
        

        #endregion



    }
}
