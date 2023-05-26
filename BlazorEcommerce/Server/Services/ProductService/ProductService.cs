
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
                Data = await _ctx.Products.Include(p => p.Variants).ToListAsync()
            };

            return resposne;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();
            var product = await _ctx.Products
                .Include(p => p.Variants)
                .ThenInclude(v => v.ProductType)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
            {
                response.Success = false;
                response.Message = "Sorry but this product does not exists.";
            }
            else
            {
                response.Success = true;
                response.Data = product;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductbyCategoryAsync(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _ctx.Products.Where(x => x.Category.Url.ToLower().Equals(categoryUrl.ToLower())).Include(p => p.Variants).ToListAsync()
            };

            return response;
        }
    }
}
