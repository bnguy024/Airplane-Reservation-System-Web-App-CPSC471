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
    public class AirplaneTypesController : ControllerBase
    {
        private readonly airplanereservationsystemContext _context;

        public AirplaneTypesController(airplanereservationsystemContext context)
        {
            _context = context;
        }

        // GET: api/AirplaneTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirplaneType>>> GetAirplaneType()
        {
            return await _context.AirplaneType.ToListAsync();
        }

        // GET: api/AirplaneTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirplaneType>> GetAirplaneType(int id)
        {
            var airplaneType = await _context.AirplaneType.FindAsync(id);

            if (airplaneType == null)
            {
                return NotFound();
            }

            return airplaneType;
        }

        // PUT: api/AirplaneTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirplaneType(int id, AirplaneType airplaneType)
        {
            if (id != airplaneType.AirplaneId)
            {
                return BadRequest();
            }

            _context.Entry(airplaneType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirplaneTypeExists(id))
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

        // POST: api/AirplaneTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AirplaneType>> PostAirplaneType(AirplaneType airplaneType)
        {
            _context.AirplaneType.Add(airplaneType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AirplaneTypeExists(airplaneType.AirplaneId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAirplaneType", new { id = airplaneType.AirplaneId }, airplaneType);
        }

        // DELETE: api/AirplaneTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AirplaneType>> DeleteAirplaneType(int id)
        {
            var airplaneType = await _context.AirplaneType.FindAsync(id);
            if (airplaneType == null)
            {
                return NotFound();
            }

            _context.AirplaneType.Remove(airplaneType);
            await _context.SaveChangesAsync();

            return airplaneType;
        }

        private bool AirplaneTypeExists(int id)
        {
            return _context.AirplaneType.Any(e => e.AirplaneId == id);
        }
    }
}
