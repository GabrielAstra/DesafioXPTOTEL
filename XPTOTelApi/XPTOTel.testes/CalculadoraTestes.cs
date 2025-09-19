using Dominio.Entidades;
using Dominio.Servicos;

namespace XPTOTel.testes
{
    public class CalculadoraTestes
    {
        [Fact]
        public void CalcularSemPlano()
        {
            var tarifa = new Tarifa("011", "016", 1.90m);
            var calculadora = new CalcularCustos();

            var resultado = calculadora.CalcularSemPlano(tarifa, 20);

            Assert.Equal(38.00m, resultado);
        }

        [Fact]
        public void CalcularComPlano()
        {
            var tarifa = new Tarifa("011", "017", 1.70m);

            var plano = Plano.PlanosDisponiveis.FirstOrDefault(p => p.Nome == "FaleMais 60");

            Assert.NotNull(plano);

            var calculadora = new CalcularCustos();

            var resultado = calculadora.CalcularComPlano(tarifa, 80, plano);

            Assert.Equal(37.40m, resultado);
        }

        [Fact]
        public void ValidarMinutos()
        {
            var tarifa = new Tarifa("011", "018", 0.90m);

            var plano = Plano.PlanosDisponiveis.FirstOrDefault(p => p.Nome == "FaleMais 30");

            Assert.NotNull(plano);

            var calculadora = new CalcularCustos();

            var resultado = calculadora.CalcularComPlano(tarifa, 20, plano);

            Assert.Equal(0, resultado);
        }
    }
}