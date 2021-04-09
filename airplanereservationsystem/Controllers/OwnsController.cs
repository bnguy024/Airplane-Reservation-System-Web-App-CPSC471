using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using airplanereservationsystem.Models;

namespace airplanereservationsystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnsController : ControllerBase
    {
        private readonly airplanereservationsystemContext _context;

        public OwnsController(airplanereservationsystemContext context)
        {
            _context = context;
        }

        // GET: api/Owns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Owns>>> GetOwns()
        {
            return await _context.Owns.ToListAsync();
        }

        // GET: api/Owns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Owns>> GetOwns(int id)
        {
            var owns = await _context.Owns.FindAsync(id);

            if (owns == null)
            {
                return NotFound();
            }

            return owns;
        }

        // PUT: api/Owns/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwns(int id, Owns owns)
        {
            if (id != owns.AirplaneId)
            {
                return BadRequest();
            }

            _context.Entry(owns).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnsExists(id))
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

        // POST: api/Owns
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Owns>> PostOwns(Owns owns)
        {
            _context.Owns.Add(owns);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OwnsExists(owns.AirplaneId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOwns", new { id = owns.AirplaneId }, owns);
        }

        // DELETE: api/Owns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Owns>> DeleteOwns(int id)
        {
            var owns = await _context.Owns.FindAsync(id);
            if (owns == null)
            {
                return NotFound();
            }

            _context.Owns.Remove(owns);
            await _context.SaveChangesAsync();

            return owns;
        }

        private bool OwnsExists(int id)
        {
            return _context.Owns.Any(e => e.AirplaneId == id);
        }
    }
}
