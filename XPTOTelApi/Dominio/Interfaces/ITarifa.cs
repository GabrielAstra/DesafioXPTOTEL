using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface ITarifa
    {
        Task<IEnumerable<Tarifa>> ObterTodas();
        Task<Tarifa?> ObterPorOrigemDestino(string origem, string destino);
        Task AdicionarOuAtualizar(Tarifa tarifa);
    }
}
