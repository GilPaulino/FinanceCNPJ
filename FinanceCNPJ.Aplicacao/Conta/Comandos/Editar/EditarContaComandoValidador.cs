using FluentValidation;

public class EditarContaComandoValidador : AbstractValidator<EditarContaComando>
{
    public EditarContaComandoValidador()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("O Id da conta é obrigatório e deve ser válido.");

        RuleFor(x => x.DocumentoBase64)
            .NotEmpty().WithMessage("O documento é obrigatório.");
    }
}
