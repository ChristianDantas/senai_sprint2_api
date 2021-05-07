using SpMedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.Interfaces
{
    interface IConsultaRepository
    {
        List<Consulta> Listar();

        Consulta BuscarPorId(int id);

        void Cadastrar(Consulta NovaConsulta);

        void Atualizar(int id, Consulta ConsultaAtualizado);

        void Deletar(int id);

       public List<Consulta> Minhas(int idUsuario, int role);

        void AlterStatus(int id, string Status);
    }
}
