namespace FinanceCNPJ.Aplicacao.Conta.Servicos.Interfaces
{
    public interface IReceitaWsService
    {
        Task<string> ObterNomeEmpresaPorCnpjAsync(string cnpjLimpo);
    }
}
