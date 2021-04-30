using hroads_tarde_webApi.Domains;
using hroads_tarde_webApi.Interfaces;
using hroads_tarde_webApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace hroads_tarde_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Requisição necessária para encontrar um usuário e assim dar suas devidas permissões.
        /// </summary>
        /// <param name="login">email e senha do usuário cadastrado</param>
        /// <returns>Caso o email e senha informado estejam errados, é retornado uma mensagem de erro, caso contrário, é dado ao usuário um token de validação</returns>
        [HttpPost]
        public IActionResult Login(Usuario login)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(login.Email, login.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos.");
            }

            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email)
                ,new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdTipoUsuario.ToString())
                ,new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("autenticacao-usuario-hroads"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "hroads.tarde.webApi",
                audience: "hroads.tarde.webApi",
                claims: claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
