using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface ITipoRepository
    {
        List<Tipos> Listar();

        Tipos BuscarPorId(int id);

        void Cadastrar (Tipos tipo);

        void Atualizar(Tipos tipo);
    }
}
