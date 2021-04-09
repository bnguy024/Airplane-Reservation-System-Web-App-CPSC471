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
    public class GoesToesController : ControllerBase
    {
        private readonly airplanereservationsystemContext _context;

        public GoesToesController(airplanereservationsystemContext context)
        {
            _context = context;
        }

        // GET: api/GoesToes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoesTo>>> GetGoesTo()
        {
            return await _context.GoesTo.ToListAsync();
        }

        // GET: api/GoesToes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GoesTo>> GetGoesTo(string id)
        {
            var goesTo = await _context.GoesTo.FindAsync(id);

            if (goesTo == null)
            {
                return NotFound();
            }

            return goesTo;
        }

        // PUT: api/GoesToes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoesTo(string id, GoesTo goesTo)
        {
            if (id != goesTo.AirportCode)
            {
                return BadRequest();
            }

            _context.Entry(goesTo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoesToExists(id))
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

        // POST: api/GoesToes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<GoesTo>> PostGoesTo(GoesTo goesTo)
        {
            _context.GoesTo.Add(goesTo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GoesToExists(goesTo.AirportCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGoesTo", new { id = goesTo.AirportCode }, goesTo);
        }

        // DELETE: api/GoesToes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GoesTo>> DeleteGoesTo(string id)
        {
            var goesTo = await _context.GoesTo.FindAsync(id);
            if (goesTo == null)
            {
                return NotFound();
            }

            _context.GoesTo.Remove(goesTo);
            await _context.SaveChangesAsync();

            return goesTo;
        }

        private bool GoesToExists(string id)
        {
            return _context.GoesTo.Any(e => e.AirportCode == id);
        }
    }
}
