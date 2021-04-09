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
    public class RunBiesController : ControllerBase
    {
        private readonly airplanereservationsystemContext _context;

        public RunBiesController(airplanereservationsystemContext context)
        {
            _context = context;
        }

        // GET: api/RunBies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RunBy>>> GetRunBy()
        {
            return await _context.RunBy.ToListAsync();
        }

        // GET: api/RunBies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RunBy>> GetRunBy(int id)
        {
            var runBy = await _context.RunBy.FindAsync(id);

            if (runBy == null)
            {
                return NotFound();
            }

            return runBy;
        }

        // PUT: api/RunBies/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRunBy(int id, RunBy runBy)
        {
            if (id != runBy.AdminId)
            {
                return BadRequest();
            }

            _context.Entry(runBy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RunByExists(id))
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

        // POST: api/RunBies
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<RunBy>> PostRunBy(RunBy runBy)
        {
            _context.RunBy.Add(runBy);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RunByExists(runBy.AdminId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRunBy", new { id = runBy.AdminId }, runBy);
        }

        // DELETE: api/RunBies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RunBy>> DeleteRunBy(int id)
        {
            var runBy = await _context.RunBy.FindAsync(id);
            if (runBy == null)
            {
                return NotFound();
            }

            _context.RunBy.Remove(runBy);
            await _context.SaveChangesAsync();

            return runBy;
        }

        private bool RunByExists(int id)
        {
            return _context.RunBy.Any(e => e.AdminId == id);
        }
    }
}
