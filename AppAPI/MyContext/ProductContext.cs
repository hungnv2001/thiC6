using AppData.Entity;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.MyContext
{
    public class ProductContext: DbContext
    {
        public ProductContext()
        {
            
        }
        public ProductContext(DbContextOptions options) : base(options)
        {
        }

      
        public DbSet<Product>? Products { get; set; }
    }
}
