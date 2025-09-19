using Infraestrutura.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Aplicacao.Aplicacoes.Comandos
{
    public interface ICommand { }

    public record CriarUsuario(string Nome, string Email, string SenhaHash, PapelUsuario Papel) : ICommand;

}
