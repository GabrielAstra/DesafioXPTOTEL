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
    public class PlanosController : ControllerBase
    {
        private readonly IPlano _planoRepositorio;

        public PlanosController(IPlano planoRepositorio)
        {
            _planoRepositorio = planoRepositorio;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var planos = await _planoRepositorio.ObterTodos();
            return Ok(planos);
        }

        [HttpPost("criar")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Criar(Plano plano)
        {
            var planos = (await _planoRepositorio.ObterTodos()).ToList();
            planos.Add(plano);
            return Ok(planos);
        }
    }
}
