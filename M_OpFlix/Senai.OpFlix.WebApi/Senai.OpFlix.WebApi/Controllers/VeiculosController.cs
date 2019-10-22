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
    [Authorize(Roles = "ADMINISTRADOR")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private IVeiculoRepository VeiculoRepository { get; set; }

        public VeiculosController()
        {
            VeiculoRepository = new VeiculoRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            {
                return Ok(VeiculoRepository.Listar());
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Veiculos veiculo)
        {
            try
            {
                VeiculoRepository.Cadastrar(veiculo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu algum erro :(" + ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Veiculos Veiculo = VeiculoRepository.BuscarPorId(id);
            if (Veiculo == null)
                return NotFound();
            return Ok(Veiculo);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Veiculos Veiculo, int id)
        {
            Veiculo.IdVeiculo = id;
            VeiculoRepository.Atualizar(Veiculo);
            return Ok();

        }
    }
}