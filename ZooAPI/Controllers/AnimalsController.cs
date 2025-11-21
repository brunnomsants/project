using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.API.Data;
using project.API.DTOs;
using project.API.DTOs.Animal;
using project.API.Models;

namespace project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly projectContext _context;

        public AnimalsController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Animals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalDTO>>> GetAnimals()
        {
            var animals = await _context.Animal
                .AsNoTracking()
                .Select(a => new AnimalDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Birthday = a.Birthday,
                    Species = a.Species,
                    Habitat = a.Habitat,
                    CountryOfOrigin = a.CountryOfOrigin
                })
                .ToListAsync();

            return Ok(animals);
        }

        // GET: api/Animals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalDTO>> GetAnimal(int id)
        {
            var animal = await _context.Animal
                .AsNoTracking()
                .Where(a => a.Id == id)
                .Select(a => new AnimalDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Birthday = a.Birthday,
                    Species = a.Species,
                    Habitat = a.Habitat,
                    CountryOfOrigin = a.CountryOfOrigin
                })
                .FirstOrDefaultAsync();

            if (animal == null)
                return NotFound();

            return Ok(animal);
        }

        // POST: api/Animals
        [HttpPost]
        public async Task<ActionResult<AnimalDTO>> PostAnimal(AnimalCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var animal = new Animal
            {
                Name = dto.Name,
                Description = dto.Description,
                Birthday = dto.Birthday,
                Species = dto.Species,
                Habitat = dto.Habitat,
                CountryOfOrigin = dto.CountryOfOrigin
            };

            _context.Animal.Add(animal);
            await _context.SaveChangesAsync();

            var result = new AnimalDTO
            {
                Id = animal.Id,
                Name = animal.Name,
                Description = animal.Description,
                Birthday = animal.Birthday,
                Species = animal.Species,
                Habitat = animal.Habitat,
                CountryOfOrigin = animal.CountryOfOrigin
            };

            return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, result);
        }

        // PUT: api/Animals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimal(int id, AnimalUpdateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var animal = await _context.Animal.FindAsync(id);

            if (animal == null)
                return NotFound();

            animal.Name = dto.Name;
            animal.Description = dto.Description;
            animal.Birthday = dto.Birthday;
            animal.Species = dto.Species;
            animal.Habitat = dto.Habitat;
            animal.CountryOfOrigin = dto.CountryOfOrigin;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Animals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            var animal = await _context.Animal.FindAsync(id);

            if (animal == null)
                return NotFound();

            _context.Animal.Remove(animal);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
