using FinanceCNPJ.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace FinanceCNPJ.Infraestrutura.Persistencia.Contexto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Conta> Contas => Set<Conta>();
        public DbSet<Transacao> Transacoes => Set<Transacao>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transacao>()
                .HasOne(t => t.ContaDestino) 
                .WithMany() 
                .HasForeignKey(t => t.ContaDestinoId);
        }
    }
}
