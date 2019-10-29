using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MxPlayer.Models;

namespace MxPlayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddPlaysController : ControllerBase
    {
        private readonly MxPlayerdbContext _context;

        public AddPlaysController(MxPlayerdbContext context)
        {
            _context = context;
        }

        // GET: api/AddPlays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddPlay>>> GetAddPlay()
        {
            return await _context.AddPlay.ToListAsync();
        }

        // GET: api/AddPlays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddPlay>> GetAddPlay(int id)
        {
            var addPlay = await _context.AddPlay.FindAsync(id);

            if (addPlay == null)
            {
                return NotFound();
            }

            return addPlay;
        }

        // PUT: api/AddPlays/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddPlay(int id, AddPlay addPlay)
        {
            if (id != addPlay.PlayId)
            {
                return BadRequest();
            }

            _context.Entry(addPlay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddPlayExists(id))
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

        // POST: api/AddPlays
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AddPlay>> PostAddPlay(AddPlay addPlay)
        {
            _context.AddPlay.Add(addPlay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddPlay", new { id = addPlay.PlayId }, addPlay);
        }

        // DELETE: api/AddPlays/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AddPlay>> DeleteAddPlay(int id)
        {
            var addPlay = await _context.AddPlay.FindAsync(id);
            if (addPlay == null)
            {
                return NotFound();
            }

            _context.AddPlay.Remove(addPlay);
            await _context.SaveChangesAsync();

            return addPlay;
        }

        private bool AddPlayExists(int id)
        {
            return _context.AddPlay.Any(e => e.PlayId == id);
        }
    }
}
