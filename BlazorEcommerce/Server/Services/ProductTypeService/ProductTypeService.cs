namespace BlazorEcommerce.Server.Services.ProductTypeService
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly DataContext _ctx;

        public ProductTypeService(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<ServiceResponse<List<ProductType>>> GetProductTypes()
        {
            var productTypes = await _ctx.ProductTypes.ToListAsync();
            return new ServiceResponse<List<ProductType>> { Data = productTypes };
        }
    }
}
