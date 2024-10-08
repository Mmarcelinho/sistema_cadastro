﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaCadastro.Infrastructure.DataAccess;

#nullable disable

namespace SistemaCadastro.Infrastructure.Migrations
{
    [DbContext(typeof(SistemaCadastroContext))]
    partial class SistemaCadastroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemaCadastro.Domain.Contexts.Cadastro.Abstractions.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<Guid>("Token")
                        .HasMaxLength(255)
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Pessoas", (string)null);

                    b.HasDiscriminator().HasValue("Pessoa");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.Entities.Cadastro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Empresa")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Cadastros", (string)null);
                });

            modelBuilder.Entity("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.Entities.PessoaFisica", b =>
                {
                    b.HasBaseType("SistemaCadastro.Domain.Contexts.Cadastro.Abstractions.Pessoa");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("Nascimento");

                    b.HasDiscriminator().HasValue("PessoaFisica");
                });

            modelBuilder.Entity("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.Entities.PessoaJuridica", b =>
                {
                    b.HasBaseType("SistemaCadastro.Domain.Contexts.Cadastro.Abstractions.Pessoa");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("RazaoSocial");

                    b.HasDiscriminator().HasValue("PessoaJuridica");
                });

            modelBuilder.Entity("SistemaCadastro.Domain.Contexts.Cadastro.Abstractions.Pessoa", b =>
                {
                    b.HasOne("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.Entities.Cadastro", null)
                        .WithOne("Pessoa")
                        .HasForeignKey("SistemaCadastro.Domain.Contexts.Cadastro.Abstractions.Pessoa", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("PessoaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Email");

                            b1.HasKey("PessoaId");

                            b1.ToTable("Pessoas");

                            b1.WithOwner()
                                .HasForeignKey("PessoaId");
                        });

                    b.OwnsOne("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects.Nome", "Nome", b1 =>
                        {
                            b1.Property<Guid>("PessoaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("NomeFantasia")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("NomeFantasia");

                            b1.Property<string>("PrimeiroNome")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("PrimeiroNome");

                            b1.Property<string>("Sobrenome")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Sobrenome");

                            b1.HasKey("PessoaId");

                            b1.ToTable("Pessoas");

                            b1.WithOwner()
                                .HasForeignKey("PessoaId");
                        });

                    b.OwnsMany("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.Entities.Domicilio", "Domicilios", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("PessoaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Tipo")
                                .HasColumnType("int")
                                .HasColumnName("DomicilioTipo");

                            b1.HasKey("Id");

                            b1.HasIndex("PessoaId");

                            b1.ToTable("Domicilios", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PessoaId");

                            b1.OwnsOne("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects.Endereco", "Endereco", b2 =>
                                {
                                    b2.Property<Guid>("DomicilioId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Bairro")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("nvarchar(50)")
                                        .HasColumnName("Bairro");

                                    b2.Property<string>("Cep")
                                        .IsRequired()
                                        .HasMaxLength(8)
                                        .HasColumnType("nvarchar(8)")
                                        .HasColumnName("Cep");

                                    b2.Property<string>("Cidade")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("nvarchar(50)")
                                        .HasColumnName("Cidade");

                                    b2.Property<string>("Complemento")
                                        .IsRequired()
                                        .HasMaxLength(255)
                                        .HasColumnType("nvarchar(255)")
                                        .HasColumnName("Complemento");

                                    b2.Property<int>("Ibge")
                                        .HasColumnType("int")
                                        .HasColumnName("Ibge");

                                    b2.Property<string>("Logradouro")
                                        .IsRequired()
                                        .HasMaxLength(255)
                                        .HasColumnType("nvarchar(255)")
                                        .HasColumnName("Logradouro");

                                    b2.Property<string>("Numero")
                                        .IsRequired()
                                        .HasMaxLength(5)
                                        .HasColumnType("nvarchar(5)")
                                        .HasColumnName("Numero");

                                    b2.Property<string>("PontoReferencia")
                                        .IsRequired()
                                        .HasMaxLength(255)
                                        .HasColumnType("nvarchar(255)")
                                        .HasColumnName("PontoReferencia");

                                    b2.Property<string>("Uf")
                                        .IsRequired()
                                        .HasMaxLength(2)
                                        .HasColumnType("nvarchar(2)")
                                        .HasColumnName("Uf");

                                    b2.HasKey("DomicilioId");

                                    b2.ToTable("Domicilios");

                                    b2.WithOwner()
                                        .HasForeignKey("DomicilioId");
                                });

                            b1.Navigation("Endereco")
                                .IsRequired();
                        });

                    b.OwnsOne("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects.Telefone", "Telefone", b1 =>
                        {
                            b1.Property<Guid>("PessoaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("Celular")
                                .HasColumnType("bit")
                                .HasColumnName("TelefoneCelular");

                            b1.Property<long>("Numero")
                                .HasColumnType("bigint")
                                .HasColumnName("TelefoneNumero");

                            b1.Property<bool>("Telegram")
                                .HasColumnType("bit")
                                .HasColumnName("TelefoneTelegram");

                            b1.Property<bool>("Whatsapp")
                                .HasColumnType("bit")
                                .HasColumnName("TelefoneWhatsapp");

                            b1.HasKey("PessoaId");

                            b1.ToTable("Pessoas");

                            b1.WithOwner()
                                .HasForeignKey("PessoaId");
                        });

                    b.Navigation("Domicilios");

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Nome")
                        .IsRequired();

                    b.Navigation("Telefone")
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.Entities.Cadastro", b =>
                {
                    b.OwnsOne("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("CadastroId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Email");

                            b1.HasKey("CadastroId");

                            b1.ToTable("Cadastros");

                            b1.WithOwner()
                                .HasForeignKey("CadastroId");
                        });

                    b.OwnsOne("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("Bairro");

                            b1.Property<Guid>("CadastroId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Cep")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("nvarchar(8)")
                                .HasColumnName("Cep");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("Cidade");

                            b1.Property<string>("Complemento")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasColumnName("Complemento");

                            b1.Property<int>("Ibge")
                                .HasColumnType("int")
                                .HasColumnName("Ibge");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasColumnName("Logradouro");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(5)
                                .HasColumnType("nvarchar(5)")
                                .HasColumnName("Numero");

                            b1.Property<string>("PontoReferencia")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasColumnName("PontoReferencia");

                            b1.Property<string>("Uf")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("nvarchar(2)")
                                .HasColumnName("Uf");

                            b1.HasKey("Id");

                            b1.HasIndex("CadastroId")
                                .IsUnique();

                            b1.ToTable("Endereco", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("CadastroId");
                        });

                    b.OwnsOne("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects.Nome", "Nome", b1 =>
                        {
                            b1.Property<Guid>("CadastroId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("NomeFantasia")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("NomeFantasia");

                            b1.Property<string>("PrimeiroNome")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("PrimeiroNome");

                            b1.Property<string>("Sobrenome")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Sobrenome");

                            b1.Property<string>("SobrenomeSocial")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("SobrenomeSocial");

                            b1.HasKey("CadastroId");

                            b1.ToTable("Cadastros");

                            b1.WithOwner()
                                .HasForeignKey("CadastroId");
                        });

                    b.OwnsOne("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects.Credencial", "Credencial", b1 =>
                        {
                            b1.Property<Guid>("CadastroId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("Bloqueada")
                                .HasColumnType("bit")
                                .HasColumnName("CredencialBloqueada");

                            b1.Property<string>("Expirada")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasColumnName("CredencialExpirada");

                            b1.Property<string>("Senha")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasColumnName("CredencialSenha");

                            b1.HasKey("CadastroId");

                            b1.ToTable("Cadastros");

                            b1.WithOwner()
                                .HasForeignKey("CadastroId");
                        });

                    b.OwnsOne("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects.Documentacao", "Documentacao", b1 =>
                        {
                            b1.Property<Guid>("CadastroId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("EstadoEmissor")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("nvarchar(2)")
                                .HasColumnName("DocumentoEstadoEmissor");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(9)
                                .HasColumnType("nvarchar(9)")
                                .HasColumnName("DocumentoNumero");

                            b1.Property<string>("OrgaoEmissor")
                                .IsRequired()
                                .HasMaxLength(3)
                                .HasColumnType("nvarchar(3)")
                                .HasColumnName("DocumentoOrgaoEmissor");

                            b1.Property<DateTime>("Validade")
                                .HasColumnType("datetime2")
                                .HasColumnName("DocumentoDataValidade");

                            b1.HasKey("CadastroId");

                            b1.ToTable("Cadastros");

                            b1.WithOwner()
                                .HasForeignKey("CadastroId");
                        });

                    b.OwnsOne("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects.Identificacao", "Identificacao", b1 =>
                        {
                            b1.Property<Guid>("CadastroId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int?>("Empresa")
                                .HasColumnType("int")
                                .HasColumnName("IdentificacaoEmpresa");

                            b1.Property<string>("Identificador")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasColumnName("IdentificacaoIdentificador");

                            b1.Property<int>("Tipo")
                                .HasColumnType("int")
                                .HasColumnName("IdentificacaoTipo");

                            b1.HasKey("CadastroId");

                            b1.ToTable("Cadastros");

                            b1.WithOwner()
                                .HasForeignKey("CadastroId");
                        });

                    b.OwnsOne("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects.Inscrito", "Inscrito", b1 =>
                        {
                            b1.Property<Guid>("CadastroId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("Afiliado")
                                .HasColumnType("bit")
                                .HasColumnName("InscritoAfiliado");

                            b1.Property<bool>("Assinante")
                                .HasColumnType("bit")
                                .HasColumnName("InscritoAssinante");

                            b1.Property<bool>("Associado")
                                .HasColumnType("bit")
                                .HasColumnName("InscritoAssociado");

                            b1.HasKey("CadastroId");

                            b1.ToTable("Cadastros");

                            b1.WithOwner()
                                .HasForeignKey("CadastroId");
                        });

                    b.OwnsOne("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects.Parceiro", "Parceiro", b1 =>
                        {
                            b1.Property<Guid>("CadastroId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("Cliente")
                                .HasColumnType("bit")
                                .HasColumnName("ParceiroCliente");

                            b1.Property<bool>("Colaborador")
                                .HasColumnType("bit")
                                .HasColumnName("ParceiroColaborador");

                            b1.Property<bool>("Fornecedor")
                                .HasColumnType("bit")
                                .HasColumnName("ParceiroFornecedor");

                            b1.Property<bool>("Prestador")
                                .HasColumnType("bit")
                                .HasColumnName("ParceiroPrestador");

                            b1.HasKey("CadastroId");

                            b1.ToTable("Cadastros");

                            b1.WithOwner()
                                .HasForeignKey("CadastroId");
                        });

                    b.Navigation("Credencial")
                        .IsRequired();

                    b.Navigation("Documentacao")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Endereco")
                        .IsRequired();

                    b.Navigation("Identificacao")
                        .IsRequired();

                    b.Navigation("Inscrito")
                        .IsRequired();

                    b.Navigation("Nome")
                        .IsRequired();

                    b.Navigation("Parceiro")
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.Entities.PessoaFisica", b =>
                {
                    b.OwnsOne("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<Guid>("PessoaFisicaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Cpf");

                            b1.HasKey("PessoaFisicaId");

                            b1.ToTable("Pessoas");

                            b1.WithOwner()
                                .HasForeignKey("PessoaFisicaId");
                        });

                    b.Navigation("Cpf")
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.Entities.PessoaJuridica", b =>
                {
                    b.OwnsOne("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects.Cnpj", "Cnpj", b1 =>
                        {
                            b1.Property<Guid>("PessoaJuridicaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Cnpj");

                            b1.HasKey("PessoaJuridicaId");

                            b1.ToTable("Pessoas");

                            b1.WithOwner()
                                .HasForeignKey("PessoaJuridicaId");
                        });

                    b.Navigation("Cnpj")
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.Entities.Cadastro", b =>
                {
                    b.Navigation("Pessoa")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
