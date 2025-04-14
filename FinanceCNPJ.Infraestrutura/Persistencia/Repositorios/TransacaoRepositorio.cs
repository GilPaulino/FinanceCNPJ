using FinanceCNPJ.Dominio.Entidades;
using FinanceCNPJ.Dominio.Repositorios;
using FinanceCNPJ.Infraestrutura.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace FinanceCNPJ.Infraestrutura.Repositorios
{
    public class TransacaoRepositorio : ITransacaoRepositorio
    {
        private readonly AppDbContext _contexto;

        public TransacaoRepositorio(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarAsync(Transacao transacao)
        {
            await _contexto.Transacoes.AddAsync(transacao);
            await _contexto.SaveChangesAsync();
        }
        public async Task<List<Transacao>> ObterPorContaIdAsync(long contaId)
        {
            return await _contexto.Transacoes
                .Where(t => t.ContaId == contaId || t.ContaDestinoId == contaId)
                .OrderBy(t => t.Data)
                .ToListAsync();
        }
    }
}
