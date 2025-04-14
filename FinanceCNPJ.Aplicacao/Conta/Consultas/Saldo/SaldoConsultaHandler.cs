using FinanceCNPJ.Aplicacao.Transacao.Servicos.Interfaces;
using FinanceCNPJ.Dominio.Enums;
using FinanceCNPJ.Dominio.Repositorios;
using MediatR;

namespace FinanceCNPJ.Aplicacao.Conta.Consultas.Saldo
{
    public class SaldoConsultaHandler : IRequestHandler<SaldoConsulta, decimal>
    {
        private readonly ITransacaoRepositorio _transacaoRepositorio;
        private readonly ISaldoService _saldoService;

        public SaldoConsultaHandler(ITransacaoRepositorio transacaoRepositorio, ISaldoService saldoService)
        {
            _transacaoRepositorio = transacaoRepositorio;
            _saldoService = saldoService;
        }

        public async Task<decimal> Handle(SaldoConsulta request, CancellationToken cancellationToken)
        {
            var saldo = await _saldoService.CalcularSaldoAsync(request.ContaId);
            return saldo;
        }
    }
}
