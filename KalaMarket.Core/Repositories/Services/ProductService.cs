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


        #region Property Name

        public List<PropertyName> ShowAllPropertyNames()
        {
            return _context.PropertyNames.ToList();
        }

        public PropertyName FindPropertyNameBy(int id)
        {
            return _context.PropertyNames.Find(id);
        }

        public int AddPropertyName(PropertyName property)
        {
            try
            {
                if (ExistsProperty(property.PropertyNameTitle)) return 0;
                var model = property;
                _context.PropertyNames.Add(model);
                Save();
                return model.PropertyNameId;
            }
            catch
            {
                return 0;
            }
        }

        public bool UpdatePropertyName(PropertyName property)
        {
            try
            {
                _context.PropertyNames.Update(property);
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePropertyName(int id)
        {
            try
            {
                var property = FindPropertyNameBy(id);
                _context.PropertyNames.Remove(property);
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ExistsProperty(string name)
        {
            return _context.PropertyNames.Any(x => x.PropertyNameTitle == name);
        }

        public bool AddPropertyNameForCategory(List<PropertyNameToCategory> category)
        {
            try
            {
                _context.PropertyNameToCategories.AddRange(category);
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}