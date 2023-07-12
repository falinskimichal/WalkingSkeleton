namespace BlazorEcommerce.Client.Services.ProductTypesService
{
    public interface IProductTypesService
    {
        event Action OnChange;
        public List<ProductType> ProductTypes { get; set; }
        Task GetProductTypes();
    }
}
