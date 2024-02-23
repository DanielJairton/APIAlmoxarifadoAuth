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
    public class SaidasController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public SaidasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Saidas
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Saida>>> GetSaidas()
        {
          if (_context.Saidas == null)
          {
              return NotFound();
          }
            return await _context.Saidas.ToListAsync();
        }

        // GET: api/Saidas/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Saida>> GetSaida(int id)
        {
          if (_context.Saidas == null)
          {
              return NotFound();
          }
            var saida = await _context.Saidas.FindAsync(id);

            if (saida == null)
            {
                return NotFound();
            }

            return saida;
        }

        // PUT: api/Saidas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutSaida(int id, Saida saida)
        {
            if (id != saida.IdSaida)
            {
                return BadRequest();
            }

            _context.Entry(saida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaidaExists(id))
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

        // POST: api/Saidas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Saida>> PostSaida(Saida saida)
        {
          if (_context.Saidas == null)
          {
              return Problem("Entity set 'ApplicationContext.Saidas'  is null.");
          }
            _context.Saidas.Add(saida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaida", new { id = saida.IdSaida }, saida);
        }

        // DELETE: api/Saidas/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteSaida(int id)
        {
            if (_context.Saidas == null)
            {
                return NotFound();
            }
            var saida = await _context.Saidas.FindAsync(id);
            if (saida == null)
            {
                return NotFound();
            }

            _context.Saidas.Remove(saida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaidaExists(int id)
        {
            return (_context.Saidas?.Any(e => e.IdSaida == id)).GetValueOrDefault();
        }
    }
}
