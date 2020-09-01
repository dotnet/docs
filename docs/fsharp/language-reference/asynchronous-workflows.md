---
title: Asynchronous Workflows
description: Learn about support in the F# programming language for performing computations asynchronously, which execute without blocking execution of other work.
ms.date: 08/15/2020
---
# Asynchronous workflows

This article describes support in F# for performing computations asynchronously, that is, without blocking execution of other work. For example, asynchronous computations can be used to write applications that have UIs that remain responsive to users as the application performs other work.

## Syntax

```fsharp
async { expression }
```

## Remarks

In the previous syntax, the computation represented by `expression` is set up to run asynchronously, that is, without blocking the current computation thread when asynchronous sleep operations, I/O, and other asynchronous operations are performed. Asynchronous computations are often started on a background thread while execution continues on the current thread. The type of the expression is `Async<'T>`, where `'T` is the type returned by the expression when the `return` keyword is used. The code in such an expression is referred to as an *asynchronous block*, or *async block*.

There are a variety of ways of programming asynchronously, and the [`Async`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html) class provides methods that support several scenarios. The general approach is to create `Async` objects that represent the computation or computations that you want to run asynchronously, and then start these computations by using one of the triggering functions. The various triggering functions provide different ways of running asynchronous computations, and which one you use depends on whether you want to use the current thread, a background thread, or a .NET Framework task object, and whether there are continuation functions that should run when the computation finishes. For example, to start an asynchronous computation on the current thread, you can use [`Async.StartImmediate`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html#StartImmediate). When you start an asynchronous computation from the UI thread, you do not block the main event loop that processes user actions such as keystrokes and mouse activity, so your application remains responsive.

## Asynchronous Binding by Using let!

In an asynchronous workflow, some expressions and operations are synchronous, and some are longer computations that are designed to return a result asynchronously. When you call a method asynchronously, instead of an ordinary `let` binding, you use `let!`. The effect of `let!` is to enable execution to continue on other computations or threads as the computation is being performed. After the right side of the `let!` binding returns, the rest of the asynchronous workflow resumes execution.

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

Several primitives for asynchronous I/O operations are included in the [`FSharp.Control.CommonExtensions`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-commonextensions.html) module. These extension methods of the `System.IO.Stream` class are [`Stream.AsyncRead`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-commonextensions.html#AsyncRead) and [`Stream.AsyncWrite`](hhttps://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-commonextensions.html#AsyncWrite).

You can also write your own asynchronous primitives by defining a function whose complete body is enclosed in an async block.

To use asynchronous methods in the .NET Framework that are designed for other asynchronous models with the F# asynchronous programming model, you create a function that returns an F# `Async` object. The F# library has functions that make this easy to do.

One example of using asynchronous workflows is included here; there are many others in the documentation for the methods of the [Async class](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html).

This example shows how to use asynchronous workflows to perform computations in parallel.

In the following code example, a function `fetchAsync` gets the HTML text returned from a Web request. The `fetchAsync` function contains an asynchronous block of code. When a binding is made to the result of an asynchronous primitive, in this case [`AsyncDownloadString`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-webextensions.html#AsyncDownloadString), `let!` is used instead of `let`.

You use the function [`Async.RunSynchronously`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html#RunSynchronously) to execute an asynchronous operation and wait for its result. As an example, you can execute multiple asynchronous operations in parallel by using the [`Async.Parallel`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html#Parallel) function together with the `Async.RunSynchronously` function. The `Async.Parallel` function takes a list of the `Async` objects, sets up the code for each `Async` task object to run in parallel, and returns an `Async` object that represents the parallel computation. Just as for a single operation, you call `Async.RunSynchronously` to start the execution.

The `runAll` function launches three asynchronous workflows in parallel and waits until they have all completed.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet8003.fs)]

## See also

- [F# Language Reference](index.md)
- [Computation Expressions](computation-expressions.md)
- [Control.Async Class](https://msdn.microsoft.com/visualfsharpdocs/conceptual/control.async-class-%5bfsharp%5d)
