---
title: Async Programming in F#
description: Learn how F# provides clean support for asynchrony based on a language-level programming model derived from core functional programming concepts.
ms.date: 12/17/2018
---
# Async Programming in F\#

Asynchronous programming is a mechanism that is essential to modern applications for diverse reasons. There are two primary use cases that most developers will encounter:

* Presenting a server process that can service a significant number of concurrent incoming requests, while minimizing the system resources locked while request processing awaits inputs from systems or services external to that process
* Maintaining a responsive UI or main thread while concurrently progressing background work

Although background work often does involve the utilization of multiple threads, it's important to consider the concepts of asynchrony and multi-threading separately. In fact, they are separate concerns, and one does not imply the other. What follows in this article will describe this in more detail.

## Asynchrony defined

The previous point - that asynchrony is independent of the utilization of multiple threads - is worth explaining a bit further. There are three concepts that are sometimes related, but strictly independent of one another:

* Concurrency, which is when multiple computations execute in overlapping time periods
* Parallelism, which is when multiple computations or several parts of a unique computation run at exactly the same time
* Asynchrony, which is when one or more computations can execute separately from the main program flow

All three are orthogonal concepts, but can be easily conflated, especially when they are used together. For example, you may need to execute multiple asynchronous computations in parallel. This does not mean that parallelism or asynchrony imply one another in this situation.

If you consider the etymology of the word "asynchronous", there are two pieces involved:

* "a", meaning "not"
* "synchronous", meaning "at the same time"

When you put these two terms together, you'll see that "asynchronous" means "not at the same time". That's it! There is no implication of concurrency or parallelism in this definition. This is also true in practice.

In practical terms, asynchronous computations in F# are scheduled to execute independently of the main program flow. This doesn't imply concurrency or parallelism, nor does it imply that a computation always happens in the background. In fact, asynchronous computations could even execute synchronously, depending on the nature of the computation and the environment the computation is executing in.

The main takeaway you should have is that asynchronous computations are independent of the main program flow. Although there are few guarantees about when or how an asynchronous computation executes, there are some approaches to orchestrating and scheduling them. The rest of this article explores core concepts for F# asynchrony and how to use the types, functions, and expressions built into F#.

## Core concepts

In F#, asynchronous programming is centered around three core concepts:

* The `Async<'T>` type, which represents a composable asynchronous computation
* The `Async` module functions, which let you schedule asynchronous work, compose multiple asynchronous computations, and transform asynchronous results
* The `async { }` [computation expression](../../language-reference/computation-expressions.md), which provides a convenient syntax for describing and controlling asynchronous computations

You can see these three concepts in the following example:

```fsharp
open System
open System.IO

let countFileBytes path =
    async {
        let! bytes = File.ReadAllBytesAsync(path) |> Async.AwaitTask
        let fileName = Path.GetFileName(path)
        printfn "File %s has %d bytes" fileName bytes.Length
    }

[<EntryPoint>]
let main argv =
    countFileBytes "path-to-file.txt"
    |> Async.RunSynchronously

    Console.Read() |> ignore
    0 // return an integer exit code
```

In the example, the `countFileBytes` function is of type `string -> Async<unit>`. Calling the function does not actually execute the asynchronous computation. Instead, it returns an `Async<unit>` that acts as a _specification_ of the work that is to execute asynchronously. It calls `Async.AwaitTask` in its body, which will convert the result of <xref:System.IO.File.WriteAllBytesAsync%2A> to an appropriate type when it is called.

Another important line is the call to `Async.RunSynchronously`. This is one of the async starting functions that you'll need to call if you want to actually execute an F# asynchronous computation.

This is a key difference with the C#/VB style of `async` programming. In F#, asynchronous computations can be thought of as **Cold tasks**. They must be explicitly started to actually execute. This has some advantages, as it allows you to combine and sequence asynchronous work much more easily than in C#/VB.

## Combining asynchronous computations

Here is an example that builds upon the previous one by combining computations:

```fsharp
open System
open System.IO

let countFileBytes path =
    async {
        let! bytes = File.ReadAllBytesAsync(path) |> Async.AwaitTask
        let fileName = Path.GetFileName(path)
        printfn "File %s has %d bytes" fileName bytes.Length
    }

[<EntryPoint>]
let main argv =
    argv
    |> Array.map countFileBytes
    |> Async.Parallel
    |> Async.Ignore
    |> Async.Start

    Console.Read() |> ignore
    0 // return an integer exit code
```

As you can see, the `main` function has quite a few more calls made. Conceptually, it does the following:

1. Transform the command-line arguments into `Async<unit>` computations with `Array.map`
2. Create an `Async<'T[]>` that schedules and runs the `countFileBytes` computations in parallel when it runs.
3. Create an `Async<unit>` that will run the parallel computation and ignore its result
4. Explicitly run the last computation with `Async.Start`

When this program runs, `countFileBytes` runs in parallel for each command-line argument. Because asynchronous computations execute independently of program flow, there is no order in which they print their information and finish executing.

