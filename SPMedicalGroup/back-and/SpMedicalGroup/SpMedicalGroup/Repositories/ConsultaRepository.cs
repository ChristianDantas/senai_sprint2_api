using Microsoft.EntityFrameworkCore;
using SpMedicalGroup.Contexts;
using SpMedicalGroup.Domains;
using SpMedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SPMGContext ctx = new SPMGContext();
        public void AlterStatus(int id, string Status)
        {
            Consulta StatusBuscado = BuscarPorId(id);
            switch (Status)
            {
                //realizada
                case "1":
                    StatusBuscado.IdSituacao = 1;
                    break;
                    //cancelada
                case "2":
                    StatusBuscado.IdSituacao = 2;
                    break;
                    //agendada
                case "3":
                    StatusBuscado.IdSituacao = 3;
                    break;

                default:
                    break;
            }
            ctx.Consultas.Update(StatusBuscado);

            ctx.SaveChanges();
        }

        public void Atualizar(int id, Consulta ConsultaAtualizado)
        {
            Consulta ConsultaBuscado = ctx.Consultas.Find(id);

            if (ConsultaAtualizado.IdMedico != null)
            {
                ConsultaBuscado.IdMedico = ConsultaAtualizado.IdMedico;
            }

            if (ConsultaAtualizado.IdPaciente != null)
            {
                ConsultaBuscado.IdPaciente = ConsultaAtualizado.IdPaciente;
            }

            if (ConsultaAtualizado.IdSituacao != null)
            {
                ConsultaBuscado.IdSituacao = ConsultaAtualizado.IdSituacao;
            }

            if (ConsultaAtualizado.DataConsulta > DateTime.Now)
            {
                ConsultaBuscado.DataConsulta = ConsultaAtualizado.DataConsulta;
            }

            if (ConsultaAtualizado.DescricaoConsulta != null)
            {
                ConsultaBuscado.DescricaoConsulta = ConsultaAtualizado.DescricaoConsulta;
            }

            ctx.Consultas.Update(ConsultaBuscado);

            ctx.SaveChanges();
        }

        public Consulta BuscarPorId(int id)
        {
            return ctx.Consultas.Find(id);
        }

        public void Cadastrar(Consulta NovaConsulta)
        {
            ctx.Consultas.Add(NovaConsulta);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Consultas.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            return ctx.Consultas.ToList();
        }


        
        public List<Consulta> Minhas(int idUsuario, int role)
        {       

            if (role== 2)
            {
                Paciente PacienteBuscado = ctx.Pacientes.FirstOrDefault(c=>c.IdUsuario==idUsuario);
                //Buscar as consultas do paciente atraves do id do paciente
                return ctx.Consultas
                        .Where(c => c.IdPaciente == PacienteBuscado.IdPaciente)
                        .ToList();
            }
            if (role == 3)
            {
                Medico MedicoBuscado = ctx.Medicos.FirstOrDefault(c => c.IdUsuario == idUsuario);
                //Buscar as consultas do medico atraves do id do medico
                return ctx.Consultas
                        .Where(c => c.IdMedico == MedicoBuscado.IdMedico)
                        .ToList();
            }
            return null;
        }
    }
}
