namespace FinanceCNPJ.Aplicacao.Conta.Servicos.Interfaces
{
    public interface IDocumentoService
    {
        Task<string> SalvarDocumentoAsync(string nomeEmpresa, string base64);
    }
}
