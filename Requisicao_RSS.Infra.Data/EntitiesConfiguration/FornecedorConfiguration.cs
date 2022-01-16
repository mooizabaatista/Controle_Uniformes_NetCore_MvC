using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Requisicao_RSS.Domain.Entities;

namespace Requisicao_RSS.Infra.Data.EntitiesConfiguration
{
    public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(f => f.FornecedorId);

            builder.Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(f => f.Telefone)
               .IsRequired()
               .HasMaxLength(14);

            builder.Property(f => f.CNPJ)
               .IsRequired()
               .HasMaxLength(18);
        }
    }
}
