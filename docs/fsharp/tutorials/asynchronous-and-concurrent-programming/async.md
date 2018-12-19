---
title: Async Programming in F#
description: Learn how F# async programming is accomplished via a language-level programming model that utilizes core functional programming concepts to allow for easy use of asynchrony in F# programming.
ms.date: 12/17/2018
---
# Async Programming in F\#

Asynchronous programming is essential to modern applications. The applications for asynchronous programming are large in number. There are two primary use cases that most developers will encounter:

* Having a non-blocking server process that can service incoming requests while awaiting results for other requests
* Having a responsive UI or main thread while background work is happening

Although background work may involve multiple threads, there is no affinity between threading and asynchrony.

## Asynchrony defined

If you consider the etymology of the word "asynchronous", there are two pieces:

* "a", meaning "not"
* "synchronous", meaning "at the same time"

Put together, "asynchronous" simply means, "not at the same time". This holds true for asynchronous programming in F#. Code that executes asynchronously is code that does not necessarily execute at the same time.

In other words, asynchronous computations execute independently of the main program flow. This does not imply any particular threading model, nor does it imply that a computation happens in the background. In fact, asynchronous computations could even execute synchronously, depending on the nature of the computation and the environment the computation is executing in.

The main takeaway you should have is that because asynchronous computations are simply independent of the main program flow, there are few guarantees about when or how a computation executes. This necessitates a means to control their execution. In F#, there are multiple ways to do this.

## Core concepts

In F#, asynchronous programming is centered around three core components:

* The `Async<'T>` type, which represents an asynchronous computation
* The `async { }` [computation expression](../../language-reference/computation-expressions.md), which provides a convenient syntax for describing and controlling asynchronous computations
* The `Async` functions, which let you start asynchronous work, coordinate multiple asynchronous computations, and transform asynchronous results

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
    |> Async.Start

    Console.Read() |> ignore
    0 // return an integer exit code
```

In the example, the `countFileBytes` function is of type `string -> Async<unit>`. Calling the function does not actually execute the asynchronous computation. Instead, it returns an `Async<unit>` that acts as a _specification_ of the work that is to execute asynchronously.

The `Async.Start` function is used to start the computation.

Additionally, `Async.AwaitTask` is called in the `countFileBytes` function. This creates an `Async<'T>` that runs <xref:System.IO.File.WriteAllBytesAsync%2A> (which returns a `Task<byte[]>`) and returns its result.

This is a key difference with the C#/VB style of `async` programming. In F#, asynchronous computations can be thought of as **Cold tasks**. They must be explicitly started to actually execute. This has some advantages, as it allows you to combine and sequence asynchronous work very easily.

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

1. Transform the command line arguments into `Async<unit>` computations with `Array.map`
2. Create an `Async<'T[]>` that will schedule and run the `countFileBytes` computations in parallel when it is ran
3. Create an `Async<unit>` that will run the parallel computation and ignore its result
4. Explicitly run the last computation with `Async.Start`

When this program is ran, `countFileBytes`is ran in parallel for each command line argument. Because asynchronous computations execute independently of program flow, there is no order in which they print their information and finish executing.

## Sequencing asynchronous computations

Because `Async<'T>` is a specification of work rather than a computation that is currently running, you can perform more intricate transformations easily. For example, here is an implementation of the Sequence monad that converts a list of `Async<'T>` into an `Async<'T>` that contains an array of results. It uses the previous `countFileBytes` function:

```fsharp
module Async =
    let sequence computations =
        async {
            let results = ResizeArray()

            for computation in computations do
                let! result = computation
                results.Add(result)

            return results.ToArray()
        }

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
    |> Async.sequence
    |> Async.RunSynchronously
    |> ignore
```

This will execute `countFileBytes` for each item in `argv` in the order of the elements of `argv` rather than executing them in parallel. This may be preferable if you wish to preserve the order of computations.

## Common async functions

Because F# asynchronous computations are a _specification_ of work rather than a representation of work that is already executing, they must be explicitly started with a starting function. There are many [Async starting functions](https://msdn.microsoft.com/library/ee370232.aspx) that are helpful in different contexts. You should take care in which to use, making sure that it is appropriate for your particular environment. The following section describes some of the more common starting functions.

### Async.Start

Starts an asynchronous computation with no return type in the thread pool. Doesn't wait for its result. Nested computations ran with `Async.Start` are independent of the parent computation that called them. If the parent computation is cancelled, the nested computations aren't cancelled.

Signature:

```fsharp
computation: Async<unit> * cancellationToken: ?CancellationToken -> unit
```

When to use:

* When you have an asynchronous computation but don't care about the result
* When you don't care about when an asynchronous computation runs
* When you don't care which thread an asynchronous computation runs on

What to watch out for:

* Exceptions raised by computations ran with `Async.Start` aren't propagated to the caller
* Any effectful work (such as calling `printfn`) ran with `Async.Start` won't cause the effect to happen on the main thread of a program's execution

### Async.StartChild

Starts a child computation within an asynchronous computation. This allows multiple asynchronous computations to be executed simultaneously. The child computation shares a cancellation token with the parent computation. When the parent is cancelled, the child is also cancelled.

Signature:

```fsharp
computation: Async<'T> * timeout: ?int -> Async<Async<'T>>
```

When to use:

* When you want to execute multiple asynchronous computation concurrently rather than one at a time, but not necessarily in parallel
* When you wish to tie the lifetime of a child computation with a parent computation

What to watch out for:

* Starting multiple computations with `Async.StartChild` isn't the same as scheduling them to run in parallel
* Cancelling a parent computation will cancel all children it started

### Async.StartImmediate

Runs an asynchronous computation, starting immediately on the current operating system thread. This is helpful if you need to update something on the calling thread during the computation. For example, if an asynchronous computation must update a UI (such as updating a progress bar), then `Async.StartImmediate` should be used.

