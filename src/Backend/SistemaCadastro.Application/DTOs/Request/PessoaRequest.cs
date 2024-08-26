using SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.Enums;

namespace SistemaCadastro.Application.DTOs.Request;

    public record CpfRequest(string Valor);
    
    public record CnpjRequest(string Valor);

    public record DomicilioRequest(EnderecoRequest Endereco, EDomicilioTipo Tipo);