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
    public class ShoesController : ControllerBase
    {
        private readonly BrandoAppContext _context;

        public ShoesController(BrandoAppContext context)
        {
            _context = context;
        }

        // GET: api/Shoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shoe>>> GetShoes()
        {
            return await _context.Shoes.ToListAsync();
        }

        // GET: api/Shoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shoe>> GetShoe(int id)
        {
            var shoe = await _context.Shoes.FindAsync(id);

            if (shoe == null)
            {
                return NotFound();
            }

            return shoe;
        }

        //Get: api/BookList/category/One
        [HttpGet("ShoesController/{categoryName}")]
        public async Task<ActionResult<IEnumerable<Shoe>>> GetShoeByCategory(string categoryName)
        {
            var shoe = await _context.Shoes.Where(p => p.Description == categoryName).ToListAsync();

            if (shoe == null)
            {
                return NotFound();
            }

            return shoe;
        }

        // PUT: api/Shoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoe(int id, Shoe shoe)
        {
            if (id != shoe.Id)
            {
                return BadRequest();
            }

            _context.Entry(shoe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoeExists(id))
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

        // POST: api/Shoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Shoe>> PostShoe(Shoe shoe)
        {
            _context.Shoes.Add(shoe);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ShoeExists(shoe.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetShoe", new { id = shoe.Id }, shoe);
        }

        // DELETE: api/Shoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoe(int id)
        {
            var shoe = await _context.Shoes.FindAsync(id);
            if (shoe == null)
            {
                return NotFound();
            }

            _context.Shoes.Remove(shoe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShoeExists(int id)
        {
            return _context.Shoes.Any(e => e.Id == id);
        }
    }
}
