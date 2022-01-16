using Microsoft.EntityFrameworkCore;
using Requisicao_RSS.Domain.Entities;

namespace Requisicao_RSS.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }

        // Mapeamento das entidades
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Requisicao> Requisicoes { get; set; }
        public DbSet<EntregaMaterial> EntregaMateriais { get; set; }
        public DbSet<RetiradaMaterial> RetiradaMateriais { get; set; }

        // Aplicando as configurações das entidades
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }       
    }
}
