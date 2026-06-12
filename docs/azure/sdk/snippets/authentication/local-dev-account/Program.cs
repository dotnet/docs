using Microsoft.Extensions.Azure;
using Azure.Storage.Blobs;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

var builder = WebApplication.CreateBuilder(args);

registerUsingUserPrincipal(builder);
registerUsingNextGen(builder);

var app = builder.Build();

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

app.MapGet("/weatherforecast", async (BlobServiceClient client) =>
{
    var containerClient = client.GetBlobContainerClient("docs");

    var blobs = containerClient.GetBlobs();

    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return blobs.FirstOrDefault()?.Name ?? string.Empty;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

void registerUsingUserPrincipal(WebApplicationBuilder builder)
{
    #region snippet_VisualStudioCredential
    builder.Services.AddAzureClients(clientBuilder =>
    {
        clientBuilder.AddBlobServiceClient(
            new Uri("https://<account-name>.blob.core.windows.net"));

        VisualStudioCredential credential = new();
        clientBuilder.UseCredential(credential);
    });
    #endregion snippet_VisualStudioCredential

    #region snippet_DefaultAzureCredentialDev
    builder.Services.AddAzureClients(clientBuilder =>
    {
        clientBuilder.AddBlobServiceClient(
            new Uri("https://<account-name>.blob.core.windows.net"));

        DefaultAzureCredential credential = new(
            DefaultAzureCredential.DefaultEnvironmentVariableName);
        clientBuilder.UseCredential(credential);
    });
    #endregion snippet_DefaultAzureCredentialDev
}

// Demonstrates the next-gen configuration and dependency injection pattern from
// System.ClientModel / Azure.Identity. The credential and endpoint are read from
// the "KeyVaultSecrets" section of appsettings.json.
void registerUsingNextGen(WebApplicationBuilder builder)
{
    #region snippet_NextGenAddSecretClient
    // Binds the "KeyVaultSecrets" section of appsettings.json and resolves the
    // credential from the nested "Credential" subsection automatically.
    builder.AddSecretClient("KeyVaultSecrets");
    #endregion snippet_NextGenAddSecretClient
}

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
