using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerHostedWasm.Server.Data;
using ServerHostedWasm.Shared;

namespace ServerHostedWasm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurfboardsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SurfboardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Surfboards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Surfboard>>> GetSurfboard()
        {
            return await _context.Surfboard.ToListAsync();
        }

        // GET: api/Surfboards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Surfboard>> GetSurfboard(int id)
        {
            var surfboard = await _context.Surfboard.FindAsync(id);

            if (surfboard == null)
            {
                return NotFound();
            }

            return surfboard;
        }

        // PUT: api/Surfboards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurfboard(int id, Surfboard surfboard)
        {
            if (id != surfboard.Id)
            {
                return BadRequest();
            }

            _context.Entry(surfboard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurfboardExists(id))
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

        // POST: api/Surfboards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Surfboard>> PostSurfboard(Surfboard surfboard)
        {
            _context.Surfboard.Add(surfboard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSurfboard", new { id = surfboard.Id }, surfboard);
        }

        // DELETE: api/Surfboards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurfboard(int id)
        {
            var surfboard = await _context.Surfboard.FindAsync(id);
            if (surfboard == null)
            {
                return NotFound();
            }

            _context.Surfboard.Remove(surfboard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SurfboardExists(int id)
        {
            return _context.Surfboard.Any(e => e.Id == id);
        }
    }
}
