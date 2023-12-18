using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JPW.Models;
using AutoMapper;
using JPW.DTO;

namespace JPW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostingsController : ControllerBase
    {
        private readonly JPWContext _context;
        private readonly IMapper _automapper;

        public JobPostingsController(JPWContext context, IMapper automapper)
        {
            _context = context;
            _automapper = automapper;
        }

        // GET: api/JobPostings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobPosting>>> GetJobPostings()
        {
          if (_context.JobPostings == null)
          {
              return NotFound();
          }
            return await _context.JobPostings.ToListAsync();
        }

        // GET: api/JobPostings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobPosting>> GetJobPosting(int id)
        {
          if (_context.JobPostings == null)
          {
              return NotFound();
          }
            var jobPosting = await _context.JobPostings.FindAsync(id);

            if (jobPosting == null)
            {
                return NotFound();
            }

            return jobPosting;
        }

        // PUT: api/JobPostings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutJobPosting(int id, JobpostingDTO jobPosting)
        // {
            [HttpPatch("{id}")]
public async Task<IActionResult> PutJobPosting(int id, JobpostingDTO jobPosting)
{
            var userProfile = await _context.JobPostings.FindAsync(id);
            try
            {
                if (userProfile == null)
                {   
                    return NotFound();
                }
                _automapper.Map(jobPosting, userProfile);
                // _context.JobPostings.Update(userProfile);
                _context.Entry(userProfile).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                 
                return Ok(jobPosting);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobPostingExists(id))
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

        // POST: api/JobPostings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobPosting>> PostJobPosting(JobpostingDTO jobPosting)
        {

            var user = _automapper.Map<JobPosting>(jobPosting);
            _context.JobPostings.Add(user);
           
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetJobPosting", new { id = user.JobId }, user);
        }

        // DELETE: api/JobPostings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobPosting(int id)
        {
            if (_context.JobPostings == null)
            {
                return NotFound();
            }
            var jobPosting = await _context.JobPostings.FindAsync(id);
            if (jobPosting == null)
            {
                return NotFound();
            }

            _context.JobPostings.Remove(jobPosting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobPostingExists(int id)
        {
            return (_context.JobPostings?.Any(e => e.JobId == id)).GetValueOrDefault();
        }
    }
}
