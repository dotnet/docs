---
title: Asynchronous file access (C#)
description: Learn how to use the async feature to access files in C#. You can call into asynchronous methods without using callbacks or splitting your code across methods.
ms.date: 08/19/2020
ms.topic: tutorial
ms.assetid: bb018fea-5313-4c80-ab3f-7c24b2145bd9
---

# Asynchronous file access (C#)

You can use the async feature to access files. By using the async feature, you can call into asynchronous methods without using callbacks or splitting your code across multiple methods or lambda expressions. To make synchronous code asynchronous, you just call an asynchronous method instead of a synchronous method and add a few keywords to the code.

You might consider the following reasons for adding asynchrony to file access calls:

> [!div class="checklist"]
>
> - Asynchrony makes UI applications more responsive because the UI thread that launches the operation can perform other work. If the UI thread must execute code that takes a long time (for example, more than 50 milliseconds), the UI may freeze until the I/O is complete and the UI thread can again process keyboard and mouse input and other events.
> - Asynchrony improves the scalability of ASP.NET and other server-based applications by reducing the need for threads. If the application uses a dedicated thread per response and a thousand requests are being handled simultaneously, a thousand threads are needed. Asynchronous operations often don't need to use a thread during the wait. They use the existing I/O completion thread briefly at the end.
> - The latency of a file access operation might be very low under current conditions, but the latency may greatly increase in the future. For example, a file may be moved to a server that's across the world.
> - The added overhead of using the Async feature is small.
> - Asynchronous tasks can easily be run in parallel.

## Use appropriate classes

The simple examples in this topic demonstrate <xref:System.IO.File.WriteAllTextAsync%2A?displayProperty=nameWithType> and <xref:System.IO.File.ReadAllTextAsync%2A?displayProperty=nameWithType>. For finite control over the file I/O operations, use the <xref:System.IO.FileStream> class, which has an option that causes asynchronous I/O to occur at the operating system level. By using this option, you can avoid blocking a thread pool thread in many cases. To enable this option, you specify the `useAsync=true` or `options=FileOptions.Asynchronous` argument in the constructor call.

You can't use this option with <xref:System.IO.StreamReader> and <xref:System.IO.StreamWriter> if you open them directly by specifying a file path. However, you can use this option if you provide them a <xref:System.IO.Stream> that the <xref:System.IO.FileStream> class opened. Asynchronous calls are faster in UI apps even if a thread pool thread is blocked, because the UI thread isn't blocked during the wait.

## Write text

The following examples write text to a file. At each await statement, the method immediately exits. When the file I/O is complete, the method resumes at the statement that follows the await statement. The async modifier is in the definition of methods that use the await statement.

### Simple example

:::code language="csharp" source="snippets/file-access/Program.cs" id="SimpleWrite":::

### Finite control example

:::code language="csharp" source="snippets/file-access/Program.cs" id="WriteText":::

The original example has the statement `await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);`, which is a contraction of the following two statements:

```csharp
Task theTask = sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
await theTask;
```

The first statement returns a task and causes file processing to start. The second statement with the await causes the method to immediately exit and return a different task. When the file processing later completes, execution returns to the statement that follows the await.

## Read text

The following examples read text from a file.

### Simple example

:::code language="csharp" source="snippets/file-access/Program.cs" id="SimpleRead":::

### Finite control example

The text is buffered and, in this case, placed into a <xref:System.Text.StringBuilder>. Unlike in the previous example, the evaluation of the await produces a value. The <xref:System.IO.Stream.ReadAsync%2A> method returns a <xref:System.Threading.Tasks.Task>\<<xref:System.Int32>>, so the evaluation of the await produces an `Int32` value `numRead` after the operation completes. For more information, see [Async Return Types (C#)](async-return-types.md).

:::code language="csharp" source="snippets/file-access/Program.cs" id="ReadText":::

## Parallel asynchronous I/O

The following examples demonstrate parallel processing by writing 10 text files.

### Simple example

:::code language="csharp" source="snippets/file-access/Program.cs" id="SimpleParallelWrite":::

### Finite control example

For each file, the <xref:System.IO.Stream.WriteAsync%2A> method returns a task that is then added to a list of tasks. The `await Task.WhenAll(tasks);` statement exits the method and resumes within the method when file processing is complete for all of the tasks.

The example closes all <xref:System.IO.FileStream> instances in a `finally` block after the tasks are complete. If each `FileStream` was instead created in a `using` statement, the `FileStream` might be disposed of before the task was complete.

Any performance boost is almost entirely from the parallel processing and not the asynchronous processing. The advantages of asynchrony are that it doesn't tie up multiple threads, and that it doesn't tie up the user interface thread.

:::code language="csharp" source="snippets/file-access/Program.cs" id="ParallelWriteText":::

When using the <xref:System.IO.Stream.WriteAsync%2A> and <xref:System.IO.Stream.ReadAsync%2A> methods, you can specify a <xref:System.Threading.CancellationToken>, which you can use to cancel the operation mid-stream. For more information, see [Cancellation in managed threads](../../../../standard/threading/cancellation-in-managed-threads.md).

## See also

- [Asynchronous programming with async and await (C#)](index.md)
- [Async return types (C#)](async-return-types.md)
