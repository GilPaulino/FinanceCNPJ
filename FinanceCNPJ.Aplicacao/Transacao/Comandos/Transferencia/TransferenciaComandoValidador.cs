using FluentValidation;

namespace FinanceCNPJ.Aplicacao.Transacao.Comandos.Transferencia
{
    public class TransferenciaComandoValidador : AbstractValidator<TransferenciaComando>
    {
        public TransferenciaComandoValidador()
        {
            RuleFor(x => x.ContaId).GreaterThan(0);
            RuleFor(x => x.Valor).GreaterThan(0);
            RuleFor(x => x.NumeroConta).NotEmpty();
            RuleFor(x => x.Agencia).NotEmpty();
        }
    }
}
