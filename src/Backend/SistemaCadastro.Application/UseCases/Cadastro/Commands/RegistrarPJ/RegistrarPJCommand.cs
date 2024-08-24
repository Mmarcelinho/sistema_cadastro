using MediatR;
using SistemaCadastro.Application.Shared.Results.Interfaces;
using SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects;

namespace SistemaCadastro.Application.UseCases.Cadastro.Commands.RegistrarPJ;

    public sealed record RegistrarPJCommand(
    Email Email,
    Nome Nome,
    bool Empresa,
    Telefone Telefone,
    Inscrito Inscrito,
    Credencial Credencial,
    Parceiro Parceiro,
    Documentacao Documentacao,
    Identificacao Identificacao,
    Endereco Endereco,
    Cnpj Cnpj,
    string RazaoSocial
) : IRequest<IResult>;