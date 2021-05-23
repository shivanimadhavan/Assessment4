using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherDetails.Models;

namespace WeatherDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClimateDetailsController : ControllerBase
    {
        private readonly WeatherContext _context;

        public ClimateDetailsController(WeatherContext context)
        {
            _context = context;
        }

        // GET: api/ClimateDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClimateDetails>>> GetWDetails()
        {
            return await _context.WDetails.ToListAsync();
        }

        // GET: api/ClimateDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClimateDetails>> GetClimateDetails(string id)
        {
            var climateDetails = await _context.WDetails.FindAsync(id);

            if (climateDetails == null)
            {
                return NotFound();
            }

            return climateDetails;
        }

        // PUT: api/ClimateDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClimateDetails(string id, ClimateDetails climateDetails)
        {
            if (id != climateDetails.City)
            {
                return BadRequest();
            }

            _context.Entry(climateDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClimateDetailsExists(id))
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

        // POST: api/ClimateDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClimateDetails>> PostClimateDetails(ClimateDetails climateDetails)
        {
            _context.WDetails.Add(climateDetails);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClimateDetailsExists(climateDetails.City))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClimateDetails", new { id = climateDetails.City }, climateDetails);
        }

        // DELETE: api/ClimateDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClimateDetails(string id)
        {
            var climateDetails = await _context.WDetails.FindAsync(id);
            if (climateDetails == null)
            {
                return NotFound();
            }

            _context.WDetails.Remove(climateDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClimateDetailsExists(string id)
        {
            return _context.WDetails.Any(e => e.City == id);
        }
    }
}
