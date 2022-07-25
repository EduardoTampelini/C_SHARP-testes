using Facec.Dominio.nsEntidades;
using FluentValidation;

namespace Facec.WebApi.nsValidations
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Documento)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull();
        }
    }
}