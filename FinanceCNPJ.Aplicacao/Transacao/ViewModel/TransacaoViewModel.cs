using FinanceCNPJ.Dominio.Enums;

namespace FinanceCNPJ.Aplicacao.Transacao.ViewModel
{
    public class TransacaoViewModel
    {
        public TipoTransacao Tipo { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public long ContaId { get; set; }
        public long? ContaDestinoId { get; set; }
    }
}
