# Sobre o Projeto

O sistema de cadastro é uma API robusta desenvolvida para gerenciar o registro e a administração de cadastros de pessoas físicas e jurídicas. O design deste sistema segue os princípios do Domain Driven Design (DDD), garantindo uma estrutura sólida, modular e alinhada às regras de negócio específicas, proporcionando maior flexibilidade e manutenção facilitada.

## Técnicas Utilizadas

- Clean Architecture
- Domain-Driven Design (DDD)
- SOLID Principles

## Tecnologias Utilizadas

![badge-ubuntu]
![badge-vs-code]
![badge-c-sharp]
![badge-dot-net]
![badge-sqlserver]
![badge-swagger]
![badge-postman]

### Cadastro:

- [x] Registrar pessoa física
- [x] Registrar pessoa jurídica

## Instalação

1. Clone o repositório: `git clone https://github.com/Mmarcelinho/sistema_cadastro.git`
2. Navegue até o diretório do projeto: `cd sistema_cadastro`
3. Restaure as dependências: `dotnet restore`
4. Configure a string de conexão com o banco de dados no arquivo `appsettings.Development.json`.
5. Inicie o projeto: `dotnet run`

## Uso

Após iniciar o projeto, você pode acessar a documentação da API através do Swagger, disponível em `https://localhost:7000/swagger`.

### Exemplos de Requisição

#### Registrar Pessoa Física

```json
{
  "email": {
    "valor": "example@example.com"
  },
  "nome": {
    "primeiroNome": "João",
    "sobrenome": "Silva",
    "nomeFantasia": "Silva Ltda",
    "sobrenomeSocial": "João da Silva"
  },
  "telefone": {
    "numero": 5521912345678,
    "celular": true,
    "whatsapp": true,
    "telegram": false
  },
  "inscrito": {
    "assinante": true,
    "associado": false,
    "afiliado": true
  },
  "credencial": {
    "bloqueada": false,
    "expirada": "2025-12-31",
    "senha": "s3cr3tP@ssw0rd"
  },
  "parceiro": {
    "cliente": true,
    "fornecedor": false,
    "prestador": true,
    "colaborador": true
  },
  "documentacao": {
    "numero": "123456789",
    "orgaoEmissor": "SSP",
    "estadoEmissor": "SP",
    "validade": "2028-08-26T00:13:33.991Z"
  },
  "identificacao": {
    "empresa": 123,
    "identificador": "ID-987654",
    "tipo": 1
  },
  "endereco": {
    "cep": "12345678",
    "logradouro": "Rua Exemplo",
    "numero": "100",
    "bairro": "Centro",
    "complemento": "Apto 101",
    "pontoReferencia": "Próximo ao Mercado",
    "uf": "SP",
    "cidade": "São Paulo",
    "ibge": 3550308
  },
  "domicilio": [
    {
      "endereco": {
        "cep": "87654321",
        "logradouro": "Avenida Principal",
        "numero": "200",
        "bairro": "Jardins",
        "complemento": "Casa",
        "pontoReferencia": "Em frente à Praça",
        "uf": "RJ",
        "cidade": "Rio de Janeiro",
        "ibge": 3304557
      },
      "tipo": 2
    }
  ],
  "cpf": {
    "valor": "67864685510"
  },
  "nascimento": "1990-08-26T00:13:33.991Z"
}
```

#### Registrar Pessoa Jurídica

```json
{
  "email": {
    "valor": "empresa@exemplo.com"
  },
  "nome": {
    "primeiroNome": "Empresa",
    "sobrenome": "Exemplo",
    "nomeFantasia": "Exemplo Ltda",
    "sobrenomeSocial": "Social Exemplo"
  },
  "telefone": {
    "numero": 5521987654321,
    "celular": false,
    "whatsapp": true,
    "telegram": false
  },
  "inscrito": {
    "assinante": true,
    "associado": false,
    "afiliado": true
  },
  "credencial": {
    "bloqueada": false,
    "expirada": "2025-12-31",
    "senha": "senhaS3gur@"
  },
  "parceiro": {
    "cliente": true,
    "fornecedor": true,
    "prestador": false,
    "colaborador": false
  },
  "documentacao": {
    "numero": "987654321",
    "orgaoEmissor": "JUC",
    "estadoEmissor": "SP",
    "validade": "2030-08-26T02:59:32.901Z"
  },
  "identificacao": {
    "empresa": 123,
    "identificador": "ID-123456",
    "tipo": 2
  },
  "endereco": {
    "cep": "12345678",
    "logradouro": "Rua Exemplo",
    "numero": "100",
    "bairro": "Centro",
    "complemento": "Apto 101",
    "pontoReferencia": "Próximo ao Mercado",
    "uf": "SP",
    "cidade": "São Paulo",
    "ibge": 3550308
  },
  "cnpj": {
    "valor": "12.345.678/0001-95"
  },
  "domicilio": [
    {
      "endereco": {
        "cep": "87654321",
        "logradouro": "Avenida Principal",
        "numero": "200",
        "bairro": "Jardins",
        "complemento": "Casa",
        "pontoReferencia": "Em frente à Praça",
        "uf": "RJ",
        "cidade": "Rio de Janeiro",
        "ibge": 3304557
      },
      "tipo": 1
    }
  ],
  "razaoSocial": "Exemplo Ltda"
}
```

## Autores

Estes projetos de exemplo foram criados para fins educacionais. [Marcelo](https://github.com/Mmarcelinho) é responsável pela criação e manutenção destes projetos.

## Licença

Este projetos não possuem uma licença específica e são fornecidos apenas para fins de aprendizado e demonstração.

[badge-ubuntu]: https://img.shields.io/badge/Ubuntu-E95420?style=for-the-badge&logo=ubuntu&logoColor=white
[badge-vs-code]: https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=for-the-badge&logo=visual-studio-code&logoColor=white
[badge-dot-net]: https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=fff&style=for-the-badge
[badge-c-sharp]: https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white
[badge-sqlserver]: https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?logo=microsoftsqlserver&logoColor=fff&style=for-the-badge
[badge-swagger]: https://img.shields.io/badge/Swagger-85EA2D?logo=swagger&logoColor=000&style=for-the-badge
[badge-postman]: https://img.shields.io/badge/Postman-FF6C37?style=for-the-badge&logo=postman&logoColor=white
