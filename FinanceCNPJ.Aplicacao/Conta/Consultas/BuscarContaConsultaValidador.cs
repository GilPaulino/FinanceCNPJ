using FluentValidation;

namespace FinanceCNPJ.Aplicacao.Conta.Consultas
{
    public class BuscarContaConsultaValidador : AbstractValidator<BuscarContaConsulta>
    {
        public BuscarContaConsultaValidador()
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
