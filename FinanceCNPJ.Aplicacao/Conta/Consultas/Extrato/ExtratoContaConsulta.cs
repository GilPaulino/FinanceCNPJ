using FinanceCNPJ.Aplicacao.Transacao.ViewModel;
using MediatR;

namespace FinanceCNPJ.Aplicacao.Conta.Consultas.Extrato
{
    public class ExtratoContaConsulta : IRequest<List<TransacaoViewModel>>
    {
        public long ContaId { get; set; }
    }
}
