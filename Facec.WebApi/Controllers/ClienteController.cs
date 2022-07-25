using Facec.Dominio.nsEntidades;
using Facec.Dominio.nsInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Facec.WebApi.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClienteController : AbstractController
    {
        private readonly IClienteServico _servico;

        public ClienteController(IClienteServico servico)
        {
            _servico = servico;
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Excluir(Guid id) => InvokeMethod(_servico.Excluir, id);

        [HttpPost]
        public IActionResult Gravar(Cliente cliente) => InvokeMethod(_servico.Gravar, cliente);

        [HttpGet]
        public IActionResult Obter() => InvokeMethod(_servico.Obter);
    }
}