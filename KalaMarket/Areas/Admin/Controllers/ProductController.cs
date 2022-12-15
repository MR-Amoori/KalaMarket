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
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
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

        #region Property Name

        public IActionResult ShowAllPropertyName()
        {
            return View(_productService.ShowAllPropertyNames());
        }

        [HttpGet]
        public IActionResult AddPropertyName()
        {
            ViewBag.Category = _categoryService.ShowSubCategories();
            return View();
        }

        [HttpPost]
        public IActionResult AddPropertyName(PropertyName propertyName, List<int> categoryid)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Category = _categoryService.ShowSubCategories();
                return View(propertyName);
            }

            int nameId = _productService.AddPropertyName(propertyName);

            if (nameId <= 0)
            {
                ViewBag.Category = _categoryService.ShowSubCategories();
                return View(propertyName);
            }

            List<PropertyNameToCategory> addPropertyNameToCategories = new List<PropertyNameToCategory>();

            foreach (int item in categoryid)
            {
                addPropertyNameToCategories.Add(new PropertyNameToCategory()
                {
                    CategoryId = item,
                    PropertyNameId = nameId
                });
            }

            bool res = _productService.AddPropertyNameForCategory(addPropertyNameToCategories);

            if (res)
            {
                ViewData["Result"] = "added";
                return RedirectToAction(nameof(ShowAllPropertyName));
            }

            ViewBag.Category = _categoryService.ShowSubCategories();
            return View(propertyName);

        }

        #endregion

    }
}
