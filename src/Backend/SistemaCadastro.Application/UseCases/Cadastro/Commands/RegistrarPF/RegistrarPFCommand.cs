using MediatR;
using SistemaCadastro.Application.DTOs.Request;
using SistemaCadastro.Application.Shared.Results.Interfaces;

namespace SistemaCadastro.Application.UseCases.Cadastro.Commands.RegistrarPF;

    public sealed record RegistrarPFCommand(
    EmailRequest Email,
    NomeRequest Nome,
    TelefoneRequest Telefone,
    InscritoRequest Inscrito,
    CredencialRequest Credencial,
    ParceiroRequest Parceiro,
    DocumentacaoRequest Documentacao,
    IdentificacaoRequest Identificacao,
    EnderecoRequest Endereco,
    List<DomicilioRequest> Domicilio,
    CpfRequest Cpf,
    DateTime Nascimento
) : IRequest<IResult>;