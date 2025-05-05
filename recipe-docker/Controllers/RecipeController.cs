using Microsoft.AspNetCore.Mvc;
using recipeAPI.Dto.Recipe;
using recipeAPI.Models;
using recipeAPI.Services.Recipe;

namespace recipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeInterface _recipeInterface;
        public RecipeController(IRecipeInterface recipeInterface)
        {
            _recipeInterface = recipeInterface;
        }

        [HttpGet("GetRecipes")]
        public async Task<ActionResult<ResponseModel<List<RecipeModel>>>> GetRecipes()
        {
            var recipes = await _recipeInterface.GetRecipes();
            return Ok(recipes);

        }

        [HttpGet("GetRecipesById/{recipeId}")]
        public async Task<ActionResult<ResponseModel<RecipeModel>>> GetRecipesById(int recipeId)
        {
            var recipe = await _recipeInterface.GetRecipeById(recipeId);
            return Ok(recipe);

        }

        [HttpGet("GetRecipeByIngredient/{idIngredient}")]
        public async Task<ActionResult<ResponseModel<RecipeModel>>> GetRecipeByIngredient(int idIngredient)
        {
            var recipe = await _recipeInterface.GetRecipeByIngredient(idIngredient);
            return Ok(recipe);

        }

        [HttpPost("CreateRecipe")]
        public async Task<ActionResult<ResponseModel<RecipeModel>>> CreateRecipe(CreateRecipeDto createRecipeDto)
        {
            var recipes = await _recipeInterface.CreateRecipe(createRecipeDto);
            return Ok(recipes);

        }

        [HttpPut("UpdateRecipe")]
        public async Task<ActionResult<ResponseModel<List<RecipeModel>>>> UpdateRecipe(UpdateRecipeDto updateRecipeDto)
        {
            var recipes = await _recipeInterface.UpdateRecipe(updateRecipeDto);
            return Ok(recipes);

        }

        [HttpDelete("DeleteRecipe")]
        public async Task<ActionResult<ResponseModel<List<RecipeModel>>>> DeleteRecipe(int idRecipe)
        {
            var recipes = await _recipeInterface.DeleteRecipe(idRecipe);
            return Ok(recipes);

        }



    }
}
