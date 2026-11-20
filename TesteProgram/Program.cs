using Microsoft.EntityFrameworkCore;
using TesteProgram.Data;
using TesteProgram.Models;
using TesteProgram.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;



// Add services to the container.
var builder = WebApplication.CreateBuilder(args);
//Antes de criar o controller temos de registar o nosso dbcontext aqui desta forma.
builder.Services.AddDbContext<RecipeDbContext>(options =>
{
    options.UseSqlite("Data Source=Recipe.db");
});
builder.Services.AddScoped<IRepository<Recipe>, RecipeRepository>();
builder.Services.AddScoped<IRepository<Ingredient>, IngredientRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
