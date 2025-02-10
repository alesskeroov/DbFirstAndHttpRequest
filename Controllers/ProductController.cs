using DbFirst.IServices;
using DbFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbFirst.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public Task<IEnumerable<Product>> GetProducts()
        {
            return _productService.GetAllProductsAsync();
        }
        [HttpGet]
        public Task<Product> GetProductById(int id)
        {
            return _productService.GetProductById(id);
        }
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            var createdProduct = await _productService.AddProduct(product);
            return await Task.FromResult(CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Value.Id }, createdProduct));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            var updateProduct= await _productService.UpdateProductAsync(id, product);
            return Ok(updateProduct);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result=await _productService.DeleteProduct(id);
            if (!result)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            return NoContent();
        }

    }
}
