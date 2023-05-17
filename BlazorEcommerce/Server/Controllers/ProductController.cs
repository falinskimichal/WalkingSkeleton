using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _ctx;

        public ProductController(DataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var products = await _ctx.Products.ToListAsync();
            return Ok(products);
        }
    }  
}
