using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Favoritos
    {
        public int IdFavorito { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdLacamentos { get; set; }

        public Lancamentos IdLacamentosNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
