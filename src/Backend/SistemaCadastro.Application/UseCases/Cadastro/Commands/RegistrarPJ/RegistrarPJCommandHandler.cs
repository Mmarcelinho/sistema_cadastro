using MediatR;
using SistemaCadastro.Application.DTOs.Conversions;
using SistemaCadastro.Application.Shared.Results;
using SistemaCadastro.Application.Shared.Results.Interfaces;
using SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.Entities;
using SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects;
using SistemaCadastro.Domain.Contexts.Cadastro.Repositories;
using SistemaCadastro.Domain.Repositories;

namespace SistemaCadastro.Application.UseCases.Cadastro.Commands.RegistrarPJ;

public class RegistrarPJCommandHandler(ICadastroRepository _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RegistrarPJCommand, IResult>
{
    public async Task<IResult> Handle(RegistrarPJCommand request, CancellationToken cancellationToken)
    {
        Result result;

        var nomePessoa = Nome.Criar
        (
            request.Nome.PrimeiroNome,
            request.Nome.Sobrenome,
            request.Nome.NomeFantasia

        );

        var cnpjPessoa = Cnpj.Criar(request.Cnpj.Valor);
        var emailPessoa = Email.Criar(request.Email.Valor);
        var telefonePessoa = Telefone.Criar
        (
            request.Telefone.Numero,
            request.Telefone.Celular,
            request.Telefone.Whatsapp,
            request.Telefone.Telegram
        );

        var domicilios = RecuperarEndereco(request);
        var pessoaJuridica = PessoaJuridica.Criar
        (
            nomePessoa,
            cnpjPessoa,
            request.RazaoSocial,
            emailPessoa,
            telefonePessoa,
            domicilios
        );

        if (!pessoaJuridica.Validate())
        {
            result = new(400, "Um ou mais erros de validações ocorreram.", false);
            result.SetNotifications([.. pessoaJuridica.Notifications]);
            return result;
        }

        var nomeCadastro = Nome.Criar
        (
            request.Nome.PrimeiroNome,
            request.Nome.Sobrenome,
            request.Nome.NomeFantasia,
            request.Nome.SobrenomeSocial
        );

        var emailCadastro = Email.Criar(request.Email.Valor);

        var telefoneCadastro = Telefone.Criar
        (
            request.Telefone.Numero,
            request.Telefone.Celular,
            request.Telefone.Whatsapp,
            request.Telefone.Telegram
        );

        var inscrito = Inscrito.Criar
        (
           request.Inscrito.Assinante,
           request.Inscrito.Associado,
           request.Inscrito.Afiliado
        );


        var credencial = Credencial.Criar(request.Credencial.Bloqueada);

        var parceiro = Parceiro.Criar
        (
            request.Parceiro.Cliente,
            request.Parceiro.Fornecedor,
            request.Parceiro.Prestador,
            request.Parceiro.Colaborador
        );

        var documentacao = Documentacao.Criar
        (
          request.Documentacao.Numero,
          request.Documentacao.OrgaoEmissor,
          request.Documentacao.EstadoEmissor,
          request.Documentacao.Validade
        );

        var identificacao = Identificacao.Criar
        (
            request.Identificacao.Empresa,
            request.Identificacao.Identificador,
            request.Identificacao.Tipo
        );

        var endereco = Endereco.Criar
        (
            request.Endereco.Cep,
            request.Endereco.Logradouro,
            request.Endereco.Numero,
            request.Endereco.Bairro,
            request.Endereco.Complemento,
            request.Endereco.PontoReferencia,
            request.Endereco.Uf,
            request.Endereco.Cidade,
            request.Endereco.Ibge
        );


        var cadastroPJ = Domain.Contexts.Cadastro.Aggregates.Entities.Cadastro.CriarCadastroPessoaJuridica
        (
            emailCadastro,
            nomeCadastro,
            telefoneCadastro,
            inscrito,
            credencial,
            parceiro,
            documentacao,
            identificacao,
            endereco,
            pessoaJuridica
        );

        if (!cadastroPJ.Validate())
        {
            result = new(400, "Um ou mais erros de validações ocorreram.", false);
            result.SetNotifications([.. cadastroPJ.Notifications]);
            return result;
        }

        await _repository.Registrar(cadastroPJ);
        await _unitOfWork.SaveChangesAsync();

        result = new Result(200, "Pessoa jurídica registrada com sucesso.", true);

        var cadastroPJResponse = CadastroConversion.FromEntityToPJ(cadastroPJ);

        result.SetData(cadastroPJResponse);
        return result;
    }

    public static List<Domicilio> RecuperarEndereco(RegistrarPJCommand request)
    {
        List<Domicilio> domicilios = [];

        foreach (var domicilio in request.Domicilio)
        {

            var endereco = Endereco.Criar
            (
                domicilio.Endereco.Cep,
                domicilio.Endereco.Logradouro,
                domicilio.Endereco.Numero,
                domicilio.Endereco.Bairro,
                domicilio.Endereco.Complemento,
                domicilio.Endereco.PontoReferencia,
                domicilio.Endereco.Uf,
                domicilio.Endereco.Cidade,
                domicilio.Endereco.Ibge
            );

            var _domicilio = Domicilio.Criar(endereco, domicilio.Tipo);

            domicilios.Add(_domicilio);
        }
        return domicilios;
    }
}
