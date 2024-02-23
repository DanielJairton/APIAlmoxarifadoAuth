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
    public class ItensController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ItensController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Itens
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Iten>>> GetItens()
        {
          if (_context.Itens == null)
          {
              return NotFound();
          }
            return await _context.Itens.ToListAsync();
        }

        // GET: api/Itens/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Iten>> GetIten(int id)
        {
          if (_context.Itens == null)
          {
              return NotFound();
          }
            var iten = await _context.Itens.FindAsync(id);

            if (iten == null)
            {
                return NotFound();
            }

            return iten;
        }

        // PUT: api/Itens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutIten(int id, Iten iten)
        {
            if (id != iten.IdItem)
            {
                return BadRequest();
            }

            _context.Entry(iten).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItenExists(id))
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

        // POST: api/Itens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Iten>> PostIten(Iten iten)
        {
          if (_context.Itens == null)
          {
              return Problem("Entity set 'ApplicationContext.Itens'  is null.");
          }
            _context.Itens.Add(iten);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIten", new { id = iten.IdItem }, iten);
        }

        // DELETE: api/Itens/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteIten(int id)
        {
            if (_context.Itens == null)
            {
                return NotFound();
            }
            var iten = await _context.Itens.FindAsync(id);
            if (iten == null)
            {
                return NotFound();
            }

            _context.Itens.Remove(iten);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItenExists(int id)
        {
            return (_context.Itens?.Any(e => e.IdItem == id)).GetValueOrDefault();
        }
    }
}
