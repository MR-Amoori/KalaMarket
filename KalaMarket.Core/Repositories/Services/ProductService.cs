using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaMarket.Core.Service.Interface;
using KalaMarket.DataLayer.Context;
using KalaMarket.DataLayer.Entities.Product;

namespace KalaMarket.Core.Repositories.Services
{
    public class ProductService : IProductService
    {
        private readonly KalaMarketContext _context;

        public ProductService(KalaMarketContext context)
        {
            _context = context;
        }

        #region Product Color

        public List<ProductColor> ShowAllColors()
        {
            return _context.ProductColors.ToList();
        }

        public int AddColor(ProductColor color)
        {
            try
            {
                if (!ExsistColor(color.ProductColorName, color.ProductColorCode))
                {
                    _context.ProductColors.Add(color);
                    Save();
                    return color.ProductColorId;
                }
            }
            catch
            {
                return 0;
            }

            return 0;
        }

        public bool UpdateColor(ProductColor color)
        {
            try
            {
                if (!ExsistColor("", color.ProductColorCode))
                {
                    _context.ProductColors.Update(color);
                    Save();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public ProductColor FindColorBy(int id)
        {
            return _context.ProductColors.FirstOrDefault(x => x.ProductColorId == id);
        }

        public bool ExsistColor(string nameColor, string ColorCode)
        {
            return _context.ProductColors.Any(x => x.ProductColorName == nameColor || x.ProductColorCode == ColorCode);
        }

        public bool DeleteColor(int id)
        {
            try
            {
                _context.ProductColors.Remove(FindColorBy(id));
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}