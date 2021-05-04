using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_Peoples.Domains;
using T_Peoples.Interfaces;
using T_Peoples.Repositories;

namespace T_Peoples.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private IFuncionarioRepository _FuncionarioRepository { get; set; }

        public FuncionarioController()
        {
            _FuncionarioRepository = new FuncionarioRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<FuncionarioDomain> ListaFuncionarios = _FuncionarioRepository.ListarTodos();
            return Ok(ListaFuncionarios);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            FuncionarioDomain FuncionarioBuscado = _FuncionarioRepository.BuscarPorId(id);
            if (FuncionarioBuscado == null)
            {
                return NotFound("Nenhum funcionario encontrado amigo!");
            }
            return Ok(FuncionarioBuscado);
        }
        [HttpPost]
        public IActionResult Post(FuncionarioDomain novoFuncionario)
        {
            _FuncionarioRepository.Cadastrar(novoFuncionario);
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _FuncionarioRepository.Deletar(id);
            return StatusCode(204);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateByUrl(int id, FuncionarioDomain FuncionarioAtualizado)
        {
            FuncionarioDomain generoBuscado = _FuncionarioRepository.BuscarPorId(id);
            if (generoBuscado == null)
            {
                return NotFound("Nenhum Funcionario com esse nome encontrado, Tente cadastra-lo ou digitar o nome corretamente!");
            }
            try
            {
                _FuncionarioRepository.AtualizaIdUrl(id, FuncionarioAtualizado);
                return NoContent();
            }
            catch (Exception codErro)
            {

                return BadRequest(codErro);
            }

        }
    }
}
