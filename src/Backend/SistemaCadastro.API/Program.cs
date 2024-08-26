using SistemaCadastro.Application;
using SistemaCadastro.Infrastructure;
using SistemaCadastro.Infrastructure.Migrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(option => option.LowercaseUrls = true);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "SISTEMA DE CADASTRO API", Version = "1.0" });
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

await UpdateDatabase();

app.Run();

async Task UpdateDatabase()
{
    await using var scope = app.Services.CreateAsyncScope();

    await MigrateExtension.MigrateDatabase(scope.ServiceProvider);
}