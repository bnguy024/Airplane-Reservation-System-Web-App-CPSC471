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
    public class AccessToesController : ControllerBase
    {
        private readonly airplanereservationsystemContext _context;

        public AccessToesController(airplanereservationsystemContext context)
        {
            _context = context;
        }

        // GET: api/AccessToes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccessTo>>> GetAccessTo()
        {
            return await _context.AccessTo.ToListAsync();
        }

        // GET: api/AccessToes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccessTo>> GetAccessTo(int id)
        {
            var accessTo = await _context.AccessTo.FindAsync(id);

            if (accessTo == null)
            {
                return NotFound();
            }

            return accessTo;
        }

        // PUT: api/AccessToes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccessTo(int id, AccessTo accessTo)
        {
            if (id != accessTo.AdminId)
            {
                return BadRequest();
            }

            _context.Entry(accessTo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccessToExists(id))
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

        // POST: api/AccessToes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AccessTo>> PostAccessTo(AccessTo accessTo)
        {
            _context.AccessTo.Add(accessTo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AccessToExists(accessTo.AdminId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAccessTo", new { id = accessTo.AdminId }, accessTo);
        }

        // DELETE: api/AccessToes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccessTo>> DeleteAccessTo(int id)
        {
            var accessTo = await _context.AccessTo.FindAsync(id);
            if (accessTo == null)
            {
                return NotFound();
            }

            _context.AccessTo.Remove(accessTo);
            await _context.SaveChangesAsync();

            return accessTo;
        }

        private bool AccessToExists(int id)
        {
            return _context.AccessTo.Any(e => e.AdminId == id);
        }
    }
}
