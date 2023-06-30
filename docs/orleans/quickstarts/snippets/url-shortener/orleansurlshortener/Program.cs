// <configuration>
using Orleans.Runtime;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseOrleans(siloBuilder =>
{
    siloBuilder.UseLocalhostClustering();
    siloBuilder.AddMemoryGrainStorage("urls");
});

using WebApplication app = builder.Build();
// </configuration>

// <endpoints>
app.MapGet("/", () => "Hello World!");

app.MapGet("/shorten",
    async (IGrainFactory grains, HttpRequest request, string url) =>
    {
        var host = $"{request.Scheme}://{request.Host.Value}";

        // Validate the URL query string.
        if (string.IsNullOrWhiteSpace(url) &&
            Uri.IsWellFormedUriString(url, UriKind.Absolute) is false)
        {
            return Results.BadRequest($"""
                The URL query string is required and needs to be well formed.
                Consider, ${host}/shorten?url=https://www.microsoft.com.
                """);
        }

        // Create a unique, short ID
        var shortenedRouteSegment = Guid.NewGuid().GetHashCode().ToString("X");

        // Create and persist a grain with the shortened ID and full URL
        var shortenerGrain = grains.GetGrain<IUrlShortenerGrain>(shortenedRouteSegment);
        await shortenerGrain.SetUrl(url);

        // Return the shortened URL for later use
        var resultBuilder = new UriBuilder(host)
        {
            Path = $"/go/{shortenedRouteSegment}"
        };

        return Results.Ok(resultBuilder.Uri);
    });

app.MapGet("/go/{shortenedRouteSegment:required}",
    async (IGrainFactory grains, string shortenedRouteSegment) =>
    {
        // Retrieve the grain using the shortened ID and url to the original URL        
        var shortenerGrain = grains.GetGrain<IUrlShortenerGrain>(shortenedRouteSegment);
        var url = await shortenerGrain.GetUrl();

        return Results.Redirect(url);
    });

app.Run();
// </endpoints>

// <graininterface>
public interface IUrlShortenerGrain : IGrainWithStringKey
{
    Task SetUrl(string fullUrl);

    Task<string> GetUrl();
}
// </graininterface>

// <grain>
public sealed class UrlShortenerGrain : Grain, IUrlShortenerGrain
{
    private readonly IPersistentState<UrlDetails> _state;

    public UrlShortenerGrain(
        [PersistentState(
            stateName: "url",
            storageName: "urls")]
            IPersistentState<UrlDetails> state) => _state = state;

    public async Task SetUrl(string fullUrl)
    {
        _state.State = new()
        {
            ShortenedRouteSegment = this.GetPrimaryKeyString(),
            FullUrl = fullUrl
        };

        await _state.WriteStateAsync();
    }

    public Task<string> GetUrl() =>
        Task.FromResult(_state.State.FullUrl);
}

[GenerateSerializer]
public record class UrlDetails
{
    [Id(0)]
    public string FullUrl { get; set; }

    [Id(1)]
    public string ShortenedRouteSegment { get; set; }
}
// </grain>
