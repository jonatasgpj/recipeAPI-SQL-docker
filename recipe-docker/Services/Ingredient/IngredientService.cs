using Microsoft.EntityFrameworkCore;
using recipeAPI.Data;
using recipeAPI.Dto.Ingredient;
using recipeAPI.Dto.Recipe;
using recipeAPI.Models;

namespace recipeAPI.Services.Ingredient
{
    public class IngredientService : IIngrendientInterface
    {
        private readonly AppDbContext _context;

        public IngredientService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<IngredientModel>>> CreateIngredient(CreateIngredientDto createIngredientDto)
        {
            ResponseModel<List<IngredientModel>> response = new ResponseModel<List<IngredientModel>>();
            try
            {
                var ingredient = new IngredientModel()
                {
                    Name = createIngredientDto.Name,
                    Unit = createIngredientDto.Unit,

                };


                _context.Ingredients.Add(ingredient);
                await _context.SaveChangesAsync();

                response.Data = await _context.Ingredients.ToListAsync();
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

        public async Task<ResponseModel<List<IngredientModel>>> DeleteIngredient(int idIngredient)
        {
            ResponseModel<List<IngredientModel>> response = new ResponseModel<List<IngredientModel>>();
            try
            {
                var ingredient = await _context.Ingredients.FirstOrDefaultAsync(ingredientDb => ingredientDb.Id == idIngredient);
                if (ingredient == null)
                {
                    response.Message = "ingredient not found";
                    response.Status = true;
                    return response;
                }
                _context.Remove(ingredient);
                await _context.SaveChangesAsync();

                response.Data = await _context.Ingredients.ToListAsync();
                response.Message = "ingredient removed";
                return response;


            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<IngredientModel>> GetIngredientById(int idIngredient)
        {
            ResponseModel<IngredientModel> response = new ResponseModel<IngredientModel>();
            try
            {
                var ingredient = await _context.Ingredients
                    .FirstOrDefaultAsync(ingredientDb => ingredientDb.Id == idIngredient);
                if (ingredient == null)
                {
                    response.Message = "no ingredient found";
                    return response;
                }
                response.Data = ingredient;
                response.Message = "ingredient found";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<IngredientModel>>> GetIngredients()
        {
            ResponseModel<List<IngredientModel>> response = new ResponseModel<List<IngredientModel>>();
            try
            {
                var ingredients = await _context.Ingredients.ToListAsync();

                response.Data = ingredients;

                
                response.Message = "all ingredients have been listed";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<IngredientModel>>> UpdateIngredient(UpdateIngredientDto updateIngredientDto)
        {
            ResponseModel<List<IngredientModel>> response = new ResponseModel<List<IngredientModel>>();
            try
            {
                var ingredient = await _context.Ingredients.FirstOrDefaultAsync(ingredientDb => ingredientDb.Id == updateIngredientDto.Id);
                if (ingredient == null)
                {
                    response.Message = "recipe not found";
                    return response;
                }
                ingredient.Name = updateIngredientDto.Name;
                ingredient.Unit = updateIngredientDto.Unit;

                _context.Update(ingredient);
                await _context.SaveChangesAsync();
                response.Data = await _context.Ingredients.ToListAsync();
                response.Message = "ingredient updated";

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
