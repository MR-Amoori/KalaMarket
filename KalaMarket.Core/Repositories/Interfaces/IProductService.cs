using System.Collections.Generic;
using KalaMarket.DataLayer.Entities.Product;

namespace KalaMarket.Core.Service.Interface
{
    public interface IProductService
    {
        #region Product Color

        List<ProductColor> ShowAllColors();
        int AddColor(ProductColor color);
        bool UpdateColor(ProductColor color);
        ProductColor FindColorBy(int id);
        bool ExsistColor(string nameColor, string ColorCode);
        void Save();

        #endregion



    }
}