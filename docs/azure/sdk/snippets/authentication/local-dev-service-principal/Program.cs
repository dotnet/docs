using Azure.Identity;
using Microsoft.Extensions.Azure;
using Azure.Storage.Blobs;
using Azure.Core;

var builder = WebApplication.CreateBuilder(args);

// Registration options
// registerUsingClientId(builder);
// registerUsingObjectId(builder);
// registerUsingResourceId(builder);

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

void registerUsingClientId(WebApplicationBuilder builder)
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
            // Use when running in Azure environments
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
            // Use when running in Azure environments
            credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
        } 
        else 
        {
            // Use locally on dev machine - DO NOT use in production or outside of local dev
            credential = new DefaultAzureCredential();
        }

        clientBuilder.UseCredential(credential);
    });
    #endregion snippet_ClientSecretCredential
}

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
