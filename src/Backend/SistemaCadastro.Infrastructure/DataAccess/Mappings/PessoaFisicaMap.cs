namespace SistemaCadastro.Infrastructure.DataAccess.Mappings;

public class PessoaFisicaMap : IEntityTypeConfiguration<PessoaFisica>
{
    public void Configure(EntityTypeBuilder<PessoaFisica> builder)
    {
        builder.OwnsOne(p => p.Cpf, navigationBuilder =>
        {
            navigationBuilder.Property(c => c.Valor)
            .HasColumnName("Cpf")
            .IsRequired();
        });

        builder.Property(p => p.Nascimento)
        .HasColumnName("Nascimento")
        .IsRequired();
    }
}