## Sequencing asynchronous computations

Because `Async<'T>` is a specification of work rather than an already-running task, you can perform more intricate transformations easily. Here is an example where you can sequence a set of computations so they execute one after another.

```fsharp
let countFileBytes path =
    async {
        let! bytes = File.ReadAllBytesAsync(path) |> Async.AwaitTask
        let fileName = Path.GetFileName(path)
        printfn "File %s has %d bytes" fileName bytes.Length
    }

[<EntryPoint>]
let main argv =
    argv
    |> Array.map countFileBytes
    |> Async.Sequential
    |> Async.RunSynchronously
    |> ignore
```

This will execute `countFileBytes` for each item in `argv` in the order of the elements of `argv` rather than executing them in parallel.

## Key async module functions

When you write async code in F# you'll usually interact with a framework that handles scheduling of computations for you. However, this is not always the case, so it is good to learn the various starting functions to schedule asynchronous work.

Because F# asynchronous computations are a _specification_ of work rather than a representation of work that is already executing, they must be explicitly started with a starting function. There are many [Async starting functions](https://msdn.microsoft.com/library/ee370232.aspx) that are helpful in different contexts.The following section describes some of the more common starting functions.

### Async.StartChild

Starts a child computation within an asynchronous computation. This allows multiple asynchronous computations to be executed simultaneously. The child computation shares a cancellation token with the parent computation. When the parent is canceled, the child is also canceled.

Signature:

```fsharp
computation: Async<'T> * timeout: ?int -> Async<Async<'T>>
```

When to use:

* When you want to execute multiple asynchronous computations concurrently rather than one at a time, but not necessarily in parallel.
* When you wish to tie the lifetime of a child computation with a parent computation.

What to watch out for:

* Starting multiple computations with `Async.StartChild` isn't the same as scheduling them to run in parallel.
* Canceling a parent computation will cancel all children it started.

### Async.StartImmediate

Runs an asynchronous computation, starting immediately on the current operating system thread. This is helpful if you need to update something on the calling thread during the computation. For example, if an asynchronous computation must update a UI (such as updating a progress bar), then `Async.StartImmediate` should be used.

Signature:

```fsharp
computation: Async<unit> * cancellationToken: ?CancellationToken -> unit
```

When to use:

* When you need to update something on the calling thread in the middle of an asynchronous computation.

What to watch out for:

* Code in the asynchronous computation will run on the caller's thread, so if you need this thread to perform other work, `Async.StartImmediate` isn't likely an appropriate starting function.

### Async.StartAsTask

Executes a computation in the thread pool. Returns a <xref:System.Threading.Tasks.Task%601> that will be completed in the corresponding state once the computation terminates (produces the result, throws exception, or gets canceled). If no cancellation token is provided, then the default cancellation token is used.

Signature:

```fsharp
computation: Async<'T> * taskCreationOptions: ?TaskCreationOptions * cancellationToken: ?CancellationToken -> Task<'T>
```

When to use:

* When you need to call into a .NET API that expects a <xref:System.Threading.Tasks.Task%601> to represent the result of an asynchronous computation.

What to watch out for:

* This call will allocate an additional `Task` object, which can increase overhead if it is used often.

### Async.Parallel

Schedules a sequence of asynchronous computations to be executed in parallel. The degree of parallelism can be optionally tuned/throttled by specifying the `maxDegreesOfParallelism` parameter.

Signature:

```fsharp
computations: seq<Async<'T>> * maxDegreesOfParallelism: ?int -> Async<'T[]>
```

When to use it:

* If you need to run a set of computations at the same time and have no reliance on their order of execution.

What to watch out for:

* Computations will be run however they end up getting scheduled. This means you cannot rely on their order of their execution.

### Async.Sequential

Schedules a sequence of asynchronous computations to be executed in the order that they are passed. The first computation will be executed, then the next, and so on. No computations will be executed in parallel.

Signature:

```fsharp
computations: seq<Async<'T>> -> Async<'T[]>
```

When to use it:

* If you need to execute multiple computations in order and/or you rely on their order of execution.

What to watch out for:

* Computations will be run in the order that they are passed to this function, which can mean significantly more time spent to get a result when compared with `Async.Parallel`.

### Async.AwaitTask

Returns an asynchronous computation that waits for the given <xref:System.Threading.Tasks.Task%601> to complete and returns its result as an `Async<'T>`

Signature:

```fsharp
task: Task<'T>  -> Async<'T>
```

When to use:

* When you are consuming a .NET API that returns a <xref:System.Threading.Tasks.Task%601> within an F# asynchronous computation.

What to watch out for:

* This call will allocate an additional `Async<'T>` object, which can increase overhead if it is used often.

### Async.Catch

