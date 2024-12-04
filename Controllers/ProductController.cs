﻿using ChocolateFactoryApi.Models;
using ChocolateFactoryApi.repositories.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChocolateFactoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getProducts()
        {
            return Ok(await _productRepository.getProductsAsync());

        }

        [HttpPost]
        public async Task<IActionResult> createProduct(string name)
        {
            Product product = new Product()
            {
                ProductName = name
            };
            await _productRepository.createProductAsync(product);
            return StatusCode(StatusCodes.Status201Created,"Product is created");
        }
    }
}