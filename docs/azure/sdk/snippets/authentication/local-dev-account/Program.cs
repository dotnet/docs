using Microsoft.Extensions.Azure;
using Azure.Storage.Blobs;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

registerUsingUserPrincipal(builder);

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

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
