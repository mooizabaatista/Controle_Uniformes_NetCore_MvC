using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Requisicao_RSS.Infra.Data.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Utilizado para criar as migrações em tempo de desenvolvimento da aplicão
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=Requisicoes_RSS_;Trusted_Connection=True;");
            optionsBuilder.UseLazyLoadingProxies();

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
