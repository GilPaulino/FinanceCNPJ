using FinanceCNPJ.Dominio.Enums;

namespace FinanceCNPJ.Dominio.Entidades
{
    public class Transacao
    {
        public long Id { get; set; }
        public required decimal Valor { get; set; }
        public required TipoTransacao Tipo { get; set; }
        public required DateTime Data { get; set; }
        public long ContaId { get; set; }
        public Conta Conta { get; set; } = null!;
        public long? ContaDestinoId { get; set; }
        public Conta? ContaDestino { get; set; }
    }
}
