using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorios
{
    public class TarifaRepositorio : ITarifa
    {
        private readonly List<Tarifa> _tarifas = Tarifa.TarifasPadroes;

        public Task AdicionarOuAtualizar(Tarifa tarifa)
        {
            var existente = _tarifas.FirstOrDefault(t => t.Origem == tarifa.Origem && t.Destino == tarifa.Destino);
            if (existente != null)
            {
                _tarifas.Remove(existente);
            }
            _tarifas.Add(tarifa);

            return Task.CompletedTask;
        }

        public Task<Tarifa?> ObterPorOrigemDestino(string origem, string destino)
        {
            return Task.FromResult( _tarifas.FirstOrDefault(t => t.Origem == origem && t.Destino == destino));
        }

        public Task<IEnumerable<Tarifa>> ObterTodas()
        {
            return Task.FromResult(_tarifas.AsEnumerable());
        }
    }
}
