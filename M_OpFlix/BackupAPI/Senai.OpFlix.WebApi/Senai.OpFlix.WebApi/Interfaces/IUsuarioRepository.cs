﻿using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuarios> Listar();

        Usuarios BuscarPorId (int id);

        void Cadastrar (Usuarios usuario);

        void Atualizar (Usuarios usuario);

        void Deletar(int id);
    }
}
