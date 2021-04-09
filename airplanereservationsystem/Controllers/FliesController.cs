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
    public class FliesController : ControllerBase
    {
        private readonly airplanereservationsystemContext _context;

        public FliesController(airplanereservationsystemContext context)
        {
            _context = context;
        }

        // GET: api/Flies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flies>>> GetFlies()
        {
            return await _context.Flies.ToListAsync();
        }

        // GET: api/Flies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flies>> GetFlies(int id)
        {
            var flies = await _context.Flies.FindAsync(id);

            if (flies == null)
            {
                return NotFound();
            }

            return flies;
        }

        // PUT: api/Flies/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlies(int id, Flies flies)
        {
            if (id != flies.AirplaneId)
            {
                return BadRequest();
            }

            _context.Entry(flies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FliesExists(id))
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

        // POST: api/Flies
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Flies>> PostFlies(Flies flies)
        {
            _context.Flies.Add(flies);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FliesExists(flies.AirplaneId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFlies", new { id = flies.AirplaneId }, flies);
        }

        // DELETE: api/Flies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Flies>> DeleteFlies(int id)
        {
            var flies = await _context.Flies.FindAsync(id);
            if (flies == null)
            {
                return NotFound();
            }

            _context.Flies.Remove(flies);
            await _context.SaveChangesAsync();

            return flies;
        }

        private bool FliesExists(int id)
        {
            return _context.Flies.Any(e => e.AirplaneId == id);
        }
    }
}
