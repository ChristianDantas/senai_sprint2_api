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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Requisição para listar todos os usuários, apenas o administrador pode realizar essa ação 
        /// </summary>
        /// <returns>uma lista com os usuários</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_usuarioRepository.ListarTodos());
        }

        /// <summary>
        /// Requisição para buscar um usuário de acordo com seu id, apenas o administrador pode realizar essa ação.
        /// </summary>
        /// <param name="id">id do usuário que será buscado</param>
        /// <returns>O usuário buscado</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            return Ok(_usuarioRepository.ListarPorId(id));
        }

        /// <summary>
        /// Requisição para listar todos os usuários com os seus tipos, apenas o administrador pode realizar essa ação.
        /// </summary>
        /// <returns>uma lista com usuários e seus tipos de usuário</returns>
        [Authorize(Roles = "1")]
        [HttpGet("tipoUsuario")]
        public IActionResult ListarComTipo()
        {
            return Ok(_usuarioRepository.ListarComUsuario());
        }

        /// <summary>
        /// Requisição para cadastrar um usuário novo, qualquer um pode realizar essa ação.
        /// </summary>
        /// <param name="novoUsuario">informações do novo usuário</param>
        /// <returns>Um status code 201 (Created)</returns>
        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Requisição para atualizar um usuário existente, apenas o administrador pode fazer isso.
        /// </summary>
        /// <param name="id">id do usuário que será atualizado</param>
        /// <param name="usuarioAtt">novas informações do usuário.</param>
        /// <returns>Um status code 204 (no Content)</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario usuarioAtt)
        {
            _usuarioRepository.Atualizar(id, usuarioAtt);

            return StatusCode(204);
        }

        /// <summary>
        /// Requisição para deletar uma conta existente, apenas um administrador pode fazer isso.
        /// </summary>
        /// <param name="id">id da conta que será deletada</param>
        /// <returns>Um status code 204 (No Content)</returns>
        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _usuarioRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
