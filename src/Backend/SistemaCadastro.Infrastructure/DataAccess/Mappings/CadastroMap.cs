namespace SistemaCadastro.Infrastructure.DataAccess.Mappings;

public class CadastroMap : IEntityTypeConfiguration<Cadastro>
{
    public void Configure(EntityTypeBuilder<Cadastro> builder)
    {
        builder.ToTable("Cadastros");

        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.Pessoa)
            .WithOne()
            .HasForeignKey<Pessoa>(p => p.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.OwnsOne(c => c.Email, navigationBuilder =>
        {
            navigationBuilder.Property(e => e.Valor)
            .HasColumnName("Email")
            .IsRequired();
        });

        builder.OwnsOne(c => c.Nome, navigationBuilder =>
        {
            navigationBuilder.Property(n => n.PrimeiroNome)
            .HasColumnName("PrimeiroNome");

            navigationBuilder.Property(n => n.Sobrenome)
            .HasColumnName("Sobrenome");

            navigationBuilder.Property(n => n.NomeFantasia)
            .HasColumnName("NomeFantasia")
            .IsRequired()
            .HasMaxLength(50);

            navigationBuilder.Property(n => n.SobrenomeSocial)
            .HasColumnName("SobrenomeSocial")
            .IsRequired()
            .HasMaxLength(50);
        });


        builder.Property(c => c.Empresa)
            .IsRequired();

        builder.OwnsOne(c => c.Credencial, navigationBuilder =>
        {
            navigationBuilder.Property(c => c.Bloqueada)
            .HasColumnName("CredencialBloqueada")
            .IsRequired();

            navigationBuilder.Property(c => c.Expirada)
            .HasColumnName("CredencialExpirada")
            .IsRequired()

            .HasMaxLength(255);
            navigationBuilder.Property(c => c.Senha)
            .HasColumnName("CredencialSenha")
            .IsRequired()
            .HasMaxLength(255);
        });

        builder.OwnsOne(c => c.Inscrito, navigationBuilder =>
        {
            navigationBuilder.Property(i => i.Assinante)
            .HasColumnName("InscritoAssinante")
            .IsRequired();

            navigationBuilder.Property(i => i.Associado)
            .HasColumnName("InscritoAssociado")
            .IsRequired();

            navigationBuilder.Property(i => i.Afiliado)
            .HasColumnName("InscritoAfiliado")
            .IsRequired();
        });

        builder.OwnsOne(c => c.Parceiro, navigationBuilder =>
        {
            navigationBuilder.Property(p => p.Cliente).HasColumnName("ParceiroCliente").IsRequired();

            navigationBuilder.Property(p => p.Fornecedor).HasColumnName("ParceiroFornecedor").IsRequired();

            navigationBuilder.Property(p => p.Prestador).HasColumnName("ParceiroPrestador").IsRequired();

            navigationBuilder.Property(p => p.Colaborador).HasColumnName("ParceiroColaborador").IsRequired();
        });

        builder.OwnsOne(c => c.Documentacao, navigationBuilder =>
        {
            navigationBuilder.Property(d => d.Numero)
            .HasColumnName("DocumentoNumero")
            .IsRequired()
            .HasMaxLength(9);

            navigationBuilder.Property(d => d.OrgaoEmissor)
            .HasColumnName("DocumentoOrgaoEmissor")
            .IsRequired()
            .HasMaxLength(3);

            navigationBuilder.Property(d => d.EstadoEmissor)
            .HasColumnName("DocumentoEstadoEmissor")
            .IsRequired()

            .HasMaxLength(2);

            navigationBuilder.Property(d => d.Validade)
            .HasColumnName("DocumentoDataValidade")
            .IsRequired();
        });

        builder.OwnsOne(c => c.Identificacao, navigationBuilder =>
        {
            navigationBuilder.Property(i => i.Empresa)
            .HasColumnName("IdentificacaoEmpresa");

            navigationBuilder.Property(i => i.Identificador)
            .HasColumnName("IdentificacaoIdentificador")
            .IsRequired()
            .HasMaxLength(255);

            navigationBuilder.Property(i => i.Tipo)
            .HasColumnName("IdentificacaoTipo")
            .IsRequired();
        });

        builder.OwnsOne(p => p.Endereco, navigationBuilder =>
        {
            navigationBuilder.ToTable("Endereco");
            navigationBuilder.WithOwner().HasForeignKey("CadastroId");
            navigationBuilder.Property<Guid>("Id");
            navigationBuilder.HasKey("Id");

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

    }
}
