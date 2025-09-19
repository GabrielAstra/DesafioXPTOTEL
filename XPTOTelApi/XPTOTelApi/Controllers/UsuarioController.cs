using Aplicacao.Aplicacoes.Comandos;
using Aplicacao.Aplicacoes.Consultas;
using Aplicacao.Aplicacoes.Handlers;
using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestrutura.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace XPTOTelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly ObterUsuariosHandler _obterUsuariosHandler;
        private readonly CriarUsuarioHandler _criarUsuarioHandler;
        private readonly IUsuario _usuario;
        private readonly IPlano _planoRepositorio;

        public UsuarioController(
            CriarUsuarioHandler criarUsuarioHandler,
            IUsuario usuarioRepositorio,
            IPlano planoRepositorio, ObterUsuariosHandler obterUsuarioHandler)
        {
            _criarUsuarioHandler = criarUsuarioHandler;
            _usuario = usuarioRepositorio;
            _planoRepositorio = planoRepositorio;
            _obterUsuariosHandler = obterUsuarioHandler;

        }

        [HttpGet("listar")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Listar()
        {
            var usuarios = await _obterUsuariosHandler.Handle(new ObterUsuarios());
            return Ok(usuarios);
        }

        [HttpPost("criar")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Criar( CriarUsuario body)
        {
            var usuario = await _criarUsuarioHandler.Handle(body);
            return Ok(usuario);
        }

        [HttpPut("atualizar")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Atualizar(Guid id, string nome)
        {
            var usuario = await _usuario.ObterPorId(id);
            if (usuario is null) return NotFound();

            var novoUsuario = new Usuario(nome, usuario.Email, usuario.SenhaHash, usuario.Papel);
            await _usuario.Atualizar(novoUsuario);

            return Ok(novoUsuario);
        }

        [HttpDelete("desativar")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Desativar(Guid id)
        {
            var usuario = await _usuario.ObterPorId(id);
            if (usuario is null) return NotFound();

            usuario.Desativar();
            await _usuario.Atualizar(usuario);

            return Ok(usuario);
        }

        [HttpPost("atribuirPlano")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> AtribuirPlano(Guid id, string nomePlano)
        {
            var usuario = await _usuario.ObterPorId(id);
            if (usuario is null) return NotFound();

            var plano = await _planoRepositorio.ObterPorNome(nomePlano);
            if (plano is null) return BadRequest("Plano inválido");

            usuario.AtribuirPlano(plano);
            await _usuario.Atualizar(usuario);

            return Ok(usuario);
        }
    }
}
