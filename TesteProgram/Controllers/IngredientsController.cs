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
    public class IngredientsController : ControllerBase
    {
        private readonly IRepository<Ingredient> IngredientRepository;

        public IngredientsController(IRepository<Ingredient> repository)
        {
            this.IngredientRepository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ingredient>> Get()
        {
            var values = IngredientRepository.GetAll();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public ActionResult<Ingredient> Get(int id)
        {
            var value = IngredientRepository.Get(id);

            if (value == null)
            {
                return NotFound();
            }

            return Ok(value);
        }

        [HttpPost]
        public ActionResult<Ingredient> Post(Ingredient value)
        {
            IngredientRepository.Add(value);

            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }

        [HttpPut("{id}")]
        public ActionResult<Ingredient> Put(int id, Ingredient value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }

            IngredientRepository.Update(value);

            return IngredientRepository.Get(value.Id)!;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            IngredientRepository.Delete(id);

            return NoContent();
        }
    }
}