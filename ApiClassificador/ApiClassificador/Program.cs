using ApiClassificador.Data;
using ApiClassificador.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ClassificacaoTextoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<ClassificacaoService>();

// CORS 
var origensPermitidos = builder.Configuration.GetValue<string>("OrigensPermitidos")?.Split(",")
    ?? Array.Empty<string>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        if (origensPermitidos.Length > 0)
        {
            policy.WithOrigins(origensPermitidos);
        }
        else
        {
            policy.AllowAnyOrigin();
        }
        policy.AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();



