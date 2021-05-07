using SpMedicalGroup.Contexts;
using SpMedicalGroup.Domains;
using SpMedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        SPMGContext ctx = new SPMGContext();
        public void Atualizar(int id, Clinica ClinicaAtualizado)
        {
            Clinica ClinicaBuscada = BuscarPorId(id);

            if (ClinicaAtualizado.Cnpj != null)
            {
                ClinicaBuscada.Cnpj = ClinicaAtualizado.Cnpj;
            }

            if (ClinicaAtualizado.Endereco != null)
            {
                ClinicaBuscada.Endereco = ClinicaAtualizado.Endereco;
            }

            if (ClinicaAtualizado.NomeFantasia != null)
            {
                ClinicaBuscada.NomeFantasia = ClinicaAtualizado.NomeFantasia;
            }

            if (ClinicaAtualizado.RazaoSocial != null)
            {
                ClinicaBuscada.RazaoSocial = ClinicaAtualizado.RazaoSocial;
            }

            ctx.Clinicas.Update(ClinicaBuscada);

            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int id)
        {
            return ctx.Clinicas.Find(id);
        }

        public void Cadastrar(Clinica NovaClinica)
        {
            ctx.Clinicas.Add(NovaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Clinicas.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
