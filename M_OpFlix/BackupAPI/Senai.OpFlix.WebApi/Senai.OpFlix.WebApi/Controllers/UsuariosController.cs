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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(UsuarioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Usuarios Usuario = UsuarioRepository.BuscarPorId(id);
                if (Usuario == null)
                    return NotFound();

                return Ok(Usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Algo de errado não está certo" + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            try
            {
                UsuarioRepository.Cadastrar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Algo de errado não está certo" + ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Usuarios usuario, int id)
        {
            try
            {
                usuario.IdUsuarios = id;
                if (usuario == null)

                    return NotFound();

                UsuarioRepository.Atualizar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Deu erro ai" + ex.Message });
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            UsuarioRepository.Deletar(id);
            return Ok();
        }
    }
}