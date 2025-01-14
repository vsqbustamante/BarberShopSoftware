using BarberShopSoftware.Server.Data;
using BarberShopSoftware.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberShopSoftware.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly DataContext _context;

        public SalesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sales>>> GetSales()
        {
            return await _context.Sales.Include(s => s.Product).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Sales>> AddSale(Sales sale)
        {
            var product = await _context.Products.FindAsync(sale.ProductId);
            if (product == null || product.Stock < sale.Quantity)
            {
                return BadRequest("Invalid product or insufficient stock.");
            }

            product.Stock -= sale.Quantity;
            sale.Total = product.Price * sale.Quantity;

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSales), new { id = sale.Id }, sale);
        }
    }
}
