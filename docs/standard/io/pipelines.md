---
title: "I/O pipelines - .NET"
description: Learn how to efficiently use I/O pipelines in .NET and avoid problems in your code.
ms.date: "10/01/2019"
ms.technology: dotnet-standard
helpviewer_keywords:
  - "Pipelines"
  - "Pipelines I/O"
  - "I/O [.NET], Pipelines"
author: rick-anderson
ms.author: riande
---
# System.IO.Pipelines in .NET

<xref:System.IO.Pipelines> is a new library that is designed to make it easier to do high-performance I/O in .NET. It’s a library targeting .NET Standard that works on all .NET implementations.

<a name="solve"></a>

## What problem does System.IO.Pipelines solve

<!-- corner case doesn't MT (machine translate)   -->
Apps that parse streaming data are composed of boilerplate code having many specialized and unusual code flows. The boilerplate and special case code is complex and difficult to maintain.

`System.IO.Pipelines` was architected to:

* Have high performance parsing streaming data.
* Reduce code complexity.

The following code is typical for a TCP server that receives line-delimited messages (delimited by `'\n'`) from a client:

```csharp
async Task ProcessLinesAsync(NetworkStream stream)
{
    var buffer = new byte[1024];
    await stream.ReadAsync(buffer, 0, buffer.Length);

    // Process a single line from the buffer
    ProcessLine(buffer);
}
```

The preceding code has several problems:

* The entire message (end of line) might not be received in a single call to `ReadAsync`.
* It's ignoring the result of `stream.ReadAsync`. `stream.ReadAsync` returns how much data was read.
* It doesn't handle the case where multiple lines are read in a single `ReadAsync` call.
* It allocates a `byte` array with each read.

To fix the preceding problems, the following changes are required:

* Buffer the incoming data until a new line is found.
* Parse all the lines returned in the buffer.
* It's possible that the line is bigger than 1 KB (1024 bytes). The code needs to resize the input buffer until the delimiter is found in order to fit the complete line inside the buffer.

  * If the buffer is resized, more buffer copies are made as longer lines appear in the input.
  * To reduce wasted space, compact the buffer used for reading lines.

* Consider using buffer pooling to avoid allocating memory repeatedly.
* The following code addresses some of these problems:

[!code-csharp[](~/samples/snippets/csharp/pipelines/ProcessLinesAsync.cs?name=snippet)]

The previous code is complex and doesn't address all the problems identified. High-performance networking usually means writing very complex code to maximize performance. `System.IO.Pipelines` was designed to make writing this type of code easier.

## Pipe

The <xref:System.IO.Pipelines.Pipe> class can be used to create a `PipeWriter/PipeReader` pair. All data written into the `PipeWriter` is available in the `PipeReader`:

[!code-csharp[](~/samples/snippets/csharp/pipelines/Pipe.cs?name=snippet2)]

<a name="pbu"></a>

### Pipe basic usage

[!code-csharp[](~/samples/snippets/csharp/pipelines/Pipe.cs?name=snippet)]

There are two loops:

* `FillPipeAsync` reads from the `Socket` and writes to the `PipeWriter`.
* `ReadPipeAsync` reads from the `PipeReader` and parses incoming lines.

There are no explicit buffers allocated. All buffer management is delegated to the `PipeReader` and `PipeWriter` implementations. Delegating buffer management makes it easier for consuming code to focus solely on the business logic.

In the first loop:

* <xref:System.IO.Pipelines.PipeWriter.GetMemory(System.Int32)?displayProperty=nameWithType> is called to get memory from the underlying writer.
* <xref:System.IO.Pipelines.PipeWriter.Advance(System.Int32)?displayProperty=nameWithType>
is called to tell the `PipeWriter` how much data was written to the buffer.
* <xref:System.IO.Pipelines.PipeWriter.FlushAsync%2A?displayProperty=nameWithType> is called to make the data available to the `PipeReader`.

In the second loop, the `PipeReader` consumes the buffers written by `PipeWriter`. The buffers come from the socket. The call to `PipeReader.ReadAsync`:

