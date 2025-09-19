using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class CalcularCustos
    {
        public decimal CalcularSemPlano(Tarifa tarifa, int minutos)
        {
            return tarifa.ValorPorMinuto * minutos;
        }

        public decimal CalcularComPlano(Tarifa tarifa, int minutos, Plano plano)
        {
            if (minutos <= plano.MinutosGratuitos) return 0;
            
            decimal acrescimoExcedente = 1.1m;

            var minutosExcedentes = minutos - plano.MinutosGratuitos;
            return minutosExcedentes * tarifa.ValorPorMinuto * acrescimoExcedente;
        }
    }
}
