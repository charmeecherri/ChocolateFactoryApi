using ChocolateFactoryApi.Data;
using ChocolateFactoryApi.DTO.response;
using ChocolateFactoryApi.Models;
using ChocolateFactoryApi.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChocolateFactoryApi.repositories
{
    public class RecipeRepository : IRecipeRepository
    {

        private readonly AppDbContext context;

        public RecipeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task createIngredientsAsync(List<Ingredients> ingredients)
        {
            await context.Ingredients.AddRangeAsync(ingredients);
            await context.SaveChangesAsync();
        }

        public async Task createRecipeAsync(Recipe recipe)
        {
            await context.Recipes.AddAsync(recipe);
            await context.SaveChangesAsync();
        }

        public async Task<Recipe> getRecipeById(int id)
        {
            return await context.Recipes.Where( r => r.RecipeId == id).FirstAsync();
        }

        public async Task<List<RecipeResponseDto>> getRecipesAsync()
        {
            return await context.Recipes.Select(r => new RecipeResponseDto()
            {
                RecipeId = r.RecipeId,
                ProductId = r.ProductId,
                ProductName = r.product.ProductName,
                Ingredients = r.Ingredients.Select(i => new RawMaterial()
                {
                    MaterialId = i.RawMaterial.MaterialId,
                    Name = i.RawMaterial.Name,
                    StockQuantity = i.RawMaterial.StockQuantity,
                    ExpiryDate = i.RawMaterial.ExpiryDate,
                    SuppilerId = i.RawMaterial.SuppilerId,
                    CostPerUnit = i.RawMaterial.CostPerUnit

                }).ToList(),
                QuantityPerBatch = r.QuantityPerBatch,
                Instructions = r.Instructions,
            }
           ).ToListAsync();
        }
    }
}
