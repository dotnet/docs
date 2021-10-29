---
title: Task expressions
description: Learn about support in the F# programming language for writing task expressions, which author .NET tasks directly.
ms.date: 10/29/2021
---
# Tasks expressions

This article describes support in F# for task expressions, which are similar to [async expressions](async-expressions.md), and which allow you to author .NET tasks directly. Like async expressions, task expressions execute code asynchronously, that is, without blocking execution of other work.

Asynchronous code is normally authored [async expressions](async-expressions.md). Using task expressions is preferred when interoperating extensively with .NET libraries that create or consume .NET tasks.

## Syntax

```fsharp
task { expression }
```

## Remarks

In the previous syntax, the computation represented by `expression` is set up to run as a .NET task. The task is started immediately this code is executed and runs on the current thread until its first asynchronous operation is performed (e.g. an asynchronous sleep, asynchronous I/O or other primitive asynchronous operation). The type of the expression is `Task<'T>`, where `'T` is the type returned by the expression when the `return` keyword is used.

## Binding by Using let!

In a task expression, some expressions and operations are synchronous, and some are longer computations that are designed to return a result asynchronously. When you call a method asynchronously, instead of an ordinary `let` binding, you use `let!`. The effect of `let!` is to enable execution to continue on other computations or threads as the computation is being performed. After the right side of the `let!` binding returns, the rest of the task resumes execution.

The following code shows the difference between `let` and `let!`. The line of code that uses `let` just creates an asynchronous computation as an object that you can run later by using, for example, `Async.StartImmediate` or [`Async.RunSynchronously`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html#RunSynchronously). The line of code that uses `let!` starts the computation, and then the thread is suspended until the result is available, at which point execution continues.

```fsharp
// let just stores the result as an asynchronous operation.
let (result1 : Async<byte[]>) = stream.AsyncRead(bufferSize)
// let! completes the asynchronous operation and returns the data.
let! (result2 : byte[])  = stream.AsyncRead(bufferSize)
```

In addition to `let!`, you can use `use!` to perform asynchronous bindings. The difference between `let!` and `use!` is the same as the difference between `let` and `use`. For `use!`, the object is disposed of at the close of the current scope. Note that in the current release of the F# language, `use!` does not allow a value to be initialized to null, even though `use` does.

## Asynchronous Primitives

A method that performs a single asynchronous task and returns the result is called an *asynchronous primitive*, and these are designed specifically for use with `let!`. Several asynchronous primitives are defined in the F# core library. Two such methods for Web applications are defined in the module [`FSharp.Control.WebExtensions`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-webextensions.html): [`WebRequest.AsyncGetResponse`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-webextensions.html#AsyncGetResponse) and [`WebClient.AsyncDownloadString`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-webextensions.html#AsyncDownloadString). Both primitives download data from a Web page, given a URL. `AsyncGetResponse` produces a `System.Net.WebResponse` object, and `AsyncDownloadString` produces a string that represents the HTML for a Web page.

Several primitives for asynchronous I/O operations are included in the [`FSharp.Control.CommonExtensions`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-commonextensions.html) module. These extension methods of the `System.IO.Stream` class are [`Stream.AsyncRead`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-commonextensions.html#AsyncRead) and [`Stream.AsyncWrite`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-commonextensions.html#AsyncWrite).

You can also write your own asynchronous primitives by defining a function whose complete body is enclosed in an async block.

To use asynchronous methods in the .NET Framework that are designed for other asynchronous models with the F# asynchronous programming model, you create a function that returns an F# `Async` object. The F# library has functions that make this easy to do.

One example of using async expressions is included here; there are many others in the documentation for the methods of the [Async class](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html).

This example shows how to use async expressions to perform computations in parallel.

In the following code example, a function `fetchAsync` gets the HTML text returned from a Web request. The `fetchAsync` function contains an asynchronous block of code. When a binding is made to the result of an asynchronous primitive, in this case [`AsyncDownloadString`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-webextensions.html#AsyncDownloadString), `let!` is used instead of `let`.

You use the function [`Async.RunSynchronously`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html#RunSynchronously) to execute an asynchronous operation and wait for its result. As an example, you can execute multiple asynchronous operations in parallel by using the [`Async.Parallel`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html#Parallel) function together with the `Async.RunSynchronously` function. The `Async.Parallel` function takes a list of the `Async` objects, sets up the code for each `Async` task object to run in parallel, and returns an `Async` object that represents the parallel computation. Just as for a single operation, you call `Async.RunSynchronously` to start the execution.

The `runAll` function launches three async expressions in parallel and waits until they have all completed.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet8003.fs)]

## See also

- [F# Language Reference](index.md)
- [Computation Expressions](computation-expressions.md)
- [Control.Async Class](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html)
