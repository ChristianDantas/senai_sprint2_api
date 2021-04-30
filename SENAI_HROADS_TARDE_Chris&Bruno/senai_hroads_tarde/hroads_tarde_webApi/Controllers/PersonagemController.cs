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
    public class PersonagemController : ControllerBase
    {
        private IPersonagemRepository _persoRepository { get; set; }

        public PersonagemController()
        {
            _persoRepository = new PersonagemRepository();
        }

        /// <summary>
        /// O usuário poderá ver todos os personagens presentes até o momento, qualquer um pode realizar essa ação.
        /// </summary>
        /// <returns>Uma lista de personagens</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_persoRepository.ListarTodos());
        }

        /// <summary>
        /// Requisição para ver um personagem de acordo com o id, qualquer um pode realizar essa ação.
        /// </summary>
        /// <param name="id">id do personagem que será buscado</param>
        /// <returns>O personagem buscado</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult ListarId(int id)
        {
            return Ok(_persoRepository.ListarPorId(id));
        }

        /// <summary>
        /// Requisição para cadastrar um novo personagem, apenas Jogadores podem realizar essa ação.
        /// </summary>
        /// <param name="novoPersonagem">informações do novo personagem que será criado</param>
        /// <returns>Um status code 201 (Created)</returns>
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Personagem novoPersonagem)
        {
            _persoRepository.Cadastrar(novoPersonagem);

            return StatusCode(201);
        }

        /// <summary>
        /// Requisição para atualizar um personagem existente, apenas jogadores podem fazer essa ação.
        /// </summary>
        /// <param name="id">id do personagem que será atualizado</param>
        /// <param name="persoAtt">informações para o personagem ser atualizado</param>
        /// <returns>Um status code 204 (No Content)</returns>
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Personagem persoAtt)
        {
            _persoRepository.Atualizar(id, persoAtt);

            return StatusCode(204);
        }

        /// <summary>
        /// Requisição para excluir um personagem existente, apenas jogadores podem fazer essa ação.
        /// </summary>
        /// <param name="id">id do personagem que será deletado</param>
        /// <returns>Um status code 204 (No Content)</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _persoRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
