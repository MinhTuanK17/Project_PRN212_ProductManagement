using BusinessObject;
using DataLayerAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ProductR
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProduct();
        Task<Product> GetProductById(string productId);
        Task InsertProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Product product);
        Task<List<Product>> SearchProductByName(string name, int? categoryId);
        Task<List<Product>> GetProductByCategoryId(int? categoryId);
        Task ChangeQuantity(string productId, int newQuantity);

    }
}
