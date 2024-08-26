using SistemaCadastro.Application.DTOs.Reponse;
using SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.Entities;

namespace SistemaCadastro.Application.DTOs.Conversions;

public static class CadastroConversion
{
    public static CadastroPessoaFisicaResponse FromEntityToPF(Cadastro cadastro)
    {
        var pessoaFisica = cadastro.Pessoa as PessoaFisica;

        return new CadastroPessoaFisicaResponse
        (
            cadastro.Id,
            new NomeResponse(
                cadastro.Nome.PrimeiroNome,
                cadastro.Nome.Sobrenome,
                cadastro.Nome.NomeFantasia,
                cadastro.Nome.SobrenomeSocial
            ),
            new EmailResponse(cadastro.Email.Valor),
            new TelefoneResponse(
                cadastro.Telefone.Numero,
                cadastro.Telefone.Celular,
                cadastro.Telefone.Whatsapp,
                cadastro.Telefone.Telegram
            ),
            new InscritoResponse(
                cadastro.Inscrito.Assinante,
                cadastro.Inscrito.Associado,
                cadastro.Inscrito.Afiliado
            ),
            new CredencialResponse(
                cadastro.Credencial.Bloqueada,
                cadastro.Credencial.Expirada,
                cadastro.Credencial.Senha
            ),
            new ParceiroResponse(
                cadastro.Parceiro.Cliente,
                cadastro.Parceiro.Fornecedor,
                cadastro.Parceiro.Prestador,
                cadastro.Parceiro.Colaborador
            ),
            new DocumentacaoResponse(
                cadastro.Documentacao.Numero,
                cadastro.Documentacao.OrgaoEmissor,
                cadastro.Documentacao.EstadoEmissor,
                cadastro.Documentacao.Validade
            ),
            new IdentificacaoResponse(
                (int)cadastro.Identificacao.Empresa!,
                cadastro.Identificacao.Identificador,
                cadastro.Identificacao.Tipo
            ),
            new EnderecoResponse(
                cadastro.Endereco.Cep,
                cadastro.Endereco.Logradouro,
                cadastro.Endereco.Numero,
                cadastro.Endereco.Bairro,
                cadastro.Endereco.Complemento,
                cadastro.Endereco.PontoReferencia,
                cadastro.Endereco.Uf,
                cadastro.Endereco.Cidade,
                cadastro.Endereco.Ibge
            ),
            new PessoaFisicaResponse(
                cadastro.Pessoa.Id,
                new CpfResponse(pessoaFisica.Cpf.Valor),
                pessoaFisica.Domicilios.Select(d => new DomicilioResponse(
                    new EnderecoResponse(
                        d.Endereco.Cep,
                        d.Endereco.Logradouro,
                        d.Endereco.Numero,
                        d.Endereco.Bairro,
                        d.Endereco.Complemento,
                        d.Endereco.PontoReferencia,
                        d.Endereco.Uf,
                        d.Endereco.Cidade,
                        d.Endereco.Ibge
                    ),
                    d.Tipo
                )).ToList()
            )
        );
    }

    public static CadastroPessoaJuridicaResponse FromEntityToPJ(Cadastro cadastro)
    {
        var pessoaJuridica = cadastro.Pessoa as PessoaJuridica;

        return new CadastroPessoaJuridicaResponse
        (
            cadastro.Id,
            new NomeResponse(
                cadastro.Nome.PrimeiroNome,
                cadastro.Nome.Sobrenome,
                cadastro.Nome.NomeFantasia,
                cadastro.Nome.SobrenomeSocial
            ),
            new EmailResponse(cadastro.Email.Valor),
            new TelefoneResponse(
                cadastro.Telefone.Numero,
                cadastro.Telefone.Celular,
                cadastro.Telefone.Whatsapp,
                cadastro.Telefone.Telegram
            ),
            new InscritoResponse(
                cadastro.Inscrito.Assinante,
                cadastro.Inscrito.Associado,
                cadastro.Inscrito.Afiliado
            ),
            new CredencialResponse(
                cadastro.Credencial.Bloqueada,
                cadastro.Credencial.Expirada,
                cadastro.Credencial.Senha
            ),
            new ParceiroResponse(
                cadastro.Parceiro.Cliente,
                cadastro.Parceiro.Fornecedor,
                cadastro.Parceiro.Prestador,
                cadastro.Parceiro.Colaborador
            ),
            new DocumentacaoResponse(
                cadastro.Documentacao.Numero,
                cadastro.Documentacao.OrgaoEmissor,
                cadastro.Documentacao.EstadoEmissor,
                cadastro.Documentacao.Validade
            ),
            new IdentificacaoResponse(
                (int)cadastro.Identificacao.Empresa!,
                cadastro.Identificacao.Identificador,
                cadastro.Identificacao.Tipo
            ),
            new EnderecoResponse(
                cadastro.Endereco.Cep,
                cadastro.Endereco.Logradouro,
                cadastro.Endereco.Numero,
                cadastro.Endereco.Bairro,
                cadastro.Endereco.Complemento,
                cadastro.Endereco.PontoReferencia,
                cadastro.Endereco.Uf,
                cadastro.Endereco.Cidade,
                cadastro.Endereco.Ibge
            ),
            new PessoaJuridicaResponse(
                cadastro.Pessoa.Id,
                new CnpjResponse(pessoaJuridica.Cnpj.Valor),
                pessoaJuridica.RazaoSocial,
                pessoaJuridica.Domicilios.Select(d => new DomicilioResponse(
                    new EnderecoResponse(
                        d.Endereco.Cep,
                        d.Endereco.Logradouro,
                        d.Endereco.Numero,
                        d.Endereco.Bairro,
                        d.Endereco.Complemento,
                        d.Endereco.PontoReferencia,
                        d.Endereco.Uf,
                        d.Endereco.Cidade,
                        d.Endereco.Ibge
                    ),
                    d.Tipo
                )).ToList()
            )
        );
    }
}
