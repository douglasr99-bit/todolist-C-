using TodoList.Config;
using TodoList.Services;

var builder = WebApplication.CreateBuilder(args);

// Porta configurável pela variável PORT (padrão 8080), como no application.properties.
string porta = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{porta}");

builder.Services.AddControllers(options => options.Filters.Add<GlobalExceptionHandler>());
builder.Services.AdicionarRepositorio(builder.Configuration);
builder.Services.AddSingleton<TodoService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();

app.Run();
