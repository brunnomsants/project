using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.API.Data;
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
        public async Task<ActionResult<IEnumerable<Cares>>> GetCares()
        {
            return await _context.Cares.ToListAsync();
        }

        // GET: api/Cares/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cares>> GetCares(int id) { 
            var cares = await _context.Cares.FindAsync(id); 
            if (cares == null) { 
                return NotFound(); 
            } 
            return cares; 
        }

        // GET: api/Cares/ByAnimal/5
        [HttpGet("ByAnimal/{animalId}")]
        public async Task<ActionResult<IEnumerable<Cares>>> GetCaresByAnimal(int animalId)
        {
            var cares = await _context.Cares
                                      .Where(c => c.AnimalId == animalId)
                                      .ToListAsync();

            if (cares == null || cares.Count == 0)
            {
                return NotFound();
            }

            return cares;
        }


        // PUT: api/Cares/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCares(int id, Cares cares)
        {
            if (id != cares.Id)
            {
                return BadRequest();
            }

            _context.Entry(cares).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaresExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cares
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cares>> PostCares(Cares cares)
        {
            _context.Cares.Add(cares);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCares", new { id = cares.Id }, cares);
        }

        // DELETE: api/Cares/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCares(int id)
        {
            var cares = await _context.Cares.FindAsync(id);
            if (cares == null)
            {
                return NotFound();
            }

            _context.Cares.Remove(cares);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaresExists(int id)
        {
            return _context.Cares.Any(e => e.Id == id);
        }
    }
}
