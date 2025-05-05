using Azure;
using Microsoft.EntityFrameworkCore;
using recipeAPI.Data;
using recipeAPI.Dto.Recipe;
using recipeAPI.Models;

namespace recipeAPI.Services.Recipe
{
    public class RecipeService : IRecipeInterface
    {
        private readonly AppDbContext _context;
        public RecipeService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<ResponseModel<List<RecipeModel>>> CreateRecipe(CreateRecipeDto createRecipeDto)
        {
            ResponseModel<List<RecipeModel>> response = new ResponseModel<List<RecipeModel>>();
            try
            {
                var recipe = new RecipeModel()
                {
                    Name = createRecipeDto.Name,
                    Instructions = createRecipeDto.Instructions,
                    Ingredients = new List<RecipeItemModel>()
                };

                foreach (var item in createRecipeDto.Ingredients) 
                {
                    var recipeItem = new RecipeItemModel
                    {
                        IngredientId = item.IngredientId,
                        Quantity = item.Quantity,
                        Recipe = recipe,
                    };
                    recipe.Ingredients.Add(recipeItem);
                }



                _context.Recipes.Add(recipe);
                await _context.SaveChangesAsync();

                response.Data = await _context.Recipes.ToListAsync();
                response.Message = "OK";
                return response;


            }
            catch (Exception ex)
            {
                response.Message = ex.InnerException?.Message ?? ex.Message;
                response.Status = false;
                return response;

            }
        }

        public async Task<ResponseModel<List<RecipeModel>>> DeleteRecipe(int idRecipe)
        {
            ResponseModel<List<RecipeModel>> response = new ResponseModel<List<RecipeModel>>();
            try
            {
                var recipe = await _context.Recipes.FirstOrDefaultAsync(recipeDb => recipeDb.Id == idRecipe);
                if (recipe == null)
                {
                    response.Message = "recipe not found";
                    response.Status = true;
                    return response;
                }
                _context.Remove(recipe);
                await _context.SaveChangesAsync();

                response.Data = await _context.Recipes.ToListAsync();
                response.Message = "recipe removed";
                return response;


            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }

        }

        public async Task<ResponseModel<RecipeResponseDto>> GetRecipeById(int idRecipe)
        {
            ResponseModel<RecipeResponseDto> response = new ResponseModel<RecipeResponseDto>();
            try
            {
                var recipe = await _context.Recipes
                    .Include(r=> r.Ingredients)
                    .ThenInclude(i => i.Ingredient)
                    .FirstOrDefaultAsync(recipeDb => recipeDb.Id == idRecipe);
                if (recipe == null) 
                {
                    response.Message = "no recipe found";
                    return response; 
                }
                var recipeDto = new RecipeResponseDto
                {
                    Id = recipe.Id,
                    Name = recipe.Name,
                    Instructions = recipe.Instructions,
                    Ingredients = recipe.Ingredients.Select(i => new RecipeIngredientDto
                    {
                        IngredientId = i.IngredientId,
                        IngredientName = i.Ingredient.Name,
                        Unit = i.Ingredient.Unit,
                        Quantity = i.Quantity

                    }).ToList()
                };



                response.Data = recipeDto;
                response.Message = "recipe found";
                return response;



            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
            
        }

        public async Task<ResponseModel<RecipeModel>> GetRecipeByIngredient(int idIngredient)
        {
            ResponseModel<RecipeModel> response = new ResponseModel<RecipeModel>();
            try
            {
                var recipeItem = await _context.RecipeItems
                    .Include(i => i.Recipe)
                    .FirstOrDefaultAsync(ingredientDb => ingredientDb.IngredientId == idIngredient);

                if (recipeItem == null)
                {
                    response.Message = "404";
                    return response;
                }
                response.Data = recipeItem.Recipe;
                response.Message = "200";
                return response;


            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<RecipeModel>>> GetRecipes()
        {
            ResponseModel<List<RecipeModel>> response = new ResponseModel<List<RecipeModel>>();
            try
            {
                var recipes = await _context.Recipes.ToListAsync();

                response.Data = recipes;

                
                response.Message = "all recipes have been listed";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<RecipeModel>>> UpdateRecipe(UpdateRecipeDto updateRecipeDto)
        {
            ResponseModel<List<RecipeModel>> response = new ResponseModel<List<RecipeModel>>();
            try
            {
                var recipe = await _context.Recipes
                    .Include(i => i.Ingredients)
                    .FirstOrDefaultAsync(recipeDb => recipeDb.Id == updateRecipeDto.Id);
                if (recipe == null)
                {
                    response.Message = "recipe not found";
                    return response;
                }
                recipe.Name = updateRecipeDto.Name;
                recipe.Instructions = updateRecipeDto.Instructions;

                _context.RecipeItems.RemoveRange(recipe.Ingredients);

                recipe.Ingredients = updateRecipeDto.Ingredients.Select(i => new RecipeItemModel
                {
                    RecipeId = recipe.Id,
                    IngredientId = i.IngredientId,
                    Quantity = i.Quantity
                }).ToList();

                _context.Update(recipe);
                await _context.SaveChangesAsync();
                response.Data = await _context.Recipes.ToListAsync();
                response.Message = "recipe updated";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

    }
}
