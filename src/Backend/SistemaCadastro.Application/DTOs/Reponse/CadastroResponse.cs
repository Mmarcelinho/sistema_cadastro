namespace SistemaCadastro.Application.DTOs.Reponse;

public record CadastroPessoaFisicaResponse
(
    Guid Id,
    NomeResponse Nome,
    EmailResponse Email,
    TelefoneResponse Telefone,
    InscritoResponse Inscrito,
    CredencialResponse Credencial,
    ParceiroResponse Parceiro,
    DocumentacaoResponse Documentacao,
    IdentificacaoResponse Identificacao,
    EnderecoResponse Endereco,
    PessoaFisicaResponse Pessoa
);

public record CadastroPessoaJuridicaResponse
(
    Guid Id,
    NomeResponse Nome,
    EmailResponse Email,
    TelefoneResponse Telefone,
    InscritoResponse Inscrito,
    CredencialResponse Credencial,
    ParceiroResponse Parceiro,
    DocumentacaoResponse Documentacao,
    IdentificacaoResponse Identificacao,
    EnderecoResponse Endereco,
    PessoaJuridicaResponse Pessoa
);

public record EmailResponse(string Valor);

public record NomeResponse
(
    string PrimeiroNome,
    string Sobrenome,
    string NomeFantasia,
    string SobrenomeSocial
);

public record TelefoneResponse
(
    long Numero,
    bool Celular,
    bool Whatsapp,
    bool Telegram
);

public record InscritoResponse
(
    bool Assinante,
    bool Associado,
    bool Afiliado
);

public record CredencialResponse
(
    bool Bloqueada,
    string Expirada,
    string Senha
);


public record ParceiroResponse
(
    bool Cliente,
    bool Fornecedor,
    bool Prestador,
    bool Colaborador
);

public record DocumentacaoResponse
(
    string Numero,
    string OrgaoEmissor,
    string EstadoEmissor,
    DateTime Validade
);

public record IdentificacaoResponse
(
    int Empresa,
    string Identificador,
    EIdentificacaoTipo Tipo
);

public record EnderecoResponse
(
    string Cep,
    string Logradouro,
    string Numero,
    string Bairro,
    string Complemento,
    string PontoReferencia,
    string Uf,
    string Cidade,
    int Ibge
);
