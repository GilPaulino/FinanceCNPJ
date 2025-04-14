using FinanceCNPJ.Aplicacao.Transacao.Servicos.Interfaces;
using FinanceCNPJ.Dominio.Entidades;
using FinanceCNPJ.Dominio.Enums;
using FinanceCNPJ.Dominio.Repositorios;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceCNPJ.Aplicacao.Transacao.Comandos.Saque
{
    public class SaqueComandoHandler : IRequestHandler<SaqueComando, Unit>
    {
        private readonly IContaRepositorio _contaRepositorio;
        private readonly ITransacaoRepositorio _transacaoRepositorio;
        private readonly ISaldoService _saldoService;
        public SaqueComandoHandler(IContaRepositorio contaRepositorio, ITransacaoRepositorio transacaoRepositorio, ISaldoService saldoService)
        {
            _contaRepositorio = contaRepositorio;
            _transacaoRepositorio = transacaoRepositorio;
            _saldoService = saldoService;
        }

        public async Task<Unit> Handle(SaqueComando request, CancellationToken cancellationToken)
        {
            var conta = await _contaRepositorio.ObterPorIdAsync(request.ContaId);
            if (conta is null)
                throw new ArgumentException("Conta não encontrada.");

            var saldo = await _saldoService.CalcularSaldoAsync(request.ContaId);

            if (saldo < request.Valor)
                throw new InvalidOperationException("Saldo insuficiente para realizar o saque.");

            var novaTransacao = new Dominio.Entidades.Transacao
            {
                ContaId = request.ContaId,
                Valor = request.Valor,
                Tipo = TipoTransacao.Saque,
                Data = DateTime.UtcNow, 
                ContaDestinoId = null 
            };

            await _transacaoRepositorio.AdicionarAsync(novaTransacao);

            return Unit.Value;
        }
    }
}
