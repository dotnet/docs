using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

public static class DownloadCache
{
    private static readonly ConcurrentDictionary<string, string> s_cachedDownloads = new();
    private static readonly HttpClient s_httpClient = new();

    public static Task<string> DownloadStringAsync(string address)
    {
        if (s_cachedDownloads.TryGetValue(address, out string content))
        {
            return Task.FromResult(content);
        }

        return Task.Run(async () =>
        {
            content = await s_httpClient.GetStringAsync(address);
            s_cachedDownloads.TryAdd(address, content);

            return content;
        });
    }

    public static async Task Main()
    {
        string[] urls = new[]
        {
            "https://docs.microsoft.com/aspnet/core",
            "https://docs.microsoft.com/dotnet",
            "https://docs.microsoft.com/dotnet/architecture/dapr-for-net-developers",
            "https://docs.microsoft.com/dotnet/azure",
            "https://docs.microsoft.com/dotnet/desktop/wpf",
            "https://docs.microsoft.com/dotnet/devops/create-dotnet-github-action",
            "https://docs.microsoft.com/dotnet/machine-learning",
            "https://docs.microsoft.com/xamarin",
            "https://dotnet.microsoft.com/",
            "https://www.microsoft.com"
        };

        Stopwatch stopwatch = Stopwatch.StartNew();
        IEnumerable<Task<string>> downloads = urls.Select(DownloadStringAsync);

        static void StopAndLogElapsedTime(
            int attemptNumber, Stopwatch stopwatch, Task<string[]> downloadTasks)
        {
            stopwatch.Stop();

            int charCount = downloadTasks.Result.Sum(result => result.Length);
            long elapsedMs = stopwatch.ElapsedMilliseconds;

            Console.WriteLine(
                $"Attempt number: {attemptNumber}\n" +
                $"Retrieved characters: {charCount:#,0}\n" +
                $"Elapsed retrieval time: {elapsedMs:#,0} milliseconds.\n");
        }

        await Task.WhenAll(downloads).ContinueWith(
            downloadTasks => StopAndLogElapsedTime(1, stopwatch, downloadTasks));

        // Perform the same operation a second time. The time required
        // should be shorter because the results are held in the cache.
        stopwatch.Restart();

        downloads = urls.Select(DownloadStringAsync);

        await Task.WhenAll(downloads).ContinueWith(
            downloadTasks => StopAndLogElapsedTime(2, stopwatch, downloadTasks));
    }
    // Sample output:
    //     Attempt number: 1
    //     Retrieved characters: 754,585
    //     Elapsed retrieval time: 2,857 milliseconds.

    //     Attempt number: 2
    //     Retrieved characters: 754,585
    //     Elapsed retrieval time: 1 milliseconds.
}
