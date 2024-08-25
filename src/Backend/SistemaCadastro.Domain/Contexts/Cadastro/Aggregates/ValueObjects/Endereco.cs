namespace SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects;

public sealed record Endereco
{
    private Endereco(
        string cep,
        string logradouro,
        string numero,
        string bairro,
        string complemento,
        string pontoReferencia,
        string uf,
        string cidade,
        int ibge)
    {
        Cep = cep;
        Logradouro = logradouro;
        Numero = numero;
        Bairro = bairro;
        Complemento = complemento;
        PontoReferencia = pontoReferencia;
        Uf = uf;
        Cidade = cidade;
        Ibge = ibge;
    }

    public string Cep { get; }

    public string Logradouro { get; }

    public string Numero { get; }

    public string Bairro { get; }

    public string Complemento { get; }

    public string PontoReferencia { get; }

    public string Uf { get; }

    public string Cidade { get; }

    public int Ibge { get; }

    public static Endereco Criar(
        string cep,
        string logradouro,
        string numero,
        string bairro,
        string complemento,
        string pontoReferencia,
        string uf,
        string cidade,
        int ibge) =>
        new(
            cep,
            logradouro,
            numero,
            bairro,
            complemento,
            pontoReferencia,
            uf,
            cidade,
            ibge
        );
}
