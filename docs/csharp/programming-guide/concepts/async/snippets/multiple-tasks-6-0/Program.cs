using System.Diagnostics;

namespace ProcessTasksAsTheyFinish;

class Program
{
    static readonly HttpClient s_client = new HttpClient
    {
        MaxResponseContentBufferSize = 1_000_000
    };

    static readonly IEnumerable<string> s_urlList = new string[]
    {
            "https://docs.microsoft.com",
            "https://docs.microsoft.com/aspnet/core",
            "https://docs.microsoft.com/azure",
            "https://docs.microsoft.com/azure/devops",
            "https://docs.microsoft.com/dotnet",
            "https://docs.microsoft.com/dynamics365",
            "https://docs.microsoft.com/education",
            "https://docs.microsoft.com/enterprise-mobility-security",
            "https://docs.microsoft.com/gaming",
            "https://docs.microsoft.com/graph",
            "https://docs.microsoft.com/microsoft-365",
            "https://docs.microsoft.com/office",
            "https://docs.microsoft.com/powershell",
            "https://docs.microsoft.com/sql",
            "https://docs.microsoft.com/surface",
            "https://docs.microsoft.com/system-center",
            "https://docs.microsoft.com/visualstudio",
            "https://docs.microsoft.com/windows",
            "https://docs.microsoft.com/xamarin"
    };

    static Task Main() => SumPageSizesAsync();

    static async Task SumPageSizesAsync()
    {
        var stopwatch = Stopwatch.StartNew();

        IEnumerable<Task<int>> downloadTasksQuery =
            from url in s_urlList
            select ProcessUrlAsync(url, s_client);

        List<Task<int>> downloadTasks = downloadTasksQuery.ToList();

        int total = 0;
        while (downloadTasks.Any())
        {
            Task<int> finishedTask = await Task.WhenAny(downloadTasks);
            downloadTasks.Remove(finishedTask);
            total += await finishedTask;
        }

        stopwatch.Stop();

        Console.WriteLine($"\nTotal bytes returned:  {total:#,#}");
        Console.WriteLine($"Elapsed time:          {stopwatch.Elapsed}\n");
    }

    static async Task<int> ProcessUrlAsync(string url, HttpClient client)
    {
        byte[] content = await client.GetByteArrayAsync(url);
        Console.WriteLine($"{url,-60} {content.Length,10:#,#}");

        return content.Length;
    }
}

// Example output:
// https://docs.microsoft.com/windows                               25,513
// https://docs.microsoft.com/gaming                                30,705
// https://docs.microsoft.com/dotnet                                69,626
// https://docs.microsoft.com/dynamics365                           50,756
// https://docs.microsoft.com/surface                               35,519
// https://docs.microsoft.com                                       39,531
// https://docs.microsoft.com/azure/devops                          75,837
// https://docs.microsoft.com/xamarin                               60,284
// https://docs.microsoft.com/system-center                         43,444
// https://docs.microsoft.com/enterprise-mobility-security          28,946
// https://docs.microsoft.com/microsoft-365                         43,278
// https://docs.microsoft.com/visualstudio                          31,414
// https://docs.microsoft.com/office                                42,292
// https://docs.microsoft.com/azure                                401,113
// https://docs.microsoft.com/graph                                 46,831
// https://docs.microsoft.com/education                             25,098
// https://docs.microsoft.com/powershell                            58,173
// https://docs.microsoft.com/aspnet/core                           87,763
// https://docs.microsoft.com/sql                                   53,362

// Total bytes returned: 1,249,485
// Elapsed time:          00:00:02.7068725
