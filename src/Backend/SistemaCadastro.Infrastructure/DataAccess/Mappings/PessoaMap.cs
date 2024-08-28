using Microsoft.EntityFrameworkCore;
using SistemaCadastro.Domain.Contexts.Cadastro.Abstractions;

namespace SistemaCadastro.Infrastructure.DataAccess.Mappings;

public class PessoaMap : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Pessoa> builder)
    {
        builder.ToTable("Pessoas");

        builder.HasKey(p => p.Id);

        builder.OwnsOne(p => p.Nome, navigationBuilder =>
        {
            navigationBuilder.Property(n => n.PrimeiroNome)
            .HasColumnName("PrimeiroNome")
            .IsRequired();

            navigationBuilder.Property(n => n.Sobrenome)
            .HasColumnName("Sobrenome")
            .IsRequired();

            navigationBuilder.Property(n => n.NomeFantasia)
            .HasColumnName("NomeFantasia")
            .IsRequired();
        });

        builder.OwnsOne(p => p.Email, navigationBuilder =>
        {
            navigationBuilder.Property(e => e.Valor)
            .HasColumnName("Email")
            .IsRequired();
        });

        builder.OwnsOne(p => p.Telefone, navigationBuilder =>
        {
            navigationBuilder.Property(t => t.Numero)
            .HasColumnName("TelefoneNumero")
            .IsRequired();

            navigationBuilder.Property(t => t.Celular)
            .HasColumnName("TelefoneCelular")
            .IsRequired();

            navigationBuilder.Property(t => t.Whatsapp)
            .HasColumnName("TelefoneWhatsapp")
            .IsRequired();

            navigationBuilder.Property(t => t.Telegram)
            .HasColumnName("TelefoneTelegram")
            .IsRequired();
        });

        builder.Property(p => p.Token)
                .HasMaxLength(255);

        builder.OwnsMany(p => p.Domicilios, navigationBuilder =>
        {
            navigationBuilder.ToTable("Domicilios");
            navigationBuilder.WithOwner().HasForeignKey("PessoaId");
            navigationBuilder.Property<Guid>("Id");
            navigationBuilder.HasKey("Id");

            navigationBuilder.Property(d => d.Tipo).HasColumnName("DomicilioTipo").IsRequired();

            navigationBuilder.OwnsOne(d => d.Endereco, navigationBuilder =>
            {
                navigationBuilder.Property(e => e.Cep)
                .HasColumnName("Cep")
                .HasMaxLength(8)
                .IsRequired();

                navigationBuilder.Property(e => e.Logradouro)
                .HasColumnName("Logradouro")
                .HasMaxLength(255)
                .IsRequired();

                navigationBuilder.Property(e => e.Numero)
                .HasColumnName("Numero")
                .HasMaxLength(5)
                .IsRequired();

                navigationBuilder.Property(e => e.Bairro).HasColumnName("Bairro")
                .HasMaxLength(50)
                .IsRequired();

                navigationBuilder.Property(e => e.Complemento)
                .HasColumnName("Complemento")
                .HasMaxLength(255);

                navigationBuilder.Property(e => e.PontoReferencia)
                .HasColumnName("PontoReferencia")
                .HasMaxLength(255);

                navigationBuilder.Property(e => e.Uf)
                .HasColumnName("Uf")
                .HasMaxLength(2)
                .IsRequired();

                navigationBuilder.Property(e => e.Cidade)
                .HasColumnName("Cidade")
                .HasMaxLength(50)
                .IsRequired();

                navigationBuilder.Property(e => e.Ibge)
                .HasColumnName("Ibge");
            });
        });
    }
}
