---
title: Async and Task Programming
description: Learn how F# provides clean support for asynchrony based on a language-level programming model derived from core functional programming concepts.
ms.date: 10/29/2021
---
# Async programming in F\#

Asynchronous programming is a mechanism that is essential to modern applications for diverse reasons. There are two primary use cases that most developers will encounter:

- Presenting a server process that can service a significant number of concurrent incoming requests, while minimizing the system resources occupied while request processing awaits inputs from systems or services external to that process
- Maintaining a responsive UI or main thread while concurrently progressing background work

Although background work often does involve the utilization of multiple threads, it's important to consider the concepts of asynchrony and multi-threading separately. In fact, they are separate concerns, and one does not imply the other. This article describes the separate concepts in more detail.

## Asynchrony defined

The previous point - that asynchrony is independent of the utilization of multiple threads - is worth explaining a bit further. There are three concepts that are sometimes related, but strictly independent of one another:

- Concurrency; when multiple computations execute in overlapping time periods.
- Parallelism; when multiple computations or several parts of a single computation run at exactly the same time.
- Asynchrony; when one or more computations can execute separately from the main program flow.

All three are orthogonal concepts, but can be easily conflated, especially when they are used together. For example, you may need to execute multiple asynchronous computations in parallel. This relationship does not mean that parallelism or asynchrony imply one another.

If you consider the etymology of the word "asynchronous", there are two pieces involved:

- "a", meaning "not".
- "synchronous", meaning "at the same time".

When you put these two terms together, you'll see that "asynchronous" means "not at the same time". That's it! There is no implication of concurrency or parallelism in this definition. This is also true in practice.

In practical terms, asynchronous computations in F# are scheduled to execute independently of the main program flow. This independent execution doesn't imply concurrency or parallelism, nor does it imply that a computation always happens in the background. In fact, asynchronous computations can even execute synchronously, depending on the nature of the computation and the environment the computation is executing in.

The main takeaway you should have is that asynchronous computations are independent of the main program flow. Although there are few guarantees about when or how an asynchronous computation executes, there are some approaches to orchestrating and scheduling them. The rest of this article explores core concepts for F# asynchrony and how to use the types, functions, and expressions built into F#.

## Core concepts

In F#, asynchronous programming is centered around two core concepts: async computations and tasks.

- The `Async<'T>` type with `async { }` [computation expression](../language-reference/computation-expressions.md), which represents a composable asynchronous computation that can be started to form a task.
- The `Task<'T>` type, with `task { }` [computation expression](../language-reference/computation-expressions.md), which represents an executing .NET task.

In general, you should use `async { }` programming in F# unless you frequently need to create or consume .NET tasks.

### Core concepts of async

You can see the basic concepts of "async" programming in the following example:

```fsharp
open System
open System.IO

// Perform an asynchronous read of a file using 'async'
let printTotalFileBytesUsingAsync (path: string) =
    async {
        let! bytes = File.ReadAllBytesAsync(path) |> Async.AwaitTask
        let fileName = Path.GetFileName(path)
        printfn $"File {fileName} has %d{bytes.Length} bytes"
    }

[<EntryPoint>]
let main argv =
    printTotalFileBytesUsingAsync "path-to-file.txt"
    |> Async.RunSynchronously

    Console.Read() |> ignore
    0
```

In the example, the `printTotalFileBytesUsingAsync` function is of type `string -> Async<unit>`. Calling the function does not actually execute the asynchronous computation. Instead, it returns an `Async<unit>` that acts as a *specification* of the work that is to execute asynchronously. It calls `Async.AwaitTask` in its body, which converts the result of <xref:System.IO.File.ReadAllBytesAsync%2A> to an appropriate type.

Another important line is the call to `Async.RunSynchronously`. This is one of the Async module starting functions that you'll need to call if you want to actually execute an F# asynchronous computation.

This is a fundamental difference with the C#/Visual Basic style of `async` programming. In F#, asynchronous computations can be thought of as **Cold tasks**. They must be explicitly started to actually execute. This has some advantages, as it allows you to combine and sequence asynchronous work much more easily than in C# or Visual Basic.

## Combine asynchronous computations

Here is an example that builds upon the previous one by combining computations:

