using System.Collections.Generic;
using KalaMarket.DataLayer.Entities.Product;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KalaMarket.Core.Service.Interface
{
    public interface IGarrantyService
    {
        List<ProductGarranty> ShowAllGarranties();
        ProductGarranty FindGarrantyBy(int id);
        bool UpdateGarranty(ProductGarranty garranty);
        bool DeleteGarranty(ProductGarranty garranty);
        bool ExistGarrante(string garrantiName, int garrantyId);
        int AddGarranty(ProductGarranty garranty);
        void Save();
    }
}