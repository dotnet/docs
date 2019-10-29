---
title: Generate and consume async streams
description: This advanced tutorial illustrates scenarios where generating and consuming async streams provides a more natural way to work with sequences of data that may be generated asynchronously.
ms.date: 02/10/2019
ms.technology: csharp-async
ms.custom: mvc
---
# Tutorial: Generate and consume async streams using C# 8.0 and .NET Core 3.0

C# 8.0 introduces **async streams**, which model a streaming source of data when the elements in the data stream may be retrieved or generated asynchronously. Async streams rely on new interfaces introduced in .NET Standard 2.1 and implemented in .NET Core 3.0 to provide a natural programming model for asynchronous streaming data sources.

In this tutorial, you'll learn how to:

> [!div class="checklist"]
>
> - Create a data source that generates a sequence of data elements asynchronously.
> - Consume that data source asynchronously.
> - Recognize when the new interface and data source are preferred to earlier synchronous data sequences.

## Prerequisites

You’ll need to set up your machine to run .NET Core, including the C# 8.0 compiler. The C# 8 compiler is available starting with [Visual Studio 2019 version 16.3](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019) or [.NET Core 3.0 SDK](https://dotnet.microsoft.com/download).

You'll need to create a [GitHub access token](https://help.github.com/articles/creating-a-personal-access-token-for-the-command-line/#creating-a-token) so that you can access the GitHub GraphQL endpoint. Select the following permissions for your GitHub Access Token:

- repo:status
- public_repo

Save the access token in a safe place so you can use it to gain access to the GitHub API endpoint.

> [!WARNING]
> Keep your personal access token secure. Any software with your personal access token could make GitHub API calls using your access rights.

This tutorial assumes you're familiar with C# and .NET, including either Visual Studio or the .NET Core CLI.

## Run the starter application

