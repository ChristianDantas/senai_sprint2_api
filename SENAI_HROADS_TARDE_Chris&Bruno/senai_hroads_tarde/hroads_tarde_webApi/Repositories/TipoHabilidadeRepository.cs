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
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        hroadsContext ctx = new hroadsContext();
        public void Atualizar(int id, TipoHabilidade tipoAtt)
        {
            TipoHabilidade tipoBuscado = ctx.TipoHabilidades.Find(id);

            if (tipoAtt.NomeTipo != null)
            {
                tipoBuscado.NomeTipo = tipoAtt.NomeTipo;
            }

            ctx.SaveChanges();
        }

        public void Cadastrar(TipoHabilidade novoTipo)
        {
            ctx.TipoHabilidades.Add(novoTipo);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoHabilidade tipoBuscado = ctx.TipoHabilidades.Find(id);

            ctx.TipoHabilidades.Remove(tipoBuscado);

            ctx.SaveChanges();
        }

        public List<TipoHabilidade> ListarComHabilidade()
        {
            return ctx.TipoHabilidades.Include(t => t.Habilidades).ToList();
        }

        public TipoHabilidade ListarPorId(int id)
        {
            return ctx.TipoHabilidades.FirstOrDefault(t => t.IdTipo == id);
        }

        public List<TipoHabilidade> ListarTodos()
        {
            return ctx.TipoHabilidades.ToList();
        }
    }
}
