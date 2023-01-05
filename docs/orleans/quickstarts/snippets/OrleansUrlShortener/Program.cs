using Microsoft.AspNetCore.Http.Extensions;
using Orleans.Runtime;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseOrleans(siloBuilder =>
{
    siloBuilder.UseLocalhostClustering();
    siloBuilder.AddMemoryGrainStorage("urls");
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/shorten/{*path}",
    async (IGrainFactory grains, HttpRequest request, string path) =>
    {
        // Create a unique, short ID
        var shortenedRouteSegment = Guid.NewGuid().GetHashCode().ToString("X");

        // Create and persist a grain with the shortened ID and full URL
        var shortenerGrain = grains.GetGrain<IUrlShortenerGrain>(shortenedRouteSegment);
        await shortenerGrain.SetUrl(path);

        // Return the shortened URL for later use
        var resultBuilder = new UriBuilder(request.GetEncodedUrl())
        {
            Path = $"/go/{shortenedRouteSegment}"
        };

        return Results.Ok(resultBuilder.Uri);
    });

app.MapGet("/go/{shortenedRouteSegment}",
    async (IGrainFactory grains, string shortenedRouteSegment) =>
    {
        // Retrieve the grain using the shortened ID and redirect to the original URL        
        var shortenerGrain = grains.GetGrain<IUrlShortenerGrain>(shortenedRouteSegment);
        var url = await shortenerGrain.GetUrl();

        return Results.Redirect(url);
    });

app.Run();

public interface IUrlShortenerGrain : IGrainWithStringKey
{
    Task SetUrl(string fullUrl);
    Task<string> GetUrl();
}

public class UrlShortenerGrain : Grain, IUrlShortenerGrain
{
    private readonly IPersistentState<UrlDetails> _state;

    public UrlShortenerGrain(
        [PersistentState(
                stateName: "url",
                storageName: "urls")]
                IPersistentState<UrlDetails> state)
    {
        _state = state;
    }

    public async Task SetUrl(string fullUrl)
    {
        _state.State = new UrlDetails() { ShortenedRouteSegment = this.GetPrimaryKeyString(), FullUrl = fullUrl };
        await _state.WriteStateAsync();
    }

    public Task<string> GetUrl()
    {
        return Task.FromResult(_state.State.FullUrl);
    }
}

[GenerateSerializer]
public record UrlDetails
{
    public string FullUrl { get; set; }
    public string ShortenedRouteSegment { get; set; }
}
