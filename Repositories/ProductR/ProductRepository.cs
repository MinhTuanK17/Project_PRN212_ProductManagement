using BusinessObject;
using DataLayerAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ProductR
{
    public class ProductRepository : IProductRepository
    {
        public async Task DeleteProduct(Product product) => await ProductDAO.Instance.DeleteProduct(product);   
        public async Task<List<Product>> GetAllProduct() => await ProductDAO.Instance.GetAllProduct();

        public async Task<Product> GetProductById(string productId) => await ProductDAO.Instance.GetProductById(productId);

        public async Task InsertProduct(Product product) => await ProductDAO.Instance.InsertProduct(product);

        public async Task<List<Product>> SearchProductByName(string name, int? categoryId) => await ProductDAO.Instance.SearchProductByName(name, categoryId);

        public async Task UpdateProduct(Product product) => await ProductDAO.Instance.UpdateProduct(product);
    }
}
