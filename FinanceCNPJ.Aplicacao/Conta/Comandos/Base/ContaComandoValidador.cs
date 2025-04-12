using FluentValidation;

namespace FinanceCNPJ.Aplicacao.Conta.Comandos.Base
{
    public abstract class ContaComandoValidador<T> : AbstractValidator<T> where T : ContaComandoBase
    {
        protected ContaComandoValidador()
        {
            RuleFor(x => x.CNPJ)
                .NotEmpty().WithMessage("O CNPJ é obrigatório.")
                .Length(14, 18).WithMessage("O CNPJ deve conter de 14 a 18 caracteres (com ou sem máscara).");

            RuleFor(x => x.DocumentoBase64)
                .NotEmpty().WithMessage("O documento é obrigatório.");
        }
    }
}