```fsharp
open System
open System.IO

let printTotalFileBytes path =
    async {
        let! bytes = File.ReadAllBytesAsync(path) |> Async.AwaitTask
        let fileName = Path.GetFileName(path)
        printfn $"File {fileName} has %d{bytes.Length} bytes"
    }

[<EntryPoint>]
let main argv =
    argv
    |> Seq.map printTotalFileBytes
    |> Async.Parallel
    |> Async.Ignore
    |> Async.RunSynchronously

    0
```

As you can see, the `main` function has quite a few more elements. Conceptually, it does the following:

1. Transform the command-line arguments into a sequence of `Async<unit>` computations with `Seq.map`.
2. Create an `Async<'T[]>` that schedules and runs the `printTotalFileBytes` computations in parallel when it runs.
3. Create an `Async<unit>` that will run the parallel computation and ignore its result (which is a `unit[]`).
4. Explicitly run the overall composed computation with `Async.RunSynchronously`, blocking until it completes.

When this program runs, `printTotalFileBytes` runs in parallel for each command-line argument. Because asynchronous computations execute independently of program flow, there is no defined order in which they print their information and finish executing. The computations will be scheduled in parallel, but their order of execution is not guaranteed.

## Sequence asynchronous computations

Because `Async<'T>` is a specification of work rather than an already-running task, you can perform more intricate transformations easily. Here is an example that sequences a set of Async computations so they execute one after another.

```fsharp
let printTotalFileBytes path =
    async {
        let! bytes = File.ReadAllBytesAsync(path) |> Async.AwaitTask
        let fileName = Path.GetFileName(path)
        printfn $"File {fileName} has %d{bytes.Length} bytes"
    }

[<EntryPoint>]
let main argv =
    argv
    |> Seq.map printTotalFileBytes
    |> Async.Sequential
    |> Async.Ignore
    |> Async.RunSynchronously
    |> ignore
```

This will schedule `printTotalFileBytes` to execute in the order of the elements of `argv` rather than scheduling them in parallel. Because each successive operation will not be scheduled until after the preceding computation has finished executing, the computations are sequenced such that there is no overlap in their execution.

## Important Async module functions

When you write async code in F#, you'll usually interact with a framework that handles scheduling of computations for you. However, this is not always the case, so it is good to understand the various functions that can be used to schedule asynchronous work.

Because F# asynchronous computations are a _specification_ of work rather than a representation of work that is already executing, they must be explicitly started with a starting function. There are many [Async starting methods](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html#section0) that are helpful in different contexts. The following section describes some of the more common starting functions.

### Async.StartChild

Starts a child computation within an asynchronous computation. This allows multiple asynchronous computations to be executed concurrently. The child computation shares a cancellation token with the parent computation. If the parent computation is canceled, the child computation is also canceled.

Signature:

```fsharp
computation: Async<'T> * ?millisecondsTimeout: int -> Async<Async<'T>>
```

When to use:

- When you want to execute multiple asynchronous computations concurrently rather than one at a time, but not have them scheduled in parallel.
- When you wish to tie the lifetime of a child computation to that of a parent computation.

What to watch out for:

- Starting multiple computations with `Async.StartChild` isn't the same as scheduling them in parallel. If you wish to schedule computations in parallel, use `Async.Parallel`.
- Canceling a parent computation will trigger cancellation of all child computations it started.

### Async.StartImmediate

Runs an asynchronous computation, starting immediately on the current operating system thread. This is helpful if you need to update something on the calling thread during the computation. For example, if an asynchronous computation must update a UI (such as updating a progress bar), then `Async.StartImmediate` should be used.

Signature:

```fsharp
computation: Async<unit> * ?cancellationToken: CancellationToken -> unit
```

When to use:

- When you need to update something on the calling thread in the middle of an asynchronous computation.

What to watch out for:

- Code in the asynchronous computation will run on whatever thread one happens to be scheduled on. This can be problematic if that thread is in some way sensitive, such as a UI thread. In such cases, `Async.StartImmediate` is likely inappropriate to use.

### Async.StartAsTask

Executes a computation in the thread pool. Returns a <xref:System.Threading.Tasks.Task%601> that will be completed on the corresponding state once the computation terminates (produces the result, throws exception, or gets canceled). If no cancellation token is provided, then the default cancellation token is used.

