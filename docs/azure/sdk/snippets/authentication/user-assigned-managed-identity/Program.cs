using Azure.Identity;
using Microsoft.Extensions.Azure;
using Azure.Storage.Blobs;
using Azure.Core;

var userAssignedClientId = "<user-assigned-client-id>";
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
        TokenCredential credential = null;

        if (builder.Environment.IsProduction())
        {
            // Managed identity token credential discovered when running in Azure environments
            credential = new ManagedIdentityCredential(
                ManagedIdentityId.FromUserAssignedClientId("<client-id>"));
        } 
        else 
        {
            // Running locally on dev machine - DO NOT use in production or outside of local dev
            credential = new DefaultAzureCredential();
        }

        clientBuilder.AddBlobServiceClient(
            new Uri("https://<account-name>.blob.core.windows.net"));
        clientBuilder.UseCredential(credential);
    });
    #endregion snippet_MIC_ClientId_UseCredential

    #region snippet_MIC_ClientId
    TokenCredential credential = null;

    if (builder.Environment.IsProduction())
    {
        // Managed identity token credential discovered when running in Azure environments
        credential = new ManagedIdentityCredential(
            ManagedIdentityId.FromUserAssignedClientId("<client-id>"));
    }
    else
    {
        // Running locally on dev machine - do NOT use in production or outside of local dev
        credential = new DefaultAzureCredential();
    }

    builder.Services.AddSingleton<BlobServiceClient>(_ =>
        new BlobServiceClient(
            new Uri("https://<account-name>.blob.core.windows.net"), credential));
    #endregion snippet_MIC_ClientId
}

void registerUsingObjectId(WebApplicationBuilder builder)
{
    #region snippet_MIC_ObjectId_UseCredential
    builder.Services.AddAzureClients(clientBuilder =>
    {
        TokenCredential credential = null;

        if (builder.Environment.IsProduction())
        {
            // Managed identity token credential discovered when running in Azure environments
            credential = new ManagedIdentityCredential(
                ManagedIdentityId.FromUserAssignedObjectId("<object-id>"));
        }
        else
        {
            // Running locally on dev machine - DO NOT use in production or outside of local dev
            credential = new DefaultAzureCredential();
        }

        clientBuilder.AddBlobServiceClient(
            new Uri("https://<account-name>.blob.core.windows.net"));
        clientBuilder.UseCredential(credential);
    });
    #endregion snippet_MIC_ObjectId_UseCredential

    #region snippet_MIC_ObjectId
    TokenCredential credential = null;

    if (builder.Environment.IsProduction())
    {
        // Managed identity token credential discovered when running in Azure environments
        credential = new ManagedIdentityCredential(
            ManagedIdentityId.FromUserAssignedObjectId("<object-id>"));
    }
    else
    {
        // Running locally on dev machine - DO NOT use in production or outside of local dev
        credential = new DefaultAzureCredential();
    }

    builder.Services.AddSingleton<BlobServiceClient>(_ =>
        new BlobServiceClient(
            new Uri("https://<account-name>.blob.core.windows.net"), credential));
    #endregion snippet_MIC_ObjectId
}


void registerUsingResourceId(WebApplicationBuilder builder)
{
    #region snippet_MIC_ResourceId_UseCredential
    builder.Services.AddAzureClients(clientBuilder =>
    {
        TokenCredential credential = null;

        if (builder.Environment.IsProduction())
        {
            // Managed identity token credential discovered when running in Azure environments
            credential = new ManagedIdentityCredential(
                ManagedIdentityId.FromUserAssignedResourceId(new ResourceIdentifier("<resource-id>")));
        }
        else
        {
            // Running locally on dev machine - DO NOT use in production or outside of local dev
            credential = new DefaultAzureCredential();
        }

        clientBuilder.AddBlobServiceClient(
            new Uri("https://<account-name>.blob.core.windows.net"));
        clientBuilder.UseCredential(credential);
    });
    #endregion snippet_MIC_ResourceId_UseCredential

    #region snippet_MIC_ResourceId
    TokenCredential credential = null;

    if (builder.Environment.IsProduction())
    {
        // Managed identity token credential discovered when running in Azure environments
        credential = new ManagedIdentityCredential(
            ManagedIdentityId.FromUserAssignedResourceId(new ResourceIdentifier("<resource-id>")));
    }
    else
    {
        // Running locally on dev machine - DO NOT use in production or outside of local dev
        credential = new DefaultAzureCredential();
    }

    builder.Services.AddSingleton<BlobServiceClient>(_ =>
        new BlobServiceClient(
            new Uri("https://<account-name>.blob.core.windows.net"), credential));
    #endregion snippet_MIC_ResourceId
}

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}