using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TesteProgram.Models;

namespace TesteProgram.Data
{
    public class RecipeDbContext : DbContext
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options)
      : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; } = default!;
        public DbSet<Ingredient> Ingredients { get; set; } = default!;
        public DbSet<Portion> Portions { get; set; } = default!;
        //public DbSet<Category> Categories { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Portion>()
                .HasKey(x => new { x.IngredientId, x.RecipeId });
        }

    }
}
