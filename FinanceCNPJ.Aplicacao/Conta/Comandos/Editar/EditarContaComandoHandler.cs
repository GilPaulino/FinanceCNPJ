using FinanceCNPJ.Aplicacao.Conta.Servicos.Interfaces;
using FinanceCNPJ.Aplicacao.Conta.ViewModel;
using FinanceCNPJ.Dominio.Repositorios;
using MediatR;

namespace FinanceCNPJ.Aplicacao.Conta.Comandos.Editar
{
    public class EditarContaComandoHandler : IRequestHandler<EditarContaComando, ContaViewModel>
    {
        private readonly IContaRepositorio _contaRepositorio;
        private readonly IDocumentoService _documentoService;

        public EditarContaComandoHandler(IContaRepositorio contaRepositorio, IDocumentoService documentoService)
        {
            _contaRepositorio = contaRepositorio;
            _documentoService = documentoService;
        }

        public async Task<ContaViewModel> Handle(EditarContaComando comando, CancellationToken cancellationToken)
        {
            var conta = await _contaRepositorio.ObterPorIdAsync(comando.Id);

            if (conta == null)
                throw new ArgumentException("Conta não encontrada.");

            var caminhoDocumento = await _documentoService.SalvarDocumentoAsync(conta.Nome, comando.DocumentoBase64);
            conta.CaminhoDocumento = caminhoDocumento;

            await _contaRepositorio.AtualizarAsync(conta);

            return new ContaViewModel
            {
                Id = conta.Id,
                Nome = conta.Nome,
                CNPJ = conta.CNPJ,
                NumeroConta = conta.NumeroConta,
                Agencia = conta.Agencia,
                CaminhoDocumento = conta.CaminhoDocumento,
            };
        }
    }

}
