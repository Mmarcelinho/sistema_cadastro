using Microsoft.Extensions.DependencyInjection;
using SistemaCadastro.Application.Shared.Results;
using SistemaCadastro.Application.Shared.Results.Interfaces;

namespace SistemaCadastro.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddMediatR(services);
    }

    private static void AddMediatR(IServiceCollection services)
    {
        var myHandlers = AppDomain.CurrentDomain.Load("SistemaCadastro.Application");

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(myHandlers);
        });
    }
}
