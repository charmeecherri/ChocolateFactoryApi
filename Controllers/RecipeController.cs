using ChocolateFactoryApi.Data;
using ChocolateFactoryApi.DTO.request;
using ChocolateFactoryApi.Models;
using ChocolateFactoryApi.repositories.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChocolateFactoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRawMaterialRepository _rawMaterialRepository;

        public RecipeController(IRecipeRepository recipeRepository,IRawMaterialRepository rawMaterialRepository)
        {
            _recipeRepository = recipeRepository;
            _rawMaterialRepository = rawMaterialRepository;
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<IActionResult> GetRecipes()
        {
            return Ok(await _recipeRepository.getRecipesAsync());
        }

        // POST: api/Recipes
        [HttpPost]
        public async Task<ActionResult<Recipe>> AddRecipe(RecipeDto recipeDto)
        {
            Recipe recipe = new Recipe()
            {
                ProductId = recipeDto.ProductId,
                QuantityPerBatch = recipeDto.QuantityPerBatch,
                Instructions = recipeDto.Instructions,
            };
            await _recipeRepository.createRecipeAsync(recipe);

            List<Ingredients> ingredients = new List<Ingredients>();
            for (int i = 0; i < recipeDto.Ingredients.Count; i++)
            {
                RawMaterial material = await _rawMaterialRepository.getRawMaterialByNameAsync(recipeDto.Ingredients[i]);
                Ingredients ingredientsObj = new Ingredients()
                {
                    RecipeId = recipe.RecipeId,
                    MaterialId = material.MaterialId
                };
                ingredients.Add(ingredientsObj);
            }

            await _recipeRepository.createIngredientsAsync(ingredients);
            return StatusCode(StatusCodes.Status201Created, "Recipe created successfully");
        }
    }
}

