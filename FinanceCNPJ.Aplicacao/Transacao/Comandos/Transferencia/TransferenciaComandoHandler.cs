using FinanceCNPJ.Aplicacao.Transacao.Servicos.Interfaces;
using FinanceCNPJ.Dominio.Entidades;
using FinanceCNPJ.Dominio.Enums;
using FinanceCNPJ.Dominio.Repositorios;
using MediatR;

namespace FinanceCNPJ.Aplicacao.Transacao.Comandos.Transferencia
{
    public class TransferenciaComandoHandler : IRequestHandler<TransferenciaComando, Unit>
    {
        private readonly IContaRepositorio _contaRepositorio;
        private readonly ITransacaoRepositorio _transacaoRepositorio;
        private readonly ISaldoService _saldoService;
        public TransferenciaComandoHandler(
            IContaRepositorio contaRepositorio,
            ITransacaoRepositorio transacaoRepositorio,
            ISaldoService saldoService)
        {
            _contaRepositorio = contaRepositorio;
            _transacaoRepositorio = transacaoRepositorio;
            _saldoService = saldoService;
        }

        public async Task<Unit> Handle(TransferenciaComando request, CancellationToken cancellationToken)
        {
            var contaRemetente = await _contaRepositorio.ObterPorIdAsync(request.ContaId);
            if (contaRemetente is null)
                throw new ArgumentException("Conta remetente não encontrada.");

            var contaDestino = await _contaRepositorio.ObterPorNumeroEAgenciaAsync(
                request.NumeroConta, request.Agencia);

            if (contaDestino is null)
                throw new ArgumentException("Conta destinatária não encontrada.");

            var saldo = await _saldoService.CalcularSaldoAsync(request.ContaId);

            if (saldo < request.Valor)
                throw new InvalidOperationException("Saldo insuficiente para realizar a transferência.");

            var novaTransacao = new Dominio.Entidades.Transacao
            {
                ContaId = request.ContaId,
                ContaDestinoId = contaDestino.Id,
                Valor = request.Valor,
                Tipo = TipoTransacao.Transferencia,
                Data = DateTime.UtcNow
            };

            await _transacaoRepositorio.AdicionarAsync(novaTransacao);

            return Unit.Value;
        }
    }
}
