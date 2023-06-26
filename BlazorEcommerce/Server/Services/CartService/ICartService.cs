namespace BlazorEcommerce.Server.Services.CartService
{
    public interface ICartService
    {
        Task<ServiceResponse<List<CartProductResponseDto>>> GetCartProductsAsync(List<CartItem> cartItems);
        Task<ServiceResponse<List<CartProductResponseDto>>> StoreCartItem(List<CartItem> cartItems, int userId);
    }
}
