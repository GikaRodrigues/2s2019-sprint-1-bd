using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        /// <summary>
        /// Listas todos os veículos
        /// </summary>
        /// <returns>Lista de veículos</returns>
        public List<Veiculos> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Veiculos.ToList();
            }
        }

        /// <summary>
        /// Cadastra um veículo
        /// </summary>
        /// <param name="veiculo"></param>
        public void Cadastrar(Veiculos veiculo)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Veiculos.Add(veiculo);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Atualiza um veículo
        /// </summary>
        /// <param name="veiculo"></param>
        public void Atualizar(Veiculos veiculo)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Veiculos veiculoBuscado = ctx.Veiculos.FirstOrDefault(x => x.IdVeiculo == veiculo.IdVeiculo);
                veiculoBuscado.Veiculo = veiculo.Veiculo;
                ctx.Veiculos.Update(veiculoBuscado);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Busca um Veículo através do ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Veículo Buscada</returns>
        public Veiculos BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Veiculos.FirstOrDefault(x => x.IdVeiculo == id);
            }
        }
    }
}
