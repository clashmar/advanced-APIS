using advanced_APIS.Controllers;
using advanced_APIS.Services;
using advanced_APIS.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using advanced_APIS.HealthChecks;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

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

builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter(policyName: "fixed", options =>
    {
        options.PermitLimit = 3;
        options.Window = TimeSpan.FromSeconds(1);
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = (1);
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseHealthChecks("/health");
app.UseRateLimiter();
//app.MapGet("/spells/randosm", () => Results.Ok("Here is a random spell!"))
//    .RequireRateLimiting("fixed");
app.MapGet("/", () => "Hello World!");
app.MapControllers().RequireRateLimiting("fixed");

app.Run();
