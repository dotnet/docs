---
title: Generate and consume async streams
description: This advanced tutorial shows how to generate and consume async streams. Async streams provide a more natural way to work with sequences of data that may be generated asynchronously.
ms.date: 02/10/2019
ms.technology: csharp-async
ms.custom: mvc
---
# Tutorial: Generate and consume async streams using C# 8.0 and .NET Core 3.0

C# 8.0 introduces **async streams**, which model a streaming source of data. Data streams often retrieve or generate elements asynchronously. Async streams rely on new interfaces introduced in .NET Standard 2.1. These interfaces are supported in .NET Core 3.0 and later. They provide a natural programming model for asynchronous streaming data sources.

In this tutorial, you'll learn how to:

> [!div class="checklist"]
>
> - Create a data source that generates a sequence of data elements asynchronously.
> - Consume that data source asynchronously.
> - Support cancellation and captured contexts for asynchronous streams.
> - Recognize when the new interface and data source are preferred to earlier synchronous data sequences.

## Prerequisites

You'll need to set up your machine to run .NET Core, including the C# 8.0 compiler. The C# 8 compiler is available starting with [Visual Studio 2019 version 16.3](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019) or [.NET Core 3.0 SDK](https://dotnet.microsoft.com/download).

You'll need to create a [GitHub access token](https://help.github.com/articles/creating-a-personal-access-token-for-the-command-line/#creating-a-token) so that you can access the GitHub GraphQL endpoint. Select the following permissions for your GitHub Access Token:

- repo:status
- public_repo

Save the access token in a safe place so you can use it to gain access to the GitHub API endpoint.

> [!WARNING]
> Keep your personal access token secure. Any software with your personal access token could make GitHub API calls using your access rights.

This tutorial assumes you're familiar with C# and .NET, including either Visual Studio or the .NET CLI.

## Run the starter application

