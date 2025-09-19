using Dominio.Interfaces;
using Infraestrutura.Autenticacao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace XPTOTelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuario _usuario;
        private readonly IJwt _jwt;

        public AuthController(IUsuario usuario, IJwt jwt)
        {
            _usuario = usuario;
            _jwt = jwt;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string senha)
        {
            var usuario = await _usuario.ObterPorEmail(email);
            if (usuario is null) return Unauthorized("usuário não encontrado.");

            var hash = Hash.GerarHash(senha);
            if (usuario.SenhaHash != hash) return Unauthorized("senh ainválida.");

            var token = _jwt.GerarToken(usuario);
            return Ok(new { Token = token, Usuario = usuario.Nome, Papel = usuario.Papel.ToString() });
        }
    }
}
