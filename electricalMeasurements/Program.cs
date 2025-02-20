using electricalMeasurements.Service;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
        {
        Title = "API do pomiarów elektrycznych",
        Version = "v1",
        Description = "API obs³uguj¹ce pomiary elektryczne, w tym impedancjê pêtli zwarcia, rezystancjê izolacji i inne.",
        Contact = new OpenApiContact
            {
            Name = "xxx",
            Email = "x@xxxx.pl",
            Url = new Uri("https://twojafirma.pl")
            }
        });
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Rejestracja serwisów pomiarowych
builder.Services.AddScoped<ContinuityTestService>();
builder.Services.AddScoped<InsulationResistanceService>();
builder.Services.AddScoped<PolarityCheckService>();
builder.Services.AddScoped<RCDTestService>();
builder.Services.AddScoped<LoopImpedanceService>();
builder.Services.AddScoped<GroundResistanceService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
// Dodanie Swagger UI
if (app.Environment.IsDevelopment())
    {
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API do pomiarów elektrycznych v1");
        c.RoutePrefix = "swagger"; // Swagger dostêpny pod /swagger
    });
    }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
