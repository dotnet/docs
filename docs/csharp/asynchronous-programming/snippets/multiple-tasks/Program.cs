using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProcessTasksAsTheyFinish
{
    class Program
    {
        static readonly HttpClient s_client = new HttpClient
        {
            MaxResponseContentBufferSize = 1_000_000
        };

        static readonly IEnumerable<string> s_urlList = new string[]
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
}
// Example output:
// https://learn.microsoft.com/windows                               25,513
// https://learn.microsoft.com/gaming                                30,705
// https://learn.microsoft.com/dotnet                                69,626
// https://learn.microsoft.com/dynamics365                           50,756
// https://learn.microsoft.com/surface                               35,519
// https://learn.microsoft.com                                       39,531
// https://learn.microsoft.com/azure/devops                          75,837
// https://learn.microsoft.com/xamarin                               60,284
// https://learn.microsoft.com/system-center                         43,444
// https://learn.microsoft.com/enterprise-mobility-security          28,946
// https://learn.microsoft.com/microsoft-365                         43,278
// https://learn.microsoft.com/visualstudio                          31,414
// https://learn.microsoft.com/office                                42,292
// https://learn.microsoft.com/azure                                401,113
// https://learn.microsoft.com/graph                                 46,831
// https://learn.microsoft.com/education                             25,098
// https://learn.microsoft.com/powershell                            58,173
// https://learn.microsoft.com/aspnet/core                           87,763
// https://learn.microsoft.com/sql                                   53,362

// Total bytes returned: 1,249,485
// Elapsed time:          00:00:02.7068725
