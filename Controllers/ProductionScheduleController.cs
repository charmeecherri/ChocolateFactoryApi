using ChocolateFactoryApi.Data;
using ChocolateFactoryApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChocolateFactoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionScheduleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductionScheduleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductionSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductionSchedule>>> GetProductionSchedules()
        {
            return await _context.ProductionSchedules.ToListAsync();
        }

        // POST: api/ProductionSchedules
        [HttpPost]
        public async Task<ActionResult<ProductionSchedule>> CreateProductionSchedule(ProductionSchedule schedule)
        {
            _context.ProductionSchedules.Add(schedule);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProductionSchedules), new { id = schedule.ScheduleId }, schedule);
        }
    }
}
