using MediatR;
using SistemaCadastro.Application.Shared.Results;
using SistemaCadastro.Application.Shared.Results.Interfaces;
using SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.Entities;
using SistemaCadastro.Domain.Contexts.Cadastro.Repositories;
using SistemaCadastro.Domain.Notifications;
using SistemaCadastro.Domain.Repositories;

namespace SistemaCadastro.Application.UseCases.Cadastro.Commands.RegistrarPF;

public sealed class RegistrarPFCommandHandler(ICadastroRepository _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RegistrarPFCommand, IResult>
{
    public async Task<IResult> Handle(RegistrarPFCommand request, CancellationToken cancellationToken)
    {
        Result result;
        var pessoaFisica = PessoaFisica.Criar(
            request.Nome,
            request.Cpf,
            request.Nascimento,
            request.Email,
            request.Telefone
        );

        if(!pessoaFisica.Validate())
        {
            result = new(400, "Um ou mais erros de validações ocorreram.", false);
            result.SetNotifications(pessoaFisica.Notifications as List<Notification>);
            return result;
        }

        var cadastroPessoaFisica = Domain.Contexts.Cadastro.Aggregates.Entities.Cadastro.CriarCadastroPessoaFisica(
            request.Email,
            request.Nome,
            request.Telefone,
            request.Inscrito,
            request.Credencial,
            request.Parceiro,
            request.Documentacao,
            request.Identificacao,
            request.Endereco,
            pessoaFisica
        );

        if(!cadastroPessoaFisica.Validate())
        {
            result = new(400, "Um ou mais erros de validações ocorreram.", false);
            result.SetNotifications(cadastroPessoaFisica.Notifications as List<Notification>);
            return result;
        }

        await _repository.Registrar(cadastroPessoaFisica);
        await _unitOfWork.SaveChangesAsync();

        result = new Result(200, "Pessoa física registrada com sucesso.", true);

        result.SetData(cadastroPessoaFisica);
        return result;
    }
}
