using hroads_tarde_webApi.Contexts;
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
    public class HabilidadeController : ControllerBase
    {
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        public HabilidadeController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        /// <summary>
        /// O usuário poderá ver todas as habilidades presentes até o momento, qualquer um pode realizar essa ação.
        /// </summary>
        /// <returns>Uma lista com as habilidades</returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_habilidadeRepository.ListarTodos());
        }

        /// <summary>
        /// Requisição para listar as habilidades com seus respectivos tipos, qualquer um pode realizar essa ação.
        /// </summary>
        /// <returns>Uma lista com habilidades e seus tipos</returns>
        [HttpGet("tipo")]
        public IActionResult ListarComHabilidade()
        {
            return Ok(_habilidadeRepository.ListarComTipo());
        }

        /// <summary>
        /// Requisição para excluir uma habilidade existente, apenas administradores poderão realizar essa ação.
        /// </summary>
        /// <param name="id">id do objeto que será deletado</param>
        /// <returns>Um Status Code 204 (No Content) informando que foi deletado</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _habilidadeRepository.Deletar(id);

            return StatusCode(204);
        }

        /// <summary>
        /// O usuário poderá procurar uma habilidade de acordo com o ID dela, qualquer um pode realizar essa ação.
        /// </summary>
        /// <param name="id">id da habilidade que será buscada</param>
        /// <returns>a habilidade buscada</returns>
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            return Ok(_habilidadeRepository.ListarPorId(id));
        }

        /// <summary>
        /// Requisição para cadastrar uma nova habilidade, apenas administradores poderão realizar essa ação.
        /// </summary>
        /// <param name="novaHabilidade">informação da nova habilidade que será cadastrada</param>
        /// <returns>Um Status Code 201 (Created) informando que foi criado</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Register(Habilidade novaHabilidade)
        {
            _habilidadeRepository.Cadastrar(novaHabilidade);

            return StatusCode(201);
        }

        /// <summary>
        /// Requisição para atualizar uma habilidade existente, apenas administradores poderão realizar essa ação.
        /// </summary>
        /// <param name="id">id da habilidade que será atualizada</param>
        /// <param name="habilidadeAtt">novas informações da habilidade para atualizar</param>
        /// <returns>Um status code 204</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, Habilidade habilidadeAtt)
        {
            _habilidadeRepository.Atualizar(id, habilidadeAtt);

            return StatusCode(204);
        }
    }
}
