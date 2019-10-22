using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Veiculos
    {
        public Veiculos()
        {
            Lancamentos = new HashSet<Lancamentos>();
        }

        public int IdVeiculo { get; set; }
        public string Veiculo { get; set; }

        public ICollection<Lancamentos> Lancamentos { get; set; }
    }
}
