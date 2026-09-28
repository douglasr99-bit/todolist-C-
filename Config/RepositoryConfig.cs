using TodoList.Repositories;

namespace TodoList.Config;

// Equivalente ao RepositoryConfig com @Profile: escolhe a implementação do repositório
// a partir da configuração "Repositorio" ("memoria" ou "banco").
public static class RepositoryConfig
{
    public static IServiceCollection AdicionarRepositorio(this IServiceCollection services, IConfiguration configuration)
    {
        string tipo = configuration["Repositorio"] ?? "banco";

        if (tipo.Equals("memoria", StringComparison.OrdinalIgnoreCase))
        {
            services.AddSingleton<ITodoRepository, TodoRepositoryMemoria>();
        }
        else
        {
            string connectionString = configuration.GetConnectionString("TodoDb") ?? "Data Source=data/tododb.db";
            Directory.CreateDirectory("data");
            services.AddSingleton<ITodoRepository>(new TodoRepositorySqlite(connectionString));
        }

        return services;
    }
}