* Returns a <xref:System.IO.Pipelines.ReadResult> that contains two important pieces of information:

  * The data that was read in the form of `ReadOnlySequence<byte>`.
  * A boolean `IsCompleted` that indicates if the end of data (EOF) has been reached.

After finding the end of line (EOL) delimiter and parsing the line:

* The logic processes the buffer to skip what's already processed.
* `PipeReader.AdvanceTo` is called to tell the `PipeReader` how much data has been consumed and examined.

The reader and writer loops end by calling `Complete`. `Complete` lets the underlying Pipe release the memory it allocated.

### Backpressure and flow control

Ideally, reading and parsing work together:

* The writing thread consumes data from the network and puts it in buffers.
* The parsing thread is responsible for constructing the appropriate data structures.

Typically, parsing takes more time than just copying blocks of data from the network:

* The reading thread gets ahead of the parsing thread.
* The reading thread has to either slow down or allocate more memory to store the data for the parsing thread.

For optimal performance, there's a balance between frequent pauses and allocating more memory.

To solve the preceding problem, the `Pipe` has two settings to control the flow of data:

* <xref:System.IO.Pipelines.PipeOptions.PauseWriterThreshold>: Determines how much data should be buffered before calls to <xref:System.IO.Pipelines.PipeWriter.FlushAsync%2A> pause.
* <xref:System.IO.Pipelines.PipeOptions.ResumeWriterThreshold>: Determines how much data the reader has to observe before calls to `PipeWriter.FlushAsync` resume.

![Diagram with ResumeWriterThreshold and PauseWriterThreshold](./media/pipelines/resume-pause.png)

<xref:System.IO.Pipelines.PipeWriter.FlushAsync%2A?displayProperty=nameWithType>:

* Returns an incomplete `ValueTask<FlushResult>` when the amount of data in the `Pipe` crosses `PauseWriterThreshold`.
* Completes `ValueTask<FlushResult>` when it becomes lower than `ResumeWriterThreshold`.

Two values are used to prevent rapid cycling, which can occur if one value is used.

### Examples

```csharp
// The Pipe will start returning incomplete tasks from FlushAsync until
// the reader examines at least 5 bytes.
var options = new PipeOptions(pauseWriterThreshold: 10, resumeWriterThreshold: 5);
var pipe = new Pipe(options);
```

### PipeScheduler

Typically when using `async` and `await`, asynchronous code resumes on either on a <xref:System.Threading.Tasks.TaskScheduler> or on the current  <xref:System.Threading.SynchronizationContext>.

When doing I/O, it's important to have fine-grained control over where the I/O is performed. This control allows taking advantage of CPU caches effectively. Efficient caching is critical for high-performance apps like web servers. <xref:System.IO.Pipelines.PipeScheduler> provides control over where asynchronous callbacks run. By default:

* The current <xref:System.Threading.SynchronizationContext> is used.
* If there's no `SynchronizationContext`, it uses the thread pool to run callbacks.

[!code-csharp[](~/samples/snippets/csharp/pipelines/Program.cs?name=snippet)]

[PipeScheduler.ThreadPool](xref:System.IO.Pipelines.PipeScheduler.ThreadPool) is the <xref:System.IO.Pipelines.PipeScheduler> implementation that queues callbacks to the thread pool. `PipeScheduler.ThreadPool` is the default and generally the best choice. [PipeScheduler.Inline](xref:System.IO.Pipelines.PipeScheduler.Inline) can cause unintended consequences such as deadlocks.

### Pipe reset

It's frequently efficient to reuse the `Pipe` object. To reset the pipe, call <xref:System.IO.Pipelines.PipeReader> <xref:System.IO.Pipelines.Pipe.Reset%2A> when both the `PipeReader` and `PipeWriter` are complete.

## PipeReader

