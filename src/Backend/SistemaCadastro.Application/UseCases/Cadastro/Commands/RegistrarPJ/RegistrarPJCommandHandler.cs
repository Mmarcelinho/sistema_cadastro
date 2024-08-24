using MediatR;
using SistemaCadastro.Application.Shared.Results;
using SistemaCadastro.Application.Shared.Results.Interfaces;
using SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.Entities;
using SistemaCadastro.Domain.Contexts.Cadastro.Repositories;
using SistemaCadastro.Domain.Notifications;
using SistemaCadastro.Domain.Repositories;

namespace SistemaCadastro.Application.UseCases.Cadastro.Commands.RegistrarPJ;

public class RegistrarPJCommandHandler(ICadastroRepository _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RegistrarPJCommand, IResult>
{
    public async Task<IResult> Handle(RegistrarPJCommand request, CancellationToken cancellationToken)
    {
        Result result;

        var pessoaJuridica = PessoaJuridica.Criar(
            request.Nome,
            request.Cnpj,
            request.RazaoSocial,
            request.Email,
            request.Telefone
        );

        if (!pessoaJuridica.Validate())
        {
            result = new(400, "Um ou mais erros de validações ocorreram.", false);
            result.SetNotifications(pessoaJuridica.Notifications as List<Notification>);
            return result;
        }

        var cadastroPessoaJuridica = Domain.Contexts.Cadastro.Aggregates.Entities.Cadastro.CriarCadastroPessoaJuridica(
            request.Email,
            request.Nome,
            request.Telefone,
            request.Inscrito,
            request.Credencial,
            request.Parceiro,
            request.Documentacao,
            request.Identificacao,
            request.Endereco,
            pessoaJuridica
        );

        if (!cadastroPessoaJuridica.Validate())
        {
            result = new(400, "Um ou mais erros de validações ocorreram.", false);
            result.SetNotifications(cadastroPessoaJuridica.Notifications as List<Notification>);
            return result;
        }

        await _repository.Registrar(cadastroPessoaJuridica);
        await _unitOfWork.SaveChangesAsync();

        result = new Result(200, "Pessoa física registrada com sucesso.", true);

        result.SetData(cadastroPessoaJuridica);
        return result;
    }
}
