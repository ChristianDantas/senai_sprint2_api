using hroads_tarde_webApi.Contexts;
using hroads_tarde_webApi.Domains;
using hroads_tarde_webApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hroads_tarde_webApi.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        hroadsContext ctx = new hroadsContext();

        /// <summary>
        /// teste
        /// </summary>
        /// <param name="id"></param>
        /// <param name="classeAtt"></param>
        public void Atualizar(int id, Classe classeAtt)
        {
            Classe classeBuscada = ctx.Classes.Find(id);

            if (classeAtt.NomeClasse != null)
            {
                classeBuscada.NomeClasse = classeAtt.NomeClasse;
            }

            ctx.Classes.Update(classeBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(Classe novaClasse)
        {
            ctx.Classes.Add(novaClasse);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Classe classeBuscada = ctx.Classes.Find(id);

            ctx.Classes.Remove(classeBuscada);

            ctx.SaveChanges();
        }

        public List<Classe> ListarComPers()
        {
            return ctx.Classes.Include(e => e.Personagens).ToList();
        }

        public Classe ListarPorId(int id)
        {
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == id);
        }

        public List<Classe> ListarTodos()
        {
            return ctx.Classes.ToList();
        }
    }
}
