using MediatR;

namespace FinanceCNPJ.Aplicacao.Conta.Comandos.Excluir
{
    public class ExcluirContaComando : IRequest<Unit>
    {
        public long Id { get; }

        public ExcluirContaComando(long id)
        {
            Id = id;
        }
    }
}
