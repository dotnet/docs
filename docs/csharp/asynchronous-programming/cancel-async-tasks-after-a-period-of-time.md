---
title: Cancel async tasks after a period of time"
description: Learn how to schedule cancellation of any associated tasks that are not completed within a period of time.
ms.date: 02/09/2023
ms.topic: tutorial
---

# Cancel async tasks after a period of time

You can cancel an asynchronous operation after a period of time by using the <xref:System.Threading.CancellationTokenSource.CancelAfter%2A?displayProperty=nameWithType> method if you don't want to wait for the operation to finish. This method schedules the cancellation of any associated tasks that aren't complete within the period of time that's designated by the `CancelAfter` expression.

This example adds to the code that's developed in [Cancel a list of tasks (C#)](cancel-an-async-task-or-a-list-of-tasks.md) to download a list of websites and to display the length of the contents of each one.

This tutorial covers:

> [!div class="checklist"]
>
> - Updating an existing .NET console application
> - Scheduling a cancellation

## Prerequisites

This tutorial requires the following:

- You're expected to have created an application in the [Cancel a list of tasks (C#)](cancel-an-async-task-or-a-list-of-tasks.md) tutorial
- [.NET 5 or later SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- Integrated development environment (IDE)
  - [We recommend Visual Studio, Visual Studio Code, or Visual Studio for Mac](https://visualstudio.microsoft.com)

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
    catch (OperationCanceledException)
    {
        Console.WriteLine("\nTasks cancelled: timed out.\n");
    }
    finally
    {
        s_cts.Dispose();
    }

    Console.WriteLine("Application ending.");
}
```

The updated `Main` method writes a few instructional messages to the console. Within the [`try-catch`](../language-reference/statements/exception-handling-statements.md#the-try-catch-statement), a call to <xref:System.Threading.CancellationTokenSource.CancelAfter(System.Int32)?displayProperty=nameWithType> schedules a cancellation. This will signal cancellation after a period of time.

Next, the `SumPageSizesAsync` method is awaited. If processing all of the URLs occurs faster than the scheduled cancellation, the application ends. However, if the scheduled cancellation is triggered before all of the URLs are processed, a <xref:System.OperationCanceledException> is thrown.

### Example application output

```console
Application started.

https://learn.microsoft.com                                       37,357
https://learn.microsoft.com/aspnet/core                           85,589
https://learn.microsoft.com/azure                                398,939
https://learn.microsoft.com/azure/devops                          73,663

Tasks cancelled: timed out.

Application ending.
```

## Complete example

The following code is the complete text of the *Program.cs* file for the example.

:::code language="csharp" source="snippets/cancel-task-after-period-of-time/Program.cs":::

## See also

- <xref:System.Threading.CancellationToken>
- <xref:System.Threading.CancellationTokenSource>
- [Asynchronous programming with async and await (C#)](index.md)
- [Cancel a list of tasks (C#)](cancel-an-async-task-or-a-list-of-tasks.md)
