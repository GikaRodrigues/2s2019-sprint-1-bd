using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Formatos
    {
        public Formatos()
        {
            Lancamentos = new HashSet<Lancamentos>();
        }

        public byte IdFormato { get; set; }
        public string Formato { get; set; }

        public ICollection<Lancamentos> Lancamentos { get; set; }
    }
}
