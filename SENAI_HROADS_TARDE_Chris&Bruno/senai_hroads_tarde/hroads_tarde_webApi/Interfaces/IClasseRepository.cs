using hroads_tarde_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hroads_tarde_webApi.Interfaces
{
    interface IClasseRepository
    {
        List<Classe> ListarTodos();

        Classe ListarPorId(int id);

        void Cadastrar(Classe novaClasse);

        void Deletar(int id);

        void Atualizar(int id, Classe classeAtt);

        List<Classe> ListarComPers();
    }
}
