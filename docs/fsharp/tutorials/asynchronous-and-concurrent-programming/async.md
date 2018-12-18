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

The main takeaway you should have is that because asynchronous computations are simply independent of the main program flow, there are few guarantees about when or how a computation will execute. This necessitates a means to control their execution. In F#, there are multiple ways to do this.

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

Additionally, `Async.AwaitTask` is called in the `countFileBytes` function. This creates an `Async<'T>` that runs <xref:File.ReadAllBytesAsync> (which returns a `Task<byte[]>`) and returns its result.

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

When this program is ran, `countFileBytes` will be ran in parallel for each command line argument. Because asynchronous computations execute independently of program flow, there is no order in which they will print their information and finish executing.

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

This will execute `countFileBytes` in order rather than executing them in parallel. This may be preferable if you wish to preserve the order of computations.

## Common async starting functions

Because F# asynchronous computations are a _specification_ of work rather than a representation of work that is already executing, they must be explicitly started with a starting function. There are many [Async starting functions](https://msdn.microsoft.com/library/ee370232.aspx) that are helpful in different contexts. You should take care in which to use, making sure that it is appropriate for your particular environment. The following section describes some of the more common starting functions.

### `Async.Start`

Starts an asynchronous computation with no return type in the thread pool. Does not wait for its result. Nested computations ran with `Async.Start` are independent of the parent computation that called them. If the parent computation is cancelled, the nested computations are not cancelled.

Signature:

```fsharp
computation: Async<unit> * cancellationToken: ?CancellationToken -> unit
```

When to use:

* When you have an asynchronous computation but don't care about the result
* When you don't care about when an asynchronous computation runs
* When you don't care which thread an asynchronous computation runs on

What to watch out for:

* Exceptions raised by computations ran with `Async.Start` are not propagated to the caller
* Any effectful work (such as calling `printfn`) ran with `Async.Start` will not cause the effect to happen on the main thread of a program's execution

### `Async.StartChild`

Starts a child computation within an asynchronous computation. This allows multiple asynchronous computations to be executed simultaneously. The child computation shares a cancellation token with the parent computation. When the parent is cancelled, the child is also cancelled.

Signature:

```fsharp
computation: Async<'T> * timeout: ?int -> Async<Async<'T>>
```

When to use:

* When you want to execute multiple asynchronous computation concurrently rather than one at a time, but not necessarily in parallel
* When you wish to tie the lifetime of a child computation with a parent computation

What to watch out for:

* Starting multiple computations with `Async.StartChild` is not the same as scheduling them to run in parallel
* Cancelling a parent computation will cancel all children it started

### `Async.StartImmediate`

Runs an asynchronous computation, starting immediately on the current operating system thread. This is helpful if you need to update something on the calling thread during the computation. For example, if an asynchronous computation must update a UI (such as updating a progress bar), then `Async.StartImmediate` should be used.

Signature:

```fsharp
computation: Async<unit> * cancellationToken: ?CancellationToken -> unit
```

When to use:

* When you need to update something on the calling thread in the middle of an asynchronous computation

What to watch out for:

* Code in the asynchronous computation will run on the caller's thread, so if you need this thread to perform other work, `Async.StartImmediate` is likely not an appropriate starting function

### `Async.StartAsTask`

Executes a computation in the thread pool. Returns a <xref:System.Threading.Task`1> that will be completed in the corresponding state once the computation terminates (produces the result, throws exception or gets canceled). If no cancellation token is provided, then the default cancellation token is used.

Signature:

```fsharp
computation: Async<'T> * taskCreationOptions: ?TaskCreationOptions * cancellationToken: ?CancellationToken -> Task<'T>
```

When to use:

* When you need to call into a .NET API that expects a <xref:System.Threading.Task`1> to represent the result of an asynchronous computation

What to watch out for:

* This call will allocate an additional `Task` object, which can increase overhead if it is used often

### `Async.RunSynchronously`

Runs an asynchronous computation and awaits its result on the calling thread. This call is blocking.

Signature:

```fsharp
computation: Async<'T> * timeout: ?int * cancellationToken: ?CancellationToken -> 'T
```

When to use:

* Only once at the entry point for an executable
* When you do not care about performance and want to execute a set of other asynchronous operations, such as the previous example using `Async.Parallel`

What to watch out for:

* This function blocks the calling thread, which undoes the use of asynchrony if it is used to only execute a single `Async<'T>`

## A Note on Threads

The phrase "on another thread" is mentioned above, but it is important to know that **this does not mean that async computations are a facade for multithreading**. The computation can actually "jump" between threads, borrowing them for a small amount of time to do useful work. When an async computation is effectively "waiting" (for example, waiting for a network call to return something), any thread it was borrowing at the time is freed up to go do useful work on something else. This allows async computations to utilize the system they run on as effectively as possible.

## Further reading

* [The F# Asynchronous Programming Model](https://www.microsoft.com/en-us/research/publication/the-f-asynchronous-programming-model)
* [Jet.com's F# Async Guide](https://medium.com/jettech/f-async-guide-eb3c8a2d180a)
* [F# for fun and profit's Asynchronous Programming guide](https://fsharpforfunandprofit.com/posts/concurrency-async-and-parallel/)
* [Async in C# and F#: Asynchronous gotchas in C#](http://tomasp.net/blog/csharp-async-gotchas.aspx/)
