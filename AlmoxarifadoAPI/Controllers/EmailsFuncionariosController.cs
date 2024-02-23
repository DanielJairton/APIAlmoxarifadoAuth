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
    public class EmailsFuncionariosController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public EmailsFuncionariosController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/EmailsFuncionarios
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<EmailsFuncionario>>> GetEmailsFuncionarios()
        {
          if (_context.EmailsFuncionarios == null)
          {
              return NotFound();
          }
            return await _context.EmailsFuncionarios.ToListAsync();
        }

        // GET: api/EmailsFuncionarios/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<EmailsFuncionario>> GetEmailsFuncionario(int id)
        {
          if (_context.EmailsFuncionarios == null)
          {
              return NotFound();
          }
            var emailsFuncionario = await _context.EmailsFuncionarios.FindAsync(id);

            if (emailsFuncionario == null)
            {
                return NotFound();
            }

            return emailsFuncionario;
        }

        // PUT: api/EmailsFuncionarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutEmailsFuncionario(int id, EmailsFuncionario emailsFuncionario)
        {
            if (id != emailsFuncionario.IdEmail)
            {
                return BadRequest();
            }

            _context.Entry(emailsFuncionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailsFuncionarioExists(id))
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

        // POST: api/EmailsFuncionarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<EmailsFuncionario>> PostEmailsFuncionario(EmailsFuncionario emailsFuncionario)
        {
          if (_context.EmailsFuncionarios == null)
          {
              return Problem("Entity set 'ApplicationContext.EmailsFuncionarios'  is null.");
          }
            _context.EmailsFuncionarios.Add(emailsFuncionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmailsFuncionario", new { id = emailsFuncionario.IdEmail }, emailsFuncionario);
        }

        // DELETE: api/EmailsFuncionarios/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteEmailsFuncionario(int id)
        {
            if (_context.EmailsFuncionarios == null)
            {
                return NotFound();
            }
            var emailsFuncionario = await _context.EmailsFuncionarios.FindAsync(id);
            if (emailsFuncionario == null)
            {
                return NotFound();
            }

            _context.EmailsFuncionarios.Remove(emailsFuncionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmailsFuncionarioExists(int id)
        {
            return (_context.EmailsFuncionarios?.Any(e => e.IdEmail == id)).GetValueOrDefault();
        }
    }
}
