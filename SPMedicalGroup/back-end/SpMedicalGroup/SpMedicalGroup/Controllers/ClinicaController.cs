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
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _ClinicaRepository { get; set; }
        public ClinicaController()
        {
            _ClinicaRepository = new ClinicaRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ClinicaRepository.Listar());
        }
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Clinica NovaClinica)
        {
            _ClinicaRepository.Cadastrar(NovaClinica);
            return StatusCode(201);
        }
        [Authorize (Roles ="1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ClinicaRepository.Deletar(id);
            return StatusCode(204);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_ClinicaRepository.BuscarPorId(id));
        }
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Clinica ClinicaAtualizada)
        {
            _ClinicaRepository.Atualizar(id, ClinicaAtualizada);
            return StatusCode(204);
        }
    }
}
