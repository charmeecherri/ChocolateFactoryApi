using ChocolateFactoryApi.DTO.request;
using ChocolateFactoryApi.Models;
using ChocolateFactoryApi.repositories;
using ChocolateFactoryApi.repositories.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChocolateFactoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagingController : ControllerBase
    {
        private readonly IPackagingRepository _packagingRepository;
        private readonly IQualityRepository _qualityRepository;

        public PackagingController(IPackagingRepository packagingRepository,IQualityRepository qualityRepository)
        {
            _packagingRepository = packagingRepository;
            _qualityRepository = qualityRepository;

        }

        [HttpGet]
        public async Task<IActionResult> getPackaging()
        {
            return Ok(await _packagingRepository.getPackagesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> createPackagingAsync(PackagingRequestDto packagingRequestDto)
        {

            if (packagingRequestDto.ExpiryDate <= DateTime.Now.ToUniversalTime() )
            {
                return BadRequest("The Expiry date cannot be in the past");
            }

            if (packagingRequestDto.PackagingDate <= DateTime.Now.ToUniversalTime())
            {
                return BadRequest("The packaging date cannot be in the past");
            }

            Quality quality = await _qualityRepository.getQualityByBatchId(packagingRequestDto.BatchId);

            if(quality.TestResults == "failed")
            {
                return BadRequest("Cannot move to packaging section because product failed in Quality testing");
            }

            Packaging packaging = new Packaging()
            {
                ProductId = packagingRequestDto.ProductId,
                BatchId = packagingRequestDto.BatchId,
                Quantity = packagingRequestDto.Quantity,
                ExpiryDate = packagingRequestDto.ExpiryDate,
                PackagingDate = packagingRequestDto.PackagingDate,
                WarehouseLocation = packagingRequestDto.WarehouseLocation,
            };

            await _packagingRepository.createPackageAsync(packaging);
            return StatusCode(StatusCodes.Status201Created, "Created the packing");
        }
    }
}
