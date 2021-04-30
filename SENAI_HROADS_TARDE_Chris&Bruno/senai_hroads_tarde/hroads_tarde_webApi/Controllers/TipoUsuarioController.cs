using hroads_tarde_webApi.Domains;
using hroads_tarde_webApi.Interfaces;
using hroads_tarde_webApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hroads_tarde_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuario { get; set; }
        
        public TipoUsuarioController()
        {
            _tipoUsuario = new TipoUsuarioRepository();
        }
        
        /// <summary>
        /// Requisição para listar todos os tipos de usuários, qualquer um pode realizar essa ação.
        /// </summary>
        /// <returns>Uma lista com os tipos de usuários</returns>
        [Authorize]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_tipoUsuario.ListarTodos());
        }

        /// <summary>
        /// Requisição para listar os tipos de usuários juntamente de seus usuários, qualquer um pode realizar essa ação.
        /// </summary>
        /// <returns>Uma lista com tipo de usuário e seus usuários</returns>
        [Authorize(Roles = "1")]
        [HttpGet("usuario")]
        public IActionResult ListarTodosUsuarios()
        {
            return Ok(_tipoUsuario.ListarComUsuario());
        }

        /// <summary>
        /// Requisição para buscar um tipo de usuário pelo seu id, qualquer um pode realizar essa ação.
        /// </summary>
        /// <param name="id">id do tipo de usuario que será buscado</param>
        /// <returns>um tipo de usuário</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            return Ok(_tipoUsuario.ListarPorId(id));
        }

        /// <summary>
        /// Requisição para cadastrar um novo tipo de usuário, apenas administradores podem realizar essa ação.
        /// </summary>
        /// <param name="novoTipo">Informações do novo tipo de usuário</param>
        /// <returns>Um status code 201 (created)</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario novoTipo)
        {
            _tipoUsuario.Cadastrar(novoTipo);

            return StatusCode(201);
        }

        /// <summary>
        /// Requisição para atualizar um tipo de usuário, apenas administradores podem fazer isso.
        /// </summary>
        /// <param name="id">id do tipo que será atualizado</param>
        /// <param name="tipoAtt">novas informações do tipo de usuário</param>
        /// <returns>um status code 204 (No Content)</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, TipoUsuario tipoAtt)
        {
            _tipoUsuario.Atualizar(id, tipoAtt);

            return StatusCode(204);
        }


        /// <summary>
        /// Requisição para deletar um tipo de usuário, apenas administradores podem realizar essa função.
        /// </summary>
        /// <param name="id">id do tipo de usuario que será deletado</param>
        /// <returns>Um statud code 204 (No Content)</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _tipoUsuario.Deletar(id);

            return StatusCode(204);
        }

    }
}
