using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Requisicao_RSS.Domain.Entities;

namespace Requisicao_RSS.Infra.Data.EntitiesConfiguration
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(f => f.FuncionarioId);

            builder.Property(f => f.Registro)
                .IsRequired();

            builder.HasIndex(f => f.Registro)
                .IsUnique();

            builder.Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(f => f.Funcao)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(f => f.Turno)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(f => f.BaseCamisa)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(f => f.BaseCalca)
                .IsRequired()
                .HasMaxLength(20);

        }
    }
}
