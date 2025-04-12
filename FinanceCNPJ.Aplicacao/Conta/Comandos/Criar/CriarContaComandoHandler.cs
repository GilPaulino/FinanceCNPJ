using FinanceCNPJ.Aplicacao.Conta.Comandos.Criar;
using FinanceCNPJ.Aplicacao.Conta.Servicos.Interfaces;
using FinanceCNPJ.Aplicacao.Conta.ViewModel;
using FinanceCNPJ.Dominio.Entidades;
using FinanceCNPJ.Dominio.Repositorios;
using MediatR;
using FluentValidation;

public class CriarContaComandoHandler : IRequestHandler<CriarContaComando, ContaViewModel>
{
    private readonly IContaRepositorio _contaRepositorio;
    private ICnpjFormatter _formatadorCnpj;
    private IReceitaWsService _receitaWs;
    private readonly IDocumentoService _documentoService;
    private readonly IValidator<CriarContaComando> _validador;

    public CriarContaComandoHandler(
        ICnpjFormatter formatadorCnpj,
        IReceitaWsService receitaWs,
        IDocumentoService documentoService,
        IContaRepositorio contaRepositorio,
        IValidator<CriarContaComando> validador)
    {
        _formatadorCnpj = formatadorCnpj;
        _receitaWs = receitaWs;
        _documentoService = documentoService;
        _contaRepositorio = contaRepositorio;
        _validador = validador;
    }

    public async Task<ContaViewModel> Handle(CriarContaComando comando, CancellationToken cancellationToken)
    {
        var resultadoValidacao = await _validador.ValidateAsync(comando, cancellationToken);
        if (!resultadoValidacao.IsValid)
        {
            throw new ValidationException(resultadoValidacao.Errors);
        }

        var cnpjSemMascara = _formatadorCnpj.RemoverMascara(comando.CNPJ);
        var nomeEmpresa = await _receitaWs.ObterNomeEmpresaPorCnpjAsync(cnpjSemMascara);
        var caminhoDocumento = await _documentoService.SalvarDocumentoAsync(nomeEmpresa, comando.DocumentoBase64);
        var numeroConta = await _contaRepositorio.ObterProximoNumeroContaAsync();

        var conta = new Conta
        {
            Nome = nomeEmpresa,
            CNPJ = cnpjSemMascara,
            NumeroConta = numeroConta,
            Agencia = "0001",
            CaminhoDocumento = caminhoDocumento
        };

        await _contaRepositorio.AdicionarAsync(conta);

        return new ContaViewModel
        {
            Id = conta.Id,
            Nome = conta.Nome,
            CNPJ = conta.CNPJ,
            NumeroConta = conta.NumeroConta,
            Agencia = conta.Agencia,
            CaminhoDocumento = conta.CaminhoDocumento
        };
    }
}
