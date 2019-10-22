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
            /// <summary>
            /// Listas todos os lançamentos
            /// </summary>
            /// <returns>Lista de lançamentos</returns>
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.ToList();
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

        /// <summary>
        /// Atualiza um lançamento
        /// </summary>
        /// <param name="lancamento"></param>
        public void Atualizar(Lancamentos lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Lancamentos lancamentoBuscado = ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == lancamento.IdLancamento);
                lancamentoBuscado.IdCategoria = lancamento.IdCategoria;
                lancamentoBuscado.Titulo = lancamento.Titulo;
                lancamentoBuscado.Sinopse = lancamento.Sinopse;
                lancamentoBuscado.TempoDuracao = lancamento.TempoDuracao;
                lancamentoBuscado.IdFormato = lancamento.IdFormato;
                lancamentoBuscado.IdVeiculos = lancamento.IdVeiculos;
                lancamentoBuscado.DataLancamento = lancamento.DataLancamento;

                ctx.Lancamentos.Update(lancamentoBuscado);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Busca um Lançamento através do ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Lançamento Buscado</returns>
        public Lancamentos BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == id);
            }
        }
        /// <summary>
        /// Exclui um lançamento pelo seu ID
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Lancamentos LancamentoBuscado = ctx.Lancamentos.Find(id);
                ctx.Lancamentos.Remove(LancamentoBuscado);
                ctx.SaveChanges();
            }
        }
    }
}
