using Microsoft.EntityFrameworkCore;
using TesteProgram.Data;
using TesteProgram.Models;

namespace TesteProgram.Repositories
{
    public class RecipeRepository : IRepository<Recipe>
    {
        private readonly RecipeDbContext context;

        public RecipeRepository(RecipeDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Recipe> GetAll()
        {
            return context
                .Recipes               
                .Include(b => b.Portions)
                .ThenInclude(b => b.Ingredient)
                .ToList();
        }

        public Recipe? Get(int id)
        {
            return context
                .Recipes
                
                .Include(b => b.Portions)
                .ThenInclude(b => b.Ingredient)
                .FirstOrDefault(b => b.Id == id);
        }

        public Recipe Add(Recipe value)
        {
            context.Recipes.Add(value);
            context.SaveChanges();

            return value;
        }

        public void Update(Recipe value)
        {
            context.Entry(value).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var value = Get(id);

            if (value != null)
            {
                context.Recipes.Remove(value);
                context.SaveChanges();
            }
        }


    }


}
