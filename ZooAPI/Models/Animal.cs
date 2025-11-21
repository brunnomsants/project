using System.ComponentModel.DataAnnotations;

namespace project.API.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        public DateOnly? Birthday { get; set; }

        [Required]
        [StringLength(100)]
        public string Species { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Habitat { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string CountryOfOrigin { get; set; } = string.Empty;
    }
}
