namespace project.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set;  }
        public DateOnly? Birthday { get; set; }
        public string? Species { get; set; } 
        public string? Habitat { get; set; }
        public string? CountryOfOrigin { get; set; }
    }
}
