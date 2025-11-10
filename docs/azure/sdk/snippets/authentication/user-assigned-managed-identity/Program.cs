using Azure.Identity;
using Microsoft.Extensions.Azure;
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
    #region snippet_MIC_ClientId_UseCredential
    builder.Services.AddAzureClients(clientBuilder =>
    {
        clientBuilder.AddBlobServiceClient(
            new Uri("https://<account-name>.blob.core.windows.net"));

        if (builder.Environment.IsProduction() || builder.Environment.IsStaging())
        {
            // Managed identity token credential discovered when running in Azure environments
            ManagedIdentityCredential credential = new(
                ManagedIdentityId.FromUserAssignedClientId("<client-id>"));
            clientBuilder.UseCredential(credential);
        } 
    });
    #endregion snippet_MIC_ClientId_UseCredential
}

void registerUsingObjectId(WebApplicationBuilder builder)
{
    #region snippet_MIC_ObjectId_UseCredential
    builder.Services.AddAzureClients(clientBuilder =>
    {
        clientBuilder.AddBlobServiceClient(
            new Uri("https://<account-name>.blob.core.windows.net"));
            
        if (builder.Environment.IsProduction() || builder.Environment.IsStaging())
        {
            // Managed identity token credential discovered when running in Azure environments
            ManagedIdentityCredential credential = new(
                ManagedIdentityId.FromUserAssignedObjectId("<object-id>"));
            clientBuilder.UseCredential(credential);
        }
    });
    #endregion snippet_MIC_ObjectId_UseCredential
}


void registerUsingResourceId(WebApplicationBuilder builder)
{
    #region snippet_MIC_ResourceId_UseCredential
    builder.Services.AddAzureClients(clientBuilder =>
    {
        clientBuilder.AddBlobServiceClient(
            new Uri("https://<account-name>.blob.core.windows.net"));

        if (builder.Environment.IsProduction() || builder.Environment.IsStaging())
        {
            // Managed identity token credential discovered when running in Azure environments
            ManagedIdentityCredential credential = new(
                ManagedIdentityId.FromUserAssignedResourceId(new ResourceIdentifier("<resource-id>")));
            clientBuilder.UseCredential(credential);
        }
    });
    #endregion snippet_MIC_ResourceId_UseCredential
}

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
