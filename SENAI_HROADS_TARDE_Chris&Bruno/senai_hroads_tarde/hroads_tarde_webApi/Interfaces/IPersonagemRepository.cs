using hroads_tarde_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hroads_tarde_webApi.Interfaces
{
    interface IPersonagemRepository
    {
        List<Personagem> ListarTodos();

        Personagem ListarPorId(int id);

        void Cadastrar(Personagem novoPerso);

        void Deletar(int id);

        void Atualizar(int id, Personagem persoAtt);

    }
}