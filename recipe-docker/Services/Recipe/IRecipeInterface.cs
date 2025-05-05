using recipeAPI.Dto.Recipe;
using recipeAPI.Models;

namespace recipeAPI.Services.Recipe
{
    public interface IRecipeInterface
    {
        Task<ResponseModel<List<RecipeModel>>> GetRecipes();
        Task<ResponseModel<RecipeResponseDto>> GetRecipeById(int idRecipe);
        Task<ResponseModel<RecipeModel>> GetRecipeByIngredient(int idIngredient);
        Task<ResponseModel<List<RecipeModel>>>CreateRecipe(CreateRecipeDto createRecipeDto);
        Task<ResponseModel<List<RecipeModel>>> UpdateRecipe(UpdateRecipeDto updateRecipeDto);
        Task<ResponseModel<List<RecipeModel>>> DeleteRecipe(int idRecipe);

    }
}
