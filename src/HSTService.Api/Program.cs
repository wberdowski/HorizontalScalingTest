using System.Diagnostics;
using System.Net;
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
    var hostname = Dns.GetHostName();

    return new
    {
        ServiceName = Assembly.GetExecutingAssembly().GetName().Name,
        ProcessId = (ulong)Process.GetCurrentProcess().StartTime.GetHashCode(),
        Hostname = hostname,
        Addresses = Dns.GetHostEntry(hostname).AddressList.Select(a => a.ToString())
    };
})
.WithOpenApi();

app.Run();