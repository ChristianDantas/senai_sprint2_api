using hroads_tarde_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hroads_tarde_webApi.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        List<TipoHabilidade> ListarTodos();

        TipoHabilidade ListarPorId(int id);

        List<TipoHabilidade> ListarComHabilidade();

        void Cadastrar(TipoHabilidade novoTipo);

        void Deletar(int id);

        void Atualizar(int id, TipoHabilidade tipoAtt);
    }
}
