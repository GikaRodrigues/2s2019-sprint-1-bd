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
    [Authorize(Roles = "Administrador")]
    [ApiController]
    public class TiposController : ControllerBase
    {
        private ITipoRepository TipoRepository { get; set; }

        public TiposController()
        {
            TipoRepository = new TipoRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(TipoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Tipos tipo = TipoRepository.BuscarPorId(id);
                if (tipo == null)
                    return NotFound();

                return Ok(tipo);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Algo de errado não está certo" + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Tipos tipo)
        {
            try
            {
                TipoRepository.Cadastrar(tipo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Algo de errado não está certo" + ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Tipos tipo, int id)
        {
            try
            {
                tipo.IdTipo = id;
                if (tipo == null)

                    return NotFound();

                TipoRepository.Atualizar(tipo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Deu erro ai" + ex.Message });
            }

        }
    }
}