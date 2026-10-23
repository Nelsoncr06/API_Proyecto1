using API.DAPPER;
using API.LOGICA.NEGOCIO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<InicioSesionBLL>();
builder.Services.AddScoped<IniciosSesionDAL>();
builder.Services.AddScoped<UsuariosBLL>();
builder.Services.AddScoped<UsuariosDAL>();

// Configure OpenAPI.
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodos", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Serve the index.html file from wwwroot at the root URL.
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors("PermitirTodos");

app.UseAuthorization();

app.MapControllers();

app.Run();