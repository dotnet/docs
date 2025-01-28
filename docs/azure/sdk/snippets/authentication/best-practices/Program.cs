using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Azure;

var clientId = "<user-assigned-client-id>";
var builder = WebApplication.CreateBuilder(args);

#region snippet_credential_reuse_AspNetCore
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddSecretClient(new Uri("<key-vault-url>"));
    clientBuilder.AddBlobServiceClient(new Uri("<blob-storage-url>"));

    string clientId = builder.Configuration["UserAssignedClientId"]!;
    ChainedTokenCredential credentialChain = new(
        new ManagedIdentityCredential(
            ManagedIdentityId.FromUserAssignedClientId(clientId)),
        new VisualStudioCredential());

    clientBuilder.UseCredential(credentialChain);
});
#endregion snippet_credential_reuse_AspNetCore

#region snippet_credential_reuse_nonAspNetCore
ChainedTokenCredential credentialChain = new(
    new ManagedIdentityCredential(
        ManagedIdentityId.FromUserAssignedClientId(clientId)),
    new VisualStudioCredential());

BlobServiceClient blobServiceClient = new(
    new Uri("<blob-storage-url>"),
    credentialChain);

SecretClient secretClient = new(
    new Uri("<key-vault-url>"),
    credentialChain);
#endregion snippet_credential_reuse_nonAspNetCore

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
    ChainedTokenCredential tokenChain = new(
        new ManagedIdentityCredential(miCredentialOptions),
        new VisualStudioCredential()
    );
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
