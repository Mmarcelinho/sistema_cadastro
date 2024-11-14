namespace SistemaCadastro.Infrastructure.DataAccess.Repositories;

public class CadastroRepository(SistemaCadastroContext _context) : ICadastroRepository
{
    public async Task<IEnumerable<Cadastro>> RecuperarTodosAsync() => await _context.Cadastros.AsNoTracking().ToListAsync();

    public async Task<Cadastro> RecuperarPorIdAsync(Guid id) => await _context.Cadastros.FirstOrDefaultAsync(cadastro => cadastro.Id == id);

    public async Task Registrar(Cadastro cadastro) => await _context.Cadastros.AddAsync(cadastro);

    public void Atualizar(Cadastro cadastro) => _context.Cadastros.Update(cadastro);

    public async Task Deletar(Guid id)
    {
        var cadastro = await _context.Cadastros.FindAsync(id);

        _context.Cadastros.Remove(cadastro!);
    }
}
