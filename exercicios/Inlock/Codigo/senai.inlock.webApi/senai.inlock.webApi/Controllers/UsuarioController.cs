using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }


        public UsuarioController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_UsuarioRepository.Listar());
        }
        [HttpPost]
        public IActionResult Post(Usuario NovoUsuario)
        {
            _UsuarioRepository.Cadastrar(NovoUsuario);
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _UsuarioRepository.Deletar(id);
            return StatusCode(204);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_UsuarioRepository.BuscarPorId(id));
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario UsuarioAtualizado)
        {
            _UsuarioRepository.Atualizar(id,UsuarioAtualizado);
            return StatusCode(204);
        }
        [HttpGet("Login")]
        public IActionResult GetEmailAndPassword(string email, string senha)
        {
            _UsuarioRepository.BuscarEmailSenha(email, senha);
            return Ok();
        }
    }
}
