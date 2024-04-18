using AppData.Entity;
using Microsoft.AspNetCore.Components.Forms;
using System.IO;

namespace AppView.Service
{
    public class ProductService : IProduct
    {
        private readonly HttpClient _httpClient;
        private readonly IWebHostEnvironment _environment;

        public ProductService(HttpClient httpClient, IWebHostEnvironment environment)
        {
            _httpClient = httpClient;
            _environment = environment;
        }

        public async Task<string> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Product/{id}");
            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>("/api/Product/get-all");
        }

        public async Task<Product> GetByID(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"/api/Product/get-by-id/{id}");
        }

        public async Task<string> Post(Product product)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Product/create", product);
            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }

        public async Task<string> PostImg(IBrowserFile file)
        {

            var name = file.Name;
            var path = Guid.NewGuid().ToString() + name.Substring(name.IndexOf("."));
            var filePath = Path.Combine(_environment.ContentRootPath,
           "wwwroot", "uploads", path);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.OpenReadStream().CopyToAsync(stream);

                return path;
            }
        }

        public async Task<string> Update(Product product)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/Product/update", product);
            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }
    }
}
