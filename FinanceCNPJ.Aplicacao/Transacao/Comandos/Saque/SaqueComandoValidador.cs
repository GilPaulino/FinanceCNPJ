using FluentValidation;
using FinanceCNPJ.Aplicacao.Transacao.Comandos.Saque;

namespace FinanceCNPJ.Aplicacao.Transacao.Comandos.Saque
{
    public class SaqueComandoValidador : AbstractValidator<SaqueComando>
    {
        public SaqueComandoValidador()
        {
            RuleFor(x => x.Valor)
                .GreaterThan(0)
                .WithMessage("O valor do saque deve ser maior que zero.");

            RuleFor(x => x.ContaId)
                .GreaterThan(0)
                .WithMessage("A conta de origem deve ser válida.");
        }
    }
}
