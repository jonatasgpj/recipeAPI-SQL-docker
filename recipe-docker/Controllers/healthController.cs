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
    public class healthController : ControllerBase
    {

        public healthController()
        {
        }

        [HttpGet("")]
        public async Task<ActionResult<ResponseModel<List<IngredientModel>>>> Gethealth()
        {
            var response = "Response - OK";
            return Ok(response);

        }

    }
}
