using Microsoft.EntityFrameworkCore;
using SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.Entities;
using SistemaCadastro.Domain.Notifications;

namespace SistemaCadastro.Infrastructure.DataAccess;

public class SistemaCadastroContext(DbContextOptions<SistemaCadastroContext> options) : DbContext(options)
{
    public DbSet<Cadastro> Cadastros { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Notification>();
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SistemaCadastroContext).Assembly);
    }
}
