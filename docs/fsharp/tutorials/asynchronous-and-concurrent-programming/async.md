---
title: Async Programming in F#
description: Learn how F# async programming is accomplished via a language-level programming model that is easy to use and natural to the language.
keywords: .NET, .NET Core
author: cartermp
ms.author: phcart
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: f9196bfc-b8a8-4d33-8b53-0dcbd58a69d8
---

# Async Programming in F# #

> [!NOTE]
> Some inaccuracies have been discovered in this article.  It is being rewritten.  See [Issue #666](https://github.com/dotnet/docs/issues/666) to learn about the changes.

Async programming in F# can be accomplished through a language-level programming model designed to be easy to use and natural to the language.

The core of async programming in F# is `Async<'T>`, a representation of work that can be triggered to run in the background, where `'T` is either the type returned via the special `return` keyword or `unit` if the async workflow has no result to return.

The key concept to understand is that an async expression’s type is `Async<'T>`, which is merely a _specification_ of work to be done in an asynchronous context. It is not executed until you explicitly start it with one of the starting functions (such as `Async.RunSynchronously`). Although this is a different way of thinking about doing work, it ends up being quite simple in practice.

For example, say you wanted to download the HTML from dotnetfoundation.org without blocking the main thread. You can accomplish it like this:

```fsharp
open System
open System.Net

let fetchHtmlAsync url = 
    async {
        let uri = Uri(url)
        use webClient = new WebClient()

        // Execution of fetchHtmlAsync won't continue until the result
        // of AsyncDownloadString is bound.
        let! html = webClient.AsyncDownloadString(uri)
        return html
    }

let html = "https://dotnetfoundation.org" |> fetchHtmlAsync |> Async.RunSynchronously
printfn "%s" html
```

And that’s it! Aside from the use of `async`, `let!`, and `return`, this is just normal F# code.

There are a few syntactical constructs which are worth noting:

*   `let!` binds the result of an async expression (which runs on another context).
*   `use!` works just like `let!`, but disposes its bound resources when it goes out of scope.
*   `do!` will await an async workflow which doesn’t return anything.
*   `return` simply returns a result from an async expression.
*   `return!` executes another async workflow and returns its return value as a result.

Additionally, normal `let`, `use`, and `do` keywords can be used alongside the async versions just as they would in a normal function.

## How to start Async Code in F# #

As mentioned earlier, async code is a specification of work to be done in another context which needs to be explicitly started. Here are two primary ways to accomplish this:

1.  `Async.RunSynchronously` will start an async workflow on another thread and await its result.

```fsharp
open System
open System.Net

let fetchHtmlAsync url = 
    async {
        let uri = Uri(url)
        use webClient = new WebClient()
        let! html = webClient.AsyncDownloadString(uri)
        return html
    }

 // Execution will pause until fetchHtmlAsync finishes
 let html = "https://dotnetfoundation.org" |> fetchHtmlAsync |> Async.RunSynchronously

 // you actually have the result from fetchHtmlAsync now!
 printfn "%s" html
 ```

2.  `Async.Start` will start an async workflow on another thread, and will **not** await its result.

```fsharp
open System
open System.Net
  
let uploadDataAsync url data = 
    async {
        let uri = Uri(url)
        use webClient = new WebClient()
        webClient.UploadStringAsync(uri, data)
    }

let workflow = uploadDataAsync "https://url-to-upload-to.com" "hello, world!"

// Execution will continue after calling this!
Async.Start(workflow)

printfn "%s" "uploadDataAsync is running in the background..."
 ```

There are other ways to start an async workflow available for more specific scenarios. They are detailed [in the Async reference](https://msdn.microsoft.com/library/ee370232.aspx).

### A Note on Threads

The phrase "on another thread" is mentioned above, but it is important to know that **this does not mean that async workflows are a facade for multithreading**. The workflow actually "jumps" between threads, borrowing them for a small amount of time to do useful work. When an async workflow is effectively "waiting" (for example, waiting for a network call to return something), any thread it was borrowing at the time is freed up to go do useful work on something else. This allows async workflows to utilize the system they run on as effectively as possible, and makes them especially strong for high-volume I/O scenarios.

## How to Add Parallelism to Async Code

Sometimes you may need to perform multiple asynchronous jobs in parallel, collect their results, and interpret them in some way. `Async.Parallel` allows you to do this without needing to use the Task Parallel Library, which would involve needing to coerce `Task<'T>` and `Async<'T>` types.

The following example will use `Async.Parallel` to download the HTML from four popular sites in parallel, wait for those tasks to complete, and then print the HTML which was downloaded.

```fsharp
open System
open System.Net

let urlList = 
    [ "https://www.microsoft.com"
      "https://www.google.com"
      "https://www.amazon.com"
      "https://www.facebook.com" ]

let fetchHtmlAsync url = 
    async {
        let uri = Uri(url)
        use webClient = new WebClient()
        let! html = webClient.AsyncDownloadString(uri)
        return html
    }

let getHtmlList urls =
    urls
    |> Seq.map fetchHtmlAsync   // Build an Async<'T> for each site
    |> Async.Parallel           // Returns an Async<'T []>
    |> Async.RunSynchronously   // Wait for the result of the parallel work

let htmlList = getHtmlList urlList

// We now have the downloaded HTML for each site!
for html in htmlList do
    printfn "%s" html
```

## Important Info and Advice

*   Append "Async" to the end of any functions you’ll consume

 Although this is just a naming convention, it does make things like API discoverability easier. Particularly if there are synchronous and asynchronous versions of the same routine, it’s a good idea to explicitly state which is asynchronous via the name.

*   Listen to the compiler!

 F#’s compiler is very strict, making it nearly impossible to do something troubling like run "async" code synchronously. If you come across a warning, that’s a sign that the code won’t execute how you think it will. If you can make the compiler happy, your code will most likely execute as expected.

## For the C#/VB Programmer Looking Into F# #

This section assumes you’re familiar with the async model in C#/VB. If you are not, [Async Programming in C#](../../../csharp/async.md) is a starting point.

There is a fundamental difference between the C#/VB async model and the F# async model.

When you call a function which returns a `Task` or `Task<'T>`, that job has already begun execution. The handle returned represents an already-running asynchronous job. In contrast, when you call an async function in F#, the `Async<'a>` returned represents a job which will be **generated** at some point. Understanding this model is powerful, because it allows for asynchronous jobs in F# to be chained together easier, performed conditionally, and be started with a finer grain of control.

There are a few other similarities and differences worth noting.

### Similarities

*   `let!`, `use!`, and `do!` are analogous to `await` when calling an async job from within an `async{ }` block.

 The three keywords can only be used within an `async { }` block, similar to how `await` can only be invoked inside an `async` method. In short, `let!` is for when you want to capture and use a result, `use!` is the same but for something whose resources should get cleaned after it’s used, and `do!` is for when you want to wait for an async workflow with no return value to finish before moving on.

*   F# supports data-parallelism in a similar way.

 Although it operates very differently, `Async.Parallel` corresponds to `Task.WhenAll` for the scenario of wanting the results of a set of async jobs when they all complete.

### Differences

*   Nested `let!` is not allowed, unlike nested `await`

 Unlike `await`, which can be nested indefinitely, `let!` cannot and must have its result bound before using it inside of another `let!`, `do!`, or `use!`.

*   Cancellation support is simpler in F# than in C#/VB.

 Supporting cancellation of a task midway through its execution in C#/VB requires checking the `IsCancellationRequested` property or calling `ThrowIfCancellationRequested()` on a `CancellationToken` object that’s passed into the async method.

In contrast, F# async workflows are more naturally cancellable. Cancellation is a simple three-step process.

1.  Create a new `CancellationTokenSource`.
2.  Pass it into a starting function.
3.  Call `Cancel` on the token.

Example:

```fsharp
open System
open System.Net

let uploadDataAsync url data = 
    async {
        let uri = Uri(url)
        use webClient = new WebClient()
        webClient.UploadStringAsync(uri, data)
    }

let workflow = uploadDataAsync "https://url-to-upload-to.com" "hello, world!"

let token = new CancellationTokenSource()
Async.Start (workflow, token)

// Immediately cancel uploadDataAsync after it's been started.
token.Cancel()
```

And that’s it!

## Further resources:

*   [Async Workflows on MSDN](https://msdn.microsoft.com/library/dd233250.aspx)
*   [Asynchronous Sequences for F#](https://fsprojects.github.io/FSharp.Control.AsyncSeq/library/AsyncSeq.html)
*   [F# Data HTTP Utilities](https://fsharp.github.io/FSharp.Data/library/Http.html)
