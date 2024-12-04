using ChocolateFactoryApi.Data;
using ChocolateFactoryApi.DTO.request;
using ChocolateFactoryApi.Models;
using ChocolateFactoryApi.repositories.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChocolateFactoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionScheduleController : ControllerBase
    {
        private readonly IProductionScheduleRepository _productionScheduleRepository;

        public ProductionScheduleController(IProductionScheduleRepository productionScheduleRepository)
        {
            _productionScheduleRepository = productionScheduleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getRawMaterials()
        {
            return Ok(await _productionScheduleRepository.getProductSchedulesAsync());

        }

        [HttpPost]
        public async Task<IActionResult> createRawMaterial(ProductionScheduleRequestDto productionScheduleRequestDto)
        {
            ProductionSchedule productionSchedule = new ProductionSchedule()
            {
               ProductId = productionScheduleRequestDto.ProductId,
               StartDate = productionScheduleRequestDto.StartDate,
               EndDate = productionScheduleRequestDto.EndDate,
               Shift = productionScheduleRequestDto.Shift,
               SupervisorId = productionScheduleRequestDto.SupervisorId,
               Status = productionScheduleRequestDto.Status,


            };
            await _productionScheduleRepository.createProductionScheduleAsync(productionSchedule);
            return StatusCode(StatusCodes.Status201Created, "Production is created");
        }
    }
}
