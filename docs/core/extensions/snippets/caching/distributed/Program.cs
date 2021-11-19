using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        // The distributed memory cache is for dev / testing scenarios only!
        // Use an actual implementation of IDistributedCache such as:
        //
        // - https://www.nuget.org/packages/Microsoft.Extensions.Caching.StackExchangeRedis
        // - https://www.nuget.org/packages/Microsoft.Extensions.Caching.SqlServer
        //
        services.AddDistributedMemoryCache();
    })
    .Build();

IDistributedCache cache =
    host.Services.GetRequiredService<IDistributedCache>();

const int MillisecondsDelayAfterAdd = 50;
const int MillisecondsAbsoluteExpiration = 750;

static async ValueTask IterateAlphabetAsync(
    Func<char, Task> asyncFunc)
{
    for (char letter = 'A'; letter <= 'Z'; ++letter)
    {
        await asyncFunc(letter);
    }

    Console.WriteLine();
}

await IterateAlphabetAsync(async letter =>
{
    // <Create>
    DistributedCacheEntryOptions options = new()
    {
        AbsoluteExpirationRelativeToNow =
            TimeSpan.FromMilliseconds(MillisecondsAbsoluteExpiration)
    };

    AlphabetLetter alphabetLetter = new(letter);
    string json = JsonSerializer.Serialize(alphabetLetter);
    byte[] bytes = Encoding.UTF8.GetBytes(json);

    await cache.SetAsync(letter.ToString(), bytes, options);
    // </Create>

    Console.WriteLine($"{alphabetLetter.Letter} was cached.");

    await Task.Delay(
        TimeSpan.FromMilliseconds(MillisecondsDelayAfterAdd));
});

await IterateAlphabetAsync(async letter =>
{
    // <Read>
    AlphabetLetter? alphabetLetter = null;
    byte[]? bytes = await cache.GetAsync(letter.ToString());
    if (bytes is { Length: > 0 })
    {
        string json = Encoding.UTF8.GetString(bytes);
        alphabetLetter = JsonSerializer.Deserialize<AlphabetLetter>(json);
    }
    // </Read>

    if (alphabetLetter is not null)
    {
        Console.WriteLine($"{letter} is still in cache. {alphabetLetter.Message}");
    }
    else
    {
        Console.WriteLine($"{letter} was evicted from the cache.");
    }
});

await IterateAlphabetAsync(async letter =>
{
    await cache.RefreshAsync(letter.ToString());

    Console.WriteLine($"{letter} was refreshed in the cache.");
});

await IterateAlphabetAsync(async letter =>
{
    await cache.RemoveAsync(letter.ToString());

    Console.WriteLine($"{letter} was removed from the cache.");
});

await host.RunAsync();

record AlphabetLetter(char Letter)
{
    internal string Message =>
        $"The '{Letter}' character is the {Letter - 64} letter in the English alphabet.";
}
