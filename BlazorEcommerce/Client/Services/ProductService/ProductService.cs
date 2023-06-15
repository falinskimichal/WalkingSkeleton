using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
        public event Action ProductChanged;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; } = "Loading products...";

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
            return result;
        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var result = categoryUrl == null ?
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("/api/product/featured") :
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"/api/product/category/{categoryUrl}");

            if (result != null && result.Data != null)
                Products = result.Data;


            ProductChanged.Invoke();

        }

        public async Task SearchProduct(string text)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/search/{text}");
            if(result != null && result.Data != null)
            {
                Products = result.Data;
            }
            if(Products.Count == 0)
            {
                Message = "No products found.";
            }
            ProductChanged?.Invoke();
        }

        public async Task<List<string>> GetProductSearchSugestions(string text)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<String>>>($"api/product/search/{text}");
            return result.Data;
        }
    }
}
