using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Plataformas
    {
        public Plataformas()
        {
            PlataformaLancamentos = new HashSet<PlataformaLancamentos>();
        }

        public int IdPlataforma { get; set; }
        public string Plataforma { get; set; }

        public ICollection<PlataformaLancamentos> PlataformaLancamentos { get; set; }
    }
}
