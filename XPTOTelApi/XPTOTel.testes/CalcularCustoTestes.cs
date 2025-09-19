using Aplicacao.Aplicacoes.Consultas;
using Infraestrutura.Repositorios;

namespace XPTOTel.testes
{
    public class CalcularCustoTestes
    {
        [Fact]
        public async Task CalcularCustoCorretamente()
        {
            var tarifaRepo = new TarifaRepositorio();
            var planoRepo = new PlanoRepositorio();
            var handler = new ObterCustoHandler(tarifaRepo, planoRepo);

            var query = new ObterCustos("011", "016", 20, "FaleMais 30");

            var (comPlano, semPlano) = await handler.Handle(query);

            Assert.Equal(0, comPlano); 
            Assert.Equal(38.00m, semPlano);
        }
    }
}