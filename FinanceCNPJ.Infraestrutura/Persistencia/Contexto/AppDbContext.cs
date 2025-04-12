using FinanceCNPJ.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace FinanceCNPJ.Infraestrutura.Persistencia.Contexto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Conta> Contas => Set<Conta>();
    }
}