Signature:

```fsharp
computation: Async<'T> * ?taskCreationOptions: TaskCreationOptions * ?cancellationToken: CancellationToken -> Task<'T>
```

When to use:

- When you need to call into a .NET API that yields a <xref:System.Threading.Tasks.Task%601> to represent the result of an asynchronous computation.

What to watch out for:

- This call will allocate an additional `Task` object, which can increase overhead if it is used often.

### Async.Parallel

Schedules a sequence of asynchronous computations to be executed in parallel, yielding an array of results in the order they were supplied. The degree of parallelism can be optionally tuned/throttled by specifying the `maxDegreeOfParallelism` parameter.

Signature:

```fsharp
computations: seq<Async<'T>> * ?maxDegreeOfParallelism: int -> Async<'T[]>
```

When to use it:

- If you need to run a set of computations at the same time and have no reliance on their order of execution.
- If you don't require results from computations scheduled in parallel until they have all completed.

What to watch out for:

- You can only access the resulting array of values once all computations have finished.
- Computations will be run whenever they end up getting scheduled. This behavior means you cannot rely on their order of their execution.

### Async.Sequential

Schedules a sequence of asynchronous computations to be executed in the order that they are passed. The first computation will be executed, then the next, and so on. No computations will be executed in parallel.

Signature:

```fsharp
computations: seq<Async<'T>> -> Async<'T[]>
```

When to use it:

- If you need to execute multiple computations in order.

What to watch out for:

- You can only access the resulting array of values once all computations have finished.
- Computations will be run in the order that they are passed to this function, which can mean that more time will elapse before the results are returned.

### Async.AwaitTask

Returns an asynchronous computation that waits for the given <xref:System.Threading.Tasks.Task%601> to complete and returns its result as an `Async<'T>`

Signature:

```fsharp
task: Task<'T> -> Async<'T>
```

When to use:

- When you are consuming a .NET API that returns a <xref:System.Threading.Tasks.Task%601> within an F# asynchronous computation.

What to watch out for:

- Exceptions are wrapped in <xref:System.AggregateException> following the convention of the Task Parallel Library; this behavior is different from how F# async generally surfaces exceptions.

### Async.Catch

Creates an asynchronous computation that executes a given `Async<'T>`, returning an `Async<Choice<'T, exn>>`. If the given `Async<'T>` completes successfully, then a `Choice1Of2` is returned with the resultant value. If an exception is thrown before it completes, then a `Choice2of2` is returned with the raised exception. If it is used on an asynchronous computation that is itself composed of many computations, and one of those computations throws an exception, the encompassing computation will be stopped entirely.

Signature:

```fsharp
computation: Async<'T> -> Async<Choice<'T, exn>>
```

When to use:

- When you are performing asynchronous work that may fail with an exception and you want to handle that exception in the caller.

What to watch out for:

- When using combined or sequenced asynchronous computations, the encompassing computation will fully stop if one of its "internal" computations throws an exception.

### Async.Ignore

Creates an asynchronous computation that runs the given computation but drops its result.

Signature:

```fsharp
computation: Async<'T> -> Async<unit>
```

When to use:

- When you have an asynchronous computation whose result is not needed. This is analogous to the `ignore` function for non-asynchronous code.

What to watch out for:

- If you must use `Async.Ignore` because you wish to use `Async.Start` or another function that requires `Async<unit>`, consider if discarding the result is okay. Avoid discarding results just to fit a type signature.

### Async.RunSynchronously

Runs an asynchronous computation and awaits its result on the calling thread. Propagates an exception should the computation yield one. This call is blocking.

Signature:

```fsharp
computation: Async<'T> * ?timeout: int * ?cancellationToken: CancellationToken -> 'T
```

When to use it:

- If you need it, use it only once in an application - at the entry point for an executable.
- When you don't care about performance and want to execute a set of other asynchronous operations at once.

What to watch out for:

- Calling `Async.RunSynchronously` blocks the calling thread until the execution completes.

### Async.Start

Starts an asynchronous computation that returns `unit` in the thread pool. Doesn't wait for its completion and/or observe an exception outcome. Nested computations started with `Async.Start` are started independently of the parent computation that called them; their lifetime is not tied to any parent computation. If the parent computation is canceled, no child computations are canceled.

