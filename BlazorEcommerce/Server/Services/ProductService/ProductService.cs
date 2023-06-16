
namespace BlazorEcommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _ctx;

        public ProductService(DataContext _ctx)
        {
            this._ctx = _ctx;
        }

        public async Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _ctx.Products.Where(p => p.Featured).Include(p => p.Variants).ToListAsync()
            };
            return response;
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

        public async Task<ServiceResponse<List<string>>> GetProductSearchSugestions(string text)
        {
            var products = await FindProductBySearchText(text);
            List<string> result = new List<string>();

            foreach (var product in products)
            {
                if (product.Title.Contains(text, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }

                if (product.Description != null)
                {
                    var punctuation = product.Description.Where(char.IsPunctuation).Distinct().ToArray();
                    var words = product.Description.Split().Select(s => s.Trim(punctuation));

                    foreach (var word in words)
                    {
                        if (word.Contains(text, StringComparison.OrdinalIgnoreCase) && !result.Contains(word))
                        {
                            result.Add(word);
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>> { Data = result };
        }

        public async Task<ServiceResponse<ProductSearchResultDto>> SearchProduct(string searchText, int page)
        {
            var pageResult = 2f;
            var pageCount = Math.Ceiling((await FindProductBySearchText(searchText)).Count / pageResult);

            var products = await _ctx.Products
                            .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                            || p.Description.ToLower().Contains(searchText.ToLower()))
                            .Include(p => p.Variants).Skip((page - 1) * (int)pageResult).Take((int)pageResult)
                            .ToListAsync();

            var response = new ServiceResponse<ProductSearchResultDto>()
            {
                Data = new ProductSearchResultDto
                {
                    Products = products,
                    CurrentPage = page,
                    Pages = (int)pageCount
                }
            };
            return response;
        }

        private async Task<List<Product>> FindProductBySearchText(string searchText)
        {
            return await _ctx.Products
                            .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                            || p.Description.ToLower().Contains(searchText.ToLower()))
                            .Include(p => p.Variants).ToListAsync();
        }
    }
}
