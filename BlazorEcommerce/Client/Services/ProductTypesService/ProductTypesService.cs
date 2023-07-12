
namespace BlazorEcommerce.Client.Services.ProductTypesService
{
    public class ProductTypesService : IProductTypesService
    {
        private readonly HttpClient _http;

        public ProductTypesService(HttpClient http)
        {
            _http = http;
        }

        public List<ProductType> ProductTypes { get; set; } = new List<ProductType>();

        public event Action OnChange;

        public async Task GetProductTypes()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<ProductType>>>("api/producttype");

            ProductTypes = result.Data;
        }
    }
}
