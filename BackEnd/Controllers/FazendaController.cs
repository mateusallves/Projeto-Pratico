using CRUD_4t.Entities;
using CRUD_4t.Models;
using CRUD_4t.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_4t.Controllers
{
    [ApiController]
    [Route("api/fazendas")]
    public class FazendaController : ControllerBase
    {
        private readonly dbEntity _contexto;
        public FazendaController(dbEntity contexto) { _contexto = contexto; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FazendaDTO>>> Get()
        {
            var fazendas = await _contexto.Fazendas.ToListAsync();
            var fazendasDTO = fazendas.Select(f => new FazendaDTO
            {
                Cod_fazenda = f.Cod_fazenda,
                Nome = f.Nome,
                Area_HA = f.Area_HA
            });
            return Ok(fazendasDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FazendaDTO>> Get(int id)
        {
            var fazenda = await _contexto.Fazendas.FindAsync(id);
            if (fazenda == null) return NotFound();
            
            var fazendaDTO = new FazendaDTO
            {
                Cod_fazenda = fazenda.Cod_fazenda,
                Nome = fazenda.Nome,
                Area_HA = fazenda.Area_HA
            };
            return Ok(fazendaDTO);
        }
        [HttpPost()]
        public async Task<ActionResult<FazendaDTO>> Post(FazendaDTO fazendaDTO)
        {
            var fazenda = new Fazenda
            {
                Nome = fazendaDTO.Nome,
                Area_HA = fazendaDTO.Area_HA
            };
            
            _contexto.Fazendas.Add(fazenda);
            await _contexto.SaveChangesAsync();
            
            fazendaDTO.Cod_fazenda = fazenda.Cod_fazenda;
            return CreatedAtAction(nameof(Get), new { id = fazenda.Cod_fazenda }, fazendaDTO);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<FazendaDTO>> Put(int id, FazendaDTO fazendaDTO)
        {
            if(id != fazendaDTO.Cod_fazenda) return BadRequest();

            var fazenda = await _contexto.Fazendas.FindAsync(id);
            if (fazenda == null) return NotFound();

            fazenda.Nome = fazendaDTO.Nome;
            fazenda.Area_HA = fazendaDTO.Area_HA;

            _contexto.Entry(fazenda).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var fazenda = await _contexto.Fazendas.FindAsync(id);
            if (fazenda == null) return NotFound();
            
            _contexto.Fazendas.Remove(fazenda);
            await _contexto.SaveChangesAsync();
            return NoContent();

        }
    }
}
