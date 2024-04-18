using AppData.Entity;
using Microsoft.AspNetCore.Components.Forms;

namespace AppView.Service
{
    public interface IProduct
    {
        public Task<List<Product>> GetAll();
        public Task<string> Post(Product product);
        public Task<string> Update(Product product);
        public Task<Product> GetByID(int id);
        public Task<string> Delete(int id);
        public Task<string> PostImg(IBrowserFile file);
    }
}
