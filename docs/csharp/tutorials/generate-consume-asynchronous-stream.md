---
title: Generate and consume async streams
description: This advanced tutorial illustrates scenarios where generating and consuming async streams provides a more natural way to work with sequences of data that may be generated asynchronously.
ms.date: 02/10/2019
ms.custom: mvc
---
# Tutorial: Generate and consume async streams using C# 8.0 and .NET Core 3.0

C# 8.0 introduces **async streams**, which model a streaming source of data when the elements in the data stream may be retrieved or generated asynchronously. Async streams rely on new interfaces introduced in .NET Standard 2.1 and implemented in .NET Core 3.0 to provide a natural programming model for asynchronous streaming data sources.

In this tutorial, you'll learn how to:

> [!div class="checklist"]
> * Create a data source that generates a sequence of data elements asynchronously.
> * Consume that data source asynchronously.
> * Recognize when the new interface and data source are preferred to earlier synchronous data sequences.

## Prerequisites

You’ll need to set up your machine to run .NET Core, including the C# 8.0 beta compiler. The C# 8 beta compiler is available with [Visual Studio 2019 preview 1](https://visualstudio.microsoft.com/vs/preview/), or [.NET Core 3.0 preview 1](https://dotnet.microsoft.com/download/dotnet-core/3.0). Async streams are first available in .NET C.0 preview 2.

This tutorial assumes you're familiar with C# and .NET, including either Visual Studio or the .NET Core CLI.

## Run the starter application

