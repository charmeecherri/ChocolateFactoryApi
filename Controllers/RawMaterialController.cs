﻿using ChocolateFactoryApi.Data;
using ChocolateFactoryApi.DTO.request;
using ChocolateFactoryApi.Models;
using ChocolateFactoryApi.repositories;
using ChocolateFactoryApi.repositories.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChocolateFactoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RawMaterialController : ControllerBase
    {
        private readonly IRawMaterialRepository _rawMaterialRepository;

        public RawMaterialController(IRawMaterialRepository rawMaterialRepository)
        {
            _rawMaterialRepository = rawMaterialRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getRawMaterials()
        {
            return Ok(await _rawMaterialRepository.getRawMaterialsAsync());

        }

        [HttpPost]
        public async Task<IActionResult> createRawMaterial(RawMaterialRequestDto rawMaterialRequestDto)
        {
            //Validation : Stoping the user to select the expiry products.
            if (rawMaterialRequestDto.ExpiryDate <= DateTime.Now.ToUniversalTime())
            {
                return BadRequest("The Expiry date cannot be in the past");
            }
            RawMaterial rawMaterial = new RawMaterial()
            {
                Name = rawMaterialRequestDto.Name,
                StockQuantity = rawMaterialRequestDto.StockQuantity,
                Unit = rawMaterialRequestDto.Unit,
                ExpiryDate = rawMaterialRequestDto.ExpiryDate,
                SupplierId = rawMaterialRequestDto.SupplierId,
                CostPerUnit = rawMaterialRequestDto.CostPerUnit,

            };
            await _rawMaterialRepository.createRawMaterialAsync(rawMaterial);
            return StatusCode(StatusCodes.Status201Created, "Material is created");
        }

       
    }
}
