namespace recipeAPI.Dto.Recipe
{
    public class CreateRecipeDto
    {
        public string Name { get; set; }
        public string Instructions { get; set; }

        public List<CreateRecipeItemDto> Ingredients { get; set; }
    }
}
