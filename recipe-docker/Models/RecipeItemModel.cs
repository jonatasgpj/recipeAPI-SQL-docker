using System.Security.Cryptography.X509Certificates;

namespace recipeAPI.Models
{
    public class RecipeItemModel
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }
        public RecipeModel Recipe { get; set; }

        public int IngredientId { get; set; }
        public IngredientModel Ingredient { get; set; }

        public double Quantity { get; set; }



    }
}
