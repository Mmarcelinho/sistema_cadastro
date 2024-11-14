namespace SistemaCadastro.Infrastructure.DataAccess;

public class UnitOfWork(SistemaCadastroContext _context) : IUnitOfWork
{
    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}
