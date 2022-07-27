using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocalizaApi.Models;

namespace LocalizaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly BancoDadosContext _context;

        public ClientesController(BancoDadosContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Gettab_Cliente()
        {
          if (_context.tab_Cliente == null)
          {
              return NotFound();
          }
            return await _context.tab_Cliente.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
          if (_context.tab_Cliente == null)
          {
              return NotFound();
          }
            var cliente = await _context.tab_Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        [HttpGet("{login}")]
        public async Task<ActionResult<Cliente>> GetClienteAcesso(string login, string senha)
        {
            try
            {
                if (_context.tab_Cliente == null)
                {
                    return NotFound();
                }

                senha = Functions.Criptografia.Descriptografar(senha);
                var cliente = await _context.tab_Cliente.Where(c => c.Nome == login).Where(c => c.Senha == senha).ToListAsync();

                if (cliente == null)
                {
                    return NotFound();
                }

                return cliente[0];
            }

            catch (Exception ex)
            {
                return Problem($"Erro ao tentar acessar: {ex.Message}");
            }
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id_Cliente)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            try
            {
                if (_context.tab_Cliente == null)
                {
                    return Problem("Entity set 'BancoDadosContext.tab_Cliente'  is null.");
                }

                cliente.Senha = Functions.Criptografia.Criptografar(cliente.Senha);

                _context.tab_Cliente.Add(cliente);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCliente", new { id = cliente.Id_Cliente }, cliente);
            }
            catch (Exception ex)
            {
                return Problem($"Erro ao tentar incluir um novo cliente: {ex.Message}");
            }
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            if (_context.tab_Cliente == null)
            {
                return NotFound();
            }
            var cliente = await _context.tab_Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.tab_Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return (_context.tab_Cliente?.Any(e => e.Id_Cliente == id)).GetValueOrDefault();
        }
    }
}
