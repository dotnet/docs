---
title: "Tutorial: Access the web with async and await (C#)"
description: This tutorial converts a synchronous application into an asynchronous solution in C# that uses the async and await features.
ms.topic: tutorial
ms.date: 08/11/2020
ms.assetid: c95d8d71-5a98-4bf0-aaf4-45fed2ebbacd
---

# Tutorial: Access the web with async and await (C#)

You can write asynchronous programs more easily and intuitively by using async/await features. You can write asynchronous code that looks like synchronous code and let the compiler handle the difficult callback functions and continuations that asynchronous code usually entails.

For more information about async feature, see [Asynchronous programming with async and await (C#)](index.md).

This tutorial starts with a synchronous Windows Presentation Foundation (WPF) application that sums the number of bytes in a list of websites. The walkthrough then converts the application to an asynchronous solution by using the async features.

If you don't want to build the applications yourself, you can download [Async Sample: Asynchronous programming with async and await in C#](https://docs.microsoft.com/samples/dotnet/samples/async-and-await-cs).

> [!NOTE]
> To run the examples, you must have Visual Studio 2019 (v16.7.0) or newer and the .NET 5.0 or newer installed on your computer.

## Create a WPF application

1. Launch Visual Studio 2019 (v16.7.0) or newer.
1. From the **Get started** pane, select **Create a new project**.
     The **New Project** dialog box opens.
1. Filter to: **C#**, **Windows**, and **Desktop**.
1. Select **WPF App (.NET Core)**.
1. In the **Project name** text box, enter `AsyncExampleWPF`, and then select the **Create** button.
     The new project appears in **Solution Explorer**.

## Design the MainWindow

1. In Visual Studio, select the **MainWindow.xaml** tab.
1. Set the following values on the `Window` element:
    - Set the **Height** property to `400`.
    - Set the **Width** property to `600`.
    - Set the **MinHeight** property to `300`.
    - Set the **MinWidth** property to `500`.
1. If the **Toolbox** window isn't visible, open the **View** menu, and then choose **Toolbox**.
1. Add a **Button** control and a **TextBox** control to the **MainWindow** window.
1. Highlight the **Button** control and, in the **Properties** window, set the following values:
    - Set the **Name** property to `_startButton`.
    - Set the **TextWrapping** property to `Wrap`.
    - Set the **VerticalAlignment** property to `Top`.
    - Set the **HorizontalAlignment** property to `Center`.
    - Set the **Height** property to `24`.
    - Set the **Width** property to `75`.
    - Set the **Margin** property to `0,10,0,0`.
    - Change the value of the **Content** property from **Button** to `Start`.
1. Highlight the **TextBox** control and, in the **Properties** window, set the following values:
    - Set the **Name** property to `_resultsTextBox`.
    - Set the **TextWrapping** property to `Wrap`.
    - Set the **VerticalScrollBarVisibility** property to `Visible`.
    - Set the **Margin** property to `0,45,0,0`.
    - On the **Text** tab, specify a monospaced font, such as `Consolas` for the **FontFamily**.
1. Position the text box and the button so that both appear in the **MainWindow** window.
     For more information about the WPF XAML Designer, see [Creating a UI by using XAML Designer](/visualstudio/xaml-tools/creating-a-ui-by-using-xaml-designer-in-visual-studio).

The resulting XAML should resemble the following:

```xaml
<Window x:Class="AsyncFirstExample.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Async Example" Height="400" Width="600" MinHeight="300" MinWidth="500">
    <Grid>
        <Button x:Name="_startButton" Content="Start" HorizontalAlignment="Center"
                Margin="0,10,0,0" VerticalAlignment="Top" Width="75" Height="24" />
        <TextBox x:Name="_resultsTextBox" TextWrapping="Wrap"
                 FontFamily="Consolas" VerticalScrollBarVisibility="Visible"
                 Margin="0,45,0,0" />
    </Grid>
</Window>
```

> [!NOTE]
> Your `x:Class` name may be different, but should match your corresponding *MainWindow.xaml.cs* file class name.

## Add necessary using directives

1. In the **Solution Explorer**, open the shortcut menu for *MainWindow.xaml.cs*, and then choose **View Code**.
1. Replace all of the `using` directives at the top of the code file with the following:

    ```csharp
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Windows;
    ```

## Create a synchronous app

1. In the design window, *MainWindow.xaml*, double-click the **Start** button to create the click event handler in *MainWindow.xaml.cs*.
1. Select the <kbd>F2</kbd> key to rename the handler to `OnStartButtonClick`.
1. In *MainWindow.xaml.cs*, copy the following code into the body of `OnStartButtonClick`:

    ```csharp
    _resultsTextBox.Clear();

    SumPageSizes();

    _resultsTextBox.Text += $"\nControl returned to {nameof(OnStartButtonClick)}.";
    ```

    The code calls the method that drives the application, `SumPageSizes`, and displays a message when control returns to `OnStartButtonClick`.

1. The code for the synchronous solution contains the following members:

    - `_urlList`, a read-only field that represents a list of web addresses.
    - `SumPageSizes`, which gets a list of webpage URLs from the `_urlList` field and then calls `ProcessUrl` and `DisplayResults` to process each URL.
    - `ProcessUrl`, which downloads the contents of each URL and returns the contents as a byte array.
    - `DisplayResults`, which displays the number of bytes in the byte array for each URL.

    Copy the following code, and paste it above the `OnStartButtonClick` event handler in *MainWindow.xaml.cs*:

    ```csharp
    readonly IEnumerable<string> _urlList = new string[]
    {
        "https://docs.microsoft.com",
        "https://docs.microsoft.com/azure",
        "https://docs.microsoft.com/powershell",
        "https://docs.microsoft.com/dotnet",
        "https://docs.microsoft.com/aspnet/core",
        "https://docs.microsoft.com/windows"
    };
    ```

    Copy the following methods, and paste them below the `OnStartButtonClick` event handler in *MainWindow.xaml.cs*:

    ```csharp
    void SumPageSizes()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        int total = _urlList.Select(url => ProcessUrl(url)).Sum();

        stopwatch.Stop();
        _resultsTextBox.Text += $"\nTotal bytes returned:  {total:#,#}";
        _resultsTextBox.Text += $"\nElapsed time:          {stopwatch.Elapsed}\n";
    }

    int ProcessUrl(string url)
    {
        using var memoryStream = new MemoryStream();
        var webReq = (HttpWebRequest)WebRequest.Create(url);

        using WebResponse response = webReq.GetResponse();
        using Stream responseStream = response.GetResponseStream();
        responseStream.CopyTo(memoryStream);

        byte[] content = memoryStream.ToArray();
        DisplayResults(url, content);

        return content.Length;
    }

    void DisplayResults(string url, byte[] content) =>
        _resultsTextBox.Text += $"{url,-60} {content.Length,10:#,#}\n";
    ```

## Test the synchronous solution

Select the <kbd>F5</kbd> key to run the program, and then choose the **Start** button.

Output that resembles the following should appear:

```text
https://docs.microsoft.com                                       39,639
https://docs.microsoft.com/azure                                401,180
https://docs.microsoft.com/powershell                            58,240
https://docs.microsoft.com/dotnet                                69,693
https://docs.microsoft.com/aspnet/core                           87,771
https://docs.microsoft.com/windows                               25,580

Total bytes returned:  682,103
Elapsed time:          00:00:06.1445331

Control returned to OnStartButtonClick.
```

Notice that it takes a few seconds to display the counts. During that time, the UI thread is blocked while it waits for requested resources to download. As a result, you can't move, maximize, minimize, or even close the display window after you choose the  **Start** button. These efforts fail until the byte counts start to appear. If a website isn't responding, you have no indication of which site failed. It is difficult even to stop waiting and close the program.

## Convert GetURLContents to an asynchronous method

1. To convert the synchronous solution to an asynchronous solution, the best place to start is in `ProcessUrl` because the calls to the <xref:System.Net.HttpWebRequest> method <xref:System.Net.HttpWebRequest.GetResponse%2A> and to the <xref:System.IO.Stream> method <xref:System.IO.Stream.CopyTo%2A> are where the application accesses the web. The .NET runtime makes the conversion easy by supplying asynchronous versions of both methods.

     For more information about the methods that are used in `ProcessUrl`, see <xref:System.Net.WebRequest>.

    > [!NOTE]
    > As you follow the steps in this tutorial, several compiler errors appear. You can ignore them and continue with the tutorial.

     Change the method that's called in `ProcessUrl` from `GetResponse` to the asynchronous, task-based <xref:System.Net.WebRequest.GetResponseAsync%2A> method.

    ```csharp
    using WebResponse response = webReq.GetResponseAsync();
    ```

1. `GetResponseAsync` returns a <xref:System.Threading.Tasks.Task%601>. In this case, the *task return variable*, `TResult`, has type <xref:System.Net.WebResponse>. The task is a promise to produce an actual `WebResponse` object after the requested data has been downloaded and the task has run to completion.

     To retrieve the `WebResponse` value from the task, apply an [await](../../../language-reference/operators/await.md) operator to the call to `GetResponseAsync`, as the following code shows.

    ```csharp
    using WebResponse response = await webReq.GetResponseAsync();
    ```

     The `await` operator suspends the execution of the current method, `ProcessUrl`, until the awaited task is complete. In the meantime, control returns to the caller of the current method. In this example, the current method is `ProcessUrl`, and the caller is `SumPageSizes`. When the task is finished, the promised `WebResponse` object is produced as the value of the awaited task and assigned to the variable `response`.

     The previous statement can be separated into the following two statements to clarify what happens, it could look as follows.

    ```csharp
    Task<WebResponse> responseTask = webReq.GetResponseAsync();
    using WebResponse response = await responseTask;
    ```

     The call to `webReq.GetResponseAsync` returns a `Task<WebResponse>` (or `Task(Of WebResponse)` in Visual Basic). Then an await operator is applied to the task to retrieve the `WebResponse` value.

     If your async method has work to do that doesn't depend on the completion of the task, the method can continue with that work between these two statements, after the call to the async method and before the `await` operator is applied. For more information, see [How to make multiple web requests in parallel using async and await (C#)](how-to-make-multiple-web-requests-in-parallel-by-using-async-and-await.md) and [Extend the async tutorial using Task.WhenAll (C#)](how-to-extend-the-async-walkthrough-by-using-task-whenall.md).

1. Because you added the `await` operator in the previous step, a compiler error occurs. The operator can be used only in methods that are marked with the [async](../../../language-reference/keywords/async.md) modifier. Ignore the error while you repeat the conversion steps to replace the call to `CopyTo` with a call to `CopyToAsync`.

    - Change the name of the method that's called to <xref:System.IO.Stream.CopyToAsync%2A>.

    - The `CopyTo` or `CopyToAsync` method copies bytes to its argument, `memoryStream`, and doesn't return a meaningful value. In the synchronous version, the call to `CopyTo` is a simple statement that doesn't return a value. The asynchronous version, `CopyToAsync`, returns a <xref:System.Threading.Tasks.Task>. The task functions like "Task(void)" and enables the method to be awaited. Apply `await` (or `Await` in Visual Basic) to the call to `CopyToAsync`, as the following code shows.

        ```csharp
        await responseStream.CopyToAsync(memoryStream);
        ```

         The previous statement abbreviates the following two lines of code.

        ```csharp
        Task copyTask = responseStream.CopyToAsync(memoryStream);
        await copyTask;
        ```

1. All that remains to be done in `ProcessUrl` is to adjust the method signature. You can use the `await` operator only in methods that are marked with the [async](../../../language-reference/keywords/async.md) modifier. Add the modifier to mark the method as an *async method*, as the following code shows.

    ```csharp
    async int ProcessUrl(string url)
    ```

1. The return type of an async method can only be <xref:System.Threading.Tasks.Task>, <xref:System.Threading.Tasks.Task%601>, or `void` in C#. Typically, a return type of `void` is used only in an async event handler, where `void` is required. In other cases, you use `Task<T>` if the completed method has a [return](../../../language-reference/keywords/return.md) statement that returns a value of type T, and you use `Task` if the completed method doesn't return a meaningful value. You can think of the `Task` return type as meaning `Task<void>`.

     For more information, see [Async return types (C#)](async-return-types.md).

     Method `ProcessUrl` has a return statement, and the statement returns an `int` value representing the content length. Therefore, the return type of the async version is `Task<T>`, where T is an `int`. Make the following changes in the method signature:

    - Change the return type to `Task<int>`.
    - By convention, asynchronous methods have names that end in "Async", so rename the method `ProcessUrlAsync`.

    The following code shows these changes.

    ```csharp
    async Task<int> ProcessUrlAsync(string url)
    ```

    With those few changes, the conversion of `ProcessUrl` to an asynchronous method is complete.

    ```csharp
    async Task<int> ProcessUrlAsync(string url)
    {
        using var memoryStream = new MemoryStream();
        var webReq = (HttpWebRequest)WebRequest.Create(url);

        using WebResponse response = await webReq.GetResponseAsync();
        using Stream responseStream = response.GetResponseStream();
        await responseStream.CopyToAsync(memoryStream);

        byte[] content = memoryStream.ToArray();
        DisplayResults(url, content);

        return content.Length;
    }
    ```

## Convert SumPageSizes to an asynchronous method

1. Repeat the steps from the previous procedure for `SumPageSizes`. First, change the call to `ProcessUrl` to an asynchronous call.
    - Convert from a `Select`, with a chained `Sum` to a `foreach`.
    - Change the name of the method that's called from `ProcessUrl` to `ProcessUrlAsync`, if you haven't already done so.
    - Apply `await` to the task that `ProcessUrlAsync` returns to obtain the byte array value.

     The following code shows these changes.

    ```csharp
    int total = 0;
    foreach (string url in _urlList)
    {
        int contentLength = await ProcessUrlAsync(url);
        total += contentLength;
    }
    ```

     The previous assignment abbreviates the following two lines of code.

    ```csharp
    Task<int> getcontentLengthTask = ProcessUrlAsync(url);
    int contentLength = await getcontentLengthTask;
    ```

1. Make the following changes in the method's signature:
    - Mark the method with the `async` modifier.
    - Add "Async" to the method name.
    - There is no task return variable, T, this time because `SumPageSizesAsync` doesn't return a value for T. (The method has no `return` statement.) However, the method must return a `Task` to be awaitable. Therefore, change the return type of the method from `void` to `Task`.

    The following code shows these changes.

    ```csharp
    async Task SumPageSizesAsync()
    ```

    The conversion of `SumPageSizes` to `SumPageSizesAsync` is complete.

    ```csharp
    async Task SumPageSizesAsync()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        int total = 0;
        foreach (string url in _urlList)
        {
            int contentLength = await ProcessUrlAsync(url);
            total += contentLength;
        }

        stopwatch.Stop();
        _resultsTextBox.Text += $"\nTotal bytes returned:  {total:#,#}";
        _resultsTextBox.Text += $"\nElapsed time:          {stopwatch.Elapsed}\n";
    }
    ```

## Convert OnStartButtonClick to an asynchronous method

1. In the event handler, change the name of the called method from `SumPageSizes` to `SumPageSizesAsync`, if you haven't already done so.
1. Because `SumPageSizesAsync` is an async method, change the code in the event handler to await the result.

     The call to `SumPageSizesAsync` mirrors the call to `CopyToAsync` in `ProcessUrlAsync`. The call returns a `Task`, not a `Task<T>`.

     As in previous procedures, you can convert the call by using one statement or two statements. The following code shows these changes.

    ```csharp
    await SumPageSizesAsync();
    ```

1. To prevent accidentally reentering the operation, add the following statement at the top of `OnStartButtonClick` to disable the **Start** button.

    ```csharp
    _startButton.IsEnabled = false;
    ```

     You can reenable the button at the end of the event handler.

    ```csharp
    _startButton.IsEnabled = true;
    ```

     For more information about reentrancy, see [Handling reentrancy in async apps (C#)](handling-reentrancy-in-async-apps.md).

1. Finally, add the `async` modifier to the declaration so that the event handler can await `SumPagSizesAsync`.

    ```csharp
    async void OnStartButtonClick(object sender, RoutedEventArgs e)
    ```

     Typically, the names of event handlers aren't changed. The return type isn't changed to `Task` because event handlers must return `void`.

     The conversion of the project from synchronous to asynchronous processing is complete.

## Test the asynchronous solution

1. Choose the <kbd>F5</kbd> key to run the program, and then choose the **Start** button.
2. Output that resembles the output of the synchronous solution should appear. However, notice the following differences.
    - The results don't all occur at the same time, after the processing is complete. For example, both programs contain a line in `OnStartButtonClick` that clears the text box. The intent is to clear the text box between runs if you choose the **Start** button for a second time, after one set of results has appeared. In the synchronous version, the text box is cleared just before the counts appear for the second time, when the downloads are completed and the UI thread is free to do other work. In the asynchronous version, the text box clears immediately after you choose the **Start** button.
    - Most importantly, the UI thread isn't blocked during the downloads. You can move or resize the window while the web resources are being downloaded, counted, and displayed. If one of the websites is slow or not responding, you can cancel the operation by choosing the **Close** button (the x in the red field in the upper-right corner).

## Update method ProcessUrlAsync with a .NET method

1. .NET Framework 4.5 and later versions provide many async methods that you can use. One of them, the <xref:System.Net.Http.HttpClient> method <xref:System.Net.Http.HttpClient.GetByteArrayAsync%28System.String%29>, does just what you need for this tutorial. You can use it instead of the `ProcessUrlAsync` method that you created in an earlier procedure.

     The first step is to create an `HttpClient` object at the class-scope. Add the following declaration the `_urlList` field.

    ```csharp
    readonly HttpClient _client =
         new HttpClient { MaxResponseContentBufferSize = 1_000_000 };
    ```

1. In `ProcessUrlAsync`, replace the method body with the following code that relies on the `HttpClient` method.

    ```csharp
    async Task<int> ProcessUrlAsync(string url, HttpClient client)
    {
        byte[] content = await client.GetByteArrayAsync(url);
        DisplayResults(url, content);

        return content.Length;
    }
    ```

1. In `SumPageSizesAsync` method, pass in the `_client` to the `ProcessUrlAsync` method.

    ```csharp
    int contentLength = await ProcessUrlAsync(url, _client);
    ```

1. Select the <kbd>F5</kbd> key to run the program, and then choose the **Start** button.
     The behavior of this version of the project should match the behavior that the "To test the asynchronous solution" procedure describes but with even less effort from you.

## Example code

The following code contains the full example of the solution that uses the `HttpClient` method, `GetByteArrayAsync`.

```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace SerialAsyncExample
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
            "https://docs.microsoft.com/windows"
        };

        async void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            _startButton.IsEnabled = false;
            _resultsTextBox.Clear();

            await SumPageSizesAsync();

            _resultsTextBox.Text += $"\nControl returned to {nameof(OnStartButtonClick)}.";
            _startButton.IsEnabled = true;
        }

        async Task SumPageSizesAsync()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            int total = 0;
            foreach (string url in _urlList)
            {
                int contentLength = await ProcessUrlAsync(url, _client);
                total += contentLength;
            }

            stopwatch.Stop();
            _resultsTextBox.Text += $"\nTotal bytes returned:  {total:#,#}";
            _resultsTextBox.Text += $"\nElapsed time:          {stopwatch.Elapsed}\n";
        }

        async Task<int> ProcessUrlAsync(string url, HttpClient client)
        {
            byte[] content = await client.GetByteArrayAsync(url);
            DisplayResults(url, content);

            return content.Length;
        }

        void DisplayResults(string url, byte[] content) =>
            _resultsTextBox.Text += $"{url,-60} {content.Length,10:#,#}\n";

        protected override void OnClosed(EventArgs e) => _client?.Dispose();
    }
}
```

## Run the improved solution

Select the <kbd>F5</kbd> key to run the program, and then choose the **Start** button.

Output that resembles the following should appear:

```text
https://docs.microsoft.com                                       39,639
https://docs.microsoft.com/azure                                401,180
https://docs.microsoft.com/powershell                            58,240
https://docs.microsoft.com/dotnet                                69,693
https://docs.microsoft.com/aspnet/core                           87,771
https://docs.microsoft.com/windows                               25,580

Total bytes returned:  682,103
Elapsed time:          00:00:03.8291937

Control returned to OnStartButtonClick.
```

## See also

- [Async return types (C#)](async-return-types.md)
- [Asynchronous programming with async and await (C#)](index.md)
- [async](../../../language-reference/keywords/async.md)
- [await](../../../language-reference/operators/await.md)
- [How to make multiple web requests in parallel by using async and await (C#)](how-to-make-multiple-web-requests-in-parallel-by-using-async-and-await.md)
- [Task-based asynchronous programming](../../../../standard/parallel-programming/task-based-asynchronous-programming.md)

## Next steps

> [!div class="nextstepaction"]
> [Extend this tutorial using Task.WhenAll (C#)](how-to-extend-the-async-walkthrough-by-using-task-whenall.md)
