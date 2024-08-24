namespace SistemaCadastro.Domain.Repositories;

    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
