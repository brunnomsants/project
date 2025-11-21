using System.ComponentModel.DataAnnotations;

namespace project.API.Dtos.Cares
{
    public class CareUpdateDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Frequency { get; set; }
    }
}
