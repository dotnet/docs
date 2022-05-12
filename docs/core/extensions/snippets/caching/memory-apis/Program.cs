using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => services.AddMemoryCache())
    .Build();

IMemoryCache cache =
    host.Services.GetRequiredService<IMemoryCache>();

const int MillisecondsDelayAfterAdd = 50;
const int MillisecondsAbsoluteExpiration = 750;

static void OnPostEviction(
    object key, object letter, EvictionReason reason, object state)
{
    if (letter is AlphabetLetter alphabetLetter)
    {
        Console.WriteLine($"{alphabetLetter.Letter} was evicted for {reason}.");
    }
};

static async ValueTask IterateAlphabetAsync(
    Func<char, Task> asyncFunc)
{
    for (char letter = 'A'; letter <= 'Z'; ++ letter)
    {
        await asyncFunc(letter);
    }

    Console.WriteLine();
}

var addLettersToCacheTask = IterateAlphabetAsync(letter =>
{
    MemoryCacheEntryOptions options = new()
    {
        AbsoluteExpirationRelativeToNow =
            TimeSpan.FromMilliseconds(MillisecondsAbsoluteExpiration)
    };

    _ = options.RegisterPostEvictionCallback(OnPostEviction);

    AlphabetLetter alphabetLetter =
        cache.Set(
            letter, new AlphabetLetter(letter), options);

    Console.WriteLine($"{alphabetLetter.Letter} was cached.");

    return Task.Delay(
        TimeSpan.FromMilliseconds(MillisecondsDelayAfterAdd));
});
await addLettersToCacheTask;

var readLettersFromCacheTask = IterateAlphabetAsync(letter =>
{
    if (cache.TryGetValue(letter, out object? value) &&
        value is AlphabetLetter alphabetLetter)
    {
        Console.WriteLine($"{letter} is still in cache. {alphabetLetter.Message}");
    }

    return Task.CompletedTask;
});
await readLettersFromCacheTask;

await host.RunAsync();

record AlphabetLetter(char Letter)
{
    internal string Message =>
        $"The '{Letter}' character is the {Letter - 64} letter in the English alphabet.";
}
