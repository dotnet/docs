using Azure.Identity;
using Microsoft.Extensions.Azure;
using Azure.Storage.Blobs;
using Azure.Core;

var userAssignedClientId = "<user-assigned-client-id>";
var builder = WebApplication.CreateBuilder(args);

var runningOnLocalDevBox = false;

#region snippet_MIC_UseCredential
builder.Services.AddAzureClients(clientBuilder =>
{
    TokenCredential credential = null;

    if (runningOnLocalDevBox)
    {
        // Running locally on dev machine - DO NOT use in production or outside of local dev
        credential = new DefaultAzureCredential();
    }
    else
    {
        // Managed identity token credential discovered when running in Azure environments
        credential = new ManagedIdentityCredential();
    }

    clientBuilder.AddBlobServiceClient(
        new Uri("https://<account-name>.blob.core.windows.net"));
    clientBuilder.UseCredential(credential);
});
#endregion snippet_MIC_UseCredential

#region snippet_MIC
TokenCredential credential = null;

if (runningOnLocalDevBox)
{
    // Running locally on dev machine - do NOT use in production or outside of local dev
    credential = new DefaultAzureCredential();
}
else
{
    // Managed identity token credential discovered when running in Azure environments
    credential = new ManagedIdentityCredential();
}

builder.Services.AddSingleton<BlobServiceClient>(_ =>
    new BlobServiceClient(
        new Uri("https://<account-name>.blob.core.windows.net"), credential));
#endregion snippet_MIC

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

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}