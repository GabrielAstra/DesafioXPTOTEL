using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorios
{
    public class UsuarioRepositorio : IUsuario
    {
        private readonly List<Usuario> _usuarios = new();
        public Task Adicionar(Usuario usuario)
        {
            _usuarios.Add(usuario);
            return Task.CompletedTask;
        }

        public Task Atualizar(Usuario usuario)
        {
            var index = _usuarios.FindIndex(u => u.Id == usuario.Id);
            if (index >= 0)
                _usuarios[index] = usuario;

            return Task.CompletedTask;
        }

        public Task<Usuario?> ObterPorEmail(string email)
        {
            return Task.FromResult(_usuarios.FirstOrDefault(u => u.Email == email));
        }

        public Task<Usuario?> ObterPorId(Guid id)
        {
            return Task.FromResult(_usuarios.FirstOrDefault(u => u.Id == id));
        }

        public Task<IEnumerable<Usuario>> ObterTodos()
        {
            return Task.FromResult(_usuarios.AsEnumerable());
        }
    }
}
