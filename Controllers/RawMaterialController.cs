using ChocolateFactoryApi.Data;
using ChocolateFactoryApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChocolateFactoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RawMaterialController : ControllerBase
    {
        private readonly AppDbContext context;
        public RawMaterialController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RawMaterial>>> GetRawMaterials()
        {
            return await context.RawMaterials.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<RawMaterial>> CreateMaterial (RawMaterial material)
        {
            context.RawMaterials.Add(material);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRawMaterials),new { id = material.MaterialId },material);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaterial(int id,RawMaterial material)
        {
            if (id !=material.MaterialId) return BadRequest();
            context.Entry(material).State= EntityState.Modified;
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            var material=await context.RawMaterials.FindAsync(id);
            if (material == null) return NotFound();
            context .RawMaterials.Remove(material);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
