namespace SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects;

public sealed record Inscrito
{
    public Inscrito(bool assinante, bool associado, bool afiliado)
    {
        Assinante = assinante;
        Associado = associado;
        Afiliado = afiliado;
    }

    public bool Assinante { get; }

    public bool Associado { get; }

    public bool Afiliado { get; }

    public static Inscrito Criar(bool assinante, bool associado, bool afiliado) => new(assinante, associado, afiliado);
}
