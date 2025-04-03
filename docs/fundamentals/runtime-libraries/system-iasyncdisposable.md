---
title: System.IAsyncDisposable interface
description: Learn about the System.IAsyncDisposable interface.
ms.date: 12/31/2023
---
# System.IAsyncDisposable interface

[!INCLUDE [context](includes/context.md)]

In .NET, classes that own unmanaged resources usually implement the <xref:System.IDisposable> interface to provide a mechanism for releasing unmanaged resources synchronously. However, in some cases they need to provide an asynchronous mechanism for releasing unmanaged resources in addition to (or instead of) the synchronous one. Providing such a mechanism enables the consumer to perform resource-intensive dispose operations without blocking the main thread of a GUI application for a long time.

The <xref:System.IAsyncDisposable.DisposeAsync%2A?displayProperty=nameWithType> method of this interface returns a <xref:System.Threading.Tasks.ValueTask> that represents the asynchronous dispose operation. Classes that own unmanaged resources implement this method, and the consumer of these classes calls this method on an object when it is no longer needed.

The async methods are used in conjunction with the `async` and `await` keywords in C# and Visual Basic. For more information, see [The Task asynchronous programming model in C#](/dotnet/csharp/programming-guide/concepts/async/index) or [Asynchronous Programming with Async and Await (Visual Basic)](../../visual-basic/programming-guide/concepts/async/index.md).

## Use an object that implements IAsyncDisposable

If your application uses an object that implements `IAsyncDisposable`, you should call the object's <xref:System.IAsyncDisposable.DisposeAsync%2A> implementation when you are finished using it. To make sure resources are released even in case of an exception, put the code that uses the `IAsyncDisposable` object into the [using](../../csharp/language-reference/keywords/using.md) statement (in C# beginning from version 8.0) or call the <xref:System.IAsyncDisposable.DisposeAsync%2A> method inside a `finally` clause of the `try`/`finally` statement. For more information about the `try`/`finally` pattern, see [try-finally](/dotnet/csharp/language-reference/keywords/try-finally) (C#) or [Try...Catch...Finally Statement](../../visual-basic/language-reference/statements/try-catch-finally-statement.md) (Visual Basic).

## Implement IAsyncDisposable

You might implement `IAsyncDisposable` in the following situations:

- When developing an asynchronous enumerator that owns unmanaged resources. Asynchronous enumerators are used with the C# 8.0 async streams feature. For more information about async streams, see [Tutorial: Generate and consume async streams using C# 8.0 and .NET Core 3.0](/dotnet/csharp/tutorials/generate-consume-asynchronous-stream).
- When your class owns unmanaged resources and releasing them requires a resource-intensive I/O operation, such as flushing the contents of an intermediate buffer into a file or sending a packet over a network to close a connection.

Use the <xref:System.IAsyncDisposable.DisposeAsync%2A> method to perform whatever cleanup is necessary after using the unmanaged resources, such as freeing, releasing, or resetting the unmanaged resources. For more information, see [Implement a DisposeAsync method](../../standard/garbage-collection/implementing-disposeasync.md).
