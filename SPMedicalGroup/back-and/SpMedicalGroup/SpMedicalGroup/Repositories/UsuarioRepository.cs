﻿using Microsoft.EntityFrameworkCore;
using SpMedicalGroup.Contexts;
using SpMedicalGroup.Domains;
using SpMedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SPMGContext ctx = new SPMGContext();
        public void Atualizar(int id, Usuario UsuarioAtualizado)
        {
            Usuario UsuarioBuscado = BuscarPorId(id);

            if (UsuarioAtualizado.Email != null)
            {
                UsuarioBuscado.Email = UsuarioAtualizado.Email;
            }

            if (UsuarioAtualizado.Senha != null)
            {
                UsuarioBuscado.Senha = UsuarioAtualizado.Senha;
            }

            if (UsuarioAtualizado.IdTipoU > 0)
            {
                UsuarioBuscado.IdTipoU = UsuarioAtualizado.IdTipoU;
            }

            ctx.Usuarios.Update(UsuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.Find(id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }
        
        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.Include(u => u.IdTipoUNavigation).FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        
    }
}
