using FinanceCNPJ.Dominio.Entidades;
using FinanceCNPJ.Dominio.Repositorios;
using FinanceCNPJ.Infraestrutura.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace FinanceCNPJ.Infraestrutura.Persistencia.Repositorios
{
    public class ContaRepositorio : IContaRepositorio
    {
        private readonly AppDbContext _contexto;

        public ContaRepositorio(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarAsync(Conta conta)
        {
            await _contexto.Contas.AddAsync(conta);
            await _contexto.SaveChangesAsync();
        }

        public async Task<bool> CnpjExisteAsync(string cnpj)
        {
            return await _contexto.Contas.AnyAsync(c => c.CNPJ == cnpj);
        }

        public async Task<string> ObterProximoNumeroContaAsync()
        {
            var ultimaConta = await _contexto.Contas
                .OrderByDescending(c => c.NumeroConta)
                .FirstOrDefaultAsync();

            if (ultimaConta == null || string.IsNullOrWhiteSpace(ultimaConta.NumeroConta))
                return "00001";

            var ultimoNumero = int.Parse(ultimaConta.NumeroConta);
            var proximoNumero = ultimoNumero + 1;

            return proximoNumero.ToString("D5");
        }

        public async Task AtualizarAsync(Conta conta)
        {
            _contexto.Contas.Update(conta);
            await _contexto.SaveChangesAsync();
        }

        public async Task ExcluirAsync(long id)
        {
            var conta = await _contexto.Contas.FindAsync(id);
            if (conta != null)
            {
                _contexto.Contas.Remove(conta); 
                await _contexto.SaveChangesAsync();
            }
        }

        public async Task<Conta?> ObterPorIdAsync(long id) => await _contexto.Contas.FindAsync(id);

        public async Task<List<Conta>> BuscarAsync(string? cnpj, string? nome, string? numeroConta, string? agencia)
        {
            var query = _contexto.Contas.AsQueryable();

            if (!string.IsNullOrEmpty(cnpj))
                query = query.Where(c => c.CNPJ.Contains(cnpj));

            if (!string.IsNullOrEmpty(nome))
                query = query.Where(c => c.Nome.Contains(nome));

            if (!string.IsNullOrEmpty(numeroConta))
                query = query.Where(c => c.NumeroConta.Contains(numeroConta));

            if (!string.IsNullOrEmpty(agencia))
                query = query.Where(c => c.Agencia.Contains(agencia));

            return await query.ToListAsync();
        }
    }
}
