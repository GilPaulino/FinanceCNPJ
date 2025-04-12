using FluentValidation;

namespace FinanceCNPJ.Aplicacao.Conta.Comandos.Excluir
{
    public class ExcluirContaComandoValidador : AbstractValidator<ExcluirContaComando>
    {
        public ExcluirContaComandoValidador()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("O Id da conta é obrigatório e deve ser maior que zero.");
        }
    }
}