<xref:System.IO.Pipelines.PipeReader> manages memory on the caller's behalf. **Always** call <xref:System.IO.Pipelines.PipeReader.AdvanceTo%2A?displayProperty=nameWithType> after calling <xref:System.IO.Pipelines.PipeReader.ReadAsync%2A?displayProperty=nameWithType>. This lets the `PipeReader` know when the caller is done with the memory so that it can be tracked. The `ReadOnlySequence<byte>` returned from `PipeReader.ReadAsync` is only valid until the call the `PipeReader.AdvanceTo`. It's illegal to use `ReadOnlySequence<byte>` after calling `PipeReader.AdvanceTo`.

`PipeReader.AdvanceTo` takes two <xref:System.SequencePosition> arguments:

* The first argument determines how much memory was consumed.
* The second argument determines how much of the buffer was observed.

Marking data as consumed means that the pipe can return the memory to the underlying buffer pool. Marking data as observed controls what the next call to `PipeReader.ReadAsync` does. Marking everything as observed means that the next call to `PipeReader.ReadAsync` won't return until there's more data written to the pipe. Any other value will make the next call to `PipeReader.ReadAsync` return immediately with the observed *and* unobserved data, but data that has already been consumed.

### Read streaming data scenarios

There are a couple of typical patterns that emerge when trying to read streaming data:

* Given a stream of data, parse a single message.
* Given a stream of data, parse all available messages.

The following examples use the `TryParseMessage` method for parsing messages from a `ReadOnlySequence<byte>`. `TryParseMessage` parses a single message and update the input buffer to trim the parsed message from the buffer. `TryParseMessage` is not part of .NET, it's a user written method used in the following sections.

```csharp
bool TryParseMessage(ref ReadOnlySequence<byte> buffer, out Message message);
```

### Read a single message

The following code reads a single message from a `PipeReader` and returns it to the caller.

[!code-csharp[ReadSingleMsg](~/samples/snippets/csharp/pipelines/ReadSingleMsg.cs?name=snippet)]

The preceding code:

* Parses a single message.
* Updates the consumed `SequencePosition` and examined `SequencePosition` to point to the start of the trimmed input buffer.

The two `SequencePosition` arguments are updated because `TryParseMessage` removes the parsed message from the input buffer. Generally, when parsing a single message from the buffer, the examined position should be one of the following:

* The end of the message.
* The end of the received buffer if no message was found.

