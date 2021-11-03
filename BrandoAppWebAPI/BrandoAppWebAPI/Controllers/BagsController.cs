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
    public class BagsController : ControllerBase
    {
        private readonly BrandoAppContext _context;

        public BagsController(BrandoAppContext context)
        {
            _context = context;
        }

        // GET: api/Bags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bag>>> GetBags()
        {
            return await _context.Bags.ToListAsync();
        }

        // GET: api/Bags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bag>> GetBag(int id)
        {
            var bag = await _context.Bags.FindAsync(id);

            if (bag == null)
            {
                return NotFound();
            }

            return bag;
        }

        //Get: api/BookList/category/One
        [HttpGet("BagsController/{categoryName}")]
        public async Task<ActionResult<IEnumerable<Bag>>> GetBagByCategory(string categoryName)
        {
            var bag = await _context.Bags.Where(p => p.Description == categoryName).ToListAsync();

            if (bag == null)
            {
                return NotFound();
            }

            return bag;
        }


        // PUT: api/Bags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBag(int id, Bag bag)
        {
            if (id != bag.Id)
            {
                return BadRequest();
            }

            _context.Entry(bag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BagExists(id))
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

        // POST: api/Bags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bag>> PostBag(Bag bag)
        {
            _context.Bags.Add(bag);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BagExists(bag.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBag", new { id = bag.Id }, bag);
        }

        // DELETE: api/Bags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBag(int id)
        {
            var bag = await _context.Bags.FindAsync(id);
            if (bag == null)
            {
                return NotFound();
            }

            _context.Bags.Remove(bag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BagExists(int id)
        {
            return _context.Bags.Any(e => e.Id == id);
        }
    }
}
