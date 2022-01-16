using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Requisicao_RSS.Domain.Entities;

namespace Requisicao_RSS.Infra.Data.EntitiesConfiguration
{
    public class RetiradaMaterialConfiguration : IEntityTypeConfiguration<RetiradaMaterial>
    {
        public void Configure(EntityTypeBuilder<RetiradaMaterial> builder)
        {
            builder.HasKey(r => r.RetiradaMaterialId);

            builder.Property(r => r.Data)
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

            builder.HasOne(r => r.Fornecedor).WithMany(r => r.RetiradaMateriais).HasForeignKey(r => r.FornecedorId);
        }
    }
}
