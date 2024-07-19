using BusinessObject;
using BusinessObject.Common;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayerAccess
{
    public class CategoryDAO : SingletonBase<CategoryDAO>
    {
        private MyPhoneDbContext? _context;
        public async Task<List<Category>> GetAllCategories()
        {
            _context = new();
            return await _context.Categories.AsNoTracking().ToListAsync();
        }
        public async Task<Category> GetCategoryById(int categoryId)
        {
            try
            {
                _context = new();
                var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
                return category!;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task InsertCategory(Category category)
        {
            _context = new();
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateCategory(Category category)
        {
            try
            {
                _context = new();
                var findCat = await GetCategoryById(category.CategoryId);
                if (findCat != null)
                {
                    _context.Entry(findCat).CurrentValues.SetValues(category);
                }
                else
                {
                    _context.Categories.Update(category);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteCategory(Category category)
        {
            try
            {
                _context = new();
                var findCat = await GetCategoryById(category.CategoryId);
                if (findCat != null)
                {
                    _context.Categories.Remove(findCat);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
