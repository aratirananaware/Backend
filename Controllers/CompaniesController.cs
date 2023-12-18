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
    public class CompaniesController : ControllerBase
    {
        private readonly JPWContext _context;
        private readonly IMapper _automapper;

        public CompaniesController(JPWContext context , IMapper automapper)
        {
            _context = context;
            _automapper = automapper;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
          if (_context.Companies == null)
          {
              return NotFound();
          }
            return await _context.Companies.ToListAsync();
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
          if (_context.Companies == null)
          {
              return NotFound();
          }
            var company = await _context.Companies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, CompanyDTO company)
        {
            var userProfile = await _context.Companies.FindAsync(id);
            try
            {
                if (userProfile == null)
                {
                    return NotFound();
                }
                _automapper.Map(company, userProfile);
                _context.Entry(userProfile).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(company);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
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

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(CompanyDTO company)
        {
            var user = _automapper.Map<Company>(company);
            _context.Companies.Add(user);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = user.CompanyId }, user);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            if (_context.Companies == null)
            {
                return NotFound();
            }
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost("CompanyLogin")]
        public async Task<ActionResult<Company>> CompanyLogin([FromBody] SignIn admin)
        {
            if (_context.Companies == null)
            {
                return NotFound("Invalid credentials");
            }
            var A_Details = await _context.Companies.Where(x => x.CompanyEmail == admin.Email && x.Password == admin.Password).Select(x => new Company()
            {
                CompanyId = x.CompanyId,
                CompanyName = x.CompanyName,
                CompanyEmail = x.CompanyEmail,
                CompanyPhone = x.CompanyPhone,
                CompanyAddress = x.CompanyAddress,
                CompanyDescription = x.CompanyDescription,
                Password = x.Password

            }).FirstOrDefaultAsync();
            if (A_Details == null)
            {
                return NotFound("Invalid credentials");
            }
            return Ok(A_Details);
        }
        private bool CompanyExists(int id)
        {
            return (_context.Companies?.Any(e => e.CompanyId == id)).GetValueOrDefault();
        }
    }
}
