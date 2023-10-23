using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiddlewareTask.Models;

namespace MiddlewareTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PersonApi
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var people = await _context.Persons.ToListAsync();
            return Ok(people);
        }

        // POST: api/PersonApi
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return Ok(person);
        }

        // PUT: api/PersonApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Persons.Any(e => e.Id == id))
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

        // DELETE: api/PersonApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return Ok(person);
        }
    }
}
