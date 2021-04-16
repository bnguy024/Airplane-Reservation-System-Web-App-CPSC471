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
    public class ArrivalsController : ControllerBase
    {
        private readonly airplanereservationsystemContext _context;

        public ArrivalsController(airplanereservationsystemContext context)
        {
            _context = context;
        }

        // GET: api/Arrivals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Arrival>>> GetArrival()
        {
            return await _context.Arrival.ToListAsync();
        }

        // GET: api/Arrivals/5
        [HttpGet("{routenum}")]
        public async Task<ActionResult<Arrival>> GetArrival(int routenum)
        {
            var arrival = _context.Arrival.Where(pub => pub.RouteNum == routenum).FirstOrDefault();

            if (arrival == null)
            {
                return NotFound();
            }

            return arrival;
        }

        // PUT: api/Arrivals/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArrival(string id, Arrival arrival)
        {
            if (id != arrival.AirportCode)
            {
                return BadRequest();
            }

            _context.Entry(arrival).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArrivalExists(id))
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

        // POST: api/Arrivals
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Arrival>> PostArrival(Arrival arrival)
        {
            _context.Arrival.Add(arrival);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ArrivalExists(arrival.AirportCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetArrival", new { id = arrival.AirportCode }, arrival);
        }

        // DELETE: api/Arrivals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Arrival>> DeleteArrival(string id)
        {
            var arrival = await _context.Arrival.FindAsync(id);
            if (arrival == null)
            {
                return NotFound();
            }

            _context.Arrival.Remove(arrival);
            await _context.SaveChangesAsync();

            return arrival;
        }

        private bool ArrivalExists(string id)
        {
            return _context.Arrival.Any(e => e.AirportCode == id);
        }
    }
}
