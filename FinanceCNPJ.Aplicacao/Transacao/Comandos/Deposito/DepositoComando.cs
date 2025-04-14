using FinanceCNPJ.Aplicacao.Transacao.Comandos.Base;
using MediatR;

namespace FinanceCNPJ.Aplicacao.Transacao.Comandos.Deposito
{
    public class DepositoComando : TransacaoComandoBase, IRequest<Unit>
    {
    }
}
