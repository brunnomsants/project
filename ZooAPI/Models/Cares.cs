using System.ComponentModel.DataAnnotations;

namespace project.API.Models
{
    public class Cares
    {
        public int Id { get; set; }

        [Required]
        public int AnimalId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Frequency { get; set; } = string.Empty;
    }
}
