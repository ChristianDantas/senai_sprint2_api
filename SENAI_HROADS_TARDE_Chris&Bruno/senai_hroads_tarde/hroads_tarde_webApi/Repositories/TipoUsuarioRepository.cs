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
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        hroadsContext ctx = new hroadsContext();
        public void Atualizar(int id, TipoUsuario tipoAtt)
        {
            TipoUsuario tipoBuscado = ctx.TipoUsuarios.Find(id);

            if (tipoAtt.TituloTipoUsuario != null)
            {
                tipoBuscado.TituloTipoUsuario = tipoAtt.TituloTipoUsuario;
            }

            ctx.SaveChanges();
        }

        public void Cadastrar(TipoUsuario novoTipo)
        {
            ctx.TipoUsuarios.Add(novoTipo);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoUsuario tipoBuscado = ctx.TipoUsuarios.Find(id);

            ctx.TipoUsuarios.Remove(tipoBuscado);
        }

        public List<TipoUsuario> ListarComUsuario()
        {
            return ctx.TipoUsuarios.Include(t => t.Usuarios).ToList();
        }

        public TipoUsuario ListarPorId(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(t => t.IdTipoUsuario == id);
        }

        public List<TipoUsuario> ListarTodos()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
