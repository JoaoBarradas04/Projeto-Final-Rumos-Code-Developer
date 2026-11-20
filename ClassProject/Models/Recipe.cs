using System.Text.Json.Serialization;

namespace TesteProgram.Models
{
    public class Recipe
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? Time { get; set; }
        public string? Difficulty { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public List<Portion>? Portions { get; set; } 


        
    }
}
