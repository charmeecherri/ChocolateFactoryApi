using Azure.Identity;
using ChocolateFactoryApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ChocolateFactoryApi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<RawMaterial> RawMaterials { get; set; }
        public DbSet<ProductionSchedule> ProductionSchedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    UserName = "Manager",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Manager123"),
                    Role = "FactorManager",
                    Email = "Manager@factory.com",
                    IsActive = true
                },
                new User
                {
                    UserId = 2,
                    UserName = "quality",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Quality123"),
                    Role = "QualityController",
                    Email = "Quality@factory.com",
                    IsActive = true


                },
                 new User
                 {
                     UserId = 3,
                     UserName = "supervisor",
                     PasswordHash = BCrypt.Net.BCrypt.HashPassword("supervisor123"),
                     Role = "ProductionSupervisor",
                     Email = "supervisor@factory.com",
                     IsActive = true

                 },
                 new User
                 {
                     UserId = 4,
                     UserName = "warehouse",
                     PasswordHash = BCrypt.Net.BCrypt.HashPassword("warehouse123"),
                     Role = "warehouseStaff",
                     Email = "warehouse@factory.com",
                     IsActive = true

                 },
                 new User
                 {
                     UserId = 5,
                     UserName = "sales",
                     PasswordHash = BCrypt.Net.BCrypt.HashPassword("sales123"),
                     Role = "SalesRepresentative",
                     Email = "sales@factory.com",
                     IsActive = true
                 }

                );
       
            modelBuilder.Entity<ProductionSchedule>().HasKey(ps => ps.ScheduleId);
            modelBuilder.Entity<RawMaterial>()
        .Property(rm => rm.CostPerUnit)
        .HasPrecision(18, 2);
            base.OnModelCreating(modelBuilder);
        }


    }
}
