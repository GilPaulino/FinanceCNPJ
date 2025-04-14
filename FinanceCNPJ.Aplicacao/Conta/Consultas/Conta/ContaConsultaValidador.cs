using FluentValidation;

namespace FinanceCNPJ.Aplicacao.Conta.Consultas.Conta
{
    public class ContaConsultaValidador : AbstractValidator<ContaConsulta>
    {
        public ContaConsultaValidador()
        {
            RuleFor(x => x)
                .Must(x =>
                    !string.IsNullOrWhiteSpace(x.Filtro.CNPJ) ||
                    !string.IsNullOrWhiteSpace(x.Filtro.Nome) ||
                    !string.IsNullOrWhiteSpace(x.Filtro.NumeroConta) ||
                    !string.IsNullOrWhiteSpace(x.Filtro.Agencia)
                ).WithMessage("Pelo menos um filtro deve ser informado.");
        }
    }
}
