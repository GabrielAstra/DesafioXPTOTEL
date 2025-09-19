using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Tarifa
    {
        public string Origem { get; private set; }
        public string Destino { get; private set; }
        public decimal ValorPorMinuto { get; private set; }

        private Tarifa() { }

        public Tarifa(string origem, string destino, decimal valorPorMinuto)
        {
            Origem = origem;
            Destino = destino;
            ValorPorMinuto = valorPorMinuto;
        }


        public static readonly List<Tarifa> TarifasPadroes = new()
        {
            new Tarifa("011", "016", 1.90m),
            new Tarifa("016", "011", 2.90m),
            new Tarifa("011", "017", 1.70m),
            new Tarifa("017", "011", 2.70m),
            new Tarifa("011", "018", 0.90m),
            new Tarifa("018", "011", 1.90m)
        };

    }
}
