﻿using ChocolateFactoryApi.DTO.request;
using ChocolateFactoryApi.Models;
using ChocolateFactoryApi.repositories.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChocolateFactoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

        }

        [HttpGet]
        public async Task<IActionResult> getOrders()
        {
            return Ok(await _orderRepository.GetOrdersAsync());
        }

        [HttpPost]
        public async Task<IActionResult> createOrder(OrderRequestDto orderRequestDto)
        {
            Order order = new Order()
            {
                CustomerId = orderRequestDto.CustomerId,
                ProductId= orderRequestDto.ProductId,
                Quantity = orderRequestDto.Quantity,
                OrderDate = orderRequestDto.OrderDate,
                DeliveryDate = orderRequestDto.DeliveryDate,
                status = orderRequestDto.status,
            };

            await _orderRepository.createOrderAsync(order);
            return StatusCode(StatusCodes.Status201Created, "Order created");
        }
    }
}