using MediatR;
using SistemaCadastro.Application.Shared.Results.Interfaces;
using SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects;

namespace SistemaCadastro.Application.UseCases.Cadastro.Commands.RegistrarPF;

    public sealed record RegistrarPFCommand(
    Email Email,
    Nome Nome,
    Telefone Telefone,
    Inscrito Inscrito,
    Credencial Credencial,
    Parceiro Parceiro,
    Documentacao Documentacao,
    Identificacao Identificacao,
    Endereco Endereco,
    Cpf Cpf,
    DateTime Nascimento
) : IRequest<IResult>;