﻿using Azure.Identity;
using ChocolateFactoryApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection.Emit;

namespace ChocolateFactoryApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<RawMaterial> RawMaterials { get; set; }
        public DbSet<ProductionSchedule> ProductionSchedules { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Ingredients> Ingredients { get; set; }

        public DbSet<Quality> Quality { get; set; }

        public DbSet<Packaging> Packagings { get; set; }

        public DbSet<Order> Orders { get; set; }


  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductionSchedule>()
                .HasOne(p => p.Product)
                .WithMany(ps => ps.ProductionSchedules)
                .HasForeignKey(ps => ps.ProductId);

            modelBuilder.Entity<Ingredients>()
               .HasOne(i => i.Recipe)
               .WithMany(r => r.Ingredients)
               .HasForeignKey(fi => fi.RecipeId);

            modelBuilder.Entity<Ingredients>()
                .HasOne(i => i.RawMaterial)
                .WithMany(m => m.Ingredients)
                .HasForeignKey(fi => fi.MaterialId);

            modelBuilder.Entity<RawMaterial>()
            .Property(rm => rm.CostPerUnit)
            .HasPrecision(18, 2);

            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.product)
                .WithMany(p => p.recipes)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Packaging>()
                .HasOne(p => p.Product)
                .WithMany(p => p.packagings)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Product)
                .WithMany(p => p.orderings)
                .HasForeignKey(o => o.ProductId);

        }



    }
}
