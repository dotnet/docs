using System.Diagnostics;

HttpClient s_client = new()
{
    MaxResponseContentBufferSize = 1_000_000
};

IEnumerable<string> s_urlList = new string[]
{
    "https://learn.microsoft.com",
    "https://learn.microsoft.com/aspnet/core",
    "https://learn.microsoft.com/azure",
    "https://learn.microsoft.com/azure/devops",
    "https://learn.microsoft.com/dotnet",
    "https://learn.microsoft.com/dynamics365",
    "https://learn.microsoft.com/education",
    "https://learn.microsoft.com/enterprise-mobility-security",
    "https://learn.microsoft.com/gaming",
    "https://learn.microsoft.com/graph",
    "https://learn.microsoft.com/microsoft-365",
    "https://learn.microsoft.com/office",
    "https://learn.microsoft.com/powershell",
    "https://learn.microsoft.com/sql",
    "https://learn.microsoft.com/surface",
    "https://learn.microsoft.com/system-center",
    "https://learn.microsoft.com/visualstudio",
    "https://learn.microsoft.com/windows",
    "https://learn.microsoft.com/xamarin"
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
// https://learn.microsoft.com                                      132,517
// https://learn.microsoft.com/powershell                            57,375
// https://learn.microsoft.com/gaming                                33,549
// https://learn.microsoft.com/aspnet/core                           88,714
// https://learn.microsoft.com/surface                               39,840
// https://learn.microsoft.com/enterprise-mobility-security          30,903
// https://learn.microsoft.com/microsoft-365                         67,867
// https://learn.microsoft.com/windows                               26,816
// https://learn.microsoft.com/xamarin                               57,958
// https://learn.microsoft.com/dotnet                                78,706
// https://learn.microsoft.com/graph                                 48,277
// https://learn.microsoft.com/dynamics365                           49,042
// https://learn.microsoft.com/office                                67,867
// https://learn.microsoft.com/system-center                         42,887
// https://learn.microsoft.com/education                             38,636
// https://learn.microsoft.com/azure                                421,663
// https://learn.microsoft.com/visualstudio                          30,925
// https://learn.microsoft.com/sql                                   54,608
// https://learn.microsoft.com/azure/devops                          86,034

// Total bytes returned:    1,454,184
// Elapsed time:            00:00:01.1290403