You can get the code for the starter application used in this tutorial from our [dotnet/samples](https://github.com/dotnet/samples) repository in the [csharp/tutorials/AsyncStreams](https://github.com/dotnet/samples/tree/master/csharp/tutorials/AsyncStreams/start) folder.

The starter application is a console application that uses the [GitHub GraphQL](https://developer.github.com/v4/) interface to retrieve recent issues written in the [dotnet/docs](https://github.com/dotnet/docs) repository. Start by looking at the following code for the starter app `Main` method:

[!code-csharp[StarterAppMain](~/samples/csharp/tutorials/AsyncStreams/start/IssuePRreport/IssuePRreport/Program.cs#StarterAppMain)]

You can either set a `GitHubKey` environment variable to your personal access token, or you can replace the last argument in the call to `GenEnvVariable` with your personal access token. Don't put your access code in source code if you'll be saving the source with others, or putting it in a shared source repository.

After creating the GitHub client, the code in `Main` creates a progress reporting object and a cancellation token. Once those objects are created, `Main` calls `runPagedQueryAsync` to retrieve the most recent 250 created issues. After that task has finished, the results are displayed.

When you run the starter application, you can make some important observations about how this application runs.  You'll see progress reported for each page returned from GitHub. You can observe a noticeable pause before GitHub returns each new page of issues. Finally, the issues are displayed only after all 10 pages have been retrieved from GitHub.

## Examine the implementation

The implementation reveals why you observed the behavior discussed in the previous section. Examine the code for `runPagedQueryAsync`:

[!code-csharp[RunPagedQueryStarter](~/samples/csharp/tutorials/AsyncStreams/start/IssuePRreport/IssuePRreport/Program.cs#RunPagedQuery)]

Let's concentrate on the paging algorithm and async structure of the preceding code. (You can consult the [GitHub GraphQL documentation](https://developer.github.com/v4/guides/) for details on the GitHub GraphQL API.) The `runPagedQueryAsync` method enumerates the issues from most recent to oldest. It requests 25 issues per page and examines the `pageInfo` structure of the response to continue with the previous page. That follows GraphQL's standard paging support for multi-page responses. The response includes a `pageInfo` object that includes a `hasPreviousPages` value and a `startCursor` value used to request the previous page. The issues are in the `nodes` array. The `runPagedQueryAsync` method appends these nodes to an array that contains all the results from all pages.

After retrieving and restoring a page of results, `runPagedQueryAsync` reports progress and checks for cancellation. If cancellation has been requested, `runPagedQueryAsync` throws an <xref:System.OperationCanceledException>.

There are several elements in this code that can be improved. Most importantly, `runPagedQueryAsync` must allocate storage for all the issues returned. This sample stops at 250 issues because retrieving all open issues would require much more memory to store all the retrieved issues. In addition, the protocols for supporting progress and supporting cancellation make the algorithm harder to understand on its first reading. You must look for the progress class to find where progress is reported. You also have to trace the communications through the <xref:System.Threading.CancellationTokenSource> and its associated <xref:System.Threading.CancellationToken> to understand where cancellation is requested and where it's granted.

## Async streams provide a better way

Async streams and the associated language support address all those concerns. The code that generates the sequence can now use `yield return` to return elements in a method that was declared with the `async` modifier. You can consume an async stream using an `await foreach` loop just as you consume any sequence using a `foreach` loop.

These new language features depend on three new interfaces added to .NET Standard 2.1 and implemented in .NET Core 3.0:

```csharp
namespace System.Collections.Generic
{
    public interface IAsyncEnumerable<out T>
    {
        IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default);
    }

    public interface IAsyncEnumerator<out T> : IAsyncDisposable
    {
        T Current { get; }

        ValueTask<bool> MoveNextAsync();
    }
}

namespace System
{
    public interface IAsyncDisposable
    {
        ValueTask DisposeAsync();
    }
}
```

These three interfaces should be familiar to most C# developers. They behave in a manner similar to their synchronous counterparts:

- <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType>
- <xref:System.Collections.Generic.IEnumerator%601?displayProperty=nameWithType>
- <xref:System.IDisposable?displayProperty=nameWithType>

One type that may be unfamiliar is <xref:System.Threading.Tasks.ValueTask?displayProperty=nameWithType>. The `ValueTask` struct provides a similar API to the <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> class. `ValueTask` is used in these interfaces for performance reasons.

## Convert to async streams

Next, convert the `runPagedQueryAsync` method to generate an async stream. First, change the signature of `runPagedQueryAsync` to return an `IAsyncEnumerable<JToken>`, and remove the cancellation token and progress objects from the parameter list as shown in the following code:

[!code-csharp[FinishedSignature](~/samples/csharp/tutorials/AsyncStreams/finished/IssuePRreport/IssuePRreport/Program.cs#UpdateSignature)]

The starter code processes each page as the page is retrieved, as shown in the following code:

[!code-csharp[StarterPaging](~/samples/csharp/tutorials/AsyncStreams/start/IssuePRreport/IssuePRreport/Program.cs#ProcessPage)]

Replace those three lines with the following code:

[!code-csharp[FinishedPaging](~/samples/csharp/tutorials/AsyncStreams/finished/IssuePRreport/IssuePRreport/Program.cs#YieldReturnPage)]

You can also remove the declaration of `finalResults` earlier in this method and the `return` statement that follows the loop you modified.

You've finished the changes to generate an async stream. The finished method should resemble the code below:

[!code-csharp[FinishedGenerate](~/samples/csharp/tutorials/AsyncStreams/finished/IssuePRreport/IssuePRreport/Program.cs#GenerateAsyncStream)]

Next, you change the code that consumes the collection to consume the async stream. Find the following code in `Main` that processes the collection of issues:

[!code-csharp[EnumerateOldStyle](~/samples/csharp/tutorials/AsyncStreams/start/IssuePRreport/IssuePRreport/Program.cs#EnumerateOldStyle)]

Replace that code with the following `await foreach` loop:

[!code-csharp[FinishedEnumerateAsyncStream](~/samples/csharp/tutorials/AsyncStreams/finished/IssuePRreport/IssuePRreport/Program.cs#EnumerateAsyncStream)]

You can get the code for the finished tutorial from the [dotnet/samples](https://github.com/dotnet/samples) repository in the [csharp/tutorials/AsyncStreams](https://github.com/dotnet/samples/tree/master/csharp/tutorials/AsyncStreams/finished) folder.

## Run the finished application

Run the application again. Contrast its behavior with the behavior of the starter application. The first page of results is enumerated as soon as it's available. There's an observable pause as each new page is requested and retrieved, then the next page's results are quickly enumerated. The `try` / `catch` block isn't needed to handle cancellation: the caller can stop enumerating the collection. Progress is clearly reported because the async stream generates results as each page is downloaded. The status for each issue returned is seamlessly included in the `await foreach` loop. You don't need a callback object to track progress.

You can see improvements in memory use by examining the code. You no longer need to allocate a collection to store all the results before they're enumerated. The caller can determine how to consume the results and if a storage collection is needed.

Run both the starter and finished applications and you can observe the differences between the implementations for yourself. You can delete the GitHub access token you created when you started this tutorial after you've finished. If an attacker gained access to that token, they could access GitHub APIs using your credentials.
