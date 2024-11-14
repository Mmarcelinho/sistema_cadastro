namespace SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects;

public sealed record Identificacao
{
    private Identificacao(int? empresa, string identificador, EIdentificacaoTipo tipo)
    {
        Empresa = empresa;
        Identificador = identificador;
        Tipo = tipo;
    }

    public int? Empresa { get; }

    public string Identificador { get; }

    public EIdentificacaoTipo Tipo { get; }

    public static Identificacao Criar(int? empresa, string identificador, EIdentificacaoTipo tipo) 
    => new(empresa, identificador, tipo);
}