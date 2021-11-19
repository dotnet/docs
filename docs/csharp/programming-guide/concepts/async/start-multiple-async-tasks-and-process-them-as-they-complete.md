---
title: Process asynchronous tasks as they complete
description: Learn how to use Task.WhenAny in C# to start multiple tasks and process their results as they finish, rather than process them in the order started.
ms.date: 10/27/2021
zone_pivot_groups: dotnet-version
ms.topic: tutorial
---

# Process asynchronous tasks as they complete (C#)

::: zone pivot="dotnet-6-0"

By using <xref:System.Threading.Tasks.Task.WhenAny%2A?displayProperty=nameWithType>, you can start multiple tasks at the same time and process them one by one as they're completed rather than process them in the order in which they're started.

The following example uses a query to create a collection of tasks. Each task downloads the contents of a specified website. In each iteration of a while loop, an awaited call to <xref:System.Threading.Tasks.Task.WhenAny%2A> returns the task in the collection of tasks that finishes its download first. That task is removed from the collection and processed. The loop repeats until the collection contains no more tasks.

## Prerequisites

You can follow this tutorial by using one of the following options:

* [Visual Studio 2022 version 17.0.0 Preview](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2022) with the **.NET desktop development** workload installed. The .NET 6.0 SDK is automatically installed when you select this workload.
* The [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) with a code editor of your choice, such as [Visual Studio Code](https://code.visualstudio.com/).

## Create example application

Create a new .NET Core console application that targets .NET 6.0. You can create one by using the [dotnet new console](../../../../core/tools/dotnet-new-sdk-templates.md#console) command or from Visual Studio.

Open the *Program.cs* file in your code editor, and replace the existing code with this code:

```csharp
using System.Diagnostics;

namespace ProcessTasksAsTheyFinish;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
    }
}
```

## Add fields

In the `Program` class definition, add the following two fields:

```csharp
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
```

The `HttpClient` exposes the ability to send HTTP requests and receive HTTP responses. The `s_urlList` holds all of the URLs that the application plans to process.

## Update application entry point

The main entry point into the console application is the `Main` method. Replace the existing method with the following:

```csharp
static Task Main() => SumPageSizesAsync();
```

The updated `Main` method is now considered an [Async main](../../../fundamentals/program-structure/main-command-line.md#async-main-return-values), which allows for an asynchronous entry point into the executable. It is expressed as a call to `SumPageSizesAsync`.

## Create the asynchronous sum page sizes method

Below the `Main` method, add the `SumPageSizesAsync` method:

```csharp
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
```

The method starts by instantiating and starting a <xref:System.Diagnostics.Stopwatch>. It then includes a query that, when executed, creates a collection of tasks. Each call to `ProcessUrlAsync` in the following code returns a <xref:System.Threading.Tasks.Task%601>, where `TResult` is an integer:

```csharp
IEnumerable<Task<int>> downloadTasksQuery =
    from url in s_urlList
    select ProcessUrlAsync(url, s_client);
```

Due to [deferred execution](../../../../standard/linq/deferred-execution-example.md) with the LINQ, you call <xref:System.Linq.Enumerable.ToList%2A?displayProperty=nameWithType> to start each task.

```csharp
List<Task<int>> downloadTasks = downloadTasksQuery.ToList();
```

The `while` loop performs the following steps for each task in the collection:

1. Awaits a call to `WhenAny` to identify the first task in the collection that has finished its download.

    ```csharp
    Task<int> finishedTask = await Task.WhenAny(downloadTasks);
    ```

1. Removes that task from the collection.

    ```csharp
    downloadTasks.Remove(finishedTask);
    ```

1. Awaits `finishedTask`, which is returned by a call to `ProcessUrlAsync`. The `finishedTask` variable is a <xref:System.Threading.Tasks.Task%601> where `TResult` is an integer. The task is already complete, but you await it to retrieve the length of the downloaded website, as the following example shows. If the task is faulted, `await` will throw the first child exception stored in the `AggregateException`, unlike reading the <xref:System.Threading.Tasks.Task%601.Result?displayProperty=nameWithType> property, which would throw the `AggregateException`.

    ```csharp
    total += await finishedTask;
    ```

## Add process method

Add the following `ProcessUrlAsync` method below the `SumPageSizesAsync` method:

```csharp
static async Task<int> ProcessUrlAsync(string url, HttpClient client)
{
    byte[] content = await client.GetByteArrayAsync(url);
    Console.WriteLine($"{url,-60} {content.Length,10:#,#}");

    return content.Length;
}
```

For any given URL, the method will use the `client` instance provided to get the response as a `byte[]`. The length is returned after the URL and length is written to the console.

Run the program several times to verify that the downloaded lengths don't always appear in the same order.

> [!CAUTION]
> You can use `WhenAny` in a loop, as described in the example, to solve problems that involve a small number of tasks. However, other approaches are more efficient if you have a large number of tasks to process. For more information and examples, see [Processing tasks as they complete](https://devblogs.microsoft.com/pfxteam/processing-tasks-as-they-complete).

## Complete example

The following code is the complete text of the *Program.cs* file for the example.

:::code language="csharp" source="snippets/multiple-tasks-6-0/Program.cs":::

## See also

- <xref:System.Threading.Tasks.Task.WhenAny%2A>
- [Asynchronous programming with async and await (C#)](index.md)

::: zone-end

::: zone pivot="dotnet-5-0,dotnet-core-3-1"

By using <xref:System.Threading.Tasks.Task.WhenAny%2A?displayProperty=nameWithType>, you can start multiple tasks at the same time and process them one by one as they're completed rather than process them in the order in which they're started.

The following example uses a query to create a collection of tasks. Each task downloads the contents of a specified website. In each iteration of a while loop, an awaited call to <xref:System.Threading.Tasks.Task.WhenAny%2A> returns the task in the collection of tasks that finishes its download first. That task is removed from the collection and processed. The loop repeats until the collection contains no more tasks.

## Prerequisites

You can follow this tutorial by using one of the following options:

* [Visual Studio](/visualstudio/install/install-visual-studio) with the **.NET desktop development** workload installed. The .NET SDK is automatically installed when you select this workload.
* The [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) with a code editor of your choice, such as [Visual Studio Code](https://code.visualstudio.com/).

## Create example application

Create a new .NET Core console application that targets .NET 5.0 or .NET Core 3.1. You can create one by using the [dotnet new console](../../../../core/tools/dotnet-new-sdk-templates.md#console) command or from Visual Studio. Open the *Program.cs* file in your favorite code editor.

### Replace using statements

Replace the existing using statements with these declarations:

```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
```

## Add fields

In the `Program` class definition, add the following two fields:

```csharp
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
```

The `HttpClient` exposes the ability to send HTTP requests and receive HTTP responses. The `s_urlList` holds all of the URLs that the application plans to process.

## Update application entry point

The main entry point into the console application is the `Main` method. Replace the existing method with the following:

```csharp
static Task Main() => SumPageSizesAsync();
```

The updated `Main` method is now considered an [Async main](../../../fundamentals/program-structure/main-command-line.md#async-main-return-values), which allows for an asynchronous entry point into the executable. It is expressed a call to `SumPageSizesAsync`.

## Create the asynchronous sum page sizes method

Below the `Main` method, add the `SumPageSizesAsync` method:

```csharp
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
```

The method starts by instantiating and starting a <xref:System.Diagnostics.Stopwatch>. It then includes a query that, when executed, creates a collection of tasks. Each call to `ProcessUrlAsync` in the following code returns a <xref:System.Threading.Tasks.Task%601>, where `TResult` is an integer:

```csharp
IEnumerable<Task<int>> downloadTasksQuery =
    from url in s_urlList
    select ProcessUrlAsync(url, s_client);
```

Due to [deferred execution](../../../../standard/linq/deferred-execution-example.md) with the LINQ, you call <xref:System.Linq.Enumerable.ToList%2A?displayProperty=nameWithType> to start each task.

```csharp
List<Task<int>> downloadTasks = downloadTasksQuery.ToList();
```

The `while` loop performs the following steps for each task in the collection:

1. Awaits a call to `WhenAny` to identify the first task in the collection that has finished its download.

    ```csharp
    Task<int> finishedTask = await Task.WhenAny(downloadTasks);
    ```

1. Removes that task from the collection.

    ```csharp
    downloadTasks.Remove(finishedTask);
    ```

1. Awaits `finishedTask`, which is returned by a call to `ProcessUrlAsync`. The `finishedTask` variable is a <xref:System.Threading.Tasks.Task%601> where `TResult` is an integer. The task is already complete, but you await it to retrieve the length of the downloaded website, as the following example shows. If the task is faulted, `await` will throw the first child exception stored in the `AggregateException`, unlike reading the <xref:System.Threading.Tasks.Task%601.Result?displayProperty=nameWithType> property, which would throw the `AggregateException`.

    ```csharp
    total += await finishedTask;
    ```

## Add process method

Add the following `ProcessUrlAsync` method below the `SumPageSizesAsync` method:

```csharp
static async Task<int> ProcessUrlAsync(string url, HttpClient client)
{
    byte[] content = await client.GetByteArrayAsync(url);
    Console.WriteLine($"{url,-60} {content.Length,10:#,#}");

    return content.Length;
}
```

For any given URL, the method will use the `client` instance provided to get the response as a `byte[]`. The length is returned after the URL and length is written to the console.

Run the program several times to verify that the downloaded lengths don't always appear in the same order.

> [!CAUTION]
> You can use `WhenAny` in a loop, as described in the example, to solve problems that involve a small number of tasks. However, other approaches are more efficient if you have a large number of tasks to process. For more information and examples, see [Processing tasks as they complete](https://devblogs.microsoft.com/pfxteam/processing-tasks-as-they-complete).

## Complete example

The following code is the complete text of the *Program.cs* file for the example.

:::code language="csharp" source="snippets/multiple-tasks/Program.cs":::

## See also

- <xref:System.Threading.Tasks.Task.WhenAny%2A>
- [Asynchronous programming with async and await (C#)](index.md)

::: zone-end
