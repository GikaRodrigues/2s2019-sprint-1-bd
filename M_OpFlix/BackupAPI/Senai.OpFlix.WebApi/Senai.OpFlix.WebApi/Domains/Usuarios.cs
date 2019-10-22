using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Favoritos = new HashSet<Favoritos>();
        }

        public int IdUsuarios { get; set; }
        public string Nome { get; set; }
        public int Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Permissao { get; set; }

        public ICollection<Favoritos> Favoritos { get; set; }
    }
}
