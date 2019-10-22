using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface IVeiculoRepository
    {
        List<Veiculos> Listar();

        Veiculos BuscarPorId(int id);

        void Cadastrar(Veiculos veiculos);

        void Atualizar(Veiculos veiculos);
    }
}
