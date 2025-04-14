using FinanceCNPJ.Dominio.Enums;
using FinanceCNPJ.Dominio.Repositorios;
using MediatR;

namespace FinanceCNPJ.Aplicacao.Conta.Consultas.Saldo
{
    public class SaldoConsultaHandler : IRequestHandler<SaldoConsulta, decimal>
    {
        private readonly ITransacaoRepositorio _transacaoRepositorio;

        public SaldoConsultaHandler(ITransacaoRepositorio transacaoRepositorio)
        {
            _transacaoRepositorio = transacaoRepositorio;
        }

        public async Task<decimal> Handle(SaldoConsulta request, CancellationToken cancellationToken)
        {
            var transacoes = await _transacaoRepositorio.ObterPorContaIdAsync(request.ContaId);

            decimal saldo = 0;

            foreach (var transacao in transacoes)
            {
                if (transacao.Tipo == TipoTransacao.Deposito)
                {
                    saldo += transacao.Valor;
                }
                else if (transacao.Tipo == TipoTransacao.Saque)
                {
                    saldo -= transacao.Valor;
                }
                else if (transacao.Tipo == TipoTransacao.Transferencia && transacao.ContaDestinoId == request.ContaId)
                {
                    saldo += transacao.Valor;
                }
                else if (transacao.Tipo == TipoTransacao.Transferencia && transacao.ContaId == request.ContaId)
                {
                    saldo -= transacao.Valor;
                }
            }

            return saldo;
        }
    }
}
