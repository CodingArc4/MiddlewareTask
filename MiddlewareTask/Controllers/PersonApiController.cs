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


        [HttpGet("GetPerson")]
        public async Task<IActionResult> Get()
        {
            var people = await _context.Persons.ToListAsync();
            //Task.Delay(10000).Wait();
            return Ok(people);
        }

   
        [HttpPost("AddPerson")]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return Ok(person);
        }


        [HttpPost("AddPersonByForm")]
        public async Task<IActionResult> PostByFrom([FromForm] Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return Ok(person);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete( int id)
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

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser([FromQuery] int id)
        {
            var person =  _context.Persons.Find(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(person);
            _context.SaveChangesAsync();
            return Ok(person);
        }
    }
}
