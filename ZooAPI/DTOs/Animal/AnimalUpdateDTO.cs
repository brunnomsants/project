using System.ComponentModel.DataAnnotations;

namespace project.API.DTOs
{
    public class AnimalUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = "";

        [Required]
        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public DateOnly? Birthday { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Species { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Habitat { get; set; }

        [Required]
        [MaxLength(100)]
        public string? CountryOfOrigin { get; set; }
    }
}
