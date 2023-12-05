---
title: Cancel a list of tasks
description: Learn how to use cancellation tokens to signal a cancellation request to a list of tasks.
ms.date: 02/09/2023
ms.topic: tutorial
---

# Cancel a list of tasks

You can cancel an async console application if you don't want to wait for it to finish. By following the example in this topic, you can add a cancellation to an application that downloads the contents of a list of websites. You can cancel many tasks by associating the <xref:System.Threading.CancellationTokenSource> instance with each task. If you select the <kbd>Enter</kbd> key, you cancel all tasks that aren't yet complete.

This tutorial covers:

> [!div class="checklist"]
>
> - Creating a .NET console application
> - Writing an async application that supports cancellation
> - Demonstrating signaling cancellation

## Prerequisites

This tutorial requires the following:

- [.NET 5 or later SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- Integrated development environment (IDE)
  - [We recommend Visual Studio or Visual Studio Code](https://visualstudio.microsoft.com)

### Create example application

Create a new .NET Core console application. You can create one by using the [`dotnet new console`](../../core/tools/dotnet-new-sdk-templates.md#console) command or from [Visual Studio](/visualstudio/install/install-visual-studio). Open the *Program.cs* file in your favorite code editor.

### Replace using statements

Replace the existing using statements with these declarations:

```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
```

## Add fields

In the `Program` class definition, add these three fields:

```csharp
static readonly CancellationTokenSource s_cts = new CancellationTokenSource();

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
```

The <xref:System.Threading.CancellationTokenSource> is used to signal a requested cancellation to a <xref:System.Threading.CancellationToken>. The `HttpClient` exposes the ability to send HTTP requests and receive HTTP responses. The `s_urlList` holds all of the URLs that the application plans to process.

## Update application entry point

The main entry point into the console application is the `Main` method. Replace the existing method with the following:

```csharp
static async Task Main()
{
    Console.WriteLine("Application started.");
    Console.WriteLine("Press the ENTER key to cancel...\n");

    Task cancelTask = Task.Run(() =>
    {
        while (Console.ReadKey().Key != ConsoleKey.Enter)
        {
            Console.WriteLine("Press the ENTER key to cancel...");
        }

        Console.WriteLine("\nENTER key pressed: cancelling downloads.\n");
        s_cts.Cancel();
    });
    
    Task sumPageSizesTask = SumPageSizesAsync();

    Task finishedTask = await Task.WhenAny(new[] { cancelTask, sumPageSizesTask });
    if (finishedTask == cancelTask)
    {
        // wait for the cancellation to take place:
        try
        {
            await sumPageSizesTask;
            Console.WriteLine("Download task completed before cancel request was processed.");
        }
        catch (TaskCanceledException)
        {
            Console.WriteLine("Download task has been cancelled.");
        }
    }
        
    Console.WriteLine("Application ending.");
}
```

The updated `Main` method is now considered an [Async main](../fundamentals/program-structure/main-command-line.md#async-main-return-values), which allows for an asynchronous entry point into the executable. It writes a few instructional messages to the console, then declares a <xref:System.Threading.Tasks.Task> instance named `cancelTask`, which will read console key strokes. If the <kbd>Enter</kbd> key is pressed, a call to <xref:System.Threading.CancellationTokenSource.Cancel?displayProperty=nameWithType> is made. This will signal cancellation. Next, the `sumPageSizesTask` variable is assigned from the `SumPageSizesAsync` method. Both tasks are then passed to <xref:System.Threading.Tasks.Task.WhenAny(System.Threading.Tasks.Task[])?displayProperty=nameWithType>, which will continue when any of the two tasks have completed.

The next block of code ensures that the application doesn't exit until the cancellation has been processed. If the first task to complete is the `cancelTask`, the `sumPageSizeTask` is awaited. If it was cancelled, when awaited it throws a <xref:System.Threading.Tasks.TaskCanceledException?displayProperty=nameWithType>. The block catches that exception, and prints a message.

## Create the asynchronous sum page sizes method

Below the `Main` method, add the `SumPageSizesAsync` method:

```csharp
static async Task SumPageSizesAsync()
{
    var stopwatch = Stopwatch.StartNew();

    int total = 0;
    foreach (string url in s_urlList)
    {
        int contentLength = await ProcessUrlAsync(url, s_client, s_cts.Token);
        total += contentLength;
    }

    stopwatch.Stop();

    Console.WriteLine($"\nTotal bytes returned:  {total:#,#}");
    Console.WriteLine($"Elapsed time:          {stopwatch.Elapsed}\n");
}
```

The method starts by instantiating and starting a <xref:System.Diagnostics.Stopwatch>. It then loops through each URL in the `s_urlList` and calls `ProcessUrlAsync`. With each iteration, the `s_cts.Token` is passed into the `ProcessUrlAsync` method and the code returns a <xref:System.Threading.Tasks.Task%601>, where `TResult` is an integer:

```csharp
int total = 0;
foreach (string url in s_urlList)
{
    int contentLength = await ProcessUrlAsync(url, s_client, s_cts.Token);
    total += contentLength;
}
```

## Add process method

Add the following `ProcessUrlAsync` method below the `SumPageSizesAsync` method:

```csharp
static async Task<int> ProcessUrlAsync(string url, HttpClient client, CancellationToken token)
{
    HttpResponseMessage response = await client.GetAsync(url, token);
    byte[] content = await response.Content.ReadAsByteArrayAsync(token);
    Console.WriteLine($"{url,-60} {content.Length,10:#,#}");

    return content.Length;
}
```

For any given URL, the method will use the `client` instance provided to get the response as a `byte[]`. The <xref:System.Threading.CancellationToken> instance is passed into the <xref:System.Net.Http.HttpClient.GetAsync(System.String,System.Threading.CancellationToken)?displayProperty=nameWithType> and <xref:System.Net.Http.HttpContent.ReadAsByteArrayAsync?displayProperty=nameWithType> methods. The `token` is used to register for requested cancellation. The length is returned after the URL and length is written to the console.

### Example application output

```console
Application started.
Press the ENTER key to cancel...

https://learn.microsoft.com                                       37,357
https://learn.microsoft.com/aspnet/core                           85,589
https://learn.microsoft.com/azure                                398,939
https://learn.microsoft.com/azure/devops                          73,663
https://learn.microsoft.com/dotnet                                67,452
https://learn.microsoft.com/dynamics365                           48,582
https://learn.microsoft.com/education                             22,924

ENTER key pressed: cancelling downloads.

Application ending.
```

## Complete example

The following code is the complete text of the *Program.cs* file for the example.

:::code language="csharp" source="snippets/cancel-tasks/Program.cs":::

## See also

- <xref:System.Threading.CancellationToken>
- <xref:System.Threading.CancellationTokenSource>
- [Asynchronous programming with async and await (C#)](index.md)

## Next steps

> [!div class="nextstepaction"]
> [Cancel async tasks after a period of time (C#)](cancel-async-tasks-after-a-period-of-time.md)
