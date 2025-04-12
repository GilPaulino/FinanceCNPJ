using FinanceCNPJ.Aplicacao.Conta.ViewModel;
using MediatR;

namespace FinanceCNPJ.Aplicacao.Conta.Consultas
{
    public class BuscarContaConsulta : IRequest<List<ContaViewModel>>
    {
        public BuscarContaFiltroViewModel Filtro { get; set; } = new();
    }
}
