using Facec.Dominio.nsEntidades;
using Facec.Dominio.nsEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facec.Dominio.nsInterfaces
{
    public interface IClienteRepositorio : IAbstractRepositorio<Cliente>
    {
        IEnumerable<Cliente> Obter(TipoSexo sexo);
    }
}