Creates an asynchronous computation that executes a given `Async<'T>`, returning an `Async<Choice<'T, exn>>`. If the given `Async<'T>` completes successfully, then a `Choice1Of2` is returned with the resultant value. If it raises an exception before it completes, then a `Choice2of2` is returned with the raised exception. If it is used on an asynchronous computation that is itself composed of many computations, and one of those computations throws an exception, then encompassing computation will be stopped entirely.

Signature:

```fsharp
computation: Async<'T> -> Async<Choice<'T, exn>>
```

When to use:

* When you are performing asynchronous work that may fail with an exception and you want to handle that exception in the caller.

What to watch out for:

* When using combined or sequenced asynchronous computations, the encompassing computation will fully stop if one of its "internal" computations throws an exception.

### Async.Ignore

Creates an asynchronous computation that runs the given computation and ignores its result.

Signature:

```fsharp
computation: Async<'T> -> Async<unit>
```

When to use:

* When you have an asynchronous computation whose result can be discarded.
* In conjunction with `Async.Start` or other functions that accept an `Async<unit>`.

What to watch out for:

* If you must use this because you wish to use `Async.Start` or another function that requires `Async<unit>`, consider if discarding the result is okay to do. Discarding results just to fit a type signature should not generally be done

### Async.RunSynchronously

Runs an asynchronous computation and awaits its result on the calling thread. This call is blocking.

Signature:

```fsharp
computation: Async<'T> * timeout: ?int * cancellationToken: ?CancellationToken -> 'T
```

When to use it:

* If you need it, use it only once in an application - at the entry point for an executable.
* When you don't care about performance and want to execute a set of other asynchronous operations at once.

What to watch out for:

* This function blocks the calling thread, which nullifies the point of asynchrony if it is used to only execute a single `Async<'T>`

### Async.Start

Starts an asynchronous computation with no return type in the thread pool. Doesn't wait for its result. Nested computations ran with `Async.Start` are ran completely independently of the parent computation that called them. If the parent computation is canceled, the nested computations aren't canceled.

Signature:

```fsharp
computation: Async<unit> * cancellationToken: ?CancellationToken -> unit
```

Use only when:

* You have an asynchronous computation but don't care about the result.
* You don't care about when an asynchronous computation runs.
* You don't care which thread an asynchronous computation runs on.
* You don't have any need to be aware of or report exceptions resulting from the task.

What to watch out for:

* Exceptions raised by computations started with `Async.Start` aren't propagated to the caller.
* Any effectual work (such as calling `printfn`) started with `Async.Start` won't cause the effect to happen on the main thread of a program's execution.

## Interoperating with .NET

You may be working with a .NET library or C# codebase that uses [async/await](../../../standard/async.md)-style asynchronous programming. Because C# and the majority of .NET libraries use the <xref:System.Threading.Tasks.Task%601> and <xref:System.Threading.Tasks.Task> types as their core abstractions rather than `Async<'T>`, you must cross a boundary between these two approaches to asynchrony.

### How to work with .NET async and `Task<T>`

Working with .NET async libraries and codebases that use <xref:System.Threading.Tasks.Task%601> (that is, async computations that have return values) is straightforward and has built-in support with F#.

You can use the `Async.AwaitTask` function to await a .NET asynchronous computation:

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

### How to work with .NET async and Task

To work with APIs that use <xref:System.Threading.Tasks.Task> (that is, .NET async computations that have no return value), you may need to add an additional function that will convert an `Async<'T>` to a <xref:System.Threading.Tasks.Task>:

```fsharp
module Async =
    // Async<unit> -> Task
    let startTaskFromAsyncUnit (comp: Async<unit>) =
        Async.StartAsTask comp :> Task
```

There is already an `Async.AwaitTask` that accepts a <xref:System.Threading.Tasks.Task> as input. With this and the previously defined `startTaskFromAsyncUnit` function, you can start and await <xref:System.Threading.Tasks.Task> types from an F# async computation.

## Relationship to multithreading

Although threading is mentioned throughout this article, there are two important things to remember:

1. There is no affinity between an asynchronous computation and a thread, unless explicitly started on the current thread
1. Asynchronous programming in F# is not an abstraction for multithreading

What this means is that **asynchronous computations are not an abstraction for multithreading**. For example, a computation may actually run on its caller's thread, depending on the nature of the work. A computation could also "jump" between threads, borrowing them for a small amount of time to do useful work in between periods of "waiting" (such as when a network call is in transit).

Although F# provides some abilities to start an asynchronous computation on the current thread (or explicitly not on the current thread), asynchrony generally is not associated with a particular threading strategy.

## See also

* [The F# Asynchronous Programming Model](https://www.microsoft.com/en-us/research/publication/the-f-asynchronous-programming-model)
* [Jet.com's F# Async Guide](https://medium.com/jettech/f-async-guide-eb3c8a2d180a)
* [F# for fun and profit's Asynchronous Programming guide](https://fsharpforfunandprofit.com/posts/concurrency-async-and-parallel/)
* [Async in C# and F#: Asynchronous gotchas in C#](http://tomasp.net/blog/csharp-async-gotchas.aspx/)
