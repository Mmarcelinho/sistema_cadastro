namespace SistemaCadastro.Domain.Contexts.Cadastro.Abstractions;

public abstract class Pessoa : Entidade
{
    protected Pessoa() { }
    
    protected Pessoa(Nome nome, Email email, Telefone telefone, List<Domicilio> domicilios)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Token = Guid.NewGuid();
        _domicilios = domicilios;
    }

    private readonly List<Domicilio> _domicilios;

    public Nome Nome { get; }

    public Email Email { get; }

    public Telefone Telefone { get; }

    public Guid Token { get; }

    public IReadOnlyCollection<Domicilio> Domicilios => _domicilios.AsReadOnly();
}
