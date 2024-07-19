using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.CategoryR
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int categoryId);
        Task InsertCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(Category category);

    }
}
