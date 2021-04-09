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
    public class ProvidesController : ControllerBase
    {
        private readonly airplanereservationsystemContext _context;

        public ProvidesController(airplanereservationsystemContext context)
        {
            _context = context;
        }

        // GET: api/Provides
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Provides>>> GetProvides()
        {
            return await _context.Provides.ToListAsync();
        }

        // GET: api/Provides/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Provides>> GetProvides(int id)
        {
            var provides = await _context.Provides.FindAsync(id);

            if (provides == null)
            {
                return NotFound();
            }

            return provides;
        }

        // PUT: api/Provides/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvides(int id, Provides provides)
        {
            if (id != provides.ReservationSystemId)
            {
                return BadRequest();
            }

            _context.Entry(provides).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvidesExists(id))
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

        // POST: api/Provides
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Provides>> PostProvides(Provides provides)
        {
            _context.Provides.Add(provides);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProvidesExists(provides.ReservationSystemId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProvides", new { id = provides.ReservationSystemId }, provides);
        }

        // DELETE: api/Provides/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Provides>> DeleteProvides(int id)
        {
            var provides = await _context.Provides.FindAsync(id);
            if (provides == null)
            {
                return NotFound();
            }

            _context.Provides.Remove(provides);
            await _context.SaveChangesAsync();

            return provides;
        }

        private bool ProvidesExists(int id)
        {
            return _context.Provides.Any(e => e.ReservationSystemId == id);
        }
    }
}
