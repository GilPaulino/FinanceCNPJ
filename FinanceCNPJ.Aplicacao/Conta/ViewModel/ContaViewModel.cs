namespace FinanceCNPJ.Aplicacao.Conta.ViewModel
{
    public class ContaViewModel
    {
        public long Id { get; set; }
        public required string Nome { get; set; }
        public required string CNPJ { get; set; }
        public required string NumeroConta { get; set; }
        public required string Agencia { get; set; }
        public required string CaminhoDocumento { get; set; }
    }
}
