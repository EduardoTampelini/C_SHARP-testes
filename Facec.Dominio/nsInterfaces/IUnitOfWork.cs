using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facec.Dominio.nsInterfaces
{
    public interface IUnitOfWork
    {
        IClienteRepositorio ClienteRepositorio { get; }

        void SaveChanges();
    }
}