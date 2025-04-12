using MediatR;
using FinanceCNPJ.Aplicacao.Conta.ViewModel;

namespace FinanceCNPJ.Aplicacao.Conta.Comandos.Base
{
    public abstract class ContaComandoBase : IRequest<ContaViewModel>
    {
        public required string CNPJ { get; set; }
        public required string DocumentoBase64 { get; set; }
    }
}
