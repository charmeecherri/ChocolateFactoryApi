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

        public PackagingController(IPackagingRepository packagingRepository)
        {
            _packagingRepository = packagingRepository;

        }

        [HttpGet]
        public async Task<IActionResult> getPackaging()
        {
            return Ok(await _packagingRepository.getPackagesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> createPackagingAsync(PackagingRequestDto packagingRequestDto)
        {
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
