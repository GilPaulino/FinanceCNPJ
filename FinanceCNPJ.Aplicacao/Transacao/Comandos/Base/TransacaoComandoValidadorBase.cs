using FluentValidation;
using FinanceCNPJ.Aplicacao.Transacao.Comandos.Base;

namespace FinanceCNPJ.Aplicacao.Transacao.Comandos
{
    public class TransacaoComandoValidadorBase : AbstractValidator<TransacaoComandoBase>
    {
        public TransacaoComandoValidadorBase()
        {
            RuleFor(x => x.Valor)
                .GreaterThan(0)
                .WithMessage("O valor da transação deve ser maior que zero.");

            RuleFor(x => x.ContaId)
                .GreaterThan(0)
                .WithMessage("Conta de origem deve ser válida.");
        }
    }
}
