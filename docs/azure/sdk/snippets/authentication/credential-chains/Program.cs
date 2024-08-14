using System.Diagnostics.Tracing;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Identity;
using Microsoft.Extensions.Azure;

var userAssignedClientId = "<user-assigned-client-id>";
var builder = WebApplication.CreateBuilder(args);

#region snippet_FilteredLogging
using AzureEventSourceListener listener = new((args, message) =>
{
    if (args is { EventSource.Name: "Azure-Identity" })
    {
        Console.WriteLine(message);
    }
}, EventLevel.LogAlways);
#endregion snippet_FilteredLogging

builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(
        new Uri("https://<account-name>.blob.core.windows.net"));
    #region snippet_Dac
    clientBuilder.UseCredential(new DefaultAzureCredential());
    #endregion snippet_Dac

    #region snippet_DacExcludes
    clientBuilder.UseCredential(new DefaultAzureCredential(
        new DefaultAzureCredentialOptions
        {
            ExcludeEnvironmentCredential = true,
            ExcludeWorkloadIdentityCredential = true,
            ManagedIdentityClientId = userAssignedClientId,
        }));
    #endregion snippet_DacExcludes

    #region snippet_Ctc
    clientBuilder.UseCredential(new ChainedTokenCredential(
        new ManagedIdentityCredential(clientId: userAssignedClientId),
        new VisualStudioCredential()));
    #endregion snippet_Ctc
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

#region snippet_NoChain
TokenCredential credential;

if (app.Environment.IsProduction() || app.Environment.IsStaging())
{
    credential = new ManagedIdentityCredential(clientId: userAssignedClientId);
}
else
{
    // local development environment
    credential = new VisualStudioCredential();
}
#endregion snippet_NoChain

#region snippet_DacEquivalents
credential = new DefaultAzureCredential(
    new DefaultAzureCredentialOptions
    {
        ExcludeEnvironmentCredential = true,
        ExcludeWorkloadIdentityCredential = true,
        ExcludeAzureCliCredential = true,
        ExcludeAzurePowerShellCredential = true,
        ExcludeAzureDeveloperCliCredential = true,
        ManagedIdentityClientId = userAssignedClientId
    });
#endregion

#region snippet_CtcEquivalents
credential = new ChainedTokenCredential(
    new ManagedIdentityCredential(clientId: userAssignedClientId),
    new VisualStudioCredential());
#endregion

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
