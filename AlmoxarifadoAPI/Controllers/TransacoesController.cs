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
    public class TransacoesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TransacoesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Transacoes
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Transaco>>> GetTransacoes()
        {
          if (_context.Transacoes == null)
          {
              return NotFound();
          }
            return await _context.Transacoes.ToListAsync();
        }

        // GET: api/Transacoes/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Transaco>> GetTransaco(int id)
        {
          if (_context.Transacoes == null)
          {
              return NotFound();
          }
            var transaco = await _context.Transacoes.FindAsync(id);

            if (transaco == null)
            {
                return NotFound();
            }

            return transaco;
        }

        // PUT: api/Transacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutTransaco(int id, Transaco transaco)
        {
            if (id != transaco.IdTransacao)
            {
                return BadRequest();
            }

            _context.Entry(transaco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransacoExists(id))
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

        // POST: api/Transacoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Transaco>> PostTransaco(Transaco transaco)
        {
          if (_context.Transacoes == null)
          {
              return Problem("Entity set 'ApplicationContext.Transacoes'  is null.");
          }
            _context.Transacoes.Add(transaco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransaco", new { id = transaco.IdTransacao }, transaco);
        }

        // DELETE: api/Transacoes/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTransaco(int id)
        {
            if (_context.Transacoes == null)
            {
                return NotFound();
            }
            var transaco = await _context.Transacoes.FindAsync(id);
            if (transaco == null)
            {
                return NotFound();
            }

            _context.Transacoes.Remove(transaco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransacoExists(int id)
        {
            return (_context.Transacoes?.Any(e => e.IdTransacao == id)).GetValueOrDefault();
        }
    }
}
