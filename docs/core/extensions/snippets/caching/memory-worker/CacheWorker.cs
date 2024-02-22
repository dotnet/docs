using System.Net.Http.Json;
using Microsoft.Extensions.Caching.Memory;

namespace CachingExamples.Memory;

public sealed class CacheWorker(
    ILogger<CacheWorker> logger,
    HttpClient httpClient,
    CacheSignal<Photo> cacheSignal,
    IMemoryCache cache) : BackgroundService
{
    private readonly TimeSpan _updateInterval = TimeSpan.FromHours(3);

    private bool _isCacheInitialized = false;

    private const string Url = "https://jsonplaceholder.typicode.com/photos";

    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        await cacheSignal.WaitAsync();
        await base.StartAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Updating cache.");

            try
            {
                Photo[]? photos =
                    await httpClient.GetFromJsonAsync<Photo[]>(
                        Url, stoppingToken);

                if (photos is { Length: > 0 })
                {
                    cache.Set("Photos", photos);
                    logger.LogInformation(
                        "Cache updated with {Count:#,#} photos.", photos.Length);
                }
                else
                {
                    logger.LogWarning(
                        "Unable to fetch photos to update cache.");
                }
            }
            finally
            {
                if (!_isCacheInitialized)
                {
                    cacheSignal.Release();
                    _isCacheInitialized = true;
                }
            }

            try
            {
                logger.LogInformation(
                    "Will attempt to update the cache in {Hours} hours from now.",
                    _updateInterval.Hours);

                await Task.Delay(_updateInterval, stoppingToken);
            }
            catch (OperationCanceledException)
            {
                logger.LogWarning("Cancellation acknowledged: shutting down.");
                break;
            }
        }
    }
}
