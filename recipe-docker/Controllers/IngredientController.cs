using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using recipeAPI.Dto.Ingredient;
using recipeAPI.Dto.Recipe;
using recipeAPI.Models;
using recipeAPI.Services.Ingredient;
using recipeAPI.Services.Recipe;

namespace recipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngrendientInterface _IngredientInterface;
        public IngredientController(IIngrendientInterface ingredientInterface)
        {
            _IngredientInterface = ingredientInterface;
        }

        [HttpGet("GetIngredients")]
        public async Task<ActionResult<ResponseModel<List<IngredientModel>>>> Getingredient()
        {
            var recipes = await _IngredientInterface.GetIngredients();
            return Ok(recipes);

        }

        [HttpGet("GetIngredientById/{ingredientId}")]
        public async Task<ActionResult<ResponseModel<IngredientModel>>> GetIngredientsById(int ingredientId)
        {
            var recipe = await _IngredientInterface.GetIngredientById(ingredientId);
            return Ok(recipe);

        }


        [HttpPost("CreateIngredient")]
        public async Task<ActionResult<ResponseModel<IngredientModel>>> CreateIngredient(CreateIngredientDto createIngredientDto)
        {
            var recipes = await _IngredientInterface.CreateIngredient(createIngredientDto);
            return Ok(recipes);

        }

        [HttpPut("UpdateRecipe")]
        public async Task<ActionResult<ResponseModel<List<IngredientModel>>>> UpdateRecipe(UpdateIngredientDto updateIngredientDto)
        {
            var recipes = await _IngredientInterface.UpdateIngredient(updateIngredientDto);
            return Ok(recipes);

        }

        [HttpDelete("DeleteIngredient")]
        public async Task<ActionResult<ResponseModel<List<IngredientModel>>>> DeleteIngredient(int ingredientId)
        {
            var recipes = await _IngredientInterface.DeleteIngredient(ingredientId);
            return Ok(recipes);

        }

    }
}
