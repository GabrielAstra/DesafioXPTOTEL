using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IUsuario
    {
        Task<Usuario?> ObterPorId(Guid id);
        Task<Usuario?> ObterPorEmail(string email);
        Task<IEnumerable<Usuario>>ObterTodos();
        Task Adicionar(Usuario usuario);
        Task Atualizar(Usuario usuario);
    }
}
