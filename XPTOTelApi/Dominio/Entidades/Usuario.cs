using Infraestrutura.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dominio.Entidades
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string SenhaHash { get; private set; }
        public PapelUsuario Papel { get; private set; }
        public Plano? Plano { get; private set; }
        public bool Ativo { get; private set; }

        public Usuario(string nome, string email, string senhaHash, PapelUsuario papel)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
            Papel = papel;
            Ativo = true;
        }

        public void AtribuirPlano(Plano plano) => Plano = plano;
        public void Desativar() => Ativo = false;
    }
}
