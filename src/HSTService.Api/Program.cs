using System.Diagnostics;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/instance-info", () =>
{
    app.Logger.LogInformation("Request served");

    return new
    {
        ServiceName = Assembly.GetExecutingAssembly().GetName().Name,
        ProcessId = Process.GetCurrentProcess().Id
    };
})
.WithOpenApi();

app.Run();