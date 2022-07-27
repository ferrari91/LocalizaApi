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
    public class Veiculo_ModeloController : ControllerBase
    {
        private readonly BancoDadosContext _context;

        public Veiculo_ModeloController(BancoDadosContext context)
        {
            _context = context;
        }

        // GET: api/Veiculo_Modelo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo_Modelo>>> Gettb_Veiculo_Modelo()
        {
          if (_context.tb_Veiculo_Modelo == null)
          {
              return NotFound();
          }
            return await _context.tb_Veiculo_Modelo.ToListAsync();
        }

        // GET: api/Veiculo_Modelo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo_Modelo>> GetVeiculo_Modelo(int id)
        {
          if (_context.tb_Veiculo_Modelo == null)
          {
              return NotFound();
          }
            var veiculo_Modelo = await _context.tb_Veiculo_Modelo.FindAsync(id);

            if (veiculo_Modelo == null)
            {
                return NotFound();
            }

            return veiculo_Modelo;
        }

        // PUT: api/Veiculo_Modelo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeiculo_Modelo(int id, Veiculo_Modelo veiculo_Modelo)
        {
            if (id != veiculo_Modelo.Id_Marca)
            {
                return BadRequest();
            }

            _context.Entry(veiculo_Modelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Veiculo_ModeloExists(id))
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

        // POST: api/Veiculo_Modelo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Veiculo_Modelo>> PostVeiculo_Modelo(Veiculo_Modelo veiculo_Modelo)
        {
          if (_context.tb_Veiculo_Modelo == null)
          {
              return Problem("Entity set 'BancoDadosContext.tb_Veiculo_Modelo'  is null.");
          }
            _context.tb_Veiculo_Modelo.Add(veiculo_Modelo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVeiculo_Modelo", new { id = veiculo_Modelo.Id_Marca }, veiculo_Modelo);
        }

        // DELETE: api/Veiculo_Modelo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeiculo_Modelo(int id)
        {
            if (_context.tb_Veiculo_Modelo == null)
            {
                return NotFound();
            }
            var veiculo_Modelo = await _context.tb_Veiculo_Modelo.FindAsync(id);
            if (veiculo_Modelo == null)
            {
                return NotFound();
            }

            _context.tb_Veiculo_Modelo.Remove(veiculo_Modelo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Veiculo_ModeloExists(int id)
        {
            return (_context.tb_Veiculo_Modelo?.Any(e => e.Id_Marca == id)).GetValueOrDefault();
        }
    }
}
