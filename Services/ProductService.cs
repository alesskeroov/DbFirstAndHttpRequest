using DbFirst.Data;
using DbFirst.IServices;
using DbFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbFirst.Services
{
    public class ProductService : IProductService
    {
        private ProductDbContext _context;

        public ProductService(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            _context.Products.Add(product);
             await _context.SaveChangesAsync();
            return product;
            
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product==null)
            {
                return false;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async  Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> UpdateProductAsync(int id, Product updatedProduct)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            product.Id = id;
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            _context.SaveChanges();
            return product;

        }
    }
}
