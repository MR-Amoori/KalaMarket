using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public ProductGarranty FindGarrantyBy(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateGarranty(ProductGarranty garranty)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteGarranty(ProductGarranty garranty)
        {
            throw new System.NotImplementedException();
        }

        public bool ExistGarrante(string garrantiName, int garrantyId)
        {
            throw new System.NotImplementedException();
        }

        public int AddGarranty(ProductGarranty garranty)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}