using recipeAPI.Dto.Ingredient;
using recipeAPI.Models;

namespace recipeAPI.Services.Ingredient
{
    public interface IIngrendientInterface
    {

        Task<ResponseModel<List<IngredientModel>>> GetIngredients();
        Task<ResponseModel<IngredientModel>> GetIngredientById(int idIngredient);
        Task<ResponseModel<List<IngredientModel>>> CreateIngredient(CreateIngredientDto createIngredientDto);
        Task<ResponseModel<List<IngredientModel>>> UpdateIngredient(UpdateIngredientDto updateIngredientDto);
        Task<ResponseModel<List<IngredientModel>>> DeleteIngredient(int idIngredient);
    }
}
