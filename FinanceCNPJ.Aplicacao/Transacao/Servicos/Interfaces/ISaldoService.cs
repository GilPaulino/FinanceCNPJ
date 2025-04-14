using System.Threading.Tasks;

namespace FinanceCNPJ.Aplicacao.Transacao.Servicos.Interfaces
{
    public interface ISaldoService
    {
        Task<decimal> CalcularSaldoAsync(long contaId);
    }
}
