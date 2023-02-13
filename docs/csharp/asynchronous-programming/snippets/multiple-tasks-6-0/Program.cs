using System.Diagnostics;

HttpClient s_client = new()
{
    MaxResponseContentBufferSize = 1_000_000
};

IEnumerable<string> s_urlList = new string[]
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

await SumPageSizesAsync();

async Task SumPageSizesAsync()
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

    Console.WriteLine($"\nTotal bytes returned:    {total:#,#}");
    Console.WriteLine($"Elapsed time:              {stopwatch.Elapsed}\n");
}

static async Task<int> ProcessUrlAsync(string url, HttpClient client)
{
    byte[] content = await client.GetByteArrayAsync(url);
    Console.WriteLine($"{url,-60} {content.Length,10:#,#}");

    return content.Length;
}

// Example output:
// https://docs.microsoft.com                                      132,517
// https://docs.microsoft.com/powershell                            57,375
// https://docs.microsoft.com/gaming                                33,549
// https://docs.microsoft.com/aspnet/core                           88,714
// https://docs.microsoft.com/surface                               39,840
// https://docs.microsoft.com/enterprise-mobility-security          30,903
// https://docs.microsoft.com/microsoft-365                         67,867
// https://docs.microsoft.com/windows                               26,816
// https://docs.microsoft.com/xamarin                               57,958
// https://docs.microsoft.com/dotnet                                78,706
// https://docs.microsoft.com/graph                                 48,277
// https://docs.microsoft.com/dynamics365                           49,042
// https://docs.microsoft.com/office                                67,867
// https://docs.microsoft.com/system-center                         42,887
// https://docs.microsoft.com/education                             38,636
// https://docs.microsoft.com/azure                                421,663
// https://docs.microsoft.com/visualstudio                          30,925
// https://docs.microsoft.com/sql                                   54,608
// https://docs.microsoft.com/azure/devops                          86,034

// Total bytes returned:    1,454,184
// Elapsed time:            00:00:01.1290403
