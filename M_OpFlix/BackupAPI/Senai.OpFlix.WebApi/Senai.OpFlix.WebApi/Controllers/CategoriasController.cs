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
    public class CategoriasController : ControllerBase
    {
        private ICategoriaRepository CategoriaRepository { get; set; }

        public CategoriasController()
        {
            CategoriaRepository = new CategoriaRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(CategoriaRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Categorias Categoria = CategoriaRepository.BuscarPorId(id);
                if (Categoria == null)
                    return NotFound();

                return Ok(Categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Algo de errado não está certo" + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Categorias categoria)
        {
            try
            {
                CategoriaRepository.Cadastrar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Algo de errado não está certo" + ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Categorias categoria, int id)
        {
            try
            {
                categoria.IdCategoria = id;
                if (categoria == null)

                    return NotFound();

                CategoriaRepository.Atualizar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Algo de errado não está certo" + ex.Message });
            }

        }
    }
}