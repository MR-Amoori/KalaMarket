using System.Collections.Generic;
using KalaMarket.DataLayer.Entities.Product;

namespace KalaMarket.Core.Service.Interface
{
    public interface ICategoryService
    {
        List<Category> ShowAllCategory();
        int AddCategory(Category category);
        bool UpdateCategoty(Category category);
        bool DeleteCategory(int categoryId);
        bool DeleteCategory(Category category);
        void Save();
        List<Category> ShowAllSubCategory(int categoryId);
        Category FindCategotyBy(int id);

    }
}