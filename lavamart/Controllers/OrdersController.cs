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
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _db;

        public OrdersController(AppDbContext dbContext)
        {
            _db = dbContext;
                    
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> addOrder([FromBody] dtoaddorder dto) 
        {
            var order = new Orders
            {
                OrderId = dto.OrderId,
                Id = dto.Id,
                OrderDate = dto.OrderDate,
                Status = dto.Status,
                TotalAmount = dto.TotalAmount,
                ShippingAddress = dto.ShippingAddress,

            };

            _db.Orders.Add(order);
            await _db.SaveChangesAsync();

            var response = new dtoaddorder
            {
                OrderId = order.OrderId,
                Id = order.Id,
                OrderDate = order.OrderDate,
                Status = order.Status,
                TotalAmount = order.TotalAmount,
                ShippingAddress = order.ShippingAddress
            };

            return Ok(response);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> getOrders()
        {
            var orders = await _db.Orders
            .Select(o => new dtogetorder
            {
                OrderId = o.OrderId,
                Id = o.Id,
                OrderDate = o.OrderDate,
                Status = o.Status,
                TotalAmount = o.TotalAmount,
                ShippingAddress = o.ShippingAddress
            })
            .ToListAsync();

            return Ok(orders);

        }




    }
}
