namespace SistemaCadastro.Application.UseCases.Cadastro.Commands.RegistrarPJ;

    public sealed record RegistrarPJCommand(
    EmailRequest Email,
    NomeRequest Nome,
    TelefoneRequest Telefone,
    InscritoRequest Inscrito,
    CredencialRequest Credencial,
    ParceiroRequest Parceiro,
    DocumentacaoRequest Documentacao,
    IdentificacaoRequest Identificacao,
    EnderecoRequest Endereco,
    CnpjRequest Cnpj,
    List<DomicilioRequest> Domicilio,
    string RazaoSocial
) : IRequest<IResult>;