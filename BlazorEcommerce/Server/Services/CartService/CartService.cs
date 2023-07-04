using BlazorEcommerce.Shared;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using System.Security.Claims;

namespace BlazorEcommerce.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly DataContext _ctx;
        private readonly IAuthService _authService;

        public CartService(DataContext ctx, IAuthService authService)
        {
            _ctx = ctx;
            _authService = authService;
        }

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
            cartItems.ForEach(cartItems => cartItems.UserId = _authService.GetUserId());
            _ctx.CartItems.AddRange(cartItems);
            await _ctx.SaveChangesAsync();

            return await GetDbCartProducts();
        }

        public async Task<ServiceResponse<int>> GetCartItemCount()
        {
            var count = (await _ctx.CartItems.Where(ci => ci.UserId == _authService.GetUserId()).ToListAsync()).Count();
            return new ServiceResponse<int>
            {
                Data = count
            };
        }

        public async Task<ServiceResponse<List<CartProductResponseDto>>> GetDbCartProducts()
        {
            return await GetCartProductsAsync(await _ctx.CartItems.Where(ci => ci.UserId == _authService.GetUserId()).ToListAsync());
        }

        public async Task<ServiceResponse<bool>> AddToCart(CartItem cartItem)
        {
            cartItem.UserId = _authService.GetUserId();
            var sameItem = await _ctx.CartItems.FirstOrDefaultAsync(ci => ci.ProductId == cartItem.ProductId
            && ci.ProductTypeId == cartItem.ProductTypeId && ci.UserId == cartItem.UserId);

            if (sameItem == null)
            {
                _ctx.CartItems.Add(cartItem);
            }
            else
            {
                sameItem.Quantity += cartItem.Quantity;
            }

            await _ctx.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };

        }

        public async Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem)
        {
            var dbCartItem = await _ctx.CartItems.FirstOrDefaultAsync(ci => ci.ProductId == cartItem.ProductId
                                && ci.ProductTypeId == cartItem.ProductTypeId && ci.UserId == _authService.GetUserId());

            if (dbCartItem == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "Cart item does not exists."
                };
            }

            dbCartItem.Quantity = cartItem.Quantity;
            await _ctx.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true, Success = true };
        }

        public async Task<ServiceResponse<bool>> RemoveItemFromCart(int productId, int productTypeId)
        {
            var dbCartItem = await _ctx.CartItems.FirstOrDefaultAsync(ci => ci.ProductId == productId
                                && ci.ProductTypeId == productTypeId && ci.UserId == _authService.GetUserId());

            if (dbCartItem == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "Cart item does not exists."
                };
            }

            _ctx.CartItems.Remove(dbCartItem);
            await _ctx.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true, Success = true };
        }
    }
}
