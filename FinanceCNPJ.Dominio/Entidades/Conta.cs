namespace FinanceCNPJ.Dominio.Entidades
{
    public class Conta
    {
        public long Id { get; set; }
        public string Nome { get; set; } = null!;
        public string CNPJ { get; set; } = null!;
        public string NumeroConta { get; set; } = null!;
        public string Agencia { get; set; } = null!;
        public string CaminhoDocumento { get; set; } = null!;
    }
}
