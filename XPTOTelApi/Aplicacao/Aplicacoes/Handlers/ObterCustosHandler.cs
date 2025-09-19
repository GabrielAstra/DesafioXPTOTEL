using Dominio.Interfaces;
using Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacoes.Consultas
{
    public class ObterCustoHandler
    {
        private readonly ITarifa _tarifa;
        private readonly IPlano _plano;
        private readonly CalcularCustos _calcularCustos;

        public ObterCustoHandler(ITarifa tarifa, IPlano plano)
        {
            _tarifa = tarifa;
            _plano = plano;
            _calcularCustos = new CalcularCustos();
        }

        public async Task<(decimal comPlano, decimal semPlano)> Handle(ObterCustos query)
        {
            var tarifa = await _tarifa.ObterPorOrigemDestino(query.Origem, query.Destino);
            if (tarifa is null) throw new InvalidOperationException("tarifa inexistente");

            var plano = await _plano.ObterPorNome(query.NomePlano);
            if (plano is null) throw new InvalidOperationException("plano não existe.");

            var semPlano = _calcularCustos.CalcularSemPlano(tarifa, query.Minutos);
            var comPlano = _calcularCustos.CalcularComPlano(tarifa, query.Minutos, plano);

            return (comPlano, semPlano);
        }
    }
}
