using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuarios BuscarPorEmailESenha (LoginViewModel login)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                // buscar os dados no banco e verificar se este email e senha sao validos
                Usuarios UsuarioBuscado = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (UsuarioBuscado == null)
                {
                    return null;
                }
                return UsuarioBuscado;
            }
        }

        public List<Usuarios> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Usuarios.ToList();
            }
        }

        public Usuarios BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Usuarios.FirstOrDefault(x => x.IdUsuarios == id);
            }
        }

        public void Cadastrar(Usuarios usuario)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Usuarios usuario)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Usuarios usuarioBuscado = ctx.Usuarios.FirstOrDefault(x => x.IdUsuarios == usuario.IdUsuarios);
                usuarioBuscado.Nome = usuario.Nome;
                usuarioBuscado.Cpf = usuario.Cpf;
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Senha = usuario.Senha;
                usuarioBuscado.DataCriacao = usuario.DataCriacao;
                usuarioBuscado.Permissao = usuario.Permissao;
                ctx.Usuarios.Update(usuarioBuscado);
                ctx.SaveChanges();
            }
        }
        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Usuarios.Remove(ctx.Usuarios.FirstOrDefault(x => x.IdUsuarios == id));
                ctx.SaveChanges();
            }
        }
    }
}
