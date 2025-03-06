using Azure.Identity;
using Microsoft.Extensions.Azure;
using Azure.Storage.Blobs;
using Azure.Core;

var builder = WebApplication.CreateBuilder(args);

registerUsingServicePrincipal(builder);

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
    return blobs.FirstOrDefault().Name;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

void registerUsingServicePrincipal(WebApplicationBuilder builder)
{
    #region snippet_ClientSecretCredential_UseCredential
    builder.Services.AddAzureClients(clientBuilder =>
    {
        var tenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");
        var clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
        var clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");

        clientBuilder.AddBlobServiceClient(
            new Uri("https://<account-name>.blob.core.windows.net"));

        TokenCredential credential = null;

        if (builder.Environment.IsProduction() || builder.Environment.IsStaging())
        {
            // Use when running in hosted production environments
            credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
        } 
        else 
        {
            // Use locally on dev machine - DO NOT use in production or outside of local dev
            credential = new DefaultAzureCredential();
        }

        clientBuilder.UseCredential(credential);
    });
    #endregion snippet_ClientSecretCredential_UseCredential

    #region snippet_ClientSecretCredential
    var tenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");
    var clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
    var clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");

    TokenCredential credential = null;

    if (builder.Environment.IsProduction() || builder.Environment.IsStaging())
    {
        // Use when running in hosted production environments
        credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
    }
    else
    {
        // Use locally on dev machine - DO NOT use in production or outside of local dev
        credential = new DefaultAzureCredential();
    }

    builder.Services.AddSingleton<BlobServiceClient>(_ =>
        new BlobServiceClient(
            new Uri("https://<account-name>.blob.core.windows.net"), credential));
    #endregion snippet_ClientSecretCredential
}

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