You can get the code for the starter application use in this tutorial from our [samples](https://github.com/dotnet/samples) repository in the [csharp/tutorials/AsyncStreams](https://github.com/dotnet/samples/tree/master/csharp/tutorials/AsyncStreams/start) folder.

The starter application is a console application that uses the[GitHub GraphQL](https://developer.github.com/v4/) interface to retrieve recent issues written in the [.NET docs](https://github.com/dotnet/docs) repository. Start by looking at the code for the starter app `Main` method as shown in the following code:

[!code-csharp[StarterAppMain](../../../samples/csharp/tutorials/AsyncStreams/start/IssuePRreport/IssuePRreport/Main.cs#StarterAppMain)]

You'll need to create a [GitHub access token](https://help.github.com/articles/creating-a-personal-access-token-for-the-command-line/#creating-a-token) so that you can access the GitHub GraphQL endpoint. You can either set a `GitHubKey` environment variable to your personal access token, or you can replace the last argument in the call to `GenEnvVariable` with your personal access token.

> [!WARNING]
> Keep your personal access token secure. Any software with your personal access token could make GitHub API calls using your access rights.

After creating the GitHub client, the code in `Main` creates a progress reporting object and a cancellation token. Once those are created, `Main` calls `runPagedQueryAsync` to retrieve the most recent 250 created issues. After that task has finished, the results are displayed.

When you run the starter application, you can make some important observations about how this application runs.  You'll see progress reported for each page returned from GitHub. After each request you can observe a noticeable pause before GitHub returns a page of issues. Finally, the issues are displayed only after all ten pages have been retrieved from GitHub.

## Examine the implementation

The implementation reveals why you observed the behavior discussed in the previous section. Examine the code for `runPagedQueryAsync`:

[!code-csharp[RunPagedQueryStarter](../../../samples/csharp/tutorials/AsyncStreams/start/IssuePRreport/IssuePRreport/Main.cs#RunPagedQuery)]

Let's concentrate on the paging algorithm and async structure of the preceding code. (You can consult the [GitHub GraphQL documentation](https://developer.github.com/v4/guides/) for details on the GitHub GraphQL API.) The `runPagedQueryAsync` method enumerates the issues from the most recent backwards to older issues. It requests 25 issues per page, and examines the `pageInfo` structure of the response to continue with the previous page. That follows GraphQL's standard paging support for multiple page responses. The response includes a `pageInfo` object that includes a `hasPreviousPages` value and a `startCursor` value used to request the previous page. The issues are in the `nodes` array. The `runPagedQueryAsync` method appends these nodes to an array that contains all the results from all pages.

After retrieving and restoring a page of results, `runPagedQueryAsync` reports progress and checks for cancellation. If cancellation has been requested, `runPagedQueryAsync` throws an <xref:System.OperationCancelledException>.

There are several elements in this code that can be improved. Most importantly, `runPagedQueryAsync` must allocate storage for all the issues returned. This sample stops at 250 issues because retrieving all open issues would require much more memory to store all the retrieved issues. In addition, the protocols for supporting progress and supporting cancellation make the algorithm harder to understand on its first reading. You must look for the progress class to find where progress is reported. You also have to trace the communications through the <xref:System.Threading.Tasks.CancellationTokenSource?displayProperty=nameWithType> and its associated <xref:System.Threading.Tasks.CancellationToken?displayProperty=nameTypeWith> to understand where cancellation is requested and where it is granted.

## Async streams provide a better way

Async streams and the associated language support address all those concerns. The code that generates the sequence can now use `yield return` to return elements in a method that was declared with the `async` modifier. You can consume an async stream using a new `await foreach` loop just as you consume any sequence using a `foreach` loop.

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

These three interfaces should be familiar to most C# developers. They behave in a manner similar to their synchronous counterparts: <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType>, <xref:System.Collections.Generic.IEnumerator%601?displayProperty=nameWithType> and <xref:System.IDisposable?displayProperty=nameWithType>. The one other type that may be unfamiliar is <xref:System.Threading.Tasks.ValueTask?displayProperty=nameWithType>. The `ValueTask` `struct` provides a similar API to the <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> class. `ValueTask` is used in these interfaces for performance reasons.

## Convert to async streams

Next, convert the `runPagedQueryAsync` to generate an async stream. First, change the signature of `runPagedQueryAsync` to return an `IAsyncEnumerable<JToken>`, and remove the cancellation token and progress objects from the parameter list as shown in the following code:

[!code-csharp[FinishedSignature](../../../samples/csharp/tutorials/AsyncStreams/finished/IssuePRreport/IssuePRreport/Main.cs#UpdateSignature)]

The starter code processes each page as the page is retrieved, as shown in the following code:

[!code-csharp[StarterPaging](../../../samples/csharp/tutorials/AsyncStreams/start/IssuePRreport/IssuePRreport/Main.cs#ProcessPage)]

Replace those three lines with the following code:

[!code-csharp[FinishedPaging](../../../samples/csharp/tutorials/AsyncStreams/finished/IssuePRreport/IssuePRreport/Main.cs#YieldReturnPage)]

You can also remove the declaration of `finalResults` earlier in this method, and the return statement that follows the loop you just modified.

You've finished the changes to generate an async stream. The finished method should resemble the code below:

[!code-csharp[FinishedGenerate](../../../samples/csharp/tutorials/AsyncStreams/finished/IssuePRreport/IssuePRreport/Main.cs#GenerateAsyncStream)]

Next, you change the code that consumes the collection to consume the async stream. Find the following code in `Main` that processes the collection of issues:

[!code-csharp[EnumerateOldStyle](../../../samples/csharp/tutorials/AsyncStreams/start/IssuePRreport/IssuePRreport/Main.cs#EnumerateOldStyle)]

Replace all that code with the following `await foreach` loop:

[!code-csharp[FinishedEnumerateAsyncStream](../../../samples/csharp/tutorials/AsyncStreams/finished/IssuePRreport/IssuePRreport/Main.cs#EnumerateAsyncStream)]

Run the application again. Contrast its behavior with the behavior of the starter application. The first page of results are enumerated as soon as they are available. There's an observable pause as each new page is requested and retrieved, then the next page's results are quickly enumerated. The `try` / `catch` block is not needed to handle cancellation: the caller could simply stop enumerating the collection. Progress is clearly reported because the async stream generates results as each page is downloaded.

You can see improvements in memory use by examining the code. You no longer need to allocate a collection to store all the results before they are enumerated. The caller can determine how to consume the results and if a storage collection is needed.

You can get the code for the finished tutorial from our [samples](https://github.com/dotnet/samples) repository in the [csharp/tutorials/AsyncStreams](https://github.com/dotnet/samples/tree/master/csharp/tutorials/AsyncStreams/finished) folder.

Run both the starter and finished applications and you can observe the differences between the implementations for yourself.
