using Facec.Dominio.nsEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facec.Dominio.nsInterfaces
{
    public interface IAbstractRepositorio<T> where T : AbstractEntidade
    {
        void Gravar(T entidade);
        void Excluir(T entidade);
        IEnumerable<T> Obter();
    }
}
