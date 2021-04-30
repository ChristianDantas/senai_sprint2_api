using hroads_tarde_webApi.Domains;
using hroads_tarde_webApi.Interfaces;
using hroads_tarde_webApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.DelegatedAuthorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hroads_tarde_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClasseController : ControllerBase
    {
        private IClasseRepository _classeRepository { get; set; }

        public ClasseController()
        {
            _classeRepository = new ClasseRepository();
        }

        /// <summary>
        /// O usuário poderá ver todas as classes presentes até o momento, qualquer um pode realizar essa ação.
        /// </summary>
        /// <returns>Lista de classes</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_classeRepository.ListarTodos());
        }

        /// <summary>
        /// O usuário poderá procurar uma classe de acordo com o ID dela, qualquer um pode realizar essa ação.
        /// </summary>
        /// <param name="id">id do objeto Classe que será retornado</param>
        /// <returns>Um objeto classe</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_classeRepository.ListarPorId(id));
        }

        /// <summary>
        /// Requisição para cadastrar uma nova classe, apenas administradores poderão realizar essa ação.
        /// </summary>
        /// <param name="novaClasse">Informação da nova classe que será cadastrada</param>
        /// <returns>StatusCode 201 (Created)</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Classe novaClasse)
        {
            _classeRepository.Cadastrar(novaClasse);

            return StatusCode(201);
        }

        /// <summary>
        /// Requisição para atualizar uma classe existente, apenas administradores poderão realizar essa ação.
        /// </summary>
        /// <param name="id">id da classe que será atualizada</param>
        /// <param name="classeAtt">informações da classe atualizada</param>
        /// <returns>Status Code 204 (No Content) informando que a classe foi atualizada.</returns>
        [Authorize(Roles ="1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Classe classeAtt)
        {
            _classeRepository.Atualizar(id, classeAtt);

            return StatusCode(204);
        }

        /// <summary>
        /// Requisição para excluir uma classe existente, apenas administradores poderão realizar essa ação.
        /// </summary>
        /// <param name="id">id do objeto classe que será deletado</param>
        /// <returns>Status Code 204 (No Content) Informando que a classe foi deletada</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _classeRepository.Deletar(id);

            return StatusCode(204);
        }

        /// <summary>
        /// Requisição para listar as classes com seus respectivos personagens, qualquer um pode realizar essa ação.
        /// </summary>
        /// <returns>Uma lista de classes com personagens</returns>
        [HttpGet("personagem")]
        public IActionResult GetChar()
        {
            return Ok(_classeRepository.ListarComPers());
        }
    }
}
