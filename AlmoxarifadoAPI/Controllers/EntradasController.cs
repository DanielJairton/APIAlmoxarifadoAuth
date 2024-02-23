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
    public class EntradasController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public EntradasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Entradas
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Entrada>>> GetEntradas()
        {
          if (_context.Entradas == null)
          {
              return NotFound();
          }
            return await _context.Entradas.ToListAsync();
        }

        // GET: api/Entradas/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Entrada>> GetEntrada(int id)
        {
          if (_context.Entradas == null)
          {
              return NotFound();
          }
            var entrada = await _context.Entradas.FindAsync(id);

            if (entrada == null)
            {
                return NotFound();
            }

            return entrada;
        }

        // PUT: api/Entradas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutEntrada(int id, Entrada entrada)
        {
            if (id != entrada.IdEntrada)
            {
                return BadRequest();
            }

            _context.Entry(entrada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntradaExists(id))
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

        // POST: api/Entradas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Entrada>> PostEntrada(Entrada entrada)
        {
          if (_context.Entradas == null)
          {
              return Problem("Entity set 'ApplicationContext.Entradas'  is null.");
          }
            _context.Entradas.Add(entrada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntrada", new { id = entrada.IdEntrada }, entrada);
        }

        // DELETE: api/Entradas/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteEntrada(int id)
        {
            if (_context.Entradas == null)
            {
                return NotFound();
            }
            var entrada = await _context.Entradas.FindAsync(id);
            if (entrada == null)
            {
                return NotFound();
            }

            _context.Entradas.Remove(entrada);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntradaExists(int id)
        {
            return (_context.Entradas?.Any(e => e.IdEntrada == id)).GetValueOrDefault();
        }
    }
}
