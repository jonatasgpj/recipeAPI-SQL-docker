namespace recipeAPI.Dto.Recipe
{
    public class RecipeItemResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }
        public List<RecipeIngredientDto> Ingredients { get; set; }
    }
}
