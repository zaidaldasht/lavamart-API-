using lavamart.Data;
using lavamart.Data.models;
using lavamart.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace lavamart.Controllers
{
    [Route("lavamart/[controller]")]
    [ApiController]
    [Authorize]

    public class CartController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CartController(AppDbContext dbContext)
        {
            _db = dbContext;
            
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> addToCart([FromBody] dtocartitem dto)
        {
            var product = await _db.Products.FindAsync(dto.ProductId);
            if (product == null)
                return NotFound("Product not found");

            var cartItem = new CartItems
            {
                CartId = dto.CartId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };

            _db.CartItems.Add(cartItem);
            await _db.SaveChangesAsync();

            // Return the created cart item as dto
            var response = new dtocartitem
            {
                CartItemId = cartItem.CartItemId,
                CartId = cartItem.CartId,
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity
            };

            return Ok(new { data = response });

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> syncCart([FromBody] dtocartsync dto)
        {
            var productIds = dto.Data.Select(x => x.ProductId).ToList();

            var existingProducts = await _db.Products
                .Where(p => productIds.Contains(p.ProductId))
                .Select(p => p.ProductId)
                .ToListAsync();

            var validCartItems = dto.Data
                .Where(c => existingProducts.Contains(c.ProductId))
                .ToList();


            return Ok(new { data = validCartItems });

        }



    }
}
