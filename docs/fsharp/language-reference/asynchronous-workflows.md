---
title: Asynchronous Workflows (F#)
description: Learn about support in the F# programming language for performing computations asynchronously, which execute without blocking execution of other work.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: ee2bb9bf-e04a-4fbe-bf58-46d07229e981 
---

# Asynchronous Workflows

> [!NOTE]
The API reference link will take you to MSDN.  The docs.microsoft.com API reference is not complete.

This topic describes support in F# for performing computations asynchronously, that is, without blocking execution of other work. For example, asynchronous computations can be used to write applications that have UIs that remain responsive to users as the application performs other work.

## Syntax

```fsharp
async { expression }
```

## Remarks

In the previous syntax, the computation represented by `expression` is set up to run asynchronously, that is, without blocking the current computation thread when asynchronous sleep operations, I/O, and other asynchronous operations are performed. Asynchronous computations are often started on a background thread while execution continues on the current thread. The type of the expression is `Async<'T>`, where `'T` is the type returned by the expression when the `return` keyword is used. The code in such an expression is referred to as an *asynchronous block*, or *async block*.

There are a variety of ways of programming asynchronously, and the [`Async`](https://msdn.microsoft.com/library/03eb4d12-a01a-4565-a077-5e83f17cf6f7) class provides methods that support several scenarios. The general approach is to create `Async` objects that represent the computation or computations that you want to run asynchronously, and then start these computations by using one of the triggering functions. The various triggering functions provide different ways of running asynchronous computations, and which one you use depends on whether you want to use the current thread, a background thread, or a .NET Framework task object, and whether there are continuation functions that should run when the computation finishes. For example, to start an asynchronous computation on the current thread, you can use [`Async.StartImmediate`](https://msdn.microsoft.com/library/2f71d1cc-187f-48cf-ac66-e7fda41c46e3). When you start an asynchronous computation from the UI thread, you do not block the main event loop that processes user actions such as keystrokes and mouse activity, so your application remains responsive.

## Asynchronous Binding by Using let!

In an asynchronous workflow, some expressions and operations are synchronous, and some are longer computations that are designed to return a result asynchronously. When you call a method asynchronously, instead of an ordinary `let` binding, you use `let!`. The effect of `let!` is to enable execution to continue on other computations or threads as the computation is being performed. After the right side of the `let!` binding returns, the rest of the asynchronous workflow resumes execution.

The following code shows the difference between `let` and `let!`. The line of code that uses `let` just creates an asynchronous computation as an object that you can run later by using, for example, `Async.StartImmediate` or [`Async.RunSynchronously`](https://msdn.microsoft.com/library/0a6663a9-50f2-4d38-8bf3-cefd1a51fd6b). The line of code that uses `let!` starts the computation, and then the thread is suspended until the result is available, at which point execution continues.

```fsharp
// let just stores the result as an asynchronous operation.
let (result1 : Async<byte[]>) = stream.AsyncRead(bufferSize)
// let! completes the asynchronous operation and returns the data.
let! (result2 : byte[])  = stream.AsyncRead(bufferSize)
```

In addition to `let!`, you can use `use!` to perform asynchronous bindings. The difference between `let!` and `use!` is the same as the difference between `let` and `use`. For `use!`, the object is disposed of at the close of the current scope. Note that in the current release of the F# language, `use!` does not allow a value to be initialized to null, even though `use` does.

## Asynchronous Primitives

A method that performs a single asynchronous task and returns the result is called an *asynchronous primitive*, and these are designed specifically for use with `let!`. Several asynchronous primitives are defined in the F# core library. Two such methods for Web applications are defined in the module [`Microsoft.FSharp.Control.WebExtensions`](https://msdn.microsoft.com/library/95ef17bc-ee3f-44ba-8a11-c90fcf4cf003): [`WebRequest.AsyncGetResponse`](https://msdn.microsoft.com/library/09a60c31-e6e2-4b5c-ad23-92a86e50060c) and [`WebClient.AsyncDownloadString`](https://msdn.microsoft.com/library/8a85a9b7-f712-4cac-a0ce-0a797f8ea32a). Both primitives download data from a Web page, given a URL. `AsyncGetResponse` produces a `System.Net.WebResponse` object, and `AsyncDownloadString` produces a string that represents the HTML for a Web page.

Several primitives for asynchronous I/O operations are included in the [`Microsoft.FSharp.Control.CommonExtensions`](https://msdn.microsoft.com/library/2edb67cb-6814-4a30-849f-b6dbdd042396) module. These extension methods of the `System.IO.Stream` class are [`Stream.AsyncRead`](https://msdn.microsoft.com/library/85698aaa-bdda-47e6-abed-3730f59fda5e) and [`Stream.AsyncWrite`](https://msdn.microsoft.com/library/1b0a2751-e42a-47e1-bd27-020224adc618).

Additional asynchronous primitives are available in the [F# PowerTools](https://fsprojects.github.io/VisualFSharpPowerTools/). You can also write your own asynchronous primitives by defining a function whose complete body is enclosed in an async block.

To use asynchronous methods in the .NET Framework that are designed for other asynchronous models with the F# asynchronous programming model, you create a function that returns an F# `Async` object. The F# library has functions that make this easy to do.

One example of using asynchronous workflows is included here; there are many others in the documentation for the methods of the [Async class](https://msdn.microsoft.com/library/03eb4d12-a01a-4565-a077-5e83f17cf6f7).

This example shows how to use asynchronous workflows to perform computations in parallel.

In the following code example, a function `fetchAsync` gets the HTML text returned from a Web request. The `fetchAsync` function contains an asynchronous block of code. When a binding is made to the result of an asynchronous primitive, in this case [`AsyncDownloadString`](https://msdn.microsoft.com/library/8a85a9b7-f712-4cac-a0ce-0a797f8ea32a), let! is used instead of let.

You use the function [`Async.RunSynchronously`](https://msdn.microsoft.com/library/0a6663a9-50f2-4d38-8bf3-cefd1a51fd6b) to execute an asynchronous operation and wait for its result. As an example, you can execute multiple asynchronous operations in parallel by using the [`Async.Parallel`](https://msdn.microsoft.com/library/aa9b0355-2d55-4858-b943-cbe428de9dc4) function together with the `Async.RunSynchronously` function. The `Async.Parallel` function takes a list of the `Async` objects, sets up the code for each `Async` task object to run in parallel, and returns an `Async` object that represents the parallel computation. Just as for a single operation, you call `Async.RunSynchronously` to start the execution.

The `runAll` function launches three asynchronous workflows in parallel and waits until they have all completed.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-2/snippet8003.fs)]

## See Also

[F# Language Reference](index.md)

[Computation Expressions](computation-expressions.md)

[Control.Async Class](https://msdn.microsoft.com/visualfsharpdocs/conceptual/control.async-class-%5bfsharp%5d)
