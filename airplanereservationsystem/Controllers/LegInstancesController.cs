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
    public class LegInstancesController : ControllerBase
    {
        private readonly airplanereservationsystemContext _context;

        public LegInstancesController(airplanereservationsystemContext context)
        {
            _context = context;
        }

        // GET: api/LegInstances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LegInstance>>> GetLegInstance()
        {
            return await _context.LegInstance.ToListAsync();
        }

        // GET: api/LegInstances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LegInstance>> GetLegInstance(string id)
        {
            var legInstance = await _context.LegInstance.FindAsync(id);

            if (legInstance == null)
            {
                return NotFound();
            }

            return legInstance;
        }

        // PUT: api/LegInstances/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLegInstance(string id, LegInstance legInstance)
        {
            if (id != legInstance.Date)
            {
                return BadRequest();
            }

            _context.Entry(legInstance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LegInstanceExists(id))
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

        // POST: api/LegInstances
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LegInstance>> PostLegInstance(LegInstance legInstance)
        {
            _context.LegInstance.Add(legInstance);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LegInstanceExists(legInstance.Date))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLegInstance", new { id = legInstance.Date }, legInstance);
        }

        // DELETE: api/LegInstances/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LegInstance>> DeleteLegInstance(string id)
        {
            var legInstance = await _context.LegInstance.FindAsync(id);
            if (legInstance == null)
            {
                return NotFound();
            }

            _context.LegInstance.Remove(legInstance);
            await _context.SaveChangesAsync();

            return legInstance;
        }

        private bool LegInstanceExists(string id)
        {
            return _context.LegInstance.Any(e => e.Date == id);
        }
    }
}
