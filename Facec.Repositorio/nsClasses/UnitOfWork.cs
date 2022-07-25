using Facec.Dominio.nsInterfaces;
using Facec.Repositorio.nsContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facec.Repositorio.nsClasses
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context;
        private readonly IClienteRepositorio _clienteRepositorio;

        public IClienteRepositorio ClienteRepositorio => _clienteRepositorio;

        public UnitOfWork(DataBaseContext context, IClienteRepositorio clienteRepositorio)
        {
            _context = context;
            _clienteRepositorio = clienteRepositorio;
        }

        public void SaveChanges() => _context.SaveChanges();
    }
}