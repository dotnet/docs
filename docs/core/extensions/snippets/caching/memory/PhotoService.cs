using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace CachingExamples.Memory
{
    public sealed class PhotoService
    {
        private readonly IMemoryCache _cache;
        private readonly PhotoCacheSignal _cacheSignal;
        private readonly ILogger<PhotoService> _logger;

        public PhotoService(
            IMemoryCache cache,
            PhotoCacheSignal cacheSignal,
            ILogger<PhotoService> logger) =>
            (_cache, _cacheSignal, _logger) = (cache, cacheSignal, logger);

        public async IAsyncEnumerable<Photo> GetPhotosAsync(Func<Photo, bool> filter)
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
                _cacheSignal.Reset(true);
            }
        }
    }
}
