using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Plano
    {
        public string Nome { get; private set; }
        public int MinutosGratuitos { get; private set; }

        public Plano(string nome, int minutosGratuitos)
        {
            Nome = nome;
            MinutosGratuitos = minutosGratuitos;
        }

        public static readonly List<Plano> PlanosDisponiveis = new()
        {
            new Plano("FaleMais 30", 30),
            new Plano("FaleMais 60", 60),
            new Plano("FaleMais 120", 120),
        };

    }
}
