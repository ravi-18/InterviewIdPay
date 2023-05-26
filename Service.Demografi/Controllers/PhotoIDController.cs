using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceDemografi.Models;

namespace Service.Demografi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoIDController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PhotoIDController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PhotoID
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotoID>>> GetPhotoIDs()
        {
            return await _context.PhotoIDs.ToListAsync();
        }

        // GET: api/PhotoID/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoID>> GetPhotoID(int id)
        {
            var photoID = await _context.PhotoIDs.FindAsync(id);

            if (photoID == null)
            {
                return NotFound();
            }

            return photoID;
        }

        // PUT: api/PhotoID/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhotoID(int id, PhotoID photoID)
        {
            if (id != photoID.Id)
            {
                return BadRequest();
            }

            _context.Entry(photoID).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoIDExists(id))
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

        // POST: api/PhotoID
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PhotoID>> PostPhotoID(PhotoID photoID)
        {
            _context.PhotoIDs.Add(photoID);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhotoID", new { id = photoID.Id }, photoID);
        }

        // DELETE: api/PhotoID/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PhotoID>> DeletePhotoID(int id)
        {
            var photoID = await _context.PhotoIDs.FindAsync(id);
            if (photoID == null)
            {
                return NotFound();
            }

            _context.PhotoIDs.Remove(photoID);
            await _context.SaveChangesAsync();

            return photoID;
        }

        private bool PhotoIDExists(int id)
        {
            return _context.PhotoIDs.Any(e => e.Id == id);
        }
    }
}
