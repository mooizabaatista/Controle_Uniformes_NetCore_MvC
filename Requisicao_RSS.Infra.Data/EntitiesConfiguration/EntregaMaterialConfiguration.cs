using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Requisicao_RSS.Domain.Entities;

namespace Requisicao_RSS.Infra.Data.EntitiesConfiguration
{
    public class EntregaMaterialConfiguration : IEntityTypeConfiguration<EntregaMaterial>
    {
        public void Configure(EntityTypeBuilder<EntregaMaterial> builder)
        {
            builder.HasKey(e => e.EntregaMaterialId);

            builder.Property(r => r.NomeFornecedor)
                .IsRequired();

            builder.Property(r => r.Tipo)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(r => r.QuantidadeCamisas)
               .IsRequired();

            builder.Property(r => r.QuantidadeCalcas)
               .IsRequired();

            builder.Property(r => r.QuantidadeLuvas)
               .IsRequired();

            builder.Property(r => r.Divergencia)
                .IsRequired();

            builder.Property(r => r.Observacoes);

            builder.HasOne(r => r.Fornecedor).WithMany(r => r.EntregaMateriais).HasForeignKey(r => r.FornecedorId);
        }
    }
}
