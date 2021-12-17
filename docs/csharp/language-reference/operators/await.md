---
title: "await operator - C# reference"
description: "Learn about the C# await operator that suspends evaluation of the enclosing async method."
ms.date: 07/13/2020
f1_keywords: 
  - "await_CSharpKeyword"
helpviewer_keywords: 
  - "await keyword [C#]"
  - "await [C#]"
ms.assetid: 50725c24-ac76-4ca7-bca1-dd57642ffedb
---
# await operator (C# reference)

The `await` operator suspends evaluation of the enclosing [async](../keywords/async.md) method until the asynchronous operation represented by its operand completes. When the asynchronous operation completes, the `await` operator returns the result of the operation, if any. When the `await` operator is applied to the operand that represents an already completed operation, it returns the result of the operation immediately without suspension of the enclosing method. The `await` operator doesn't block the thread that evaluates the async method. When the `await` operator suspends the enclosing async method, the control returns to the caller of the method.

In the following example, the <xref:System.Net.Http.HttpClient.GetByteArrayAsync%2A?displayProperty=nameWithType> method returns the `Task<byte[]>` instance, which represents an asynchronous operation that produces a byte array when it completes. Until the operation completes, the `await` operator suspends the `DownloadDocsMainPageAsync` method. When `DownloadDocsMainPageAsync` gets suspended, control is returned to the `Main` method, which is the caller of `DownloadDocsMainPageAsync`. The `Main` method executes until it needs the result of the asynchronous operation performed by the `DownloadDocsMainPageAsync` method. When <xref:System.Net.Http.HttpClient.GetByteArrayAsync%2A> gets all the bytes, the rest of the `DownloadDocsMainPageAsync` method is evaluated. After that, the rest of the `Main` method is evaluated.

[!code-csharp[await example](snippets/shared/AwaitOperator.cs)]

The preceding example uses the [async `Main` method](../../fundamentals/program-structure/main-command-line.md), which is possible beginning with C# 7.1. For more information, see the [await operator in the Main method](#await-operator-in-the-main-method) section.

> [!NOTE]
> For an introduction to asynchronous programming, see [Asynchronous programming with async and await](../../programming-guide/concepts/async/index.md). Asynchronous programming with `async` and `await` follows the [task-based asynchronous pattern](../../../standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap.md).

You can use the `await` operator only in a method, [lambda expression](lambda-expressions.md), or [anonymous method](delegate-operator.md) that is modified by the [async](../keywords/async.md) keyword. Within an async method, you can't use the `await` operator in the body of a synchronous function, inside the block of a [lock statement](../statements/lock.md), and in an [unsafe](../keywords/unsafe.md) context.

The operand of the `await` operator is usually of one of the following .NET types: <xref:System.Threading.Tasks.Task>, <xref:System.Threading.Tasks.Task%601>, <xref:System.Threading.Tasks.ValueTask>, or <xref:System.Threading.Tasks.ValueTask%601>. However, any awaitable expression can be the operand of the `await` operator. For more information, see the [Awaitable expressions](~/_csharplang/spec/expressions.md#awaitable-expressions) section of the [C# language specification](~/_csharplang/spec/introduction.md).

The type of expression `await t` is `TResult` if the type of expression `t` is <xref:System.Threading.Tasks.Task%601> or <xref:System.Threading.Tasks.ValueTask%601>. If the type of `t` is <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.ValueTask>, the type of `await t` is `void`. In both cases, if `t` throws an exception, `await t` rethrows the exception. For more information about exception handling, see the [Exceptions in async methods](../keywords/try-catch.md#exceptions-in-async-methods) section of the [try-catch statement](../keywords/try-catch.md) article.

The `async` and `await` keywords are available in C# 5 and later.

## Asynchronous streams and disposables

Beginning with C# 8.0, you can work with asynchronous streams and disposables.

You use the `await foreach` statement to consume an asynchronous stream of data. For more information, see the [`foreach` statement](../statements/iteration-statements.md#the-foreach-statement) section of the [Iteration statements](../statements/iteration-statements.md) article and the [Asynchronous streams](../../whats-new/csharp-8.md#asynchronous-streams) section of the [What's new in C# 8.0](../../whats-new/csharp-8.md) article.

You use the `await using` statement to work with an asynchronously disposable object, that is, an object of a type that implements an <xref:System.IAsyncDisposable> interface. For more information, see the [Using async disposable](../../../standard/garbage-collection/implementing-disposeasync.md#using-async-disposable) section of the [Implement a DisposeAsync method](../../../standard/garbage-collection/implementing-disposeasync.md) article.

## await operator in the Main method

Beginning with C# 7.1, the [`Main` method](../../fundamentals/program-structure/main-command-line.md), which is the application entry point, can return `Task` or `Task<int>`, enabling it to be async so you can use the `await` operator in its body. In earlier C# versions, to ensure that the `Main` method waits for the completion of an asynchronous operation, you can retrieve the value of the <xref:System.Threading.Tasks.Task%601.Result?displayProperty=nameWithType> property of the <xref:System.Threading.Tasks.Task%601> instance that is returned by the corresponding async method. For asynchronous operations that don't produce a value, you can call the <xref:System.Threading.Tasks.Task.Wait%2A?displayProperty=nameWithType> method. For information about how to select the language version, see [C# language versioning](../configure-language-version.md).

## C# language specification

For more information, see the [Await expressions](~/_csharplang/spec/expressions.md#await-expressions) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [async](../keywords/async.md)
- [Task asynchronous programming model](../../programming-guide/concepts/async/task-asynchronous-programming-model.md)
- [Asynchronous programming](../../async.md)
- [Async in depth](../../../standard/async-in-depth.md)
- [Walkthrough: accessing the Web by using async and await](../../programming-guide/concepts/async/index.md)
- [Tutorial: Generate and consume async streams using C# 8.0 and .NET Core 3.0](../../whats-new/tutorials/generate-consume-asynchronous-stream.md)
