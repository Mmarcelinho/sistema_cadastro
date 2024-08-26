using SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.Enums;

namespace SistemaCadastro.Application.DTOs.Reponse;

public record PessoaFisicaResponse
(
    Guid Id,
    CpfResponse Cpf,
    List<DomicilioResponse> Domicilios
);

public record PessoaJuridicaResponse
(
    Guid Id,
    CnpjResponse Cnpj,
    string RazaoSocial,
    List<DomicilioResponse> Domicilios
);

public record CpfResponse(string Valor);

public record CnpjResponse(string Valor);

public record DomicilioResponse
(
    EnderecoResponse Endereco,
     EDomicilioTipo Tipo
);