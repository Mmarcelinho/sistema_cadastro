namespace SistemaCadastro.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddContext(services, configuration);
        AddRepositories(services);
    }

    private static void AddContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Conexao");

        services.AddDbContext<SistemaCadastroContext>(opcoes =>
        {
            opcoes.UseSqlServer(connectionString);
        });
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<ICadastroRepository, CadastroRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
