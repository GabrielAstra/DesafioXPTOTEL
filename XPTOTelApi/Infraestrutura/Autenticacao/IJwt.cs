using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Autenticacao
{
    public interface IJwt
    {
        string GerarToken(Usuario usuario);
    }
}
