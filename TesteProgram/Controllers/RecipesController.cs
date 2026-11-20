using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteProgram.Data;
using TesteProgram.Models;
using TesteProgram.Repositories;

namespace TesteProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRepository<Recipe> RecipeRepository;
        private readonly IRepository<Ingredient> IngredientRepository;
        public RecipesController(IRepository<Recipe> RecipeRepository, IRepository<Ingredient> IngredientRepository)
        {
            this.RecipeRepository = RecipeRepository;
            this.IngredientRepository = IngredientRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> Get()
        {
            var recipes = RecipeRepository.GetAll();

            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public ActionResult<Recipe> Get(int id)
        {
            var recipes = RecipeRepository.Get(id);

            if (recipes == null)
            {
                return NotFound();
            }

            return Ok(recipes);
        }

        [HttpPost]
        public ActionResult<Recipe> Post(Recipe recipes)
        {
            RecipeRepository.Add(recipes);

            return CreatedAtAction(nameof(Get), new { id = recipes.Id }, recipes);
        }

        [HttpPut("{id}")]
        public ActionResult<Recipe> Put(int id, Recipe recipes)
        {
            if (id != recipes.Id)
            {
                return BadRequest();
            }

            RecipeRepository.Update(recipes);

            return RecipeRepository.Get(id)!;
        }

        [HttpPatch("{id}")]
        public ActionResult<Recipe> Patch(int id)
        {
            var recipes = RecipeRepository.Get(id);

            if (recipes == null)
            {
                return NotFound();
            }

            RecipeRepository.Update(recipes);

            return RecipeRepository.Get(id)!;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            RecipeRepository.Delete(id);

            return NoContent();
        }

        [HttpPost("{id}/portion/{ingredientId}")]
        public ActionResult<Recipe> Rent(int id, int ingredientId, Portion portion)
        {
            var recipe = RecipeRepository.Get(id);

            if (recipe == null)
            {
                return NotFound();
            }

            var ingredient = IngredientRepository.Get(ingredientId);

            if (ingredient == null)
            {
                return NotFound();
            }

            portion.Ingredient = ingredient;
            portion.Recipe = recipe;

            recipe.Portions!.Add(portion);

            RecipeRepository.Update(recipe);

            return Ok(recipe);
        }
    }
}