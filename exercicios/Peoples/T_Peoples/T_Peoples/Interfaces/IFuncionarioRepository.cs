using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_Peoples.Domains;

namespace T_Peoples.Interfaces
{
    interface IFuncionarioRepository
    {
        List<FuncionarioDomain> ListarTodos();

        FuncionarioDomain BuscarPorId(int Id);

        void Cadastrar(FuncionarioDomain NovoFuncionario);

        void AtualizaIdUrl(int id, FuncionarioDomain funcionarioAtualizado);

        void Deletar(int id);
    }
}
