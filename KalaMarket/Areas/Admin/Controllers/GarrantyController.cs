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

        #region AddGarranty

        //[HttpGet]
        //public IActionResult AddGarranty()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult AddGarranty(ProductGarranty garranty)
        //{
        //    if (!ModelState.IsValid) return View(garranty);

        //    if (_garrantyService.AddGarranty(garranty) > 0)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(garranty);
        //}

        #endregion

        [HttpPost]
        public IActionResult AddGarranty(ProductGarranty garranty)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            int garrantyId = _garrantyService.AddGarranty(garranty);
            TempData["Result"] = garrantyId > 0 ? "added" : "error";
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult UpdateGarranty(int id)
        {
            var garranty = _garrantyService.FindGarrantyBy(id);
            if (garranty != null)
            {
                return View(garranty);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult UpdateGarranty(ProductGarranty garranty)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            bool update = _garrantyService.UpdateGarranty(garranty);
            TempData["Result"] = update == true  ? "edited" : "error";
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult DeleteGarranty(int id)
        {
            var garranty = _garrantyService.FindGarrantyBy(id);
            if (garranty != null)
            {
                if (_garrantyService.DeleteGarranty(id))
                {
                    TempData["Result"] = "deleted";
                    return RedirectToAction(nameof(Index));
                }
            }

            TempData["Result"] = "error";
            return RedirectToAction(nameof(Index));
        }

    }
}