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
    public class AirplanesController : ControllerBase
    {
        private readonly airplanereservationsystemContext _context;

        public AirplanesController(airplanereservationsystemContext context)
        {
            _context = context;
        }

        // GET: api/Airplanes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Airplane>>> GetAirplane()
        {
            return await _context.Airplane.ToListAsync();
        }

        // GET: api/Airplanes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Airplane>> GetAirplane(int id)
        {
            var airplane = await _context.Airplane.FindAsync(id);

            if (airplane == null)
            {
                return NotFound();
            }

            return airplane;
        }

        // PUT: api/Airplanes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirplane(int id, Airplane airplane)
        {
            if (id != airplane.AirplaneId)
            {
                return BadRequest();
            }

            _context.Entry(airplane).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirplaneExists(id))
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

        // POST: api/Airplanes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Airplane>> PostAirplane(Airplane airplane)
        {
            _context.Airplane.Add(airplane);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirplane", new { id = airplane.AirplaneId }, airplane);
        }

        // DELETE: api/Airplanes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Airplane>> DeleteAirplane(int id)
        {
            var airplane = await _context.Airplane.FindAsync(id);
            if (airplane == null)
            {
                return NotFound();
            }

            _context.Airplane.Remove(airplane);
            await _context.SaveChangesAsync();

            return airplane;
        }

        private bool AirplaneExists(int id)
        {
            return _context.Airplane.Any(e => e.AirplaneId == id);
        }
    }
}
