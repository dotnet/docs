#region snippet_UseCredential
using Azure.Identity;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(
        new Uri("https://<account-name>.blob.core.windows.net"));
    clientBuilder.UseCredential(new DefaultAzureCredential());

    #region snippet_DacExcludes
    clientBuilder.UseCredential(new DefaultAzureCredential(
        new DefaultAzureCredentialOptions
        {
            ExcludeEnvironmentCredential = true,
            ExcludeWorkloadIdentityCredential = true,
        }));
    #endregion

    #region snippet_Ctc
    clientBuilder.UseCredential(new ChainedTokenCredential(
        new ManagedIdentityCredential(),
        new VisualStudioCredential()));
    #endregion
});
#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
