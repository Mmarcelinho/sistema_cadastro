namespace SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects;

public sealed record Nome
{
    private Nome(string primeiroNome, string sobrenome, string nomeFantasia, string sobrenomeSocial)
    {
        PrimeiroNome = primeiroNome;
        Sobrenome = sobrenome;
        NomeFantasia = nomeFantasia;
        SobrenomeSocial = sobrenomeSocial;
    }

    private Nome(string primeiroNome, string sobrenome, string nomeFantasia)
    {
        PrimeiroNome = primeiroNome;
        Sobrenome = sobrenome;
        NomeFantasia = nomeFantasia;
    }

    public string PrimeiroNome { get; }

    public string Sobrenome { get; }

    public string NomeFantasia { get; }

    public string SobrenomeSocial { get; }

    public static Nome Criar(string primeiroNome, string sobrenome, string nomeFantasia, string sobrenomeSocial) 
    => new(primeiroNome, sobrenome, nomeFantasia, sobrenomeSocial);

    public static Nome Criar(string primeiroNome, string sobrenome, string nomeFantasia) 
    => new(primeiroNome, sobrenome, nomeFantasia);    
}
