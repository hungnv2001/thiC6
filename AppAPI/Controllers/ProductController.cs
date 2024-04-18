using AppAPI.MyContext;
using AppData.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }
        [HttpGet("get-all")]
        public async Task<List<Product>> GetALl()
        {
            return await _context.Products.ToListAsync();
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product.ID);
        }
        [HttpGet("get-by-id/{id}")]
        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            try
            {
                _context.Products.Remove(await GetById(id));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPut("update")]
        public async Task<bool> Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
