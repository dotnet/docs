---
title: "Async Return Types (C#)"
description: Learn about the return types that async methods can have in C# with code examples for each type and additional resources.
ms.date: 04/14/2020
ms.assetid: ddb2539c-c898-48c1-ad92-245e4a996df8
---
# Async Return Types (C#)

Async methods can have the following return types:

- <xref:System.Threading.Tasks.Task%601>, for an async method that returns a value.
- <xref:System.Threading.Tasks.Task>, for an async method that performs an operation but returns no value.
- `void`, for an event handler.
- Starting with C# 7.0, any type that has an accessible `GetAwaiter` method. The object returned by the `GetAwaiter` method must implement the <xref:System.Runtime.CompilerServices.ICriticalNotifyCompletion?displayProperty=nameWithType> interface.
- Starting with C# 8.0, <xref:System.Collections.Generic.IAsyncEnumerable%601>, for an async method that returns an *async stream*.

For more information about async methods, see [Asynchronous Programming with async and await (C#)](./index.md).  
  
## Task\<TResult\> Return Type  
The <xref:System.Threading.Tasks.Task%601> return type is used for an async method that contains a [return](../../../language-reference/keywords/return.md) (C#) statement in which the operand is `TResult`.  
  
In the following example, the `GetLeisureHours` async method contains a `return` statement that returns an integer. Therefore, the method declaration must specify a return type of `Task<int>`.  The <xref:System.Threading.Tasks.Task.FromResult%2A> async method is a placeholder for an operation that returns a string.
  
:::code language="csharp" source="./snippets/async-return-types/async-returns1.cs" id="SnippetFirstExample":::

When `GetLeisureHours` is called from within an await expression in the `ShowTodaysInfo` method, the await expression retrieves the integer value (the value of `leisureHours`) that's stored in the task returned by the `GetLeisureHours` method. For more information about await expressions, see [await](../../../language-reference/operators/await.md).  
  
You can better understand how `await` retrieves the result from a `Task<T>` by separating the call to `GetLeisureHours` from the application of `await`, as the following code shows. A call to method `GetLeisureHours` that isn't immediately awaited returns a `Task<int>`, as you would expect from the declaration of the method. The task is assigned to the `integerTask` variable in the example. Because `integerTask` is a <xref:System.Threading.Tasks.Task%601>, it contains a <xref:System.Threading.Tasks.Task%601.Result> property of type `TResult`. In this case, `TResult` represents an integer type. When `await` is applied to `integerTask`, the await expression evaluates to the contents of the <xref:System.Threading.Tasks.Task%601.Result%2A> property of `integerTask`. The value is assigned to the `ret` variable.  
  
> [!IMPORTANT]
> The <xref:System.Threading.Tasks.Task%601.Result%2A> property is a blocking property. If you try to access it before its task is finished, the thread that's currently active is blocked until the task completes and the value is available. In most cases, you should access the value by using `await` instead of accessing the property directly. <br/> The previous example retrieved the value of the <xref:System.Threading.Tasks.Task%601.Result%2A> property to block the main thread so that the `ShowTodaysInfo` method could finish execution before the application ended.  

:::code language="csharp" source="./snippets/async-return-types/async-returns1a.cs" id="SnippetSecondVersion":::

## Task Return Type  
Async methods that don't contain a `return` statement or that contain a `return` statement that doesn't return an operand usually have a return type of <xref:System.Threading.Tasks.Task>. Such methods return `void` if they run synchronously. If you use a <xref:System.Threading.Tasks.Task> return type for an async method, a calling method can use an `await` operator to suspend the caller's completion until the called async method has finished.  
  
In the following example, the `WaitAndApologize` async method doesn't contain a `return` statement, so the method returns a <xref:System.Threading.Tasks.Task> object. Returning a `Task` enables `WaitAndApologize` to be awaited. The <xref:System.Threading.Tasks.Task> type doesn't include a `Result` property because it has no return value.  

:::code language="csharp" source="./snippets/async-return-types/async-returns2.cs" id="SnippetTaskReturn":::

`WaitAndApologize` is awaited by using an await statement instead of an await expression, similar to the calling statement for a synchronous void-returning method. The application of an await operator in this case doesn't produce a value.  
  
As in the previous <xref:System.Threading.Tasks.Task%601> example, you can separate the call to `WaitAndApologize` from the application of an await operator, as the following code shows. However, remember that a `Task` doesn't have a `Result` property, and that no value is produced when an await operator is applied to a `Task`.  
  
The following code separates calling the `WaitAndApologize` method from awaiting the task that the method returns.  

:::code language="csharp" source="./snippets/async-return-types/async-returns2a.cs" id="SnippetAwaitTask":::

## Void return type

You use the `void` return type in asynchronous event handlers, which require a `void` return type. For methods other than event handlers that don't return a value, you should return a <xref:System.Threading.Tasks.Task> instead, because an async method that returns `void` can't be awaited. Any caller of such a method must continue to completion without waiting for the called async method to finish. The caller must be independent of any values or exceptions that the async method generates.  
  
The caller of a void-returning async method can't catch exceptions thrown from the method, and such unhandled exceptions are likely to cause your application to fail. If a method that returns a <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601> throws an exception, the exception is stored in the returned task. The exception is rethrown when the task is awaited. Therefore, make sure that any async method that can produce an exception has a return type of <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601> and that calls to the method are awaited.  
  
For more information about how to catch exceptions in async methods, see the [Exceptions in Async Methods](../../../language-reference/keywords/try-catch.md#exceptions-in-async-methods) section of the [try-catch](../../../language-reference/keywords/try-catch.md) article.  
  
The following example shows the behavior of an async event handler. In the example code, an async event handler must let the main thread know when it finishes. Then the main thread can wait for an async event handler to complete before exiting the program.

:::code language="csharp" source="./snippets/async-return-types/async-returns3.cs":::

## Generalized async return types and ValueTask\<TResult\>

Starting with C# 7.0, an async method can return any type that has an accessible `GetAwaiter` method.

Because <xref:System.Threading.Tasks.Task> and <xref:System.Threading.Tasks.Task%601> are reference types, memory allocation in performance-critical paths, particularly when allocations occur in tight loops, can adversely affect performance. Support for generalized return types means that you can return a lightweight value type instead of a reference type to avoid additional memory allocations.

.NET provides the <xref:System.Threading.Tasks.ValueTask%601?displayProperty=nameWithType> structure as a lightweight implementation of a generalized task-returning value. To use the <xref:System.Threading.Tasks.ValueTask%601?displayProperty=nameWithType> type, you must add the `System.Threading.Tasks.Extensions` NuGet package to your project. The following example uses the <xref:System.Threading.Tasks.ValueTask%601> structure to retrieve the value of two dice rolls.
  
:::code language="csharp" source="./snippets/async-return-types/async-valuetask.cs":::

## Async streams with IAsyncEnumerable\<T\>

Starting with C# 8.0, an async method may return an *async stream*, represented by <xref:System.Collections.Generic.IAsyncEnumerable%601>. An async stream provides a way to enumerate items read from a stream when elements are generated in chunks with repeated asynchronous calls. The following example shows an async method that generates an async stream:

:::code language="csharp" source="./snippets/async-return-types/AsyncStreams.cs" id="SnippetGenerateAsyncStream":::

The preceding example reads lines from a string asynchronously. Once each line is read, the code enumerates each word in the string. Callers would enumerate each word using the `await foreach` statement. The method awaits when it needs to asynchronously read the next line from the source string.

## See also

- <xref:System.Threading.Tasks.Task.FromResult%2A>
- [Walkthrough: Accessing the Web by Using async and await (C#)](./walkthrough-accessing-the-web-by-using-async-and-await.md)
- [Control Flow in Async Programs (C#)](./control-flow-in-async-programs.md)
- [async](../../../language-reference/keywords/async.md)
- [await](../../../language-reference/operators/await.md)
