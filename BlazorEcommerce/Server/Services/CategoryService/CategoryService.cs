using System.Runtime.InteropServices;

namespace BlazorEcommerce.Server.Services.CategoryService
{

    public class CategoryService : ICategoryService
    {
        private readonly DataContext _ctx;

        public CategoryService(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<ServiceResponse<List<Category>>> AddCategoryAsync(Category category)
        {
            category.Editing = false;
            category.IsNew = false;
            
            _ctx.Categories.Add(category);
            await _ctx.SaveChangesAsync();
            
            return await GetAdminCategoriesAsync();
        }

        public async Task<ServiceResponse<List<Category>>> DeleteCategoryAsync(int categoryId)
        {
            Category category = await GetCategoryById(categoryId);
            if (categoryId == null)
            {
                return new ServiceResponse<List<Category>>
                {
                    Success = false,
                    Message = "Category not found."
                };
            }

            category.Deleted = true;

            await _ctx.SaveChangesAsync();

            return await GetAdminCategoriesAsync();
        }

        private async Task<Category> GetCategoryById(int categoryId)
        {
            return await _ctx.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
        }

        public async Task<ServiceResponse<List<Category>>> GetAdminCategoriesAsync()
        {
            var categories = await _ctx.Categories.Where(c => !c.Deleted).ToListAsync();

            return new ServiceResponse<List<Category>>()
            {
                Data = categories
            };
        }

        public async Task<ServiceResponse<List<Category>>> GetCategoriesAsync()
        {
            var categories = await _ctx.Categories.Where(c => !c.Deleted && c.Visible).ToListAsync();

            return new ServiceResponse<List<Category>>()
            {
                Data = categories
            };
        }

        public async Task<ServiceResponse<List<Category>>> UpdateCategoryAsync(Category category)
        {

            var dbCategory = await GetCategoryById(category.Id);
            if (dbCategory == null)
            {
                return new ServiceResponse<List<Category>>
                {
                    Success = false,
                    Message = "Category not found."
                };
            }

            dbCategory.Name = category.Name;
            dbCategory.Url = category.Url;
            dbCategory.Visible  = category.Visible; 

            await _ctx.SaveChangesAsync();

            return await GetAdminCategoriesAsync();
        }
    }
}
