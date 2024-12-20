using advanced_APIS.Controllers;
using advanced_APIS.Services;
using advanced_APIS.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using advanced_APIS.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<WizardsService>();
builder.Services.AddScoped<WizardsModel>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks()
    .AddCheck<TeachersHealthCheck>("teachers_file_health_check",
    failureStatus: HealthStatus.Unhealthy,
    tags: new[] { "file", "teachers" });


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();
app.UseHealthChecks("/health");
app.MapGet("/", () => "Hello World!");

app.Run();
