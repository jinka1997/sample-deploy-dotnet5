using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Entities;
using Infrastructure;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HogeFugaController : ControllerBase
    {
        private readonly SampleContext _context;

        public HogeFugaController(SampleContext context)
        {
            _context = context;
        }

        // GET: api/HogeFuga
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HogeFuga>>> GetHogeFugas()
        {
            return await _context.HogeFugas.ToListAsync();
        }

        // GET: api/HogeFuga/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HogeFuga>> GetHogeFuga(long id)
        {
            var hogeFuga = await _context.HogeFugas.FindAsync(id);

            if (hogeFuga == null)
            {
                return NotFound();
            }

            return hogeFuga;
        }

        // PUT: api/HogeFuga/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHogeFuga(long id, HogeFuga hogeFuga)
        {
            if (id != hogeFuga.Id)
            {
                return BadRequest();
            }

            _context.Entry(hogeFuga).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HogeFugaExists(id))
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

        // POST: api/HogeFuga
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HogeFuga>> PostHogeFuga(HogeFuga hogeFuga)
        {
            _context.HogeFugas.Add(hogeFuga);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHogeFuga", new { id = hogeFuga.Id }, hogeFuga);
        }

        // DELETE: api/HogeFuga/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHogeFuga(long id)
        {
            var hogeFuga = await _context.HogeFugas.FindAsync(id);
            if (hogeFuga == null)
            {
                return NotFound();
            }

            _context.HogeFugas.Remove(hogeFuga);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HogeFugaExists(long id)
        {
            return _context.HogeFugas.Any(e => e.Id == id);
        }
    }
}
