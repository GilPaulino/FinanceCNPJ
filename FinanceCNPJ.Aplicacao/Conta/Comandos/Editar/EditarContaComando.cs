using FinanceCNPJ.Aplicacao.Conta.ViewModel;
using MediatR;

public class EditarContaComando : IRequest<ContaViewModel>
{
    public long Id { get; set; }
    public required string DocumentoBase64 { get; set; }
}
