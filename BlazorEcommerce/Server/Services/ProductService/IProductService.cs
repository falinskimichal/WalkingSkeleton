
using System.Xml.Schema;

namespace BlazorEcommerce.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductAsync();
        Task<ServiceResponse<Product>> GetProductAsync(int productId);
        Task<ServiceResponse<List<Product>>> GetProductbyCategoryAsync(string categoryUrl);
        Task<ServiceResponse<List<Product>>> SearchProduct(string searchText);
        Task<ServiceResponse<List<string>>> GetProductSearchSugestions(string text);

        Task<ServiceResponse<List<Product>>> GetFeaturedProducts();

    }
}
