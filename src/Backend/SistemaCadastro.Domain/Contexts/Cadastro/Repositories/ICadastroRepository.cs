namespace SistemaCadastro.Domain.Contexts.Cadastro.Repositories;

public interface ICadastroRepository
{
    Task<Aggregates.Entities.Cadastro> RecuperarTodosAsync();

    Task<Aggregates.Entities.Cadastro> RecuperarPorIdAsync(Guid id);
    
    Task Registrar(Aggregates.Entities.Cadastro cadastro);

    void Atualizar(Aggregates.Entities.Cadastro cadastro);

    Task Deletar(Guid id);
}
