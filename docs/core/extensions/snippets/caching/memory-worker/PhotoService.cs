using Microsoft.Extensions.Caching.Memory;

namespace CachingExamples.Memory;

public sealed class PhotoService
{
    private readonly IMemoryCache _cache;
    private readonly CacheSignal<Photo> _cacheSignal;
    private readonly ILogger<PhotoService> _logger;

    public PhotoService(
        IMemoryCache cache,
        CacheSignal<Photo> cacheSignal,
        ILogger<PhotoService> logger) =>
        (_cache, _cacheSignal, _logger) = (cache, cacheSignal, logger);

    public async IAsyncEnumerable<Photo> GetPhotosAsync(Func<Photo, bool>? filter = default)
    {
        try
        {
            await _cacheSignal.WaitAsync();

            Photo[] photos =
                await _cache.GetOrCreateAsync(
                    "Photos", _ =>
                    {
                        _logger.LogWarning("This should never happen!");

                        return Task.FromResult(Array.Empty<Photo>());
                    });

            // If no filter is provided, use a pass-thru.
            filter ??= _ => true;

            foreach (Photo? photo in photos)
            {
                if (photo is not null && filter(photo))
                {
                    yield return photo;
                }
            }
        }
        finally
        {
            _cacheSignal.Release();
        }
    }
}
