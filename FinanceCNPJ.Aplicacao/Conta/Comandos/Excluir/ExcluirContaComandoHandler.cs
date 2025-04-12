using FinanceCNPJ.Aplicacao.Conta.Comandos.Excluir;
using FinanceCNPJ.Dominio.Repositorios;
using MediatR;

public class ExcluirContaComandoHandler : IRequestHandler<ExcluirContaComando, Unit>
{
    private readonly IContaRepositorio _contaRepositorio;

    public ExcluirContaComandoHandler(IContaRepositorio contaRepositorio)
    {
        _contaRepositorio = contaRepositorio;
    }

    public async Task<Unit> Handle(ExcluirContaComando comando, CancellationToken cancellationToken)
    {
        var conta = await _contaRepositorio.ObterPorIdAsync(comando.Id);
        if (conta == null)
            throw new ArgumentException("Conta não encontrada.");

        await _contaRepositorio.ExcluirAsync(conta.Id);

        return Unit.Value;
    }
}
