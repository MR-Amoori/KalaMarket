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

        [HttpGet]
        public IActionResult AddGarranty()
        {
            return PartialView("");
        }

        public IActionResult AddGarranty(ProductGarranty garranty)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            int garrantyId = _garrantyService.AddGarranty(garranty);
            int sendJson = garrantyId > 0 ? 1 : 0;
            return Json(sendJson);
        }


        [HttpGet]
        public IActionResult UpdateGarranty(int garrantyId)
        {
            var garranty = _garrantyService.FindGarrantyBy(garrantyId);
            return PartialView("",garranty);
        }

        public IActionResult UpdateGarranty(ProductGarranty garranty)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            bool result = _garrantyService.UpdateGarranty(garranty);
            int sendJson = result == true ? 2 : 0;
            return Json(sendJson);
        }



        [HttpGet]
        public IActionResult DeleteGarranty(int garrantyId)
        {
            var garranty = _garrantyService.FindGarrantyBy(garrantyId);
            return PartialView("", garranty);
        }

        public IActionResult DeleteGarranty(ProductGarranty garranty)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            bool result = _garrantyService.DeleteGarranty(garranty.ProductGarrantyId);
            int sendJson = result == true ? 3 : 0;
            return Json(sendJson);
        }
    }
}