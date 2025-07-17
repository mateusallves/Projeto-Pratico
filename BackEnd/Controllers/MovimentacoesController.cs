using CRUD_4t.Entities;
using CRUD_4t.Models;
using CRUD_4t.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRUD_4t.Controllers
{
    [ApiController]
    [Route("api/movimentacoes")]
    public class MovimentacoesController : ControllerBase
    {
        private readonly dbEntity _contexto;

        public MovimentacoesController(dbEntity contexto)
            =>_contexto = contexto;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovimentacaoDTO>>> Get()
        {
            var movimentacoes = await _contexto.Movimentacoes
                .Include(m => m.Fazenda)
                .Include(m => m.Operacao)
                .Include(m => m.Produtor)
                .ToListAsync();
            var movimentacoesDTO = movimentacoes.Select(m => new MovimentacaoDTO{
                Cod_movimentacao = m.Cod_movimentacao,
                Cod_Fazenda = m.Cod_Fazenda,
                Cod_Produtor = m.Cod_Produtor,
                Cod_Operacao = m.Cod_Operacao,
                Data = m.data
            });
            return Ok(movimentacoesDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MovimentacaoDTO>> Get(int id)
        {
            var mov = await _contexto.Movimentacoes
                .Include(m => m.Fazenda)
                .Include(m => m.Operacao)
                .Include(m => m.Produtor)
                .FirstOrDefaultAsync(m => m.Cod_movimentacao== id);

            if (mov == null) return NotFound();
            var movimentacaoDTO = new MovimentacaoDTO{
                Cod_movimentacao = mov.Cod_movimentacao,
                Cod_Fazenda = mov.Cod_Fazenda,
                Cod_Produtor = mov.Cod_Produtor,
                Cod_Operacao = mov.Cod_Operacao,
                Data = mov.data
            };
            return Ok(movimentacaoDTO);
        }
        [HttpPost()]
        public async Task<ActionResult<MovimentacaoDTO>> Post(MovimentacaoDTO movimentacaoDTO)
        {
            var movimentacao = new Movimentacao{
                Cod_Fazenda = movimentacaoDTO.Cod_Fazenda,
                Cod_Produtor = movimentacaoDTO.Cod_Produtor,
                Cod_Operacao = movimentacaoDTO.Cod_Operacao,
                data = movimentacaoDTO.Data
            };
            _contexto.Movimentacoes.Add(movimentacao);
            await _contexto.SaveChangesAsync();
            movimentacaoDTO.Cod_movimentacao = movimentacao.Cod_movimentacao;
            return CreatedAtAction(nameof(Get), new { id = movimentacao.Cod_movimentacao}, movimentacaoDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MovimentacaoDTO>> Put(int id, MovimentacaoDTO movimentacaoDTO)
        {
            if (id != movimentacaoDTO.Cod_movimentacao) return BadRequest();

            var movimentacao = await _contexto.Movimentacoes.FindAsync(id);
            if (movimentacao == null) return NotFound();

            movimentacao.Cod_Fazenda = movimentacaoDTO.Cod_Fazenda;
            movimentacao.Cod_Produtor = movimentacaoDTO.Cod_Produtor;
            movimentacao.Cod_Operacao = movimentacaoDTO.Cod_Operacao;
            movimentacao.data = movimentacaoDTO.Data;
            
            _contexto.Entry(movimentacao).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var mov = await _contexto.Movimentacoes.FindAsync(id);
            if (mov == null) return NotFound();
            _contexto.Movimentacoes.Remove(mov);
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}
