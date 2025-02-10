using DbFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbFirst.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductById(int id);
        Task<ActionResult<Product>> AddProduct(Product product);
        Task<Product> UpdateProductAsync(int id, Product updatedProduct);
        Task<bool> DeleteProduct(int id);
    }
}
