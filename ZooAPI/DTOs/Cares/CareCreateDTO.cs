using System.ComponentModel.DataAnnotations;

namespace project.API.Dtos.Cares
{
    public class CareCreateDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Frequency { get; set; }

        [Required]
        public int AnimalId { get; set; }
    }
}
