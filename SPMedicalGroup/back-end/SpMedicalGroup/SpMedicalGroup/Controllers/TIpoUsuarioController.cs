using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SpMedicalGroup.Domains;
using SpMedicalGroup.Interfaces;
using SpMedicalGroup.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SpMedicalGroup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }
        public TipoUsuarioController()
        {
            _TipoUsuarioRepository = new TipoUsuarioRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_TipoUsuarioRepository.Listar());
        }
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoUsuario NovoTipoUsuario)
        {
            _TipoUsuarioRepository.Cadastrar(NovoTipoUsuario);
            return StatusCode(201);
        }
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _TipoUsuarioRepository.Deletar(id);
            return StatusCode(204);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_TipoUsuarioRepository.BuscarPorId(id));
        }
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario TipoUsuarioAtualizado)
        {
            _TipoUsuarioRepository.Atualizar(id, TipoUsuarioAtualizado);
            return StatusCode(204);
        }
    }
}
