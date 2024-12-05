using ChocolateFactoryApi.DTO.response;
using ChocolateFactoryApi.Models;

namespace ChocolateFactoryApi.repositories.interfaces
{
    public interface IRecipeRepository
    {
        Task<List<RecipeResponseDto>> getRecipesAsync();
        Task<Recipe> getRecipeById(int id);

        Task createRecipeAsync(Recipe recipe);

        Task createIngredientsAsync(List<Ingredients> ingredients);
    }
}
