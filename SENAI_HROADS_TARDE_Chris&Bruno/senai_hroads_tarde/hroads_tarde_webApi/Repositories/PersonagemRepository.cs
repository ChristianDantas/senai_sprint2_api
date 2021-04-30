using hroads_tarde_webApi.Contexts;
using hroads_tarde_webApi.Domains;
using hroads_tarde_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hroads_tarde_webApi.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        hroadsContext ctx = new hroadsContext();
        public void Atualizar(int id, Personagem persoAtt)
        {
            Personagem persoBuscado = ctx.Personagens.Find(id);

            if (persoAtt.NomePersonagem != null)
            {
                persoBuscado.NomePersonagem = persoAtt.NomePersonagem;
            }

            if (persoAtt.CapacidadeMaxvida != null)
            {
                persoBuscado.CapacidadeMaxvida = persoAtt.CapacidadeMaxvida;
            }

            if (persoAtt.CapacidadeMaxmana != null)
            {
                persoBuscado.CapacidadeMaxmana = persoAtt.CapacidadeMaxmana;
            }

            if (persoAtt.DataAtualizacao != null)
            {
                persoBuscado.DataAtualizacao = persoAtt.DataAtualizacao;
            }

            if (persoAtt.DataCriacao != null)
            {
                persoBuscado.DataCriacao = persoAtt.DataCriacao;
            }

            ctx.Personagens.Update(persoBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(Personagem novoPerso)
        {
            ctx.Personagens.Add(novoPerso);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Personagem persoBuscado = ctx.Personagens.Find(id);

            ctx.Personagens.Remove(persoBuscado);

            ctx.SaveChanges();
        }

        public Personagem ListarPorId(int id)
        {
            return ctx.Personagens.FirstOrDefault(p => p.IdPersonagem == id);
        }

        public List<Personagem> ListarTodos()
        {
            return ctx.Personagens.ToList();
        }
    }
}
