using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JPW.Models;

namespace JPW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobMatchesController : ControllerBase
    {
        private readonly JPWContext _context;

        public JobMatchesController(JPWContext context)
        {
            _context = context;
        }

        // GET: api/JobMatches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobMatch>>> GetJobMatches()
        {
          if (_context.JobMatches == null)
          {
              return NotFound();
          }
            return await _context.JobMatches.ToListAsync();
        }

        // GET: api/JobMatches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobMatch>> GetJobMatch(int id)
        {
          if (_context.JobMatches == null)
          {
              return NotFound();
          }
            var jobMatch = await _context.JobMatches.FindAsync(id);

            if (jobMatch == null)
            {
                return NotFound();
            }

            return jobMatch;
        }

        // PUT: api/JobMatches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobMatch(int id, JobMatch jobMatch)
        {
            if (id != jobMatch.JobMatchId)
            {
                return BadRequest();
            }

            _context.Entry(jobMatch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobMatchExists(id))
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

        // POST: api/JobMatches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobMatch>> PostJobMatch(JobMatch jobMatch)
        {
          if (_context.JobMatches == null)
          {
              return Problem("Entity set 'JPWContext.JobMatches'  is null.");
          }
            _context.JobMatches.Add(jobMatch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobMatch", new { id = jobMatch.JobMatchId }, jobMatch);
        }

        // DELETE: api/JobMatches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobMatch(int id)
        {
            if (_context.JobMatches == null)
            {
                return NotFound();
            }
            var jobMatch = await _context.JobMatches.FindAsync(id);
            if (jobMatch == null)
            {
                return NotFound();
            }

            _context.JobMatches.Remove(jobMatch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobMatchExists(int id)
        {
            return (_context.JobMatches?.Any(e => e.JobMatchId == id)).GetValueOrDefault();
        }
    }
}
