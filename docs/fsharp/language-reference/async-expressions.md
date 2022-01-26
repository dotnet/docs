---
title: Async Expressions
description: Learn about support in the F# programming language for writing async expressions, which execute without blocking execution of other work.
ms.date: 10/29/2021
---
# Async expressions

This article describes support in F# for async expressions. Async expressions provide one way of performing computations asynchronously, that is, without blocking execution of other work. For example, asynchronous computations can be used to write apps that have UIs that remain responsive to users as the application performs other work.

Asynchronous code can also be authored using [task expressions](task-expressions.md), which create .NET tasks directly. Using task expressions is preferred when interoperating extensively with .NET libraries that create or consume .NET tasks. When writing most asynchronous code in F#, F# async expressions are preferred because they are more succinct, more compositional, and avoid certain caveats associated with .NET tasks.

## Syntax

```fsharp
async { expression }
```

## Remarks

In the previous syntax, the computation represented by `expression` is set up to run asynchronously, that is, without blocking the current computation thread when asynchronous sleep operations, I/O, and other asynchronous operations are performed. Asynchronous computations are often started on a background thread while execution continues on the current thread. The type of the expression is `Async<'T>`, where `'T` is the type returned by the expression when the `return` keyword is used.

The [`Async`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html) class provides methods that support several scenarios. The general approach is to create `Async` objects that represent the computation or computations that you want to run asynchronously, and then start these computations by using one of the triggering functions. The triggering you use depends on whether you want to use the current thread, a background thread, or a .NET task object. For example, to start an async computation on the current thread, you can use [`Async.StartImmediate`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html#StartImmediate). When you start an async computation from the UI thread, you do not block the main event loop that processes user actions such as keystrokes and mouse activity, so your application remains responsive.

## Asynchronous Binding by Using let!

In an async expression, some expressions and operations are synchronous, and some are asynchronous. When you call a method asynchronously, instead of an ordinary `let` binding, you use `let!`. The effect of `let!` is to enable execution to continue on other computations or threads as the computation is being performed. After the right side of the `let!` binding returns, the rest of the async expression resumes execution.

The following code shows the difference between `let` and `let!`. The line of code that uses `let` just creates an asynchronous computation as an object that you can run later by using, for example, `Async.StartImmediate` or [`Async.RunSynchronously`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html#RunSynchronously). The line of code that uses `let!` starts the computation and performs an asynchronous wait: the thread is suspended until the result is available, at which point execution continues.

```fsharp
// let just stores the result as an asynchronous operation.
let (result1 : Async<byte[]>) = stream.AsyncRead(bufferSize)
// let! completes the asynchronous operation and returns the data.
let! (result2 : byte[])  = stream.AsyncRead(bufferSize)
```

`let!` can only be used to await F# async computations [`Async<T>`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html) directly. You can await other kinds of asynchronous operations indirectly:

* .NET tasks, <xref:System.Threading.Tasks.Task%601> and the non-generic <xref:System.Threading.Tasks.Task>, by combining with `Async.AwaitTask`
* .NET value tasks, <xref:System.Threading.Tasks.ValueTask%601> and the non-generic <xref:System.Threading.Tasks.ValueTask>, by combining with `.AsTask()` and `Async.AwaitTask`
* Any object following the "GetAwaiter" pattern specified in [F# RFC FS-1097](https://github.com/fsharp/fslang-design/blob/main/FSharp-6.0/FS-1097-task-builder.md), by combining with `task { return! expr } |> Async.AwaitTask`.

## Control Flow

Async expressions can include control-flow constructs, such as `for .. in .. do`, `while .. do`, `try .. with ..`, `try .. finally ..`, `if .. then .. else`, and `if .. then ..`. These may, in turn, include further async constructs, with the exception of the `with` and `finally` handlers, which execute synchronously.

F# async expressions don't support asynchronous `try .. finally ..`. You can use a [task expression](task-expressions.md) for this case.

## `use` and `use!` bindings

Within async expressions, `use` bindings can bind to values of type <xref:System.IDisposable>. For the latter, the disposal cleanup operation is executed asynchronously.

In addition to `let!`, you can use `use!` to perform asynchronous bindings. The difference between `let!` and `use!` is the same as the difference between `let` and `use`. For `use!`, the object is disposed of at the close of the current scope. Note that in the current release of F#, `use!` does not allow a value to be initialized to null, even though `use` does.

## Asynchronous Primitives

A method that performs a single asynchronous task and returns the result is called an *asynchronous primitive*, and these are designed specifically for use with `let!`. Several asynchronous primitives are defined in the F# core library. Two such methods for Web applications are defined in the module [`FSharp.Control.WebExtensions`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-webextensions.html): [`WebRequest.AsyncGetResponse`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-webextensions.html#AsyncGetResponse) and [`WebClient.AsyncDownloadString`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-webextensions.html#AsyncDownloadString). Both primitives download data from a Web page, given a URL. `AsyncGetResponse` produces a `System.Net.WebResponse` object, and `AsyncDownloadString` produces a string that represents the HTML for a Web page.

Several primitives for asynchronous I/O operations are included in the [`FSharp.Control.CommonExtensions`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-commonextensions.html) module. These extension methods of the `System.IO.Stream` class are [`Stream.AsyncRead`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-commonextensions.html#AsyncRead) and [`Stream.AsyncWrite`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-commonextensions.html#AsyncWrite).

You can also write your own asynchronous primitives by defining a function or method whose body is an async expression.

To use asynchronous methods in the .NET Framework that are designed for other asynchronous models with the F# asynchronous programming model, you create a function that returns an F# `Async` object. The F# library has functions that make this easy to do.

One example of using async expressions is included here; there are many others in the documentation for the methods of the [Async class](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html).

This example shows how to use async expressions to execute code in parallel.

In the following code example, a function `fetchAsync` gets the HTML text returned from a Web request. The `fetchAsync` function contains an asynchronous block of code. When a binding is made to the result of an asynchronous primitive, in this case [`AsyncDownloadString`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-webextensions.html#AsyncDownloadString), `let!` is used instead of `let`.

You use the function [`Async.RunSynchronously`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html#RunSynchronously) to execute an asynchronous operation and wait for its result. As an example, you can execute multiple asynchronous operations in parallel by using the [`Async.Parallel`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html#Parallel) function together with the `Async.RunSynchronously` function. The `Async.Parallel` function takes a list of the `Async` objects, sets up the code for each `Async` task object to run in parallel, and returns an `Async` object that represents the parallel computation. Just as for a single operation, you call `Async.RunSynchronously` to start the execution.

The `runAll` function launches three async expressions in parallel and waits until they have all completed.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet8003.fs)]

## See also

- [F# Language Reference](index.md)
- [Computation Expressions](computation-expressions.md)
- [Task Expressions](task-expressions.md)
- [Control.Async Class](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html)
