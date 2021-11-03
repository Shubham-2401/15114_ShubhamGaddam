using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrandoAppWebAPI.Models;

namespace BrandoAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TshirtsController : ControllerBase
    {
        private readonly BrandoAppContext _context;

        public TshirtsController(BrandoAppContext context)
        {
            _context = context;
        }

        // GET: api/Tshirts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tshirt>>> GetTshirts()
        {
            return await _context.Tshirts.ToListAsync();
        }

        // GET: api/Tshirts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tshirt>> GetTshirt(int id)
        {
            var tshirt = await _context.Tshirts.FindAsync(id);

            if (tshirt == null)
            {
                return NotFound();
            }

            return tshirt;
        }
        //Get: api/BookList/category/One
        [HttpGet("TshirtsController/{categoryName}")]

        public async Task<ActionResult<IEnumerable<Tshirt>>> GetTshirtByCategory(string categoryName)
        {
            var tshirt = await _context.Tshirts.Where(p => p.Description == categoryName).ToListAsync();

            if (tshirt == null)
            {
                return NotFound();
            }

            return tshirt;
        }

        // PUT: api/Tshirts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTshirt(int id, Tshirt tshirt)
        {
            if (id != tshirt.Id)
            {
                return BadRequest();
            }

            _context.Entry(tshirt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TshirtExists(id))
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

        // POST: api/Tshirts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tshirt>> PostTshirt(Tshirt tshirt)
        {
            _context.Tshirts.Add(tshirt);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TshirtExists(tshirt.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTshirt", new { id = tshirt.Id }, tshirt);
        }

        // DELETE: api/Tshirts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTshirt(int id)
        {
            var tshirt = await _context.Tshirts.FindAsync(id);
            if (tshirt == null)
            {
                return NotFound();
            }

            _context.Tshirts.Remove(tshirt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TshirtExists(int id)
        {
            return _context.Tshirts.Any(e => e.Id == id);
        }
    }
}
