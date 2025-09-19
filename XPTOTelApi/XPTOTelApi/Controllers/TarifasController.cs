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
    public class TarifasController : ControllerBase
    {
        private readonly ITarifa _tarifa;

        public TarifasController(ITarifa tarifa)
        {
            _tarifa = tarifa;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var tarifas = await _tarifa.ObterTodas();
            return Ok(tarifas);
        }

        [HttpPost("criarOuAtializar")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> CriarOuAtualizar(Tarifa tarifa)
        {
            await _tarifa.AdicionarOuAtualizar(tarifa);
            return Ok(tarifa);
        }
    }
}
