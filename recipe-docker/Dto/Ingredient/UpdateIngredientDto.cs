using recipeAPI.Dto.Recipe;

namespace recipeAPI.Dto.Ingredient
{
    public class UpdateIngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }

    }
}
