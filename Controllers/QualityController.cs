using ChocolateFactoryApi.DTO.request;
using ChocolateFactoryApi.Models;
using ChocolateFactoryApi.repositories.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChocolateFactoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualityController : ControllerBase
    {
        private readonly IQualityRepository _qualityRepository;

        public QualityController(IQualityRepository qualityRepository) {
            _qualityRepository = qualityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getQualityI()
        {
            return Ok(await _qualityRepository.GetQualitiesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> createQuality(QualityRequestDto qualityRequestDto)
        {
            Quality quality = new Quality()
            {
                BatchId = qualityRequestDto.BatchId,
                Inspectorid = qualityRequestDto.InspectorId,
                InspectionDate = qualityRequestDto.InspectionDate,
                TestResults = qualityRequestDto.TestResults,
                status = qualityRequestDto.status,
            };

            await _qualityRepository.createQualityAsync(quality);
            return StatusCode(StatusCodes.Status201Created, "Quality checking is created");

        }

        [HttpPut]
        public async Task<IActionResult> updateQualityStatus(int id, string status)
        {
            Quality quality = await _qualityRepository.getQualityByIdAsync(id);
            if (quality == null)
                return BadRequest("Cannot the quality with the id specified");

            quality.status = status;
            await _qualityRepository.updateQualityAsync(quality);
            return Ok("Updated the quality status");
        }
    }
}
