using FinanceCNPJ.Infraestrutura.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FinanceCNPJ.Infraestrutura.Persistencia.Fabricas
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=Gilmpeg12;Database=financecnpj");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
