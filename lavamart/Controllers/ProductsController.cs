using lavamart.Data;
using lavamart.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace lavamart.Controllers
{
    [Route("lavamart/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ProductsController(AppDbContext dbContext)
        {
            _db = dbContext;
            
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> getProducts([FromQuery] dtoproductsfilter filter)
        {
            var query = _db.Products.AsQueryable();

            // Keyword filter
            if (!string.IsNullOrWhiteSpace(filter.Keyword))
                query = query.Where(p => p.ProductName.Contains(filter.Keyword));

            // Category filter
            if (filter.Categories != null && filter.Categories.Any()) 
            {
                var categoryList = filter.Categories
                    .Split(',', StringSplitOptions.RemoveEmptyEntries) 
                    .Select(int.Parse)                               
                    .ToList();

                query = query.Where(p => categoryList.Contains(p.CategoryId));

            }

            // Total count (before pagination)
            var totalCount = await query.CountAsync();

            // Pagination
            var products = await query
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync(); 

            var response = new dtoproductresponse
            {
                TotalCount = totalCount,
                Page = filter.Page,
                PageSize = filter.PageSize,
                Products = products
            };

            return Ok(response);

        }





    }
}
