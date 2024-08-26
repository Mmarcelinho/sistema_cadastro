namespace SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects;

public sealed record Documentacao
{
    private Documentacao(string numero, string orgaoEmissor, string estadoEmissor, DateTime validade)
    {
        Numero = numero;
        OrgaoEmissor = orgaoEmissor;
        EstadoEmissor = estadoEmissor;
        Validade = validade;
    }

    public string Numero { get; }

    public string OrgaoEmissor { get; }

    public string EstadoEmissor { get; }

    public DateTime Validade { get; }

    public static Documentacao Criar(
        string numero,
        string orgaoEmissor,
        string estadoEmissor,
        DateTime validade) =>
        new(numero, orgaoEmissor, estadoEmissor, validade);
}
