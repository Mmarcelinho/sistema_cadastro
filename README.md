# Sobre o Projeto

O sistema de cadastro é uma API robusta desenvolvida para gerenciar o registro e a administração de cadastros de pessoas físicas e jurídicas. O design deste sistema segue os princípios do Domain Driven Design (DDD), garantindo uma estrutura sólida, modular e alinhada às regras de negócio específicas, proporcionando maior flexibilidade e manutenção facilitada.

## Técnicas Utilizadas

- Clean Architecture
- Domain-Driven Design (DDD)
- Princípios SOLID

## Tecnologias Utilizadas

![Ubuntu](https://img.shields.io/badge/Ubuntu-E95420?style=for-the-badge&logo=ubuntu&logoColor=white)
![Visual Studio Code](https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=for-the-badge&logo=visual-studio-code&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)
![Swagger](https://camo.githubusercontent.com/6e4dd9644d5327ffad6433ecb2f4c0a8f41531fcfe142ae36d7e1cb162774fc3/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f537761676765722d3230354533423f7374796c653d666f722d7468652d6261646765266c6f676f3d73776167676572266c6f676f436f6c6f723d7768697465)
![Postman](https://img.shields.io/badge/Postman-FF6C37?style=for-the-badge&logo=postman&logoColor=white)

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
