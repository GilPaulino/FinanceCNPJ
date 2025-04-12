using FinanceCNPJ.Aplicacao.Conta.Servicos.Interfaces;
using System.Net.Http.Json;

namespace FinanceCNPJ.Aplicacao.Conta.Servicos.Implementacoes
{
    public class ReceitaWsService : IReceitaWsService
    {
        private readonly HttpClient _httpClient;

        public ReceitaWsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> ObterNomeEmpresaPorCnpjAsync(string cnpjLimpo)
        {
            var resposta = await _httpClient.GetFromJsonAsync<ReceitaWsResponse>($"https://receitaws.com.br/v1/cnpj/{cnpjLimpo}");
            return resposta?.Nome ?? throw new Exception("Empresa não encontrada na ReceitaWS.");
        }

        private class ReceitaWsResponse
        {
            public string Nome { get; set; } = string.Empty;
        }
    }
}