Signature:

```fsharp
computation: Async<unit> * cancellationToken: ?CancellationToken -> unit
```

When to use:

* When you need to update something on the calling thread in the middle of an asynchronous computation

What to watch out for:

* Code in the asynchronous computation will run on the caller's thread, so if you need this thread to perform other work, `Async.StartImmediate` isn't likely an appropriate starting function

### Async.StartAsTask

Executes a computation in the thread pool. Returns a <xref:System.Threading.Tasks.Task%601> that will be completed in the corresponding state once the computation terminates (produces the result, throws exception or gets canceled). If no cancellation token is provided, then the default cancellation token is used.

Signature:

```fsharp
computation: Async<'T> * taskCreationOptions: ?TaskCreationOptions * cancellationToken: ?CancellationToken -> Task<'T>
```

When to use:

* When you need to call into a .NET API that expects a <xref:System.Threading.Tasks.Task%601> to represent the result of an asynchronous computation

What to watch out for:

* This call will allocate an additional `Task` object, which can increase overhead if it is used often

### Async.AwaitTask

Returns an asynchronous computation that waits for the given <xref:System.Threading.Tasks.Task%601> to complete and returns its result as an `Async<'T>`

Signature:

```fsharp
task: Task<'T>  -> Async<'T>
```

When to use:

* When you are consuming a .NET API that returns a <xref:System.Threading.Tasks.Task%601> within an F# asynchronous computation

What to watch out for:

* This call will allocate an additional `Async<'T>` object, which can increase overhead if it is used often

### Async.Catch

Creates an asychronous computation that executes a given `Async<'T>`, returning a `Async<Choice<'T, exn>>`. If the given `Async<'T>` completes successfully, then a `Choice1Of2` is returned with the resultant value. If it raises an exception before it completes, then a `Choice2of2` is returned with the raised exception. If it is used on an asynchronous computation that is itself composed of many computations, and one of those computations throws an exception, then encompassing computation will be stopped entirely.

Signature:

```fsharp
computation: Async<'T> -> Async<Choice<'T, exn>>
```

When to use:

* When you are performing asynchronous work that may fail with an exception and you want to handle that exception in the caller

What to watch out for:

* When using combined or sequenced asynchronous computations, the encompassing computation will fully stop if one of its "internal" computations throws an exception

### Async.Ignore

Creates an asynchronous computation that runs the given computation and ignores its result.

Signature:

```fsharp
computation: Async<'T> -> Async<unit>
```

When to use:

* When you have an asynchronous computation whose result can be discarded
* In conjunction with `Async.Start` or other functions that accept an `Async<unit>`

What to watch out for:

* If you must use this because you wish to use `Async.Start` or another function that requires `Async<unit>`, consider if discarding the result is actually okay to do. Discarding results just to fit a type signature should not generally be done

### Async.RunSynchronously

Runs an asynchronous computation and awaits its result on the calling thread. This call is blocking.

Signature:

```fsharp
computation: Async<'T> * timeout: ?int * cancellationToken: ?CancellationToken -> 'T
```

When to use:

* If you need it, use it only once in an application - at the entry point for an executable
* When you don't care about performance and want to execute a set of other asynchronous operations at once

What to watch out for:

* This function blocks the calling thread, which undoes the use of asynchrony if it is used to only execute a single `Async<'T>`

## Interoperating with .NET

You may be working with a library or C# codebase that uses [async/await](../../../standard/async.md)-style asynchronous programming. Because these use the <xref:System.Threading.Tasks.Task%601> and <xref:System.Threading.Tasks.Task> types as their core abstractions rather than `Async<'T>`, you must cross a boundary between these two approaches to asynchrony.

### How to work with .NET async and Task<T>

Working with .NET async libraries and codebases that use <xref:System.Threading.Tasks.Task%601> (i.e., async computations that have return values) is straightforward and has built-in support with F#.

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

To work with <xref:System.Threading.Tasks.Task> types (i.e., .NET async computations that have no return value) requires a bit more work. These helper functions are up to the task (pun _definitely_ intended):

```fsharp
module Async =
    // Async<unit> -> Task
    let startTaskFromAsyncUnit (comp: Async<unit>) =
        Async.StartAsTask comp :> Task

    // Task -> Async<unit>
    let awaitTaskToAsyncUnit (task: Task) =
        task.ContinueWith(fun t -> ()) |> Async.AwaitTask
```

You can then use them like so:

```fsharp
// TODO examples
```

## Relationship to multithreading

Although threading is mentioned throughout this article, there are two important things to remember:

1. There is no affinity between an asynchronous computation and a thread, unless explicitly started on the current thread
1. Asynchronous programming in F# is not an abstraction for multithreading

What this means is that **asynchronous computations are not an abstraction for multithreading**. For example, a computation may actually run on the its caller's thread, depending on the nature of the work. A computation could also "jump" between threads, borrowing them for a small amount of time to do useful work in between periods of "waiting" (such as when a network call is in transit).

Although F# provides some abilities to start an asynchronous computation on the current thread (or explicitly not on the current thread), asynchrony generally is not associated with a particular threading strategy.

## Further reading

* [The F# Asynchronous Programming Model](https://www.microsoft.com/en-us/research/publication/the-f-asynchronous-programming-model)
* [Jet.com's F# Async Guide](https://medium.com/jettech/f-async-guide-eb3c8a2d180a)
* [F# for fun and profit's Asynchronous Programming guide](https://fsharpforfunandprofit.com/posts/concurrency-async-and-parallel/)
* [Async in C# and F#: Asynchronous gotchas in C#](http://tomasp.net/blog/csharp-async-gotchas.aspx/)
