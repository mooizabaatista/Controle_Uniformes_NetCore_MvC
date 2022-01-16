using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Requisicao_RSS.Application.Interfaces;
using Requisicao_RSS.Application.Mappings;
using Requisicao_RSS.Application.Services;
using Requisicao_RSS.Domain.Interfaces;
using Requisicao_RSS.Infra.Data.Context;
using Requisicao_RSS.Infra.Data.Repositories;

namespace Requisicao_RSS.Infra.IoC
{
    public static class DependencyInjection
    {
        // Método utilizado para registrar o contexto, interfaces e classes de repositório, interfaces e classes de serviço
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                (b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))));

            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IRequisicaoRepository, RequisicaoRepository>();
            services.AddScoped<IEntregaMaterialRepository, EntregaMaterialRepository>();
            services.AddScoped<IRetiradaMaterialRepository, RetiradaMaterialRepository>();

            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IRequisicaoService, RequisicaoService>();
            services.AddScoped<IEntregaMaterialService, EntregaMaterialService>();
            services.AddScoped<IRetiradaMaterialService, RetiradaMaterialService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
