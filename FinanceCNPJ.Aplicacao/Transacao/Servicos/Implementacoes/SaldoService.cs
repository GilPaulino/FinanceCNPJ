using FinanceCNPJ.Dominio.Enums;
using FinanceCNPJ.Dominio.Repositorios;
using FinanceCNPJ.Aplicacao.Transacao.Servicos.Interfaces;

namespace FinanceCNPJ.Aplicacao.Transacao.Servicos.Implementacoes
{
    public class SaldoService : ISaldoService
    {
        private readonly ITransacaoRepositorio _transacaoRepositorio;

        public SaldoService(ITransacaoRepositorio transacaoRepositorio)
        {
            _transacaoRepositorio = transacaoRepositorio;
        }

        public async Task<decimal> CalcularSaldoAsync(long contaId)
        {
            var transacoes = await _transacaoRepositorio.ObterPorContaIdAsync(contaId);
            decimal saldo = 0;

            foreach (var transacao in transacoes)
            {
                switch (transacao.Tipo)
                {
                    case TipoTransacao.Deposito:
                        saldo += transacao.Valor;
                        break;
                    case TipoTransacao.Saque:
                        saldo -= transacao.Valor;
                        break;
                    case TipoTransacao.Transferencia:
                        if (transacao.ContaId == contaId)
                            saldo -= transacao.Valor;
                        else if (transacao.ContaDestinoId == contaId)
                            saldo += transacao.Valor;
                        break;
                }
            }

            return saldo;
        }
    }
}
