using FluentValidation;

namespace FinanceCNPJ.Aplicacao.Conta.Consultas.Extrato
{
    public class ExtratoContaConsultaValidador : AbstractValidator<ExtratoContaConsulta>
    {
        public ExtratoContaConsultaValidador()
        {
            RuleFor(x => x.ContaId).GreaterThan(0).WithMessage("O Id da conta deve ser maior que zero.");
        }
    }
}
