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
    public class HabilidadeRepository : IHabilidadeRepository
    {
        hroadsContext ctx = new hroadsContext();
        public void Atualizar(int id, Habilidade habilidadeAtt)
        {
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);

            if (habilidadeAtt.NomeHabilidade != null)
            {
                habilidadeBuscada.NomeHabilidade = habilidadeAtt.NomeHabilidade;
            }

            ctx.Habilidades.Update(habilidadeBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            ctx.Habilidades.Add(novaHabilidade);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);

            ctx.Habilidades.Remove(habilidadeBuscada);

            ctx.SaveChanges();
        }

        public List<Habilidade> ListarComTipo()
        {
            return ctx.Habilidades.Include(h => h.IdTipoNavigation).ToList();
        }

        public Habilidade ListarPorId(int id)
        {
            return ctx.Habilidades.FirstOrDefault(h => h.IdHabilidade == id);
        }

        public List<Habilidade> ListarTodos()
        {
            return ctx.Habilidades.ToList();
        }
    }
}
