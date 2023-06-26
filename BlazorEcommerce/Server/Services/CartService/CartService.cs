using Microsoft.Extensions.Configuration.EnvironmentVariables;
using System.Security.Claims;

namespace BlazorEcommerce.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly DataContext _ctx;
        private readonly IHttpContextAccessor _httpCtxAccesor;

        public CartService(DataContext ctx, IHttpContextAccessor ctxAccesor)
        {
            _ctx = ctx;
            _httpCtxAccesor = ctxAccesor;
        }

        private int GetUserId() => int.Parse(_httpCtxAccesor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<CartProductResponseDto>>> GetCartProductsAsync(List<CartItem> cartItems)
        {
            var result = new ServiceResponse<List<CartProductResponseDto>>
            {
                Data = new List<CartProductResponseDto>()
            };

            foreach (var item in cartItems)
            {
                var product = await _ctx.Products.Where(p => p.Id == item.ProductId).FirstOrDefaultAsync();

                if (product == null)
                {
                    continue;
                }

                var productVariant = await _ctx.ProductVariants
                    .Where(v => v.ProductId == item.ProductId && v.ProductTypeId == item.ProductTypeId)
                    .Include(v => v.ProductType).FirstOrDefaultAsync();

                var cartProduct = new CartProductResponseDto
                {
                    ProductId = product.Id,
                    Title = product.Title,
                    ImageUrl = product.ImageUrl,
                    Price = productVariant.Price,
                    ProductType = productVariant.ProductType.Name,
                    ProductTypeId = productVariant.ProductTypeId,
                    Quantity = item.Quantity
                };
                result.Data.Add(cartProduct);
            }
            return result;
        }

        public async Task<ServiceResponse<List<CartProductResponseDto>>> StoreCartItem(List<CartItem> cartItems)
        {
            cartItems.ForEach(cartItems => cartItems.UserId = GetUserId());
            _ctx.CartItems.AddRange(cartItems);
            await _ctx.SaveChangesAsync();

            return await GetDbCartProducts();
        }

        public async Task<ServiceResponse<int>> GetCartItemCount()
        {
            var count = (await _ctx.CartItems.Where(ci => ci.UserId == GetUserId()).ToListAsync()).Count();
            return new ServiceResponse<int>
            {
                Data = count
            };
        }

        public async Task<ServiceResponse<List<CartProductResponseDto>>> GetDbCartProducts()
        {
            return await GetCartProductsAsync(await _ctx.CartItems.Where(ci => ci.UserId == GetUserId()).ToListAsync());
        }
    }
}
