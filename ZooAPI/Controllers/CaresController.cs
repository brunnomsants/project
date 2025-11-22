using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.API.Data;
using project.API.Dtos.Cares;
using project.API.DTOs.Cares;
using project.API.Models;

namespace ZooAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaresController : ControllerBase
    {
        private readonly projectContext _context;

        public CaresController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Cares
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CareDTO>>> GetCares()
        {
            var list = await _context.Cares
                .AsNoTracking()
                .Select(c => new CareDTO
                {
                    Id = c.Id,
                    AnimalId = c.AnimalId,
                    Name = c.Name,
                    Description = c.Description,
                    Frequency = c.Frequency
                })
                .ToListAsync();

            return Ok(list);
        }

        // GET: api/Cares/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CareDTO>> GetCaresById(int id)
        {
            var care = await _context.Cares
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new CareDTO
                {
                    Id = c.Id,
                    AnimalId = c.AnimalId,
                    Name = c.Name,
                    Description = c.Description,
                    Frequency = c.Frequency
                })
                .FirstOrDefaultAsync();

            if (care == null)
                return NotFound();

            return Ok(care);
        }

        // GET: api/Cares/ByAnimal/3
        [HttpGet("ByAnimal/{animalId}")]
        public async Task<ActionResult<IEnumerable<CareDTO>>> GetCaresByAnimal(int animalId)
        {

            var animalExists = await _context.Animal
                .AsNoTracking()
                .AnyAsync(animal => animal.Id == animalId);

            if (!animalExists)
                return NotFound(new { message = $"Animal com ID {animalId} não existe." });

            var cares = await _context.Cares
                .AsNoTracking()
                .Where(c => c.AnimalId == animalId)
                .Select(c => new CareDTO
                {
                    Id = c.Id,
                    AnimalId = c.AnimalId,
                    Name = c.Name,
                    Description = c.Description,
                    Frequency = c.Frequency
                })
                .ToListAsync();
            return Ok(cares);
        }


        // POST: api/Cares
        [HttpPost]
        public async Task<ActionResult<CareDTO>> PostCares(CareCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var care = new Cares
            {
                AnimalId = dto.AnimalId,
                Name = dto.Name,
                Description = dto.Description,
                Frequency = dto.Frequency
            };

            _context.Cares.Add(care);
            await _context.SaveChangesAsync();

            var result = new CareDTO
            {
                Id = care.Id,
                AnimalId = care.AnimalId,
                Name = care.Name,
                Description = care.Description,
                Frequency = care.Frequency
            };

            return CreatedAtAction(nameof(GetCaresById), new { id = care.Id }, result);
        }

        // PUT: api/Cares/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCares(int id, CareUpdateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var care = await _context.Cares.FindAsync(id);

            if (care == null)
                return NotFound();

            care.Name = dto.Name;
            care.Description = dto.Description;
            care.Frequency = dto.Frequency;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Cares/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCares(int id)
        {
            var care = await _context.Cares.FindAsync(id);

            if (care == null)
                return NotFound();

            _context.Cares.Remove(care);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
