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
        [HttpGet("GetArrival/{routenum}")]
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
        [HttpPut("{routenum}")]
        public async Task<IActionResult> PutArrival(int routenum, Arrival arrival)
        {
            if (routenum != arrival.RouteNum)
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
                if (!ArrivalExists(routenum))
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
                if (ArrivalExists(arrival.RouteNum))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetArrival", new { routenum = arrival.RouteNum }, arrival);
        }

        // DELETE: api/Arrivals/5
        [HttpDelete("{routenum}")]
        public async Task<ActionResult<Arrival>> DeleteArrival(int routenum)
        {
            var arrival = await _context.Arrival.FindAsync(routenum);
            if (arrival == null)
            {
                return NotFound();
            }

            _context.Arrival.Remove(arrival);
            await _context.SaveChangesAsync();

            return arrival;
        }

        private bool ArrivalExists(int routenum)
        {
            return _context.Arrival.Any(e => e.RouteNum == routenum);
        }
    }
}
