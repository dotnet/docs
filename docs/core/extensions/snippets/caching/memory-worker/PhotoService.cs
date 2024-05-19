using Microsoft.Extensions.Caching.Memory;

namespace CachingExamples.Memory;

public sealed class PhotoService(
        IMemoryCache cache,
        CacheSignal<Photo> cacheSignal,
        ILogger<PhotoService> logger)
{
    public async IAsyncEnumerable<Photo> GetPhotosAsync(Func<Photo, bool>? filter = default)
    {
        try
        {
            await cacheSignal.WaitAsync();

            Photo[] photos =
                (await cache.GetOrCreateAsync(
                    "Photos", _ =>
                    {
                        logger.LogWarning("This should never happen!");

                        return Task.FromResult(Array.Empty<Photo>());
                    }))!;

            // If no filter is provided, use a pass-thru.
            filter ??= _ => true;

            foreach (Photo photo in photos)
            {
                if (!default(Photo).Equals(photo) && filter(photo))
                {
                    yield return photo;
                }
            }
        }
        finally
        {
            cacheSignal.Release();
        }
    }
}
