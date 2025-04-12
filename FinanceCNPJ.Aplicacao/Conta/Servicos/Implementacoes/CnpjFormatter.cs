using System.Text.RegularExpressions;
using FinanceCNPJ.Aplicacao.Conta.Servicos.Interfaces;

namespace FinanceCNPJ.Aplicacao.Conta.Servicos.Implementacoes
{
    public class CnpjFormatter : ICnpjFormatter
    {
        public string RemoverMascara(string cnpj)
        {
            return Regex.Replace(cnpj, "[^0-9]", "");
        }
    }
}
