using Senai_Filmes_webApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai_Filmes_webApi.Repositories;
using Senai_Filmes_webApi.Domains;

/// <summary>
/// Controller responsavel pelos endpoints referentes aos generos
/// </summary>
namespace Senai_Filmes_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {/// <summary>
     /// O objeto _GeneroRepository que irá receber todos os metodos definidos na interface IGeneroRepository
     /// </summary>
        private IGeneroRepository _generoRepository { get; set; }
        /// <summary>
        /// Instancia o objeto _generoRepository para que haja a referencia aos metodos no repositorio
        /// </summary>
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }
        /// <summary>
        /// lista todos os generos
        /// </summary>
        /// <returns>uma lista de generos e um status code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<GeneroDomain> ListaGeneros = _generoRepository.ListarTodos();
            return Ok(ListaGeneros);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GeneroDomain GeneroBuscado = _generoRepository.BuscarPorId(id);
            if (GeneroBuscado == null)
            {
                return NotFound("Nenhum genero encontrado amigo!");
            }
            return Ok(GeneroBuscado);
        }

        /// <summary>
        /// Cadastrar um novo Genero
        /// </summary>
        /// <param name="novoGenero"></param>
        /// <returns>status code 201-created</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            _generoRepository.Cadastrar(novoGenero);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _generoRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateByUrl(int id, GeneroDomain generoAtualizado )
        {
            GeneroDomain generoBuscado  = _generoRepository.BuscarPorId(id);
            if (generoBuscado == null)
            {
                return NotFound("Nenhum genero encontrado amigo!");
            }
            try
            {
                 _generoRepository.AtualizaIdUrl(id,generoAtualizado);
                return NoContent();
            }
            catch (Exception codErro)
            {

                return BadRequest(codErro);
            }
            
        }
    }
}
