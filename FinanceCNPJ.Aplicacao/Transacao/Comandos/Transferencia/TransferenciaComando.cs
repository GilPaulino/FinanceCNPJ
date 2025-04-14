using MediatR;

namespace FinanceCNPJ.Aplicacao.Transacao.Comandos.Transferencia
{
    public class TransferenciaComando : IRequest
    {
        public long ContaId { get; set; }
        public decimal Valor { get; set; }
        public required string NumeroConta { get; set; }
        public required string Agencia { get; set; }
    }
}
