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
    public class ReseverationSystemsController : ControllerBase
    {
        private readonly airplanereservationsystemContext _context;

        public ReseverationSystemsController(airplanereservationsystemContext context)
        {
            _context = context;
        }

        // GET: api/ReseverationSystems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReseverationSystem>>> GetReseverationSystem()
        {
            return await _context.ReseverationSystem.ToListAsync();
        }

        // GET: api/ReseverationSystems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReseverationSystem>> GetReseverationSystem(int id)
        {
            var reseverationSystem = await _context.ReseverationSystem.FindAsync(id);

            if (reseverationSystem == null)
            {
                return NotFound();
            }

            return reseverationSystem;
        }

        // PUT: api/ReseverationSystems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReseverationSystem(int id, ReseverationSystem reseverationSystem)
        {
            if (id != reseverationSystem.ReservationSystemId)
            {
                return BadRequest();
            }

            _context.Entry(reseverationSystem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReseverationSystemExists(id))
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

        // POST: api/ReseverationSystems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ReseverationSystem>> PostReseverationSystem(ReseverationSystem reseverationSystem)
        {
            _context.ReseverationSystem.Add(reseverationSystem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReseverationSystem", new { id = reseverationSystem.ReservationSystemId }, reseverationSystem);
        }

        // DELETE: api/ReseverationSystems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReseverationSystem>> DeleteReseverationSystem(int id)
        {
            var reseverationSystem = await _context.ReseverationSystem.FindAsync(id);
            if (reseverationSystem == null)
            {
                return NotFound();
            }

            _context.ReseverationSystem.Remove(reseverationSystem);
            await _context.SaveChangesAsync();

            return reseverationSystem;
        }

        private bool ReseverationSystemExists(int id)
        {
            return _context.ReseverationSystem.Any(e => e.ReservationSystemId == id);
        }
    }
}
