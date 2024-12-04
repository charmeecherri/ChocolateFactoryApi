using ChocolateFactoryApi.Data;
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

        public async Task<List<Recipe>> getRecipesAsync()
        {
            return await context.Recipes.ToListAsync();
        }
    }
}
