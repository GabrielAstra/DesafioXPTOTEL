using Aplicacao.Aplicacoes.Comandos;
using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacoes.Handlers
{
    public class CriarUsuarioHandler
    {
        private readonly IUsuario _usuario;

        public CriarUsuarioHandler(IUsuario usuario)
        {
            _usuario = usuario;
        }

        public async Task<Usuario> Handle(CriarUsuario criarUsuario)
        {
            var usuarioExistente = await _usuario.ObterPorEmail(criarUsuario.Email);
            if (usuarioExistente is not null) throw new InvalidOperationException("usuário com mesmo email");

            var usuario = new Usuario(criarUsuario.Nome, criarUsuario.Email, criarUsuario.SenhaHash, criarUsuario.Papel);
            await _usuario.Adicionar(usuario);

            return usuario;
        }
    }
}
