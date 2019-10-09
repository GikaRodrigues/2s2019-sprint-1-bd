using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        public List<Lancamentos> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.ToList();
            }
        }

        public Lancamentos BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == id);
            }
        }

        public void Cadastrar(Lancamentos lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Lancamentos.Add(lancamento);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Lancamentos lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Lancamentos lancamentoBuscado = ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == lancamento.IdLancamento);
                lancamentoBuscado.Titulo = lancamento.Titulo;
                lancamentoBuscado.Sinopse = lancamento.Sinopse;
                lancamentoBuscado.IdCategoria = lancamento.IdCategoria;
                lancamentoBuscado.TempoDeDuracao = lancamento.TempoDeDuracao;
                lancamentoBuscado.IdTipo = lancamento.IdTipo;
                lancamentoBuscado.DataLancamento = lancamento.DataLancamento;
                ctx.Lancamentos.Update(lancamentoBuscado);
                ctx.SaveChanges();
            }
        }
        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Lancamentos.Remove(ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == id));
                ctx.SaveChanges();
            }
        }
    }
}