You can get the code for the starter application used in this tutorial from the [dotnet/docs](https://github.com/dotnet/docs) repository in the [csharp/whats-new/tutorials](https://github.com/dotnet/docs/tree/main/docs/csharp/whats-new/tutorials/snippets/generate-consume-asynchronous-streams/start) folder.

The starter application is a console application that uses the [GitHub GraphQL](https://developer.github.com/v4/) interface to retrieve recent issues written in the [dotnet/docs](https://github.com/dotnet/docs) repository. Start by looking at the following code for the starter app `Main` method:

:::code language="csharp" source="snippets/generate-consume-asynchronous-streams/start/Program.cs" id="SnippetStarterAppMain" :::

You can either set a `GitHubKey` environment variable to your personal access token, or you can replace the last argument in the call to `GetEnvVariable` with your personal access token. Don't put your access code in source code if you'll be sharing the source with others. Never upload access codes to a shared source repository.

After creating the GitHub client, the code in `Main` creates a progress reporting object and a cancellation token. Once those objects are created, `Main` calls `RunPagedQueryAsync` to retrieve the most recent 250 created issues. After that task has finished, the results are displayed.

When you run the starter application, you can make some important observations about how this application runs.  You'll see progress reported for each page returned from GitHub. You can observe a noticeable pause before GitHub returns each new page of issues. Finally, the issues are displayed only after all 10 pages have been retrieved from GitHub.

## Examine the implementation

The implementation reveals why you observed the behavior discussed in the previous section. Examine the code for `RunPagedQueryAsync`:

:::code language="csharp" source="snippets/generate-consume-asynchronous-streams/start/Program.cs" id="SnippetRunPagedQuery" :::

Let's concentrate on the paging algorithm and async structure of the preceding code. (You can consult the [GitHub GraphQL documentation](https://developer.github.com/v4/guides/) for details on the GitHub GraphQL API.) The `RunPagedQueryAsync` method enumerates the issues from most recent to oldest. It requests 25 issues per page and examines the `pageInfo` structure of the response to continue with the previous page. That follows GraphQL's standard paging support for multi-page responses. The response includes a `pageInfo` object that includes a `hasPreviousPages` value and a `startCursor` value used to request the previous page. The issues are in the `nodes` array. The `RunPagedQueryAsync` method appends these nodes to an array that contains all the results from all pages.

After retrieving and restoring a page of results, `RunPagedQueryAsync` reports progress and checks for cancellation. If cancellation has been requested, `RunPagedQueryAsync` throws an <xref:System.OperationCanceledException>.

There are several elements in this code that can be improved. Most importantly, `RunPagedQueryAsync` must allocate storage for all the issues returned. This sample stops at 250 issues because retrieving all open issues would require much more memory to store all the retrieved issues. The protocols for supporting progress reports and cancellation make the algorithm harder to understand on its first reading. More types and APIs are involved. You must trace the communications through the <xref:System.Threading.CancellationTokenSource> and its associated <xref:System.Threading.CancellationToken> to understand where cancellation is requested and where it's granted.

## Async streams provide a better way

Async streams and the associated language support address all those concerns. The code that generates the sequence can now use `yield return` to return elements in a method that was declared with the `async` modifier. You can consume an async stream using an `await foreach` loop just as you consume any sequence using a `foreach` loop.

These new language features depend on three new interfaces added to .NET Standard 2.1 and implemented in .NET Core 3.0:

- <xref:System.Collections.Generic.IAsyncEnumerable%601?displayProperty=nameWithType>
- <xref:System.Collections.Generic.IAsyncEnumerator%601?displayProperty=nameWithType>
- <xref:System.IAsyncDisposable?displayProperty=nameWithType>

These three interfaces should be familiar to most C# developers. They behave in a manner similar to their synchronous counterparts:

- <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType>
- <xref:System.Collections.Generic.IEnumerator%601?displayProperty=nameWithType>
- <xref:System.IDisposable?displayProperty=nameWithType>

One type that may be unfamiliar is <xref:System.Threading.Tasks.ValueTask?displayProperty=nameWithType>. The `ValueTask` struct provides a similar API to the <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> class. `ValueTask` is used in these interfaces for performance reasons.

## Convert to async streams

Next, convert the `RunPagedQueryAsync` method to generate an async stream. First, change the signature of `RunPagedQueryAsync` to return an `IAsyncEnumerable<JToken>`, and remove the cancellation token and progress objects from the parameter list as shown in the following code:

:::code language="csharp" source="snippets/generate-consume-asynchronous-streams/finished/Program.cs" id="SnippetUpdateSignature" :::

The starter code processes each page as the page is retrieved, as shown in the following code:

:::code language="csharp" source="snippets/generate-consume-asynchronous-streams/start/Program.cs" id="SnippetProcessPage" :::

Replace those three lines with the following code:

:::code language="csharp" source="snippets/generate-consume-asynchronous-streams/finished/Program.cs" id="SnippetYieldReturnPage" :::

You can also remove the declaration of `finalResults` earlier in this method and the `return` statement that follows the loop you modified.

You've finished the changes to generate an async stream. The finished method should resemble the following code:

:::code language="csharp" source="snippets/generate-consume-asynchronous-streams/finished/Program.cs" id="SnippetGenerateAsyncStream" :::

Next, you change the code that consumes the collection to consume the async stream. Find the following code in `Main` that processes the collection of issues:

:::code language="csharp" source="snippets/generate-consume-asynchronous-streams/start/Program.cs" id="SnippetEnumerateOldStyle" :::

Replace that code with the following `await foreach` loop:

:::code language="csharp" source="snippets/generate-consume-asynchronous-streams/finished/Program.cs" id="SnippetEnumerateAsyncStream" :::

The new interface <xref:System.Collections.Generic.IAsyncEnumerator%601> derives from <xref:System.IAsyncDisposable>. That means the preceding loop will asynchronously dispose the stream when the loop finishes. You can imagine the loop looks like the following code:

```csharp
int num = 0;
var enumerator = RunPagedQueryAsync(client, PagedIssueQuery, "docs").GetEnumeratorAsync();
try
{
    while (await enumerator.MoveNextAsync())
    {
        var issue = enumerator.Current;
        Console.WriteLine(issue);
        Console.WriteLine($"Received {++num} issues in total");
    }
} finally
{
    if (enumerator != null)
        await enumerator.DisposeAsync();
}
```

By default, stream elements are processed in the captured context. If you want to disable capturing of the context, use the <xref:System.Threading.Tasks.TaskAsyncEnumerableExtensions.ConfigureAwait%2A?displayProperty=nameWithType> extension method. For more information about synchronization contexts and capturing the current context, see the article on [consuming the Task-based asynchronous pattern](../../../standard/asynchronous-programming-patterns/consuming-the-task-based-asynchronous-pattern.md).

Async streams support cancellation using the same protocol as other `async` methods. You would modify the signature for the async iterator method as follows to support cancellation:

:::code language="csharp" source="snippets/generate-consume-asynchronous-streams/finished/Program.cs" id="SnippetGenerateWithCancellation" :::

The <xref:System.Runtime.CompilerServices.EnumeratorCancellationAttribute?dipslayProperty=nameWithType> attribute causes the compiler to generate code for the <xref:System.Collections.Generic.IAsyncEnumerator%601> that makes the token passed to `GetAsyncEnumerator` visible to the body of the async iterator as that argument. Inside `runQueryAsync`, you could examine the state of the token and cancel further work if requested.

You use another extension method, <xref:System.Threading.Tasks.TaskAsyncEnumerableExtensions.WithCancellation%2A>, to pass the cancellation token to the async stream. You would modify the loop enumerating the issues as follows:

:::code language="csharp" source="snippets/generate-consume-asynchronous-streams/finished/Program.cs" id="SnippetEnumerateWithCancellation" :::

You can get the code for the finished tutorial from the [dotnet/docs](https://github.com/dotnet/docs) repository in the [csharp/whats-new/tutorials](https://github.com/dotnet/docs/tree/main/docs/csharp/whats-new/tutorials/snippets/generate-consume-asynchronous-streams/finished) folder.

## Run the finished application

Run the application again. Contrast its behavior with the behavior of the starter application. The first page of results is enumerated as soon as it's available. There's an observable pause as each new page is requested and retrieved, then the next page's results are quickly enumerated. The `try` / `catch` block isn't needed to handle cancellation: the caller can stop enumerating the collection. Progress is clearly reported because the async stream generates results as each page is downloaded. The status for each issue returned is seamlessly included in the `await foreach` loop. You don't need a callback object to track progress.

You can see improvements in memory use by examining the code. You no longer need to allocate a collection to store all the results before they're enumerated. The caller can determine how to consume the results and if a storage collection is needed.

Run both the starter and finished applications and you can observe the differences between the implementations for yourself. You can delete the GitHub access token you created when you started this tutorial after you've finished. If an attacker gained access to that token, they could access GitHub APIs using your credentials.
