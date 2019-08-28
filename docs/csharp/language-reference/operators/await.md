---
title: "await operator - C# reference"
ms.custom: seodec18
ms.date: 08/30/2019
f1_keywords: 
  - "await_CSharpKeyword"
helpviewer_keywords: 
  - "await keyword [C#]"
  - "await [C#]"
ms.assetid: 50725c24-ac76-4ca7-bca1-dd57642ffedb
---
# await operator (C# reference)

The `await` operator suspends evaluation of the enclosing [async](../keywords/async.md) method until the asynchronous operation represented by its operand completes. When that asynchronous operation completes, the `await` operator returns the result of the operation, if any. If the `await` operator is applied to the operand that represents already completed operation, it returns the result of the operation immediately without suspension of the enclosing async method. The `await` operator doesn't block the thread that evaluates the async method. When the `await` operator suspends the async method, the control returns to the caller of the async method.

In the following example, the <xref:System.Net.Http.HttpClient.GetByteArrayAsync%2A?displayProperty=nameWithType> method returns the `Task<byte[]>` instance, which represents the asynchronous operation that produces the byte array when it completes. Until that operation completes, the `await` operator suspends the `DownloadDocsMainPage` method. If `DownloadDocsMainPage` gets suspended, control is returned to the `Main` method, which is the caller of `DownloadDocsMainPage`. The `Main` method executes until it needs the result of the asynchronous operation performed by the `DownloadDocsMainPage` method. When <xref:System.Net.Http.HttpClient.GetByteArrayAsync%2A> gets all the bytes, the rest of the `DownloadDocsMainPage` method is evaluated. After that, the rest of the `Main` method is evaluated.

[!code-csharp[await example](~/samples/csharp/language-reference/operators/AwaitOperator.cs)]

The preceding example uses the [async `Main` method](../../programming-guide/main-and-command-args/index.md), which is possible starting with C# 7.1. For more information, see the [await operator in the Main method](#await-operator-in-the-main-method) section.

> [!NOTE]
> For an introduction to asynchronous programming, see [Asynchronous programming with async and await](../../programming-guide/concepts/async/index.md). Asynchronous programming with `async` and `await` follows the [task-based asynchronous pattern](../../../standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap.md).

You can use the `await` operator only in a method, [lambda expression](../../programming-guide/statements-expressions-operators/lambda-expressions.md), or [anonymous method](delegate-operator.md) that is modified by the [async](../keywords/async.md) keyword. Within an async method, you cannot use the `await` operator in the body of a synchronous function, inside the block of a [lock statement](../keywords/lock-statement.md), and in an [unsafe](../keywords/unsafe.md) context.
  
The operand of the `await` operator is usually of one of the following .NET types: <xref:System.Threading.Tasks.Task>, <xref:System.Threading.Tasks.Task%601>, <xref:System.Threading.Tasks.ValueTask>, or <xref:System.Threading.Tasks.ValueTask%601>. However, any awaitable expression can be the operand of the `await` operator. For more information, see the [Awaitable expressions](~/_csharplang/spec/expressions.md#awaitable-expressions) section of the [C# language specification](~/_csharplang/spec/introduction.md).

The type of expression `await t` is `TResult` if expression `t` is of the <xref:System.Threading.Tasks.Task%601> or <xref:System.Threading.Tasks.ValueTask%601> type. If the type of `t` is <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.ValueTask>, the type of `await t` is `void`. In both cases, if `t` throws an exception, `await t` rethrows the exception. For more information about exception handling, see the [Exceptions in async methods](../keywords/try-catch.md#exceptions-in-async-methods) section of the [try-catch statement](../keywords/try-catch.md) article.

The `async` and `await` keywords are available starting with C# 5.

## await operator in the Main method

Starting with C# 7.1, the [`Main` method](../../programming-guide/main-and-command-args/index.md), which is the application entry point, can be async and you can use the `await` operator in its body. In earlier C# versions, to ensure that the `Main` method waits for the completion of an asynchronous operation, you can retrieve the value of the <xref:System.Threading.Tasks.Task%601.Result?displayProperty=nameWithType> property of the <xref:System.Threading.Tasks.Task%601> instance that is returned by the corresponding async method. For asynchronous operations that don't produce a value, you can call the <xref:System.Threading.Tasks.Task.Wait%2A?displayProperty=nameWithType> method. For information about how to select the language version, see [Select the C# language version](../configure-language-version.md).

## C# language specification

For more information, see the [Await expressions](~/_csharplang/spec/expressions.md#await-expressions) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
- [async](../keywords/async.md)
- [Asynchronous programming with async and await](../../programming-guide/concepts/async/index.md)
- [Task asynchronous programming model](../../programming-guide/concepts/async/task-asynchronous-programming-model.md)
- [Asynchronous programming](../../async.md)
- [Task-based asynchronous pattern](../../../standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap.md)
- [Async in depth](../../../standard/async-in-depth.md)
- [Walkthrough: accessing the Web by using async and await](../../programming-guide/concepts/async/walkthrough-accessing-the-web-by-using-async-and-await.md)
