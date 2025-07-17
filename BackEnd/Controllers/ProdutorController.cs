using CRUD_4t.Entities;
using CRUD_4t.Models;
using CRUD_4t.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_4t.Controllers
{
    [ApiController]
    [Route("api/produtores")]
    public class ProdutorController : ControllerBase
    {
        private readonly dbEntity _contexto;
        public ProdutorController(dbEntity contexto ) { _contexto = contexto; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutorDTO>>> Get()
        {
            var produtores = await _contexto.Produtores.ToListAsync();
            var produtoresDTO = produtores.Select(p => new ProdutorDTO{
                Cod_Produtor = p.Cod_Produtor,
                Nome = p.Nome
            });
            return Ok(produtoresDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutorDTO>> Get(int id)
        {
            var produtor = await _contexto.Produtores.FindAsync(id);
            if (produtor == null) return NotFound();
            var produtorDTO = new ProdutorDTO{
                Cod_Produtor = produtor.Cod_Produtor,
                Nome = produtor.Nome
            };
            return Ok(produtorDTO);
        }
        [HttpPost()]
        public async Task<ActionResult<ProdutorDTO>> Post(ProdutorDTO produtorDTO)
        {
            var produtor = new Produtor{
                Nome = produtorDTO.Nome
            };
            _contexto.Produtores.Add(produtor);
            await _contexto.SaveChangesAsync();
            produtorDTO.Cod_Produtor = produtor.Cod_Produtor;
            return CreatedAtAction(nameof(Get), new { id = produtor.Cod_Produtor }, produtorDTO);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutorDTO>> Put(int id, ProdutorDTO produtorDTO)
        {
            if(id != produtorDTO.Cod_Produtor) return BadRequest();
            var produtor = await _contexto.Produtores.FindAsync(id);
            if (produtor == null) return NotFound();
            produtor.Nome = produtorDTO.Nome;
            _contexto.Entry(produtor).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produtor = await _contexto.Produtores.FindAsync(id);
            if (produtor == null) return NotFound();
            
            _contexto.Produtores.Remove(produtor);
            await _contexto.SaveChangesAsync();
            return NoContent();

        }
    }
}