Signature:

```fsharp
computation: Async<unit> * ?cancellationToken: CancellationToken -> unit
```

Use only when:

- You have an asynchronous computation that doesn't yield a result and/or require processing of one.
- You don't need to know when an asynchronous computation completes.
- You don't care which thread an asynchronous computation runs on.
- You don't have any need to be aware of or report exceptions resulting from the execution.

What to watch out for:

- Exceptions raised by computations started with `Async.Start` aren't propagated to the caller. The call stack will be completely unwound.
- Any work (such as calling `printfn`) started with `Async.Start` won't cause the effect to happen on the main thread of a program's execution.

### Interoperate with .NET

If using `async { }` programming, you may need to interoperate with a .NET library or C# codebase that uses [async/await](../../standard/async.md)-style asynchronous programming. Because C# and the majority of .NET libraries use the <xref:System.Threading.Tasks.Task%601> and <xref:System.Threading.Tasks.Task> types as their core abstractions this may change how you write your F# asynchronous code.

One option is to switch to writing .NET tasks directly using `task { }`. Alternatively, you can use the `Async.AwaitTask` function to await a .NET asynchronous computation:

```fsharp
let getValueFromLibrary param =
    async {
        let! value = DotNetLibrary.GetValueAsync param |> Async.AwaitTask
        return value
    }
```

You can use the `Async.StartAsTask` function to pass an asynchronous computation to a .NET caller:

```fsharp
let computationForCaller param =
    async {
        let! result = getAsyncResult param
        return result
    } |> Async.StartAsTask
```

To work with APIs that use <xref:System.Threading.Tasks.Task> (that is, .NET async computations that do not return a value), you may need to add an additional function that will convert an `Async<'T>` to a <xref:System.Threading.Tasks.Task>:

```fsharp
module Async =
    // Async<unit> -> Task
    let startTaskFromAsyncUnit (comp: Async<unit>) =
        Async.StartAsTask comp :> Task
```

There is already an `Async.AwaitTask` that accepts a <xref:System.Threading.Tasks.Task> as input. With this and the previously defined `startTaskFromAsyncUnit` function, you can start and await <xref:System.Threading.Tasks.Task> types from an F# async computation.

## Writing .NET tasks directly in F\#

In F#, you can write tasks directly using `task { }`, for example:

```fsharp
open System
open System.IO

/// Perform an asynchronous read of a file using 'task'
let printTotalFileBytesUsingTasks (path: string) =
    task {
        let! bytes = File.ReadAllBytesAsync(path)
        let fileName = Path.GetFileName(path)
        printfn $"File {fileName} has %d{bytes.Length} bytes"
    }

[<EntryPoint>]
let main argv =
    let task = printTotalFileBytesUsingTasks "path-to-file.txt"
    task.Wait()

    Console.Read() |> ignore
    0
```

In the example, the `printTotalFileBytesUsingTasks` function is of type `string -> Task<unit>`. Calling the function starts to execute the task.
The call to `task.Wait()` waits for the task to complete.

## Relationship to multi-threading

Although threading is mentioned throughout this article, there are two important things to remember:

1. There is no affinity between an asynchronous computation and a thread, unless explicitly started on the current thread.
1. Asynchronous programming in F# is not an abstraction for multi-threading.

For example, a computation may actually run on its caller's thread, depending on the nature of the work. A computation could also "jump" between threads, borrowing them for a small amount of time to do useful work in between periods of "waiting" (such as when a network call is in transit).

Although F# provides some abilities to start an asynchronous computation on the current thread (or explicitly not on the current thread), asynchrony generally is not associated with a particular threading strategy.

## See also

- [The F# Asynchronous Programming Model](https://www.microsoft.com/research/publication/the-f-asynchronous-programming-model)
- [Leo Gorodinski's F# Async Guide](https://medium.com/jettech/f-async-guide-eb3c8a2d180a)
- [F# for fun and profit's Asynchronous Programming guide](https://fsharpforfunandprofit.com/posts/concurrency-async-and-parallel/)
- [Async in C# and F#: Asynchronous gotchas in C#](http://tomasp.net/blog/csharp-async-gotchas.aspx/)
