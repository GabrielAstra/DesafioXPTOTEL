using Aplicacao.Aplicacoes.Consultas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace XPTOTelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustosController : ControllerBase
    {
        private readonly ObterCustoHandler _calcularCustoHandler;

        public CustosController(ObterCustoHandler obterCustoHandler)
        {
            _calcularCustoHandler = obterCustoHandler;
        }

        [HttpPost("calcular")]
        public async Task<IActionResult> Calcular([FromBody] ObterCustos query)
        {
            var (comPlano, semPlano) = await _calcularCustoHandler.Handle(query);
            return Ok(new
            {
                query.Origem,
                query.Destino,
                query.Minutos,
                query.NomePlano,
                ComPlano = comPlano,
                SemPlano = semPlano
            });
        }
    }
}
