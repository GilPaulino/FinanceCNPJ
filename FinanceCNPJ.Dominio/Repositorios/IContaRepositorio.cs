using FinanceCNPJ.Dominio.Entidades;
namespace FinanceCNPJ.Dominio.Repositorios
{
    public interface IContaRepositorio
    {
        Task AdicionarAsync(Conta conta);
        Task<bool> CnpjExisteAsync(string cnpj);
        Task<string> ObterProximoNumeroContaAsync();
        Task<Conta?> ObterPorIdAsync(long id);
        Task AtualizarAsync(Conta conta);
        Task ExcluirAsync(long id);
        Task<List<Conta>> BuscarAsync(string? cnpj, string? nome, string? numeroConta, string? agencia);
    }
}
