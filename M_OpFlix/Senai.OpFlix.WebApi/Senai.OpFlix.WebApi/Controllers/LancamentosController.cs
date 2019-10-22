using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class LancamentosController : ControllerBase
    {
        private ILancamentoRepository LancamentoRepository { get; set; }

        public LancamentosController()
        {
                LancamentoRepository = new LancamentoRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            {
                return Ok(LancamentoRepository.Listar());
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Lancamentos lancamento)
        {
            try
            {
                LancamentoRepository.Cadastrar(lancamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu algum erro :(" + ex.Message });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Lancamentos Lancamento = LancamentoRepository.BuscarPorId(id);
            if (Lancamento == null)
                return NotFound();
            return Ok(Lancamento);
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(Lancamentos Lancamento, int id)
        {
            Lancamento.IdLancamento = id;
            LancamentoRepository.Atualizar(Lancamento);
            return Ok();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            LancamentoRepository.Deletar(id);
            return Ok();    
        }
    }
}