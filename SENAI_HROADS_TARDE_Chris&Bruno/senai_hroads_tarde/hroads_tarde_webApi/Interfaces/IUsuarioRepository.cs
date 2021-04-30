using hroads_tarde_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hroads_tarde_webApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> ListarTodos();

        Usuario ListarPorId(int id);

        List<Usuario> ListarComUsuario();

        Usuario BuscarPorEmailESenha(string email, string senha);

        void Cadastrar(Usuario novoUsuario);

        void Deletar(int id);

        void Atualizar(int id, Usuario usuarioAtt);


    }
}
