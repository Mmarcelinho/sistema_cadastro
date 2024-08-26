namespace SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects;

public sealed record Email
{
    public Email(string valor)
    {
        Valor = valor;
    }

    public string Valor { get; }

    public static Email Criar(string valor) => new(valor);
}