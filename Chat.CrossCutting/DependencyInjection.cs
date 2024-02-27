using System.Data;

using Chat.Domain.Repositories;
using Chat.Infrastructure.Repositories;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.CrossCutting;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDbConnection, SqlConnection>(provider =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(connectionString);
        });

        services.AddScoped<IConversasRepository, ConversasRepository>();
        services.AddScoped<IContatosRepository, ContatosRepository>();
        services.AddScoped<IMensagensRepository, MensagensRepository>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        var assembly = AppDomain.CurrentDomain.Load("Chat.Application");
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        return services;
    }
}
