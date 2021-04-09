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
    public class DeparturesController : ControllerBase
    {
        private readonly airplanereservationsystemContext _context;

        public DeparturesController(airplanereservationsystemContext context)
        {
            _context = context;
        }

        // GET: api/Departures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departure>>> GetDeparture()
        {
            return await _context.Departure.ToListAsync();
        }

        // GET: api/Departures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departure>> GetDeparture(string id)
        {
            var departure = await _context.Departure.FindAsync(id);

            if (departure == null)
            {
                return NotFound();
            }

            return departure;
        }

        // PUT: api/Departures/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeparture(string id, Departure departure)
        {
            if (id != departure.AirportCode)
            {
                return BadRequest();
            }

            _context.Entry(departure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartureExists(id))
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

        // POST: api/Departures
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Departure>> PostDeparture(Departure departure)
        {
            _context.Departure.Add(departure);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DepartureExists(departure.AirportCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDeparture", new { id = departure.AirportCode }, departure);
        }

        // DELETE: api/Departures/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Departure>> DeleteDeparture(string id)
        {
            var departure = await _context.Departure.FindAsync(id);
            if (departure == null)
            {
                return NotFound();
            }

            _context.Departure.Remove(departure);
            await _context.SaveChangesAsync();

            return departure;
        }

        private bool DepartureExists(string id)
        {
            return _context.Departure.Any(e => e.AirportCode == id);
        }
    }
}
