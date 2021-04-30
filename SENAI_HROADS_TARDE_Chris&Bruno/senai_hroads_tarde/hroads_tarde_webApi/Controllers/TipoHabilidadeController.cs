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
    public class TipoHabilidadeController : ControllerBase
    {
        private ITipoHabilidadeRepository _tipoHabilidade { get; set; }

        public TipoHabilidadeController()
        {
            _tipoHabilidade = new TipoHabilidadeRepository();
        }

        /// <summary>
        /// Requisição para ver todos os tipos de habilidade presentes até o momento, qualquer um pode realizar essa função.
        /// </summary>
        /// <returns>Uma lista dos tipos de habilidade</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipoHabilidade.ListarTodos());
        }

        /// <summary>
        /// Requisição para ver os tipos de habilidade com suas respectivas habilidades, qualquer um pode realizar essa função.
        /// </summary>
        /// <returns>Uma lista dos tipos de habilidade e habilidades</returns>
        [HttpGet("habilidade")]
        public IActionResult ListarHabilidade()
        {
            return Ok(_tipoHabilidade.ListarComHabilidade());
        }

        /// <summary>
        /// Requisição para buscar um tipo de habilidade pelo seu id, qualquer um pode realizar essa função.
        /// </summary>
        /// <param name="id">id do tipo de habilidade que será buscado</param>
        /// <returns>um tipo de habilidade correspondente ao seu id</returns>
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            return Ok(_tipoHabilidade.ListarPorId(id));
        }

        /// <summary>
        /// Requisição para registrar um novo tipo de habilidade, apenas administradores podem realizar essa ação.
        /// </summary>
        /// <param name="novoTipo">informações do novo tipo de habilidade</param>
        /// <returns>Um status code 201 (Created)</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(TipoHabilidade novoTipo)
        {
            _tipoHabilidade.Cadastrar(novoTipo);

            return StatusCode(201);
        }

        /// <summary>
        /// Requisição para atualizar um tipo de habilidade existente, apenas administradores podem realizar essa ação.
        /// </summary>
        /// <param name="id">id do tipo de habilidade que será atualizado</param>
        /// <param name="tipoAtt">informações para atualizar</param>
        /// <returns>Um status code 204 (No Content)</returns>
        [Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult Atualizar(int id, TipoHabilidade tipoAtt)
        {
            _tipoHabilidade.Atualizar(id, tipoAtt);

            return StatusCode(204);
        }

        /// <summary>
        /// Requisição para excluir um tipo de habilidade, apenas administradores podem realizar essa ação. 
        /// </summary>
        /// <param name="id">id do tipo que será deletado</param>
        /// <returns>Um status code 204 (No Content)</returns>
        [Authorize(Roles = "1")]
        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            _tipoHabilidade.Deletar(id);

            return StatusCode(204);
        }

    }
}
