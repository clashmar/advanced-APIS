using advanced_APIS.HealthChecks;
using advanced_APIS.Models;
using advanced_APIS.Services;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<WizardsService>();
builder.Services.AddScoped<WizardsModel>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddHealthChecks()
    .AddCheck<TeachersHealthCheck>("teachers_file_health_check",
    failureStatus: HealthStatus.Unhealthy,
    tags: new[] { "file", "teachers" });


builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter(policyName: "fixed", options =>
    {
        options.PermitLimit = 3;
        options.Window = TimeSpan.FromMinutes(1);
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = (1);

    });

    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    options.OnRejected = async (context, cancellationToken) =>
    {
        await context.HttpContext.Response.WriteAsync("Too many requests, try again later", cancellationToken);
    };
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
app.MapControllers();

app.Run();
