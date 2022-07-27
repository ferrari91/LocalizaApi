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
    public class VeiculosController : ControllerBase
    {
        private readonly BancoDadosContext _context;

        public VeiculosController(BancoDadosContext context)
        {
            _context = context;
        }

        // GET: api/Veiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculos>>> Gettab_Veiculo()
        {
          if (_context.tab_Veiculo == null)
          {
              return NotFound();
          }
            return await _context.tab_Veiculo.ToListAsync();
        }

        // GET: api/Veiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculos>> GetVeiculos(int id)
        {
          if (_context.tab_Veiculo == null)
          {
              return NotFound();
          }
            var veiculos = await _context.tab_Veiculo.FindAsync(id);

            if (veiculos == null)
            {
                return NotFound();
            }

            return veiculos;
        }

        // PUT: api/Veiculos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeiculos(int id, Veiculos veiculos)
        {
            if (id != veiculos.Id_Veiculo)
            {
                return BadRequest();
            }

            _context.Entry(veiculos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeiculosExists(id))
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

        // POST: api/Veiculos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Veiculos>> PostVeiculos(Veiculos veiculos)
        {
          if (_context.tab_Veiculo == null)
          {
              return Problem("Entity set 'BancoDadosContext.tab_Veiculo'  is null.");
          }
            _context.tab_Veiculo.Add(veiculos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVeiculos", new { id = veiculos.Id_Veiculo }, veiculos);
        }

        // DELETE: api/Veiculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeiculos(int id)
        {
            if (_context.tab_Veiculo == null)
            {
                return NotFound();
            }
            var veiculos = await _context.tab_Veiculo.FindAsync(id);
            if (veiculos == null)
            {
                return NotFound();
            }

            _context.tab_Veiculo.Remove(veiculos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VeiculosExists(int id)
        {
            return (_context.tab_Veiculo?.Any(e => e.Id_Veiculo == id)).GetValueOrDefault();
        }
    }
}
