namespace SistemaCadastro.Infrastructure.Migrations;

public static class MigrateExtension
{
    public async static Task MigrateDatabase(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<SistemaCadastroContext>();

        await dbContext.Database.MigrateAsync();
    }
}
