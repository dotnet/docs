using System.Net.Http.Json;
using Microsoft.Extensions.Caching.Memory;

namespace CachingExamples.Memory;

public sealed class CacheWorker : BackgroundService
{
    private readonly ILogger<CacheWorker> _logger;
    private readonly HttpClient _httpClient;
    private readonly CacheSignal<Photo> _cacheSignal;
    private readonly IMemoryCache _cache;
    private readonly TimeSpan _updateInterval = TimeSpan.FromHours(3);

    private const string Url = "https://jsonplaceholder.typicode.com/photos";

    public CacheWorker(
        ILogger<CacheWorker> logger,
        HttpClient httpClient,
        CacheSignal<Photo> cacheSignal,
        IMemoryCache cache) =>
        (_logger, _httpClient, _cacheSignal, _cache) = (logger, httpClient, cacheSignal, cache);

    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        await _cacheSignal.WaitAsync();
        await base.StartAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var initialCaching = true;
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Updating cache.");

            try
            {
                Photo[]? photos =
                    await _httpClient.GetFromJsonAsync<Photo[]>(
                        Url, stoppingToken);

                if (photos is { Length: > 0 })
                {
                    _cache.Set("Photos", photos);
                    _logger.LogInformation(
                        "Cache updated with {Count:#,#} photos.", photos.Length);
                }
                else
                {
                    _logger.LogWarning(
                        "Unable to fetch photos to update cache.");
                }
            }
            finally
            {
                if (initialRun)
                {
                    _cacheSignal.Release();
                    initialRun = false;
                }
            }

            try
            {
                _logger.LogInformation(
                    "Will attempt to update the cache in {Hours} hours from now.",
                    _updateInterval.Hours);

                await Task.Delay(_updateInterval, stoppingToken);
            }
            catch (OperationCanceledException)
            {
                _logger.LogWarning("Cancellation acknowledged: shutting down.");
                break;
            }
        }
    }
}
