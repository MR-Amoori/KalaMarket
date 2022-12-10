using System;
using System.Collections.Generic;
using System.Linq;
using KalaMarket.Core.Service.Interface;
using KalaMarket.DataLayer.Context;
using KalaMarket.DataLayer.Entities.Product;

namespace KalaMarket.Core.Repositories.Services
{
    public class GarrantyService : IGarrantyService
    {
        private readonly KalaMarketContext _context;

        public GarrantyService(KalaMarketContext context)
        {
            _context = context;
        }

        public List<ProductGarranty> ShowAllGarranties()
        {
            return _context.ProductGarranties.Where(x => !x.IsDeleted).ToList();
        }

        public ProductGarranty FindGarrantyBy(int id)
        {
            return _context.ProductGarranties.Find(id);
        }

        public bool UpdateGarranty(ProductGarranty garranty)
        {
            try
            {
                _context.ProductGarranties.Update(garranty);
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteGarranty(int garrantyId)
        {
            try
            {
                var garranty = FindGarrantyBy(garrantyId);
                garranty.IsDeleted = true;
                return UpdateGarranty(garranty);
            }
            catch
            {
                return false;
            }
        }

        public bool ExistGarrante(string garrantiName)
        {
            return _context.ProductGarranties.Any(x =>
                x.ProductGarrantyName == garrantiName);
        }

        public int AddGarranty(ProductGarranty garranty)
        {
            try
            {
                if (! ExistGarrante(garranty.ProductGarrantyName))
                {
                    var model = garranty;
                    _context.ProductGarranties.Add(model);
                    Save();
                    return model.ProductGarrantyId;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}