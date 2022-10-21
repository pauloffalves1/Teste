using Contabilidade.Domain.Entities;
using FluentValidation;

namespace Contabilidade.Service.Validators
{
    public class LancamentoValidator : AbstractValidator<Lancamento>
    {
        public LancamentoValidator()
        {
            RuleFor(l => l.Descricao)
                .NotEmpty().WithMessage("Por favor! Entre com uma Descrição.")
                .NotNull().WithMessage("Por favor! Entre com uma Descrição.");

            //RuleFor(l => ((int)l.TipoLancamento))
            //    .NotEmpty().WithMessage("Por favor! Entre com um Tipo de Lançamento.")
            //    .NotNull().WithMessage("Por favor! Entre com um Tipo de Lançamento.");

            RuleFor(l => l.Valor)
                .NotEmpty().WithMessage("Por favor! Entre com um Valor.")
                .NotNull().WithMessage("Por favor! Entre com um Valor.");

            RuleFor(l => l.MomentoLancamento)
                .NotEmpty().WithMessage("Por favor! Entre com uma Data.")
                .NotNull().WithMessage("Por favor! Entre com uma Data.");
        }
    }
}
