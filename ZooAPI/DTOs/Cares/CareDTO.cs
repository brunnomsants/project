namespace project.API.DTOs.Cares
{
    public class CareDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Frequency { get; set; }
        public int AnimalId { get; set; }
    }
}
