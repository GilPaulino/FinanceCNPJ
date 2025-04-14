using FinanceCNPJ.Dominio.Repositorios;
using FinanceCNPJ.Aplicacao.Transacao.ViewModel;
using MediatR;

namespace FinanceCNPJ.Aplicacao.Conta.Consultas.Extrato
{
    public class ExtratoContaConsultaHandler : IRequestHandler<ExtratoContaConsulta, List<TransacaoViewModel>>
    {
        private readonly ITransacaoRepositorio _transacaoRepositorio;

        public ExtratoContaConsultaHandler(ITransacaoRepositorio transacaoRepositorio)
        {
            _transacaoRepositorio = transacaoRepositorio;
        }

        public async Task<List<TransacaoViewModel>> Handle(ExtratoContaConsulta request, CancellationToken cancellationToken)
        {
            var transacoes = await _transacaoRepositorio.ObterPorContaIdAsync(request.ContaId);

            return transacoes.Select(t => new TransacaoViewModel
            {
                Tipo = t.Tipo,
                Valor = t.Valor,
                Data = t.Data,
                ContaId = t.ContaId,
                ContaDestinoId = t.ContaDestinoId
            }).ToList();
        }
    }
}
