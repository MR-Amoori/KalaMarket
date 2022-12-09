using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using KalaMarket.Core.Service.Interface;
using KalaMarket.DataLayer.Entities.Product;

namespace KalaMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(_categoryService.ShowAllCategory());
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                if (_categoryService.AddCategory(category) != 0)
                {
                    TempData["Result"] = "added";
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(category);
        }


        [HttpGet]
        public IActionResult UpdateCategory(int categoryId)
        {
            var categoty = _categoryService.FindCategotyBy(categoryId);
            if (categoty != null)
            {
                return View(categoty);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                if (_categoryService.UpdateCategoty(category))
                {
                    TempData["Result"] = "edited";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(category);
        }


        public IActionResult DeleteCategory(int categoryId)
        {
            if (_categoryService.DeleteCategory(categoryId))
            {
                TempData["Result"] = "deleted";
                return RedirectToAction(nameof(Index));
            }
            TempData["Result"] = "error";
            return RedirectToAction(nameof(Index));
        }

    }
}