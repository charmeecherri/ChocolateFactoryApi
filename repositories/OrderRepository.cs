using ChocolateFactoryApi.Data;
using ChocolateFactoryApi.DTO.response;
using ChocolateFactoryApi.Models;
using ChocolateFactoryApi.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChocolateFactoryApi.repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;

        public OrderRepository(AppDbContext appDbContext) 
        {
            context = appDbContext;
        }
        public async Task createOrderAsync(Order order)
        {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }

        public Task deleteOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderResponseDto>> GetOrdersAsync()
        {
            return await context.Orders.Select(o => new OrderResponseDto()
            {
                OrderId = o.OrderId,
                CustomerId = o.CustomerId,
                ProductId = o.ProductId,
                ProductName = o.Product.ProductName,
                Quantity = o.Quantity,
                OrderDate = o.OrderDate,
                DeliveryDate = o.DeliveryDate,
                status = o.status,
            }).ToListAsync();
        }

        public Task updateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
