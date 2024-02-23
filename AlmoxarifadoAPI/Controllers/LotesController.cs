using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlmoxarifadoAPI;

//Adicionado para autentificação
using AlmoxarifadoAPI.Data;
using AlmoxarifadoAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace AlmoxarifadoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public LotesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Lotes
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Lote>>> GetLotes()
        {
          if (_context.Lotes == null)
          {
              return NotFound();
          }
            return await _context.Lotes.ToListAsync();
        }

        // GET: api/Lotes/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Lote>> GetLote(int id)
        {
          if (_context.Lotes == null)
          {
              return NotFound();
          }
            var lote = await _context.Lotes.FindAsync(id);

            if (lote == null)
            {
                return NotFound();
            }

            return lote;
        }

        // PUT: api/Lotes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutLote(int id, Lote lote)
        {
            if (id != lote.IdLote)
            {
                return BadRequest();
            }

            _context.Entry(lote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoteExists(id))
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

        // POST: api/Lotes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Lote>> PostLote(Lote lote)
        {
          if (_context.Lotes == null)
          {
              return Problem("Entity set 'ApplicationContext.Lotes'  is null.");
          }
            _context.Lotes.Add(lote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLote", new { id = lote.IdLote }, lote);
        }

        // DELETE: api/Lotes/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteLote(int id)
        {
            if (_context.Lotes == null)
            {
                return NotFound();
            }
            var lote = await _context.Lotes.FindAsync(id);
            if (lote == null)
            {
                return NotFound();
            }

            _context.Lotes.Remove(lote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoteExists(int id)
        {
            return (_context.Lotes?.Any(e => e.IdLote == id)).GetValueOrDefault();
        }
    }
}
