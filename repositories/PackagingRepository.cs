using ChocolateFactoryApi.Data;
using ChocolateFactoryApi.DTO.response;
using ChocolateFactoryApi.Models;
using ChocolateFactoryApi.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChocolateFactoryApi.repositories
{
    public class PackagingRepository : IPackagingRepository
    {
        private readonly AppDbContext context;

        public PackagingRepository(AppDbContext appDbContext)
        {
            context = appDbContext;
        }
        public async Task createPackageAsync(Packaging packaging)
        {
            await context.Packagings.AddAsync(packaging);
            await context.SaveChangesAsync();
        }

        public Task deletePackageAsync(Packaging packaging)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PackagingResponseDto>> getPackagesAsync()
        {
            return await context.Packagings.Select(p => new PackagingResponseDto()
            {
                PackagingId = p.PackagingId,
                ProductId = p.ProductId,
                ProductName = p.Product.ProductName,
                BatchId = p.BatchId,
                Quantity = p.Quantity,
                ExpiryDate = p.ExpiryDate,
                PackagingDate = p.PackagingDate,
                WarehouseLocation = p.WarehouseLocation
            }).ToListAsync();
        }

        public Task updatePackagingAsync(Packaging packaging)
        {
            throw new NotImplementedException();
        }
    }
}
