using SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.Enums;

namespace SistemaCadastro.Application.DTOs.Request;

public record EmailRequest(string Valor);

public record NomeRequest
(
    string PrimeiroNome,
    string Sobrenome,
    string NomeFantasia,
    string SobrenomeSocial
);

public record TelefoneRequest
(
    long Numero,
    bool Celular,
    bool Whatsapp,
    bool Telegram
);

public record InscritoRequest
(
    bool Assinante,
    bool Associado,
    bool Afiliado
);

public record CredencialRequest
(
    bool Bloqueada,
    string Expirada,
    string Senha
);


public record ParceiroRequest
(
    bool Cliente,
    bool Fornecedor,
    bool Prestador,
    bool Colaborador
);

public record DocumentacaoRequest
(
    string Numero,
    string OrgaoEmissor,
    string EstadoEmissor,
    DateTime Validade
);

public record IdentificacaoRequest
(
    int Empresa,
    string Identificador,
    EIdentificacaoTipo Tipo
);

public record EnderecoRequest
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
