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
    public class SongsTablesController : ControllerBase
    {
        private readonly MxPlayerdbContext _context;

        public SongsTablesController(MxPlayerdbContext context)
        {
            _context = context;
        }

        // GET: api/SongsTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongsTable>>> GetSongsTable()
        {
            return await _context.SongsTable.ToListAsync();
        }

        // GET: api/SongsTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongsTable>> GetSongsTable(int id)
        {
            var songsTable = await _context.SongsTable.FindAsync(id);

            if (songsTable == null)
            {
                return NotFound();
            }

            return songsTable;
        }

        // PUT: api/SongsTables/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongsTable(int id, SongsTable songsTable)
        {
            if (id != songsTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(songsTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongsTableExists(id))
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

        // POST: api/SongsTables
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SongsTable>> PostSongsTable(SongsTable songsTable)
        {
            _context.SongsTable.Add(songsTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSongsTable", new { id = songsTable.Id }, songsTable);
        }

        // DELETE: api/SongsTables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SongsTable>> DeleteSongsTable(int id)
        {
            var songsTable = await _context.SongsTable.FindAsync(id);
            if (songsTable == null)
            {
                return NotFound();
            }

            _context.SongsTable.Remove(songsTable);
            await _context.SaveChangesAsync();

            return songsTable;
        }

        private bool SongsTableExists(int id)
        {
            return _context.SongsTable.Any(e => e.Id == id);
        }
    }
}
