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
        private IGeneroRepository _generoRepository { get; set;}
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
    }
}
