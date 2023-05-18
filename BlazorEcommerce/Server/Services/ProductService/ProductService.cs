
namespace BlazorEcommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _ctx;

        public ProductService(DataContext _ctx)
        {
            this._ctx = _ctx;
        }
        public async Task<ServiceResponse<List<Product>>> GetProductAsync()
        {
            var resposne = new ServiceResponse<List<Product>>()
            {
                Data = await _ctx.Products.ToListAsync()
            };

            return resposne;
        }
    }
}
