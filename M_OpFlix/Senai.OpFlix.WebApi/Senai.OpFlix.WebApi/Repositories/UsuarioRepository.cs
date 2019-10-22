using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_OpFlix;User Id=sa;Pwd=132;";

        /// <summary>
        /// Busca uma Usuário através do Email e Senha
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Categoria Buscada</returns>
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Usuarios UsuarioBuscado = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (UsuarioBuscado == null)
                    return null;
                return UsuarioBuscado;
            }
        }
        /// <summary>
        /// Cadastra um usuário comum ou administrador
        /// </summary>
        /// <param name="usuario"></param>
        public void CadastrarAdmin(Usuarios usuario)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Cadastra um usuário comum
        /// </summary>
        /// <param name="usuario"></param>
        public void Cadastrar(Usuarios usuario)
        {
            string Query = "INSERT INTO Usuarios(Nome, Email, Senha, CPF) VALUES (@Nome, @Email, @Senha, @CPF)";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@CPF", usuario.Cpf);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

