using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Requisicao_RSS.Domain.Entities;
using System;

namespace Requisicao_RSS.Infra.Data.EntitiesConfiguration
{
    public class RequisicaoConfiguration : IEntityTypeConfiguration<Requisicao>
    {
        public void Configure(EntityTypeBuilder<Requisicao> builder)
        {
            builder.HasKey(r => r.RequisicaoId);

            builder.Property(r => r.Registro)
                .IsRequired();


            builder.Property(r => r.Data)
                .IsRequired()
                .HasColumnType("datetime");
                
                   
            builder.Property(r => r.TamanhoCamisa)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(r => r.TamanhoCalca)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(r => r.QuantidadeCamisa)
                .IsRequired();

            builder.Property(r => r.QuantidadeCalca)
                .IsRequired();

            builder.Property(r => r.QuantidadeLuva)
                .IsRequired();

            builder.Property(r => r.Divergencia)
               .IsRequired();

            builder.Property(r => r.Observacoes);

            builder.HasOne(r => r.Funcionario).WithMany(r => r.Requisicoes).HasForeignKey(r => r.FuncionarioId);
        }
    }
}
