using hroads_tarde_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hroads_tarde_webApi.Interfaces
{
    interface IHabilidadeRepository
    {
        List<Habilidade> ListarTodos();

        Habilidade ListarPorId(int id);

        void Cadastrar(Habilidade novaHabilidade);

        void Deletar(int id);

        void Atualizar(int id, Habilidade habilidadeAtt);

        List<Habilidade> ListarComTipo();
    }
}
