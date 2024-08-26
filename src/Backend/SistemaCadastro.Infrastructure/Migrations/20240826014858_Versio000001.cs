using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCadastro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Versio000001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cadastros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimeiroNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SobrenomeSocial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Empresa = table.Column<bool>(type: "bit", nullable: false),
                    InscritoAssinante = table.Column<bool>(type: "bit", nullable: false),
                    InscritoAssociado = table.Column<bool>(type: "bit", nullable: false),
                    InscritoAfiliado = table.Column<bool>(type: "bit", nullable: false),
                    CredencialBloqueada = table.Column<bool>(type: "bit", nullable: false),
                    CredencialExpirada = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CredencialSenha = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ParceiroCliente = table.Column<bool>(type: "bit", nullable: false),
                    ParceiroFornecedor = table.Column<bool>(type: "bit", nullable: false),
                    ParceiroPrestador = table.Column<bool>(type: "bit", nullable: false),
                    ParceiroColaborador = table.Column<bool>(type: "bit", nullable: false),
                    DocumentoNumero = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    DocumentoOrgaoEmissor = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    DocumentoEstadoEmissor = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DocumentoDataValidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdentificacaoEmpresa = table.Column<int>(type: "int", nullable: true),
                    IdentificacaoIdentificador = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdentificacaoTipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrimeiroNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefoneNumero = table.Column<long>(type: "bigint", nullable: false),
                    TelefoneCelular = table.Column<bool>(type: "bit", nullable: false),
                    TelefoneWhatsapp = table.Column<bool>(type: "bit", nullable: false),
                    TelefoneTelegram = table.Column<bool>(type: "bit", nullable: false),
                    Token = table.Column<Guid>(type: "uniqueidentifier", maxLength: 255, nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazaoSocial = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoas_Cadastros_Id",
                        column: x => x.Id,
                        principalTable: "Cadastros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Domicilios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PontoReferencia = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Uf = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ibge = table.Column<int>(type: "int", nullable: false),
                    DomicilioTipo = table.Column<int>(type: "int", nullable: false),
                    PessoaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Domicilios_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Domicilios_PessoaId",
                table: "Domicilios",
                column: "PessoaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Domicilios");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Cadastros");
        }
    }
}
