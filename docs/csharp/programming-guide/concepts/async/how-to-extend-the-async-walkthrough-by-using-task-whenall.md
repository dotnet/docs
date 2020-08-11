---
title: "How to extend the async walkthrough by using Task.WhenAll (C#)"
description: Learn how to improve performance of the async solution in C# by using Task.WhenAll. This method asynchronously awaits multiple asynchronous operations.
ms.date: 08/11/2020
ms.assetid: f6927ef2-dc6c-43f8-bc82-bbeac42de423
---

# Extend the async tutorial using Task.WhenAll (C#)

You can improve the performance of the async solution in [Tutorial: Access the web with async and await (C#)](walkthrough-accessing-the-web-by-using-async-and-await.md) by using the <xref:System.Threading.Tasks.Task.WhenAll%2A?displayProperty=nameWithType> method. This method asynchronously awaits multiple asynchronous operations, which are represented as a collection of tasks.

You might have noticed in the tutorial that the websites download at different rates. Sometimes one of the websites is slow, which delays all the remaining downloads. When you run the asynchronous solutions that you build in the walkthrough, you can end the program easily if you don't want to wait, but a better option would be to start all the downloads at the same time and let faster downloads continue without waiting for the one that's delayed.

You apply the `Task.WhenAll` method to a collection of tasks. The application of `WhenAll` returns a single task that isn't complete until every task in the collection is completed. The tasks appear to run in parallel, but no additional threads are created. The tasks can complete in any order.

> [!IMPORTANT]
> The following procedures describe extensions to the async applications that are developed in [Tutorial: Access the web with async and await (C#)](walkthrough-accessing-the-web-by-using-async-and-await.md). You can develop the applications by either completing the tutorial or downloading the code from [Code samples browser](https://docs.microsoft.com/samples/dotnet/samples/async-and-await-cs).
>
> To run the example, you must have Visual Studio 2019 or later installed on your computer.

## Update the DisplayResults method

Open the *MainWindow.xaml.cs* file, and navigate to the `DisplayResults` method. If you downloaded the code from [Code samples browser](https://docs.microsoft.com/samples/dotnet/samples/async-and-await-cs), open the *SerialAsyncExample* project.

The `DisplayResults` method used string concatenation to append the `url` and the corresponding download size as an interpolated string to the `_resultsTextBox.Text`. Apply the following updates.

- Change the method return type to <xref:System.Threading.Tasks.Task>.
- Wrap the expression-bodied member in a <xref:System.Windows.Threading.Dispatcher.BeginInvoke%2A?displayProperty=nameWithType>.
- The `BeginInvoke` method returns a <xref:System.Windows.Threading.DispatcherOperation?displayProperty=nameWithType>, you need to access the <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> that represents the operation.
- Apply the "Async" suffix to the `DisplayResults` method.

```csharp
Task DisplayResultsAsync(string url, byte[] content) =>
    Dispatcher.BeginInvoke(() =>
        _resultsTextBox.Text += $"{url,-60} {content.Length,10:#,#}\n")
                .Task;
```

The use of `Dispatcher` is required to ensure that all UI updates are correctly dispatched to the UI thread. Later, you use  that queues work on the thread pool.

## Update the ProcessUrlAsync method

The `ProcessUrlAsync` method is updated to call the task-returning `DisplayResultsAsync` method. Be sure to `await` the call.

```csharp
async Task<int> ProcessUrlAsync(string url, HttpClient client)
{
    byte[] byteArray = await client.GetByteArrayAsync(url);
    await DisplayResultsAsync(url, byteArray);

    return byteArray.Length;
}
```

## Update the _urlList field

This tutorial exemplifies downloading website content in parallel, the app will be capable of processing many more URLs than before, in less time. Replace the existing `_urlList` field with the following:

```csharp
readonly IEnumerable<string> _urlList = new string[]
{
    "https://docs.microsoft.com",
    "https://docs.microsoft.com/azure",
    "https://docs.microsoft.com/powershell",
    "https://docs.microsoft.com/dotnet",
    "https://docs.microsoft.com/aspnet/core",
    "https://docs.microsoft.com/windows",
    "https://docs.microsoft.com/office",
    "https://docs.microsoft.com/enterprise-mobility-security",
    "https://docs.microsoft.com/visualstudio",
    "https://docs.microsoft.com/microsoft-365",
    "https://docs.microsoft.com/sql",
    "https://docs.microsoft.com/dynamics365",
    "https://docs.microsoft.com/surface",
    "https://docs.microsoft.com/xamarin",
    "https://docs.microsoft.com/azure/devops",
    "https://docs.microsoft.com/system-center",
    "https://docs.microsoft.com/graph",
    "https://docs.microsoft.com/education",
    "https://docs.microsoft.com/gaming",
};
```

## Create a StartSumPageSizesAsync method

Add the following code under the `OnStartButtonClick` event handler. The method will await the invocation to `SumPageSizesAsync`, and when it's completed the method will use the `MainWindow.Dispatcher` instance to update the results textbox and re-enable the start button on the UI thread.

```csharp
async Task StartSumPageSizesAsync()
{
    await SumPageSizesAsync();
    await Dispatcher.BeginInvoke(() =>
    {
        _resultsTextBox.Text += $"\nControl returned to {nameof(OnStartButtonClick)}.";
        _startButton.IsEnabled = true;
    });
}
```

## Update the OnStartButtonClick event handler

The `OnStartButtonClick` event handler needs to be updated to call `Task.Run`. The event handler fires, and run synchronously. Disable the start button, and clear the previous results text.

- Remove the `async` keyword from the event handler, it's no longer needed.
- Add `Task.Run(StartSumPageSizesAsync)`.

The event handler should resemble the following code:

```csharp
void OnStartButtonClick(object sender, RoutedEventArgs e)
{
    _startButton.IsEnabled = false;
    _resultsTextBox.Clear();

    Task.Run(StartSumPageSizesAsync);
}
```

## Add Task.WhenAll to the solution

Navigate to the `SumPageSizesAsync` method.

1. Comment out or delete the `foreach` (or `For Each` in Visual Basic) loop in `SumPageSizesAsync`, as the following code shows.

    ```csharp
    //int total = 0;
    //foreach (string url in _urlList)
    //{
    //    int contentLength = await ProcessUrlAsync(url, _client);
    //    total += contentLength;
    //}
    ```

1. Define a [query](../linq/index.md) that, when executed by the <xref:System.Linq.Enumerable.ToArray%2A> method, creates a collection of tasks that download the contents of each website. The tasks are started when the query is evaluated.

    Add the following code to the `SumPageSizesAsync` method after the instantiation of `stopwatch` and the call to <xref:System.Diagnostics.Stopwatch.Start?displayProperty=nameWithType>.

    ```csharp
    IEnumerable<Task<int>> downloadTasksQuery =
        from url in _urlList
        select ProcessURLAsync(url, _client);

    Task<int>[] downloadTasks = downloadTasksQuery.ToArray();
    ```

    Calling <xref:System.Linq.Enumerable.ToArray%2A> is used to start the download tasks.

1. Next, apply <xref:System.Threading.Tasks.Task.WhenAll%2A?displayProperty=nameWithType> to the collection of tasks, `downloadTasks`. `Task.WhenAll` returns a single task that finishes when all the tasks in the collection of tasks have completed.

    In the following example, the `await` expression awaits the completion of the single task that `Task.WhenAll` returns. When complete, the `await` expression evaluates to an array of integers, where each integer is the length of a downloaded website. Add the following code to `SumPageSizesAsync`, just after the code that you added in the previous step.

    ```csharp
    int[] lengths = await Task.WhenAll(downloadTasks);
    ```

1. Use the <xref:System.Linq.Enumerable.Sum%2A> method to get the sum of the lengths of all the websites. Add the following line to `SumPageSizesAsync`.

    ```csharp
    int total = lengths.Sum();
    ```

1. Finally, wrap the updates to the results textbox and the call to <xref:System.Diagnostics.Stopwatch.Stop?displayProperty=nameWithType> in the <xref:System.Windows.Threading.Dispatcher.BeginInvoke%2A?displayProperty=nameWithType>. Be sure to `await` the call.

```csharp
await Dispatcher.BeginInvoke(() =>
{
    stopwatch.Stop();

    _resultsTextBox.Text += $"\nTotal bytes returned:  {total:#,#}";
    _resultsTextBox.Text += $"\nElapsed time:          {stopwatch.Elapsed}\n";
});
```

The updated version of the `SumPageSizesAsync` method should be as follows:

```csharp
async Task SumPageSizesAsync()
{
    var stopwatch = new Stopwatch();
    stopwatch.Start();

    IEnumerable<Task<int>> downloadTasksQuery =
        from url in _urlList
        select ProcessURLAsync(url, _client);

    Task<int>[] downloadTasks = downloadTasksQuery.ToArray();

    int[] lengths = await Task.WhenAll(downloadTasks);
    int total = lengths.Sum();

    await Dispatcher.BeginInvoke(() =>
    {
        stopwatch.Stop();

        _resultsTextBox.Text += $"\nTotal bytes returned:  {total:#,#}";
        _resultsTextBox.Text += $"\nElapsed time:          {stopwatch.Elapsed}\n";
    });
}
```

## Test the Task.WhenAll solutions

Select the <kbd>F5</kbd> key to run the program, and then select the **Start** button. The output should resemble the following output:

```text
https://docs.microsoft.com                                       39,530
https://docs.microsoft.com/powershell                            58,131
https://docs.microsoft.com/azure                                401,071
https://docs.microsoft.com/windows                               25,471
https://docs.microsoft.com/enterprise-mobility-security          28,904
https://docs.microsoft.com/dotnet                                69,584
https://docs.microsoft.com/visualstudio                          31,372
https://docs.microsoft.com/office                                42,250
https://docs.microsoft.com/aspnet/core                           87,662
https://docs.microsoft.com/microsoft-365                         43,236
https://docs.microsoft.com/surface                               33,055
https://docs.microsoft.com/sql                                   53,384
https://docs.microsoft.com/dynamics365                           50,714
https://docs.microsoft.com/xamarin                               60,242
https://docs.microsoft.com/azure/devops                          75,795
https://docs.microsoft.com/system-center                         43,402
https://docs.microsoft.com/graph                                 46,789
https://docs.microsoft.com/education                             25,056
https://docs.microsoft.com/gaming                                30,704

Total bytes returned:  1,246,352
Elapsed time:          00:00:01.2316864

Control returned to OnStartButtonClick.
```

The order in which the download tasks occur is *not* important in this application, thus the tasks can run in parallel. Notice that the websites appear in a different order each time. Also, the elapsed time is faster. This is due to the fact that all fo the download tasks are running in parallel with `Task.WhenAll`.

## Final source code

The following code shows the extensions to the project to download content from the web.

```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ParallelAsyncExample
{
    public partial class MainWindow : Window
    {
        readonly HttpClient _client = new HttpClient { MaxResponseContentBufferSize = 1_000_000 };

        readonly IEnumerable<string> _urlList = new string[]
        {
            "https://docs.microsoft.com",
            "https://docs.microsoft.com/azure",
            "https://docs.microsoft.com/powershell",
            "https://docs.microsoft.com/dotnet",
            "https://docs.microsoft.com/aspnet/core",
            "https://docs.microsoft.com/windows",
            "https://docs.microsoft.com/office",
            "https://docs.microsoft.com/enterprise-mobility-security",
            "https://docs.microsoft.com/visualstudio",
            "https://docs.microsoft.com/microsoft-365",
            "https://docs.microsoft.com/sql",
            "https://docs.microsoft.com/dynamics365",
            "https://docs.microsoft.com/surface",
            "https://docs.microsoft.com/xamarin",
            "https://docs.microsoft.com/azure/devops",
            "https://docs.microsoft.com/system-center",
            "https://docs.microsoft.com/graph",
            "https://docs.microsoft.com/education",
            "https://docs.microsoft.com/gaming",
        };

        void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            _startButton.IsEnabled = false;
            _resultsTextBox.Clear();

            Task.Run(StartSumPageSizesAsync);
        }

        async Task StartSumPageSizesAsync()
        {
            await SumPageSizesAsync();
            await Dispatcher.BeginInvoke(() =>
            {
                _resultsTextBox.Text += $"\nControl returned to {nameof(OnStartButtonClick)}.";
                _startButton.IsEnabled = true;
            });
        }

        async Task SumPageSizesAsync()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            IEnumerable<Task<int>> downloadTasksQuery =
                from url in _urlList
                select ProcessUrlAsync(url, _client);

            Task<int>[] downloadTasks = downloadTasksQuery.ToArray();

            int[] lengths = await Task.WhenAll(downloadTasks);
            int total = lengths.Sum();

            await Dispatcher.BeginInvoke(() =>
            {
                stopwatch.Stop();

                _resultsTextBox.Text += $"\nTotal bytes returned:  {total:#,#}";
                _resultsTextBox.Text += $"\nElapsed time:          {stopwatch.Elapsed}\n";
            });
        }

        async Task<int> ProcessUrlAsync(string url, HttpClient client)
        {
            byte[] byteArray = await client.GetByteArrayAsync(url);
            await DisplayResultsAsync(url, byteArray);

            return byteArray.Length;
        }

        Task DisplayResultsAsync(string url, byte[] content) =>
            Dispatcher.BeginInvoke(() =>
                _resultsTextBox.Text += $"{url,-60} {content.Length,10:#,#}\n")
                      .Task;
    }
}
```

## See also

- <xref:System.Threading.Tasks.Task.WhenAll%2A?displayProperty=nameWithType>
- [Tutorial: Access the web with async and await (C#)](walkthrough-accessing-the-web-by-using-async-and-await.md)
- [Code samples browser: async (C#)](https://docs.microsoft.com/samples/browse/?terms=async&languages=csharp)
