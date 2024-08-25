namespace SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects;

public sealed record Parceiro
{
    private Parceiro(bool cliente, bool fornecedor, bool prestador, bool colaborador)
    {
        Cliente = cliente;
        Fornecedor = fornecedor;
        Prestador = prestador;
        Colaborador = colaborador;
    }

    public bool Cliente { get; }

    public bool Fornecedor { get; }

    public bool Prestador { get; }

    public bool Colaborador { get; }

    public static Parceiro Criar(bool cliente, bool fornecedor, bool prestador, bool colaborador)
    => new(cliente, fornecedor, prestador, colaborador);
}
