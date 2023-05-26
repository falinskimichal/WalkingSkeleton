namespace BlazorEcommerce.Server.Services.CategoryService
{

    public class CategoryService : ICategoryService
    {
        private readonly DataContext _ctx;

        public CategoryService(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<ServiceResponse<List<Category>>> GetCategoriesAsync()
        {
            var categories = await _ctx.Categories.ToListAsync();
            return new ServiceResponse<List<Category>>()
            {
                Data = categories
            };
        }
    }
}
