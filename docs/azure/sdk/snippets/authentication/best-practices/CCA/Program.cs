using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Azure;

string clientId = "<user-assigned-client-id>";
string storageAccountName = "<account-name>";
string keyVaultName = "<vault-name>";
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

#region snippet_credential_reuse_AspNetCore
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddSecretClient(
        new Uri($"https://{keyVaultName}.vault.azure.net"));
    clientBuilder.AddBlobServiceClient(
        new Uri($"https://{storageAccountName}.blob.core.windows.net"));

    TokenCredential credential;

    if (builder.Environment.IsProduction() || builder.Environment.IsStaging())
    {
        string? clientId = builder.Configuration["UserAssignedClientId"];
        credential = new ManagedIdentityCredential(
            ManagedIdentityId.FromUserAssignedClientId(clientId));
    }
    else
    {
        // local development environment
        credential = new ChainedTokenCredential(
            new VisualStudioCredential(),
            new AzureCliCredential(),
            new AzurePowerShellCredential());
    }

    clientBuilder.UseCredential(credential);
});
#endregion snippet_credential_reuse_AspNetCore

#region snippet_retries
ManagedIdentityCredentialOptions miCredentialOptions = new(
        ManagedIdentityId.FromUserAssignedClientId(clientId)
    )
    {
        Retry =
        {
            MaxRetries = 3,
            Delay = TimeSpan.FromSeconds(0.5),
        }
    };

ManagedIdentityCredential miCredential = new(miCredentialOptions);
#endregion

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

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
.WithName("GetWeatherForecast");

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
