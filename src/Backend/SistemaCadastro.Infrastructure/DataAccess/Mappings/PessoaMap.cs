using Microsoft.EntityFrameworkCore;
using SistemaCadastro.Domain.Contexts.Cadastro.Abstractions;

namespace SistemaCadastro.Infrastructure.DataAccess.Mappings;

public class PessoaMap : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Pessoa> builder)
    {
        builder.ToTable("Pessoas");

        builder.HasKey(p => p.Id);

        builder.OwnsOne(p => p.Nome, n =>
        {
            n.Property(n => n.PrimeiroNome)
            .HasColumnName("PrimeiroNome")
            .IsRequired();

            n.Property(n => n.Sobrenome)
            .HasColumnName("Sobrenome")
            .IsRequired();

            n.Property(n => n.NomeFantasia)
            .HasColumnName("NomeFantasia")
            .IsRequired();

            n.Property(n => n.SobrenomeSocial)
            .HasColumnName("SobrenomeSocial");
        });

        builder.OwnsOne(p => p.Email, e =>
        {
            e.Property(e => e.Valor)
            .HasColumnName("Email")
            .IsRequired();
        });

        builder.OwnsOne(p => p.Telefone, telefoneBuilder =>
        {
            telefoneBuilder.Property(t => t.Numero)
            .HasColumnName("TelefoneNumero")
            .IsRequired();

            telefoneBuilder.Property(t => t.Celular)
            .HasColumnName("TelefoneCelular")
            .IsRequired();

            telefoneBuilder.Property(t => t.Whatsapp)
            .HasColumnName("TelefoneWhatsapp")
            .IsRequired();

            telefoneBuilder.Property(t => t.Telegram)
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

            navigationBuilder.OwnsOne(d => d.Endereco, enderecoBuilder =>
            {
                enderecoBuilder.Property(e => e.Cep)
                .HasColumnName("Cep")
                .HasMaxLength(8)
                .IsRequired();

                enderecoBuilder.Property(e => e.Logradouro)
                .HasColumnName("Logradouro")
                .HasMaxLength(255)
                .IsRequired();

                enderecoBuilder.Property(e => e.Numero)
                .HasColumnName("Numero")
                .HasMaxLength(5)
                .IsRequired();

                enderecoBuilder.Property(e => e.Bairro).HasColumnName("Bairro")
                .HasMaxLength(50)
                .IsRequired();

                enderecoBuilder.Property(e => e.Complemento)
                .HasColumnName("Complemento")
                .HasMaxLength(255);

                enderecoBuilder.Property(e => e.PontoReferencia)
                .HasColumnName("PontoReferencia")
                .HasMaxLength(255);

                enderecoBuilder.Property(e => e.Uf)
                .HasColumnName("Uf")
                .HasMaxLength(2)
                .IsRequired();

                enderecoBuilder.Property(e => e.Cidade)
                .HasColumnName("Cidade")
                .HasMaxLength(50)
                .IsRequired();

                enderecoBuilder.Property(e => e.Ibge)
                .HasColumnName("Ibge");
            });
        });
    }
}
