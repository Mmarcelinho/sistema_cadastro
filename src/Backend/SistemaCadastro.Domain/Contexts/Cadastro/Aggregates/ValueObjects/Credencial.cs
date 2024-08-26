namespace SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects;

public sealed record Credencial
{
    private Credencial(bool bloqueada)
    {
        Bloqueada = bloqueada;
        Expirada = DateTime.UtcNow.AddMonths(3).ToString();
        Senha = Guid.NewGuid().ToString();
    }

    private Credencial(bool bloqueada, string expirada, string senha)
    {
        Bloqueada = bloqueada;
        Expirada = expirada;
        Senha = senha;
    }

    public bool Bloqueada { get; }

    public string Expirada { get; }

    public string Senha { get; }

    public static Credencial Criar(bool bloqueada) => new(bloqueada);

    public static Credencial Criar(bool bloqueada, string expirada, string senha) => new(bloqueada, expirada, senha);
}