using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaCadastro.Infrastructure.DataAccess;

namespace SistemaCadastro.Infrastructure.Migrations;

public static class MigrateExtension
{
    public async static Task MigrateDatabase(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<SistemaCadastroContext>();

        await dbContext.Database.MigrateAsync();
    }
}
