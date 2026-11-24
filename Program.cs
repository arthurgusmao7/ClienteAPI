
using ClienteApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os Controllers
builder.Services.AddControllers();

// Registra a conexão com o banco como Singleton
builder.Services.AddSingleton<ConexaoBanco>();

var app = builder.Build();

// Configura os Controllers
app.MapControllers();

app.Run();
