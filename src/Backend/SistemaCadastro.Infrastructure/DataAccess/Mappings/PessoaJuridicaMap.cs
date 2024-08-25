using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.Entities;

namespace SistemaCadastro.Infrastructure.DataAccess.Mappings;

public class PessoaJuridicaMap : IEntityTypeConfiguration<PessoaJuridica>
{
    public void Configure(EntityTypeBuilder<PessoaJuridica> builder)
    {
        builder.OwnsOne(p => p.Cnpj, cnpj =>
        {
            cnpj.Property(c => c.Valor)
            .HasColumnName("Cnpj")
            .IsRequired();
        });

        builder.Property(p => p.RazaoSocial)
        .HasColumnName("RazaoSocial")
        .HasMaxLength(30)
        .IsRequired();
    }
}
