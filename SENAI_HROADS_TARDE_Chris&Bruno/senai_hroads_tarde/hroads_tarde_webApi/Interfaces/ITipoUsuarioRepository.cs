using hroads_tarde_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hroads_tarde_webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> ListarTodos();

        TipoUsuario ListarPorId(int id);

        List<TipoUsuario> ListarComUsuario();

        void Cadastrar(TipoUsuario novoTipo);

        void Deletar(int id);

        void Atualizar(int id, TipoUsuario tipoAtt);
    }
}
