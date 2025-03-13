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
    #region snippet_DefaultAzureCredential_UseCredential
    builder.Services.AddAzureClients(clientBuilder =>
    {
        clientBuilder.AddBlobServiceClient(
            new Uri("https://<account-name>.blob.core.windows.net"));

        clientBuilder.UseCredential(new DefaultAzureCredential);
    });
    #endregion snippet_DefaultAzureCredential_UseCredential

    #region snippet_DefaultAzureCredential
    builder.Services.AddSingleton<BlobServiceClient>(_ =>
        new BlobServiceClient(
            new Uri("https://<account-name>.blob.core.windows.net"),
            new DefaultAzureCredential));
    #endregion snippet_DefaultAzureCredential
}

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
