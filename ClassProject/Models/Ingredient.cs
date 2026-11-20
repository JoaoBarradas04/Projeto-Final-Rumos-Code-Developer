using System.Text.Json.Serialization;

namespace TesteProgram.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [JsonIgnore] public List<Portion>? Portions { get; set; } 
    }
}
