using Facec.Dominio.nsInterfaces;
using Facec.Repositorio.nsClasses;
using Facec.Repositorio.nsContext;
using Facec.Servicos.nsServicos;
using Microsoft.EntityFrameworkCore;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facec.IoC
{
    public static class Instalador
    {
        public static void Registrar(ref Container container)
        {
            container
                .Register<IClienteRepositorio, ClienteRepositorio>(Lifestyle.Singleton);
            container
                .Register<IUnitOfWork, UnitOfWork>(Lifestyle.Singleton);
            container
                .Register<IClienteServico, ClienteServico>(Lifestyle.Singleton);
        }
    }
}