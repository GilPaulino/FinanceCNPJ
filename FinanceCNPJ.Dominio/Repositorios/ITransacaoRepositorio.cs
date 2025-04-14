using FinanceCNPJ.Dominio.Entidades;

public interface ITransacaoRepositorio
{
    Task AdicionarAsync(Transacao transacao);
    Task<List<Transacao>> ObterPorContaIdAsync(long contaId);

}
