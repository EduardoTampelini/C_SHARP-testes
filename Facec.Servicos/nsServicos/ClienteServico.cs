using Facec.Dominio.nsEntidades;
using Facec.Dominio.nsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facec.Servicos.nsServicos
{
    public class ClienteServico : IClienteServico
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ValidadorDocumentoServico _validadorDocumentoServico = new ValidadorDocumentoServico();

        public ClienteServico(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Excluir(Guid id)
        {
            var cliente = _unitOfWork.ClienteRepositorio.Obter()
                .FirstOrDefault(x => x.Id == id);

            _unitOfWork.ClienteRepositorio.Excluir(cliente
                ?? throw new ApplicationException("Cliente nao existe!"));
            _unitOfWork.SaveChanges();
        }

        public void Gravar(Cliente cliente)
        {
            _validadorDocumentoServico.Validar(cliente.Documento);

            if (_unitOfWork.ClienteRepositorio.Obter()
                .FirstOrDefault(x => x.Documento == cliente.Documento) != null)
                throw new ApplicationException("Cliente já cadastrado! Verifique.");

            _unitOfWork.ClienteRepositorio.Gravar(cliente);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<Cliente> Obter()
        {
            return _unitOfWork.ClienteRepositorio.Obter();
        }
    }
}