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
    public class GetsInfoFromsController : ControllerBase
    {
        private readonly airplanereservationsystemContext _context;

        public GetsInfoFromsController(airplanereservationsystemContext context)
        {
            _context = context;
        }

        // GET: api/GetsInfoFroms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetsInfoFrom>>> GetGetsInfoFrom()
        {
            return await _context.GetsInfoFrom.ToListAsync();
        }

        // GET: api/GetsInfoFroms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetsInfoFrom>> GetGetsInfoFrom(int id)
        {
            var getsInfoFrom = await _context.GetsInfoFrom.FindAsync(id);

            if (getsInfoFrom == null)
            {
                return NotFound();
            }

            return getsInfoFrom;
        }

        // PUT: api/GetsInfoFroms/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGetsInfoFrom(int id, GetsInfoFrom getsInfoFrom)
        {
            if (id != getsInfoFrom.ReservationSystemId)
            {
                return BadRequest();
            }

            _context.Entry(getsInfoFrom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GetsInfoFromExists(id))
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

        // POST: api/GetsInfoFroms
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<GetsInfoFrom>> PostGetsInfoFrom(GetsInfoFrom getsInfoFrom)
        {
            _context.GetsInfoFrom.Add(getsInfoFrom);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GetsInfoFromExists(getsInfoFrom.ReservationSystemId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGetsInfoFrom", new { id = getsInfoFrom.ReservationSystemId }, getsInfoFrom);
        }

        // DELETE: api/GetsInfoFroms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GetsInfoFrom>> DeleteGetsInfoFrom(int id)
        {
            var getsInfoFrom = await _context.GetsInfoFrom.FindAsync(id);
            if (getsInfoFrom == null)
            {
                return NotFound();
            }

            _context.GetsInfoFrom.Remove(getsInfoFrom);
            await _context.SaveChangesAsync();

            return getsInfoFrom;
        }

        private bool GetsInfoFromExists(int id)
        {
            return _context.GetsInfoFrom.Any(e => e.ReservationSystemId == id);
        }
    }
}
