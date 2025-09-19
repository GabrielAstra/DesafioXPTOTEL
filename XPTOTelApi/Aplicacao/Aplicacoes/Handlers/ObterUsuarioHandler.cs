using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacoes.Consultas
{
    public class ObterUsuariosHandler
    {
        private readonly IUsuario _usuario;

        public ObterUsuariosHandler(IUsuario usuario)
        {
            _usuario = usuario;
        }

        public async Task<IEnumerable<Usuario>> Handle(ObterUsuarios query)
        {
            return await _usuario.ObterTodos();
        }
    }
}
