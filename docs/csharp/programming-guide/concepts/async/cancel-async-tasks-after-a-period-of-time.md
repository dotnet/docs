---
title: Cancel async tasks after a period of time (C#)"
description: Use the CancellationTokenSource.CancelAfter method in C# to schedule cancellation of any associated tasks not completed within a period in this example.
ms.date: 08/18/2020
ms.assetid: 194282c2-399f-46da-a7a6-96674e00b0b3
---

# Cancel async tasks after a period of time (C#)

You can cancel an asynchronous operation after a period of time by using the <xref:System.Threading.CancellationTokenSource.CancelAfter%2A?displayProperty=nameWithType> method if you don't want to wait for the operation to finish. This method schedules the cancellation of any associated tasks that aren't complete within the period of time that's designated by the `CancelAfter` expression.

This example adds to the code that's developed in [Cancel a list of tasks (C#)](cancel-an-async-task-or-a-list-of-tasks.md) to download a list of websites and to display the length of the contents of each one.

## Update application entry point

Replace the existing `Main` method with the following:

```csharp
static async Task Main()
{
    Console.WriteLine("Application started.");

    try
    {
        s_cts.CancelAfter(3500);

        await SumPageSizesAsync();
    }
    catch (TaskCanceledException)
    {
        Console.WriteLine("\nTasks cancelled: timed out.\n");
    }

    Console.WriteLine("Application ending.");
}
```

The updated `Main` method writes a few instructional messages to the console. Within the [try catch](../../../language-reference/keywords/try-catch.md), a call to <xref:System.Threading.CancellationTokenSource.CancelAfter(System.Int32)?displayProperty=nameWithType> to schedule a cancellation. This will signal cancellation after a period of time.

Next, the `SumPageSizesAsync` method is awaited. If processing all of the URLs occurs faster than the scheduled cancellation, the application ends. However, if the scheduled cancellation is triggered before all of the URLs are processed, a <xref:System.Threading.Tasks.TaskCanceledException> is thrown.

### Example application output

```console
Application started.

https://docs.microsoft.com                                       37,357
https://docs.microsoft.com/aspnet/core                           85,589
https://docs.microsoft.com/azure                                398,939
https://docs.microsoft.com/azure/devops                          73,663

Tasks cancelled: timed out.

Application ending.
```

## Complete example

The following code is the complete text of the *Program.cs* file for the example.

:::code language="csharp" source="snippets/cancel-tasks/cancel-task-after-period-of-time/Program.cs":::

## See also

- <xref:System.Threading.CancellationTokenSource>
- <xref:System.Threading.CancellationToken>
- [Asynchronous programming with async and await (C#)](index.md)
- [Cancel a list of tasks (C#)](cancel-an-async-task-or-a-list-of-tasks.md)
