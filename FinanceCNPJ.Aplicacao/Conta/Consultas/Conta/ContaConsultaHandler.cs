using FinanceCNPJ.Aplicacao.Conta.ViewModel;
using FinanceCNPJ.Dominio.Repositorios;
using MediatR;

namespace FinanceCNPJ.Aplicacao.Conta.Consultas.Conta
{
    public class ContaConsultaHandler : IRequestHandler<ContaConsulta, List<ContaViewModel>>
    {
        private readonly IContaRepositorio _contaRepositorio;

        public ContaConsultaHandler(IContaRepositorio contaRepositorio)
        {
            _contaRepositorio = contaRepositorio;
        }

        public async Task<List<ContaViewModel>> Handle(ContaConsulta request, CancellationToken cancellationToken)
        {
            var filtro = request.Filtro;
            var contas = await _contaRepositorio.BuscarAsync(filtro.CNPJ, filtro.Nome, filtro.NumeroConta, filtro.Agencia);

            return contas.Select(conta => new ContaViewModel
            {
                Id = conta.Id,
                Nome = conta.Nome,
                CNPJ = conta.CNPJ,
                Agencia = conta.Agencia,
                NumeroConta = conta.NumeroConta,
                CaminhoDocumento = conta.CaminhoDocumento,
            }).ToList();
        }
    }
}
