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
    public class AirlineCompaniesController : ControllerBase
    {
        private readonly airplanereservationsystemContext _context;

        public AirlineCompaniesController(airplanereservationsystemContext context)
        {
            _context = context;
        }

        // GET: api/AirlineCompanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirlineCompany>>> GetAirlineCompany()
        {
            return await _context.AirlineCompany.ToListAsync();
        }

        // GET: api/AirlineCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirlineCompany>> GetAirlineCompany(string id)
        {
            var airlineCompany = await _context.AirlineCompany.FindAsync(id);

            if (airlineCompany == null)
            {
                return NotFound();
            }

            return airlineCompany;
        }

        // PUT: api/AirlineCompanies/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirlineCompany(string id, AirlineCompany airlineCompany)
        {
            if (id != airlineCompany.Name)
            {
                return BadRequest();
            }

            _context.Entry(airlineCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirlineCompanyExists(id))
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

        // POST: api/AirlineCompanies
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AirlineCompany>> PostAirlineCompany(AirlineCompany airlineCompany)
        {
            _context.AirlineCompany.Add(airlineCompany);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AirlineCompanyExists(airlineCompany.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAirlineCompany", new { id = airlineCompany.Name }, airlineCompany);
        }

        // DELETE: api/AirlineCompanies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AirlineCompany>> DeleteAirlineCompany(string id)
        {
            var airlineCompany = await _context.AirlineCompany.FindAsync(id);
            if (airlineCompany == null)
            {
                return NotFound();
            }

            _context.AirlineCompany.Remove(airlineCompany);
            await _context.SaveChangesAsync();

            return airlineCompany;
        }

        private bool AirlineCompanyExists(string id)
        {
            return _context.AirlineCompany.Any(e => e.Name == id);
        }
    }
}
