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
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CategoriesController(AppDbContext dbContext)
        {
            _db = dbContext;
            
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> getCategories()
        {
            var categories = await _db.Categories
                .Select(c => new dtocategory
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Description = c.Description

                })
                .ToListAsync();

            var result = new { data = categories };

            return Ok(result);

        }


    }
}