The single message case has the most potential for errors. Passing the wrong values to *examined* can result in an out of memory exception or an infinite loop. For more information, see the [PipeReader common problems](#gotchas) section in this article.

### Reading multiple messages

The following code reads all messages from a `PipeReader` and calls `ProcessMessageAsync` on each.

[!code-csharp[MyConnection1](~/samples/snippets/csharp/pipelines/MyConnection1.cs?name=snippet)]

### Cancellation

`PipeReader.ReadAsync`:

* Supports passing a <xref:System.Threading.CancellationToken>.
* Throws an <xref:System.OperationCanceledException> if the `CancellationToken` is canceled while there's a read pending.
* Supports a way to cancel the current read operation via <xref:System.IO.Pipelines.PipeReader.CancelPendingRead%2A?displayProperty=nameWithType>, which avoids raising an exception. Calling `PipeReader.CancelPendingRead` causes the current or next call to `PipeReader.ReadAsync` to return a <xref:System.IO.Pipelines.ReadResult> with `IsCanceled` set to `true`. This can be useful for halting the existing read loop in a non-destructive and non-exceptional way.

[!code-csharp[MyConnection](~/samples/snippets/csharp/pipelines/MyConnection.cs?name=snippet)]

<a name="gotchas"></a>

### PipeReader common problems

* Passing the wrong values to `consumed` or `examined` may result in reading already read data.
* Passing `buffer.End` as examined may result in:

  * Stalled data
  * Possibly an eventual Out of Memory (OOM) exception if data isn't consumed. For example, `PipeReader.AdvanceTo(position, buffer.End)` when processing a single message at a time from the buffer.

* Passing the wrong values to `consumed` or `examined` may result in an infinite loop. For example, `PipeReader.AdvanceTo(buffer.Start)` if `buffer.Start` hasn't changed will cause the next call to `PipeReader.ReadAsync` to return immediately before new data arrives.
* Passing the wrong values to `consumed` or `examined` may result in infinite buffering (eventual OOM).
* Using the `ReadOnlySequence<byte>` after calling `PipeReader.AdvanceTo` may result in memory corruption (use after free).
* Failing to call `PipeReader.Complete/CompleteAsync` may result in a memory leak.
* Checking <xref:System.IO.Pipelines.ReadResult.IsCompleted?displayProperty=nameWithType> and exiting the reading logic before processing the buffer results in data loss. The loop exit condition should be based on `ReadResult.Buffer.IsEmpty` and `ReadResult.IsCompleted`. Doing this incorrectly could result in an infinite loop.

#### Problematic code

❌ **Data loss**

The `ReadResult` can return the final segment of data when `IsCompleted` is set to `true`. Not reading that data before exiting the read loop will result in data loss.

[!INCLUDE [pipelines-do-not-use-1](../../../includes/pipelines-do-not-use-1.md)]

[!code-csharp[DoNotUse#1](~/samples/snippets/csharp/pipelines/DoNotUse.cs?name=snippet)]

[!INCLUDE [pipelines-do-not-use-2](../../../includes/pipelines-do-not-use-2.md)]

❌ **Infinite loop**

The following logic may result in an infinite loop if the `Result.IsCompleted` is `true` but there's never a complete message in the buffer.

[!INCLUDE [pipelines-do-not-use-1](../../../includes/pipelines-do-not-use-1.md)]

[!code-csharp[DoNotUse#2](~/samples/snippets/csharp/pipelines/DoNotUse.cs?name=snippet2)]

[!INCLUDE [pipelines-do-not-use-2](../../../includes/pipelines-do-not-use-2.md)]

Here's another piece of code with the same problem. It's checking for a non-empty buffer before checking `ReadResult.IsCompleted`. Because it's in an `else if`, it will loop forever if there's never a complete message in the buffer.

[!INCLUDE [pipelines-do-not-use-1](../../../includes/pipelines-do-not-use-1.md)]

[!code-csharp[DoNotUse#3](~/samples/snippets/csharp/pipelines/DoNotUse.cs?name=snippet3)]

[!INCLUDE [pipelines-do-not-use-2](../../../includes/pipelines-do-not-use-2.md)]

❌ **Unexpected Hang**

Unconditionally calling `PipeReader.AdvanceTo` with `buffer.End` in the `examined` position may result in hangs when parsing a single message. The next call to `PipeReader.AdvanceTo` won't return until:

* There's more data written to the pipe.
* And the new data wasn't previously examined.

[!INCLUDE [pipelines-do-not-use-1](../../../includes/pipelines-do-not-use-1.md)]

[!code-csharp[DoNotUse#4](~/samples/snippets/csharp/pipelines/DoNotUse.cs?name=snippet4)]

[!INCLUDE [pipelines-do-not-use-2](../../../includes/pipelines-do-not-use-2.md)]

❌ **Out of Memory (OOM)**

With the following conditions, the following code keeps buffering until an <xref:System.OutOfMemoryException> occurs:

* There's no maximum message size.
* The data returned from the `PipeReader` doesn't make a complete message. For example, it doesn't make a complete message because the other side is writing a large message (For example, a 4-GB message).

[!INCLUDE [pipelines-do-not-use-1](../../../includes/pipelines-do-not-use-1.md)]

[!code-csharp[DoNotUse#5](~/samples/snippets/csharp/pipelines/DoNotUse.cs?name=snippet5)]

[!INCLUDE [pipelines-do-not-use-2](../../../includes/pipelines-do-not-use-2.md)]

❌ **Memory Corruption**

When writing helpers that read the buffer, any returned payload should be copied before calling `Advance`. The following example will return memory that the `Pipe` has discarded and may reuse it for the next operation (read/write).

[!INCLUDE [pipelines-do-not-use-1](../../../includes/pipelines-do-not-use-1.md)]

[!code-csharp[DoNotUse#Message](~/samples/snippets/csharp/pipelines/DoNotUse.cs?name=snippetMessage)]

[!code-csharp[DoNotUse#6](~/samples/snippets/csharp/pipelines/DoNotUse.cs?name=snippet6)]

[!INCLUDE [pipelines-do-not-use-2](../../../includes/pipelines-do-not-use-2.md)]

## PipeWriter

The <xref:System.IO.Pipelines.PipeWriter> manages buffers for writing on the caller's behalf. `PipeWriter` implements [`IBufferWriter<byte>`](xref:System.Buffers.IBufferWriter%601). `IBufferWriter<byte>` makes it possible to get access to buffers to perform writes without additional buffer copies.

[!code-csharp[MyPipeWriter](~/samples/snippets/csharp/pipelines/MyPipeWriter.cs?name=snippet)]

The previous code:

* Requests a buffer of at least 5 bytes from the `PipeWriter` using <xref:System.IO.Pipelines.PipeWriter.GetMemory%2A>.
* Writes bytes for the ASCII string `"Hello"` to the returned `Memory<byte>`.
* Calls <xref:System.IO.Pipelines.PipeWriter.Advance%2A> to indicate how many bytes were written to the buffer.
* Flushes the `PipeWriter`, which sends the bytes to the underlying device.

The previous method of writing uses the buffers provided by the `PipeWriter`. Alternatively, <xref:System.IO.Pipelines.PipeWriter.WriteAsync%2A?displayProperty=nameWithType>:

* Copies the existing buffer to the `PipeWriter`.
* Calls `GetSpan`, `Advance` as appropriate and calls <xref:System.IO.Pipelines.PipeWriter.FlushAsync%2A>.

[!code-csharp[MyPipeWriter#2](~/samples/snippets/csharp/pipelines/MyPipeWriter.cs?name=snippet2)]

### Cancellation

<xref:System.IO.Pipelines.PipeWriter.FlushAsync%2A> supports passing a <xref:System.Threading.CancellationToken>. Passing a `CancellationToken` results in an `OperationCanceledException` if the token is canceled while there's a flush pending. `PipeWriter.FlushAsync` supports a way to cancel the current flush operation via <xref:System.IO.Pipelines.PipeWriter.CancelPendingFlush%2A?displayProperty=nameWithType> without raising an exception. Calling `PipeWriter.CancelPendingFlush` causes the current or next call to `PipeWriter.FlushAsync` or `PipeWriter.WriteAsync` to return a <xref:System.IO.Pipelines.FlushResult> with `IsCanceled` set to `true`. This can be useful for halting the yielding flush in a non-destructive and non-exceptional way.

<a name="pwcp"></a>

### PipeWriter common problems

* <xref:System.IO.Pipelines.PipeWriter.GetSpan%2A> and <xref:System.IO.Pipelines.PipeWriter.GetMemory%2A> return a buffer with at least the requested amount of memory. **Don't** assume exact buffer sizes.
* There's no guarantee that successive calls will return the same buffer or the same-sized buffer.
* A new buffer must be requested after calling <xref:System.IO.Pipelines.PipeWriter.Advance%2A> to continue writing more data. The previously acquired buffer can't be written to.
* Calling `GetMemory` or `GetSpan` while there's an incomplete call to `FlushAsync` isn't safe.
* Calling `Complete` or `CompleteAsync` while there's unflushed data can result in memory corruption.

## IDuplexPipe

The <xref:System.IO.Pipelines.IDuplexPipe> is a contract for types that support both reading and writing. For example, a network connection would be represented by an `IDuplexPipe`.

 Unlike `Pipe` which contains a `PipeReader` and a `PipeWriter`, `IDuplexPipe` represents a single side of a full duplex connection. That means what is written to the `PipeWriter` will not be read from the `PipeReader`.

## Streams

When reading or writing stream data, you typically read data using a de-serializer and write data using a serializer. Most of these read and write stream APIs have a `Stream` parameter. To make it easier to integrate with these existing APIs, `PipeReader` and `PipeWriter` expose an <xref:System.IO.Pipelines.PipeReader.AsStream%2A>.  <xref:System.IO.Pipelines.PipeWriter.AsStream%2A> returns a `Stream` implementation around the `PipeReader` or `PipeWriter`.
