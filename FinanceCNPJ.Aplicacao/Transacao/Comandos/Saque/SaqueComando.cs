using FinanceCNPJ.Aplicacao.Transacao.Comandos.Base;
using MediatR;

namespace FinanceCNPJ.Aplicacao.Transacao.Comandos.Saque
{
    public class SaqueComando : TransacaoComandoBase, IRequest<Unit>
    {
    }
}
