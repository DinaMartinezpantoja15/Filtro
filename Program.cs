using System.Text;
using Filtro.Data;
using Filtro.Service.Owners;
using Filtro.Service.Pets;
using Filtro.Service.Quotes;
using Filtro.Service.Vets;
using Microsoft.EntityFrameworkCore;
using Simulacro2.Services;


var builder = WebApplication.CreateBuilder(args);

// Configuración de la base de datos
builder.Services.AddDbContext<BaseContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));

// Añadir servicios al contenedor
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Añadimos el CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder => builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// Registrar los repositorios
builder.Services.AddScoped<IPetsRepository, PetsRepository>();
builder.Services.AddScoped<IQuotesRepository, QuotesRepository>();
builder.Services.AddScoped<IVetsRepository, VetsRepository>();
builder.Services.AddScoped<IOwnersRepository, OwnersRepository>();


// Registrar el servicio de MailerSend
builder.Services.AddScoped<MailerSendService>();

var app = builder.Build();

app.UseCors("AllowAnyOrigin"); // Usamos el CORS

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Añadir autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers(); // Este también se comparte con el token

app.Run();
