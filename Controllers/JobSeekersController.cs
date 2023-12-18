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
    public class JobSeekersController : ControllerBase
    {
        private readonly JPWContext _context;
        private readonly IMapper _automapper;


        public JobSeekersController(JPWContext context, IMapper automapper)
        {
            _context = context;
            _automapper = automapper;
        }

        // GET: api/JobSeekers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobSeeker>>> GetJobSeekers()
        {
          if (_context.JobSeekers == null)
          {
              return NotFound();
          }
            return await _context.JobSeekers.ToListAsync();
        }

        // GET: api/JobSeekers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobSeeker>> GetJobSeeker(int id)
        {
          if (_context.JobSeekers == null)
          {
              return NotFound();
          }
            var jobSeeker = await _context.JobSeekers.FindAsync(id);

            if (jobSeeker == null)
            {
                return NotFound();
            }

            return jobSeeker;
        }

        // PUT: api/JobSeekers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobSeeker(int id, JobSeekerDTO jobSeeker)
        {
            var userProfile = await _context.JobSeekers.FindAsync(id);
            try
            {
                if (userProfile == null)
                {
                    return NotFound();
                }
                _automapper.Map(jobSeeker, userProfile);
                _context.Entry(userProfile).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(jobSeeker);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobSeekerExists(id))
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

        // POST: api/JobSeekers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobSeeker>> PostJobSeeker(JobSeekerDTO jobSeeker)
        {
            var user = _automapper.Map<JobSeeker>(jobSeeker);
            _context.JobSeekers.Add(user);
            await _context.SaveChangesAsync();




            return CreatedAtAction("GetJobSeeker", new { id = user.JobSeekerId }, user);
        }

        // DELETE: api/JobSeekers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobSeeker(int id)
        {
            if (_context.JobSeekers == null)
            {
                return NotFound();
            }
            var jobSeeker = await _context.JobSeekers.FindAsync(id);
            if (jobSeeker == null)
            {
                return NotFound();
            }

            _context.JobSeekers.Remove(jobSeeker);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost("JobSeekerLogin")]
        public async Task<ActionResult<JobSeeker>> JobSeekerLogin([FromBody] SignIn admin)
        {
            if (_context.JobSeekers == null)
            {
                return NotFound("Invalid credentials");
            }
            var A_Details = await _context.JobSeekers.Where(x => x.Email == admin.Email && x.Password == admin.Password).Select(x => new JobSeeker()
            {
                JobSeekerId = x.JobSeekerId,
                JobSeekerName=x.JobSeekerName,
                Gender = x.Gender,
                Email = x.Email,
                MobileNumber = x.MobileNumber,
                Skills = x.Skills,
                Password = x.Password

            }).FirstOrDefaultAsync();
            if (A_Details == null)
            {
                return NotFound("Invalid credentials");
            }
            return Ok(A_Details);
        }

        private bool JobSeekerExists(int id)
        {
            return (_context.JobSeekers?.Any(e => e.JobSeekerId == id)).GetValueOrDefault();
        }
    }
}
