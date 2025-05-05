namespace recipeAPI.Dto.Recipe
{
    public class RecipeResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }
        public List<RecipeIngredientDto> Ingredients { get; set; }
    }

    public class RecipeIngredientDto
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public string Unit { get; set; }
        public double Quantity { get; set; }
    }
}
