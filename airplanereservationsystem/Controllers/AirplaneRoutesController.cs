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
    public class AirplaneRoutesController : ControllerBase
    {
        private readonly airplanereservationsystemContext _context;

        public AirplaneRoutesController(airplanereservationsystemContext context)
        {
            _context = context;
        }

        // GET: api/AirplaneRoutes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirplaneRoute>>> GetAirplaneRoute()
        {
            return await _context.AirplaneRoute.ToListAsync();
        }

        // GET: api/AirplaneRoutes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirplaneRoute>> GetAirplaneRoute(int id)
        {
            var airplaneRoute = await _context.AirplaneRoute.FindAsync(id);

            if (airplaneRoute == null)
            {
                return NotFound();
            }

            return airplaneRoute;
        }

        // PUT: api/AirplaneRoutes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirplaneRoute(int id, AirplaneRoute airplaneRoute)
        {
            if (id != airplaneRoute.RouteNum)
            {
                return BadRequest();
            }

            _context.Entry(airplaneRoute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirplaneRouteExists(id))
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

        // POST: api/AirplaneRoutes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AirplaneRoute>> PostAirplaneRoute(AirplaneRoute airplaneRoute)
        {
            _context.AirplaneRoute.Add(airplaneRoute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirplaneRoute", new { id = airplaneRoute.RouteNum }, airplaneRoute);
        }

        // DELETE: api/AirplaneRoutes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AirplaneRoute>> DeleteAirplaneRoute(int id)
        {
            var airplaneRoute = await _context.AirplaneRoute.FindAsync(id);
            if (airplaneRoute == null)
            {
                return NotFound();
            }

            _context.AirplaneRoute.Remove(airplaneRoute);
            await _context.SaveChangesAsync();

            return airplaneRoute;
        }

        private bool AirplaneRouteExists(int id)
        {
            return _context.AirplaneRoute.Any(e => e.RouteNum == id);
        }
    }
}
