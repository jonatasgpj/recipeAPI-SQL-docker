namespace recipeAPI.Dto.Recipe
{
    public class UpdateRecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }

        public List<CreateRecipeItemDto> Ingredients { get; set; }
    }
}
