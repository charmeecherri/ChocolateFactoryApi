using Azure.Identity;
using ChocolateFactoryApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ChocolateFactoryApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<RawMaterial> RawMaterials { get; set; }
        public DbSet<ProductionSchedule> ProductionSchedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductionSchedule>().HasKey(ps => ps.ScheduleId);
            modelBuilder.Entity<RawMaterial>()
            .Property(rm => rm.CostPerUnit)
            .HasPrecision(18, 2);

        }


    }
}
