using FinanceCNPJ.Aplicacao.Conta.Servicos.Interfaces;
using System.Net;
using System.Net.Http.Json;

namespace FinanceCNPJ.Aplicacao.Conta.Servicos.Implementacoes
{
    public class ReceitaWsService : IReceitaWsService
    {
        private readonly HttpClient _httpClient;
        private const int MaxTentativas = 3;
        private const int DelayEntreTentativasMs = 5000;

        public ReceitaWsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> ObterNomeEmpresaPorCnpjAsync(string cnpjLimpo)
        {
            for (int tentativa = 1; tentativa <= MaxTentativas; tentativa++)
            {
                var respostaHttp = await _httpClient.GetAsync($"https://receitaws.com.br/v1/cnpj/{cnpjLimpo}");

                if (respostaHttp.StatusCode == HttpStatusCode.TooManyRequests)
                {
                    if (tentativa == MaxTentativas)
                        throw new Exception("Limite de requisições à ReceitaWS atingido. Tente novamente mais tarde.");

                    await Task.Delay(DelayEntreTentativasMs);
                    continue;
                }

                if (respostaHttp.StatusCode == HttpStatusCode.GatewayTimeout)
                    throw new Exception("Timeout na ReceitaWS. Os dados podem não estar disponíveis no momento.");

                if (!respostaHttp.IsSuccessStatusCode)
                    throw new Exception($"Erro ao consultar a ReceitaWS: {respostaHttp.StatusCode}");

                var dados = await respostaHttp.Content.ReadFromJsonAsync<ReceitaWsResponse>();
                return dados?.Nome ?? throw new Exception("Empresa não encontrada na ReceitaWS.");
            }

            throw new Exception("Falha ao consultar a ReceitaWS após múltiplas tentativas.");
        }

        private class ReceitaWsResponse
        {
            public string Nome { get; set; } = string.Empty;
        }
    }
}
