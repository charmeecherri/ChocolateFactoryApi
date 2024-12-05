using ChocolateFactoryApi.Data;
using ChocolateFactoryApi.Models;
using ChocolateFactoryApi.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChocolateFactoryApi.repositories
{
    public class QualityRepository : IQualityRepository
    {
        private readonly AppDbContext context;

        public QualityRepository(AppDbContext appDbContext)
        {
            context = appDbContext;
        }
        public async Task createQualityAsync(Quality quality)
        {
            await context.Quality.AddAsync(quality);
            await context.SaveChangesAsync();
        }

        public Task deleteQualityAsync(Quality quality)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Quality>> GetQualitiesAsync()
        {
            return await context.Quality.ToListAsync();
        }

        public async Task<Quality> getQualityByIdAsync(int qualityId)
        {
            return await context.Quality.Where(q => q.CheckId == qualityId).FirstAsync();
        }

        public Task updateQualityAsync(Quality quality)
        {
            throw new NotImplementedException();
        }
    }
}
