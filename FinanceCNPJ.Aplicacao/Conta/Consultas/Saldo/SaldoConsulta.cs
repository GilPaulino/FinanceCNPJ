using MediatR;

namespace FinanceCNPJ.Aplicacao.Conta.Consultas.Saldo
{
    public class SaldoConsulta : IRequest<decimal>
    {
        public long ContaId { get; set; }
    }
}
