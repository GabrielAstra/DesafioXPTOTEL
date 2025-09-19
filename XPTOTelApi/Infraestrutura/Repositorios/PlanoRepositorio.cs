using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorios
{
    public class PlanoRepositorio : IPlano
    {
        private readonly List<Plano> _planos = Plano.PlanosDisponiveis;

        public Task<Plano?> ObterPorNome(string nome)
        {
            return Task.FromResult(_planos.FirstOrDefault(p => p.Nome == nome));
        }

        public Task<IEnumerable<Plano>> ObterTodos()
        {
            return Task.FromResult(_planos.AsEnumerable());
        }
    }
}
