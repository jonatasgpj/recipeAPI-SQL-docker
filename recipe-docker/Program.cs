using Microsoft.EntityFrameworkCore;
using recipeAPI.Controllers;
using recipeAPI.Data;
using recipeAPI.Services.Ingredient;
using recipeAPI.Services.Recipe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRecipeInterface, RecipeService>();
builder.Services.AddScoped<IIngrendientInterface, IngredientService>();

builder.Services.AddDbContext<AppDbContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();
app.UseDefaultFiles(); // Ativa index.html automaticamente
app.UseStaticFiles();  // Serve arquivos da pasta wwwroot

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//using (var scope = app.Services.CreateScope())
{
//    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    Console.WriteLine("Aplicando migrations...");
//    db.Database.Migrate();
    Console.WriteLine("✅ Migrations aplicadas com sucesso.");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
