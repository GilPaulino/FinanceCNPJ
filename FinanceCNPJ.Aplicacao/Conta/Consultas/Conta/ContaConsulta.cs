using FinanceCNPJ.Aplicacao.Conta.ViewModel;
using MediatR;

namespace FinanceCNPJ.Aplicacao.Conta.Consultas.Conta
{
    public class ContaConsulta : IRequest<List<ContaViewModel>>
    {
        public ContaFiltroViewModel Filtro { get; set; } = new();
    }
}
