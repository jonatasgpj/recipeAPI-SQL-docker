using Microsoft.EntityFrameworkCore;
using recipeAPI.Models;

namespace recipeAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<RecipeModel> Recipes { get; set; }
        public DbSet<RecipeItemModel> RecipeItems { get; set; }
        public DbSet<IngredientModel> Ingredients { get; set; }

    }
}
