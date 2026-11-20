using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TesteProgram.Models
{
    public class Portion
    {       
        public string? Unit { get; set; }
        public int Quantity { get; set; }

        // Chaves estrangeiras
        public int? RecipeId { get; set; }
        [JsonIgnore] public Recipe? Recipe { get; set; }

        [JsonIgnore] public Ingredient? Ingredient { get; set; }
        [Key] 
        public int? IngredientId { get; set; }
       
       

    }
}
