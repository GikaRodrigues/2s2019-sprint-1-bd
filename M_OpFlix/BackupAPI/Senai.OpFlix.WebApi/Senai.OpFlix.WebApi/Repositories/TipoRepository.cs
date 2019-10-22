using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class TipoRepository : ITipoRepository
    {
        public List<Tipos> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Tipos.ToList();
            }
        }

        public Tipos BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Tipos.FirstOrDefault(x => x.IdTipo == id);
            }
        }

        public void Cadastrar(Tipos tipo)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Tipos.Add(tipo);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Tipos tipo)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Tipos tipoBuscado = ctx.Tipos.FirstOrDefault(x => x.IdTipo == tipo.IdTipo);
                tipoBuscado.Tipo= tipo.Tipo;
                ctx.Tipos.Update(tipoBuscado);
                ctx.SaveChanges();
            }
        }
    }
}
