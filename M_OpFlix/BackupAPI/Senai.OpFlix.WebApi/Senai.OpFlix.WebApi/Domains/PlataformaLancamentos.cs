using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class PlataformaLancamentos
    {
        public int IdPlataformaLancamentos { get; set; }
        public int? IdPlataforma { get; set; }
        public int? IdLancamento { get; set; }

        public Lancamentos IdLancamentoNavigation { get; set; }
        public Plataformas IdPlataformaNavigation { get; set; }
    }
}
