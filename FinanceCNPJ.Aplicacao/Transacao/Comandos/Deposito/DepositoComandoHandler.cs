using FinanceCNPJ.Dominio.Entidades;
using FinanceCNPJ.Dominio.Enums;
using FinanceCNPJ.Dominio.Repositorios;
using MediatR;

namespace FinanceCNPJ.Aplicacao.Transacao.Comandos.Deposito
{
    public class DepositoComandoHandler : IRequestHandler<DepositoComando, Unit>
    {
        private readonly IContaRepositorio _contaRepositorio;
        private readonly ITransacaoRepositorio _transacaoRepositorio;

        public DepositoComandoHandler(
            IContaRepositorio contaRepositorio,
            ITransacaoRepositorio transacaoRepositorio)
        {
            _contaRepositorio = contaRepositorio;
            _transacaoRepositorio = transacaoRepositorio;
        }

        public async Task<Unit> Handle(DepositoComando request, CancellationToken cancellationToken)
        {

            var conta = await _contaRepositorio.ObterPorIdAsync(request.ContaId);
            if (conta is null)
                throw new ArgumentException("Conta de origem não encontrada.");

            var transacao = new Dominio.Entidades.Transacao
            {
                ContaId = request.ContaId,
                Valor = request.Valor,
                Tipo = TipoTransacao.Deposito,
                Data = DateTime.UtcNow,
                ContaDestinoId = null 
            };

            await _transacaoRepositorio.AdicionarAsync(transacao);


            return Unit.Value;
        }
    }
}
