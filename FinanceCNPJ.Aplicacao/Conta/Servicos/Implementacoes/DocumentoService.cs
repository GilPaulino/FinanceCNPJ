using FinanceCNPJ.Aplicacao.Conta.Servicos.Interfaces;

namespace FinanceCNPJ.Aplicacao.Conta.Servicos.Implementacoes
{
    public class DocumentoService : IDocumentoService
    {
        private readonly string _caminhoBase = Path.Combine(Directory.GetCurrentDirectory(), "Documentos");

        public async Task<string> SalvarDocumentoAsync(string nomeEmpresa, string base64)
        {
            if (!Directory.Exists(_caminhoBase))
                Directory.CreateDirectory(_caminhoBase);

            var bytes = Convert.FromBase64String(base64);
            var extensao = DetectarExtensao(base64);
            var nomeArquivo = $"Doc{nomeEmpresa}.{extensao}";
            var caminhoCompleto = Path.Combine(_caminhoBase, nomeArquivo);

            await File.WriteAllBytesAsync(caminhoCompleto, bytes);

            return caminhoCompleto;
        }

        private string DetectarExtensao(string base64)
        {
            if (base64.StartsWith("iVBOR")) return "png";
            if (base64.StartsWith("/9j/")) return "jpg";
            if (base64.StartsWith("JVBER")) return "pdf";
            return "bin";
        }
    }
}
