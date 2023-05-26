using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceDemografi.Models;

namespace ServiceDemografi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemografiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DemografiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Demografi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Demografi>>> GetDemografis()
        {
            return await _context.Demografis.ToListAsync();
        }

        // GET: api/Demografi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Demografi>> GetDemografi(int id)
        {
            var demografi = await _context.Demografis.FindAsync(id);

            if (demografi == null)
            {
                return NotFound();
            }

            return demografi;
        }

        // PUT: api/Demografi/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDemografi(int id, Demografi demografi)
        {
            if (id != demografi.Id)
            {
                return BadRequest();
            }

            _context.Entry(demografi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DemografiExists(id))
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

        // POST: api/Demografi
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Demografi>> PostDemografi(Demografi demografi)
        {
            _context.Demografis.Add(demografi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDemografi", new { id = demografi.Id }, demografi);
        }

        // DELETE: api/Demografi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Demografi>> DeleteDemografi(int id)
        {
            var demografi = await _context.Demografis.FindAsync(id);
            if (demografi == null)
            {
                return NotFound();
            }

            _context.Demografis.Remove(demografi);
            await _context.SaveChangesAsync();

            return demografi;
        }

        private bool DemografiExists(int id)
        {
            return _context.Demografis.Any(e => e.Id == id);
        }
    }
}
