using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface ICategoriaRepository
    {
        List<Categorias> Listar();

        Categorias BuscarPorId(int id);

        void Cadastrar(Categorias pecas);

        void Atualizar(Categorias pecas);

    }
}
