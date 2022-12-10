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

        public IActionResult ShowSubCategory(int id)
        {
            ViewBag.id = id;
            return View(_categoryService.ShowAllSubCategory(id));
        }

        [HttpGet]
        public IActionResult AddCategory(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                if (_categoryService.AddCategory(category) != 0)
                {
                    if (category.SubCategory == null)
                    {
                        TempData["Result"] = "added";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["Result"] = "added";
                        int id = category.SubCategory.Value;
                        return Redirect("/admin/category/showsubcategory/"+id.ToString());
                    }
                }
            }
            TempData["Result"] = "error";
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
            TempData["Result"] = "error";
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