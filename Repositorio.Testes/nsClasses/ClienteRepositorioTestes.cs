using Facec.Dominio.nsEntidades;
using Facec.Dominio.nsEnums;
using Facec.Repositorio.nsClasses;
using Facec.Repositorio.nsContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Testes.nsClasses
{
    [TestClass]
    public class ClienteRepositorioTestes
    {
        
        [TestMethod]
        public void Excluir_clienteValido_Sucesso()
        {
           using (var contexto = new DataBaseContext(new DbContextOptionsBuilder<DataBaseContext>().UseInMemoryDatabase("teste1").Options)) { 
            var repositorio = new ClienteRepositorio(contexto);
            var uow = new UnitOfWork(contexto, repositorio);
            var cliente = new Cliente("Vanessa Allana", "896.275.938-18",TipoSexo.Feminino);
            uow.ClienteRepositorio.Gravar(cliente);
                uow.SaveChanges();

            uow.ClienteRepositorio.Excluir(cliente);
                uow.SaveChanges();

            Assert.IsNull(repositorio.Obter().FirstOrDefault(x => x.Documento == "896.275.938-18"));
            }
        }
        [TestMethod]
        public void Gravar_clienteValido_Sucesso()
        {
           using (var contexto = new DataBaseContext(new DbContextOptionsBuilder<DataBaseContext>().UseInMemoryDatabase("teste2").Options)) { 
            var repositorio = new ClienteRepositorio(contexto);
            var uow = new UnitOfWork(contexto, repositorio);
            var cliente = new Cliente("Vanessa Allana", "896.275.938-18",TipoSexo.Feminino);
            uow.ClienteRepositorio.Gravar(cliente);
                uow.SaveChanges();
                var resultado = repositorio.Obter().FirstOrDefault(x => x.Documento == "896.275.938-18");

                Assert.IsNotNull(resultado);
                Assert.IsNotNull(resultado.Id);
                Assert.AreEqual("896.275.938-18", resultado.Documento);
            }
        }
        [TestMethod]
        public void Obter_clienteValido_Sucesso()
        {
           using (var contexto = new DataBaseContext(new DbContextOptionsBuilder<DataBaseContext>().UseInMemoryDatabase("teste3").Options)) { 
            var repositorio = new ClienteRepositorio(contexto);
            var uow = new UnitOfWork(contexto, repositorio);
            var clienteF = new Cliente("Vanessa Allana", "896.275.938-18",TipoSexo.Feminino);
            var clienteM = new Cliente("Eduardo", "496.737.989-31", TipoSexo.Masculino);
                
                uow.ClienteRepositorio.Gravar(clienteM);
                uow.SaveChanges();
                uow.ClienteRepositorio.Gravar(clienteF);
                uow.SaveChanges();
               
                var resultado = uow.ClienteRepositorio.Obter();

                Assert.IsNotNull(resultado);
                Assert.IsTrue(resultado.Any());
                Assert.AreEqual(2, resultado.Count());
                
            }
        }
    }
}
