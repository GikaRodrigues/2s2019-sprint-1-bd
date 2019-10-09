using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Lancamentos
    {
        public Lancamentos()
        {
            Favoritos = new HashSet<Favoritos>();
            PlataformaLancamentos = new HashSet<PlataformaLancamentos>();
        }

        public int IdLancamento { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public int? IdCategoria { get; set; }
        public TimeSpan TempoDeDuracao { get; set; }
        public int? IdTipo { get; set; }
        public DateTime DataLancamento { get; set; }

        public Categorias IdCategoriaNavigation { get; set; }
        public Tipos IdTipoNavigation { get; set; }
        public ICollection<Favoritos> Favoritos { get; set; }
        public ICollection<PlataformaLancamentos> PlataformaLancamentos { get; set; }
    }
}
