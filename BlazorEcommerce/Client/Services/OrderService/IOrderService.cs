namespace BlazorEcommerce.Client.Services.OrderService
{
    public interface IOrderService
    {
        public  Task PlaceOrder();
        public Task<List<OrderOverviewResponseDto>> GetOrders();
    }
}
