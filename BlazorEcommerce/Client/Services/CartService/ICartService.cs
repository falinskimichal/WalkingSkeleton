namespace BlazorEcommerce.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCart(CartItem item);
        Task<List<CartProductResponseDto>> GetCartProducts();
        Task RemoveProductFromTheCart(int productId, int productTypeId);

        Task UpdateQuantity(CartProductResponseDto product);
        Task StoreCartItems(bool emptyLocalCart);
        Task GetCartItemsCount();
    }
}
