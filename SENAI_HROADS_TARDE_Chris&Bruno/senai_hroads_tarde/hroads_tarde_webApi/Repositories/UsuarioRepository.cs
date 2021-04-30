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
    public class UsuarioRepository : IUsuarioRepository
    {
        hroadsContext ctx = new hroadsContext();
        public void Atualizar(int id, Usuario usuarioAtt)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            if (usuarioAtt.Email != null)
            {
                usuarioBuscado.Email = usuarioAtt.Email;
            }

            if (usuarioAtt.Senha != null)
            {
                usuarioBuscado.Senha = usuarioAtt.Senha;
            }

            ctx.SaveChanges();
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            ctx.Usuarios.Remove(usuarioBuscado);
        }

        public List<Usuario> ListarComUsuario()
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).ToList();
        }

        public Usuario ListarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
