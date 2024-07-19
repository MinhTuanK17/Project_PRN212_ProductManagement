using BusinessObject;
using DataLayerAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.CategoryR
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task DeleteCategory(Category category) => await CategoryDAO.Instance.DeleteCategory(category);

        public async Task<List<Category>> GetAllCategories() => await CategoryDAO.Instance.GetAllCategories();

        public async Task<Category> GetCategoryById(int categoryId) => await CategoryDAO.Instance.GetCategoryById(categoryId);

        public async Task InsertCategory(Category category) => await CategoryDAO.Instance.InsertCategory(category);

        public async Task UpdateCategory(Category category) => await CategoryDAO.Instance.UpdateCategory(category); 
    }
}
