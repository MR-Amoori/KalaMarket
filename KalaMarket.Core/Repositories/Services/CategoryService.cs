using System;
using System.Collections.Generic;
using System.Linq;
using KalaMarket.Core.Service.Interface;
using KalaMarket.DataLayer.Context;
using KalaMarket.DataLayer.Entities.Product;

namespace KalaMarket.Core.Repositories.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly KalaMarketContext _context;

        public CategoryService(KalaMarketContext context)
        {
            _context = context;
        }

        public List<Category> ShowAllCategory()
        {
            return _context.Categories.Where(x => !x.IsDeleted && x.SubCategory == null).ToList();
        }

        public int AddCategory(Category category)
        {
            try
            {
                Category model = category;
                _context.Categories.Add(model);
                Save();
                return model.CategoryId;
            }
            catch
            {
                return 0;
            }
        }

        public bool UpdateCategoty(Category category)
        {
            try
            {
                _context.Categories.Update(category);
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            try
            {
                return DeleteCategory(FindCategotyBy(categoryId));
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCategory(Category category)
        {
            try
            {
                FindCategotyBy(category.CategoryId).IsDeleted = true;
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

        public List<Category> ShowAllSubCategory(int categoryId)
        {
            return _context.Categories.Where(x => !x.IsDeleted && x.SubCategory == categoryId).ToList();
        }

        public Category FindCategotyBy(int id)
        {
            return _context.Categories.Where(x => !x.IsDeleted).FirstOrDefault(x => x.CategoryId == id);
        }

        public List<Category> ShowSubCategories()
        {
            return _context.Categories.Where(x => x.SubCategory != null).ToList();
        }
    }
}