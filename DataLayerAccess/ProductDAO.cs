using BusinessObject;
using BusinessObject.Common;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayerAccess
{
    public class ProductDAO : SingletonBase<ProductDAO>
    {
        private MyPhoneDbContext? _context;
        public async Task<List<Product>> GetAllProduct()
        {
            _context = new();
            return await _context.Products.AsNoTracking().Include(p => p.Category).ToListAsync();
        }
        public async Task<Product> GetProductById(string productId)
        {
            try
            {
                _context = new();
                var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductPhoneId.Equals(productId));
                return product!;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task InsertProduct(Product product)
        {
            _context = new();
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateProduct(Product product)
        {
            try
            {
                _context = new();
                var findProduct = await GetProductById(product.ProductPhoneId);
                if (findProduct != null)
                {
                    _context.Entry(findProduct).CurrentValues.SetValues(product);
                }
                else
                {
                    _context.Products.Update(product);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task ChangeQuantity(string productId, int newQuantity)
        {
            try
            {
                var findProduct = await GetProductById(productId);
                if (findProduct != null)
                {
                    
                    findProduct.PhoneQuantity = findProduct.PhoneQuantity - newQuantity;
                }
                else
                {
                    throw new Exception($"Product with ID {productId} not found.");
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteProduct(Product product)
        {
            try
            {
                _context = new();
                var findProduct = await GetProductById(product.ProductPhoneId);
                if (findProduct != null)
                {
                    _context.Products.Remove(findProduct);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<Product>> SearchProductByName(string name, int? categoryId)
        {
            try
            {
                _context = new();
                var query = _context.Products.AsNoTracking()
                                    .Include(x => x.Category)
                                    .Where(p => p.ProductPhoneName.ToLower().Contains(name.ToLower()));

                if (categoryId.HasValue)
                {
                    query = query.AsNoTracking().Where(p => p.CategoryId == categoryId.Value);
                }
                return await query.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<List<Product>> GetProductByCategoryId(int? categoryId)
        {
            try
            {
                _context = new();
                var query = _context.Products.AsNoTracking()
                                    .Include(x => x.Category)
                                    .Where(p => p.CategoryId == categoryId);

                if (categoryId.HasValue)
                {
                    query = query.AsNoTracking().Where(p => p.CategoryId == categoryId.Value);
                }
                return await query.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
