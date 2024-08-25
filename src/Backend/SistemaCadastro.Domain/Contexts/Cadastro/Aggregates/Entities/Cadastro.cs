using SistemaCadastro.Domain.Contexts.Cadastro.Abstractions;
using SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects;
using SistemaCadastro.Domain.Contexts.Cadastro.Errors;
using SistemaCadastro.Domain.Validations;
using SistemaCadastro.Domain.Validations.Interfaces;

namespace SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.Entities;

public sealed class Cadastro : Entidade, IContract
{
    private Cadastro() { }

    private Cadastro(
        Email email,
        Nome nome,
        bool empresa,
        Telefone telefone,
        Inscrito inscrito,
        Credencial credencial,
        Parceiro parceiro,
        Documentacao documentacao,
        Identificacao identificacao,
        Endereco endereco,
        Pessoa pessoa)
    {
        Email = email;
        Nome = nome;
        Empresa = empresa;
        Telefone = telefone;
        Inscrito = inscrito;
        Credencial = credencial;
        Parceiro = parceiro;
        Documentacao = documentacao;
        Identificacao = identificacao;
        Endereco = endereco;
        Pessoa = pessoa;
    }


    public Email Email { get; }

    public Nome Nome { get; }

    public bool Empresa { get; }

    public Telefone Telefone { get; }

    public Inscrito Inscrito { get; }

    public Credencial Credencial { get; }

    public Parceiro Parceiro { get; }

    public Documentacao Documentacao { get; }

    public Identificacao Identificacao { get; }

    public Endereco Endereco { get; }

    public Pessoa Pessoa { get; }

    private static Cadastro Criar(
        Email email,
        Nome nome,
        bool empresa,
        Telefone telefone,
        Inscrito inscrito,
        Credencial credencial,
        Parceiro parceiro,
        Documentacao documentacao,
        Identificacao identificacao,
        Endereco endereco,
        Pessoa pessoa) =>
        new(
        email,
        nome,
        empresa,
        telefone,
        inscrito,
        credencial,
        parceiro,
        documentacao,
        identificacao,
        endereco,
        pessoa);

        public static Cadastro CriarCadastroPessoaFisica(
        Email email,
        Nome nome,
        Telefone telefone,
        Inscrito inscrito,
        Credencial credencial,
        Parceiro parceiro,
        Documentacao documentacao,
        Identificacao identificacao,
        Endereco endereco,
        PessoaFisica pessoa) => Criar(
        email,
        nome,
        false,
        telefone,
        inscrito,
        credencial,
        parceiro,
        documentacao,
        identificacao,
        endereco,
        pessoa);

        public static Cadastro CriarCadastroPessoaJuridica(
        Email email,
        Nome nome,
        Telefone telefone,
        Inscrito inscrito,
        Credencial credencial,
        Parceiro parceiro,
        Documentacao documentacao,
        Identificacao identificacao,
        Endereco endereco,
        PessoaJuridica pessoa) => Criar(
        email,
        nome,
        true,
        telefone,
        inscrito,
        credencial,
        parceiro,
        documentacao,
        identificacao,
        endereco,
        pessoa);

    public override bool Validate()
    {
        var contracts = new ContractValidations<Cadastro>()
        .NomeFantasiaIsOk(Nome, 3, 30, DomainErrors.NOME_INVALIDO, nameof(Nome.NomeFantasia))
        .SobrenomeSocialIsOk(Nome, 3, 30, DomainErrors.NOME_INVALIDO, nameof(Nome.SobrenomeSocial))
        .EmailIsValid(Email, DomainErrors.EMAIL_INVALIDO, nameof(Email.Valor))
        .TelefoneIsValid(Telefone, 12, 13, DomainErrors.TELEFONE_INVALIDO, nameof(Telefone.Numero))
        .DocumentoIsValid(Documentacao, DomainErrors.DOCUMENTO_INVALIDO, nameof(Documentacao))
        .EnderecoIsValid(Endereco, 3, 20, DomainErrors.ENDERECO_INVALIDO, nameof(Endereco));

        SetNotificationList([.. contracts.Notifications]);
        
        return contracts.IsValid();
    }
}
