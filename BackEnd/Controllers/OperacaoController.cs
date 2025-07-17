using CRUD_4t.Entities;
using CRUD_4t.Models;
using CRUD_4t.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_4t.Controllers
{
    [ApiController]
    [Route("api/operacoes")]
    public class OperacaoController : ControllerBase
    {
        private readonly dbEntity _contexto;

        public OperacaoController(dbEntity contexto) => _contexto = contexto;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperacaoDTO>>> Get(){
            var operacoes = await _contexto.Operacoes.ToListAsync();
            var operacoesDTO = operacoes.Select(o => new OperacaoDTO{
                Cod_Operacao = o.Cod_Operacao,
                Descricao = o.Descricao
            });
            return Ok(operacoesDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OperacaoDTO>> Get(int id)
        {
            var op = await _contexto.Operacoes.FindAsync(id);
            if (op == null) return NotFound();
            var operacaoDTO = new OperacaoDTO{
                Cod_Operacao = op.Cod_Operacao,
                Descricao = op.Descricao
            };
            return Ok(operacaoDTO);
        }
        [HttpPost()]
        public async Task<ActionResult<OperacaoDTO>> Post(OperacaoDTO operacaoDTO)
        {
            var operacao = new Operacao{
                Descricao = operacaoDTO.Descricao
            };
            _contexto.Operacoes.Add(operacao);
            await _contexto.SaveChangesAsync();
            operacaoDTO.Cod_Operacao = operacao.Cod_Operacao;
            return CreatedAtAction(nameof(Get), new { id = operacao.Cod_Operacao }, operacaoDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OperacaoDTO>> Put(int id, OperacaoDTO operacaoDTO)
        {
            if(id != operacaoDTO.Cod_Operacao) return BadRequest();
            var operacao = await _contexto.Operacoes.FindAsync(id);
            if (operacao == null) return NotFound();
            operacao.Descricao = operacaoDTO.Descricao;
            _contexto.Entry(operacao).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var op = await _contexto.Operacoes.FindAsync(id);
            if (op == null) return NotFound();
            _contexto.Operacoes.Remove(op);
            await _contexto.SaveChangesAsync(); 
            return NoContent();
        }
    }
}
