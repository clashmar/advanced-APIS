using advanced_APIS.Controllers;
using advanced_APIS.Services;
using advanced_APIS.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<SpellsService>();
builder.Services.AddScoped<SpellsModel>();

var app = builder.Build();

app.MapControllers();
app.UseRouting();

app.MapGet("/", () => "Hello World!");

app.Run();
