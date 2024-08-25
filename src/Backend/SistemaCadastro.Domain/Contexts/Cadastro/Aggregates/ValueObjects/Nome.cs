namespace SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects;

public sealed record Nome
{
    public Nome(string primeiroNome, string sobrenome, string nomeFantasia, string sobrenomeSocial)
    {
        PrimeiroNome = primeiroNome;
        Sobrenome = sobrenome;
        NomeFantasia = nomeFantasia;
        SobrenomeSocial = sobrenomeSocial;
    }

    public string PrimeiroNome { get; }

    public string Sobrenome { get; }

    public string NomeFantasia { get; }

    public string SobrenomeSocial { get; }

    public static Nome Criar(string nomeFantasia, string sobrenomeSocial) =>
    new(string.Empty, string.Empty, nomeFantasia, sobrenomeSocial);

    public static Nome Criar(string primeiroNome, string sobrenome, string nomeFantasia, string sobrenomeSocial) =>
    new(primeiroNome, sobrenome, nomeFantasia, sobrenomeSocial);
}
