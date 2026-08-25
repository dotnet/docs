---
title: System.IO.Pipelines - .NET
description: Learn how to efficiently use I/O pipelines in .NET and avoid problems in your code.
ms.date: 03/26/2026
helpviewer_keywords:
  - "Pipelines"
  - "Pipelines I/O"
  - "I/O [.NET], Pipelines"
ai-usage: ai-assisted
---

# System.IO.Pipelines

<xref:System.IO.Pipelines> is a library designed to make high-performance I/O in .NET easier. The package targets .NET Standard for broad compatibility, .NET Framework, and modern .NET. In modern .NET versions, `System.IO.Pipelines` is included in the shared framework and doesn't require a separate NuGet package.

The library is also available as the [System.IO.Pipelines](https://www.nuget.org/packages/System.IO.Pipelines) NuGet package.

## What problem does System.IO.Pipelines solve?

<!-- corner case doesn't MT (machine translate)   -->
Apps that parse streaming data are composed of boilerplate code having many specialized and unusual code flows. The boilerplate and special case code is complex and difficult to maintain.

`System.IO.Pipelines` was architected to:

* Have high performance parsing streaming data.
* Reduce code complexity.

This code is typical for a TCP server that receives line-delimited messages (delimited by `'\n'`) from a client:

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

To fix the preceding problems, make these changes:

* Buffer the incoming data until a new line is found.
* Parse all the lines returned in the buffer.
* The line might be bigger than 1 KB (1024 bytes). The code needs to resize the input buffer until the delimiter is found to fit the complete line inside the buffer.

  * If the buffer is resized, more buffer copies are made as longer lines appear in the input.
  * To reduce wasted space, compact the buffer used for reading lines.

* Consider using buffer pooling to avoid allocating memory repeatedly.
* This code addresses some of these problems:

:::code language="csharp" source="snippets/pipelines_1/ProcessLinesAsync.cs" id="snippet":::

The previous code is complex and doesn't address all the problems identified. High-performance networking usually means writing complex code to maximize performance. `System.IO.Pipelines` was designed to make writing this type of code easier.

## Pipe

Use the <xref:System.IO.Pipelines.Pipe> class to create a `PipeWriter/PipeReader` pair. All data written into the `PipeWriter` is available in the `PipeReader`:

:::code language="csharp" source="snippets/pipelines_1/Pipe.cs" id="snippet2":::

### Pipe basic usage

:::code language="csharp" source="snippets/pipelines_1/Pipe.cs" id="snippet":::

Two loops handle the reading and writing:

* `FillPipeAsync` reads from the `Socket` and writes to the `PipeWriter`.
* `ReadPipeAsync` reads from the `PipeReader` and parses incoming lines.

No explicit buffers are allocated. All buffer management is delegated to the `PipeReader` and `PipeWriter` implementations. Delegating buffer management makes it easier for consuming code to focus solely on the business logic.

In the first loop:

* <xref:System.IO.Pipelines.PipeWriter.GetMemory(System.Int32)?displayProperty=nameWithType> is called to get memory from the underlying writer.
* <xref:System.IO.Pipelines.PipeWriter.Advance(System.Int32)?displayProperty=nameWithType>
is called to tell the `PipeWriter` how much data was written to the buffer.
* <xref:System.IO.Pipelines.PipeWriter.FlushAsync*?displayProperty=nameWithType> is called to make the data available to the `PipeReader`.

In the second loop, the `PipeReader` consumes the buffers written by `PipeWriter`. The buffers come from the socket. The call to <xref:System.IO.Pipelines.PipeReader.ReadAsync*?displayProperty=nameWithType>:

* Returns a <xref:System.IO.Pipelines.ReadResult> that contains two important pieces of information:

  * The data that was read in the form of <xref:System.Buffers.ReadOnlySequence`1>.
  * A boolean `IsCompleted` that indicates if the end of data (EOF) has been reached.

After finding the end of line (EOL) delimiter and parsing the line:

* The logic processes the buffer to skip what's already processed.
* <xref:System.IO.Pipelines.PipeReader.AdvanceTo*?displayProperty=nameWithType> is called to tell the `PipeReader` how much data has been consumed and examined.

The reader and writer loops end by calling <xref:System.IO.Pipelines.PipeReader.Complete*?displayProperty=nameWithType> and <xref:System.IO.Pipelines.PipeWriter.Complete*?displayProperty=nameWithType>. Calling `Complete` releases the memory the underlying `Pipe` allocated.

### Backpressure and flow control

Ideally, reading and parsing work together:

* The reading thread consumes data from the network and puts it in buffers.
* The parsing thread is responsible for constructing the appropriate data structures.

Typically, parsing takes more time than just copying blocks of data from the network:

* The reading thread gets ahead of the parsing thread.
* The reading thread has to either slow down or allocate more memory to store the data for the parsing thread.

For optimal performance, there's a balance between frequent pauses and allocating more memory.

To solve the preceding problem, the `Pipe` has two settings to control the flow of data:

* <xref:System.IO.Pipelines.PipeOptions.PauseWriterThreshold>: Determines how much data should be buffered before calls to <xref:System.IO.Pipelines.PipeWriter.FlushAsync*> pause.
* <xref:System.IO.Pipelines.PipeOptions.ResumeWriterThreshold>: Determines how much data the reader has to observe before calls to <xref:System.IO.Pipelines.PipeWriter.FlushAsync*?displayProperty=nameWithType> resume.

![Diagram with ResumeWriterThreshold and PauseWriterThreshold](media/pipelines/resume-pause.png)

<xref:System.IO.Pipelines.PipeWriter.FlushAsync*?displayProperty=nameWithType>:

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

Typically when using `async` and `await`, asynchronous code resumes on either a <xref:System.Threading.Tasks.TaskScheduler> or the current <xref:System.Threading.SynchronizationContext>.

When doing I/O, it's important to have fine-grained control over where the I/O is performed. This control allows taking advantage of CPU caches effectively. Efficient caching is critical for high-performance apps like web servers. <xref:System.IO.Pipelines.PipeScheduler> provides control over where asynchronous callbacks run. By default:

* The current <xref:System.Threading.SynchronizationContext> is used.
* If there's no `SynchronizationContext`, it uses the thread pool to run callbacks.

:::code language="csharp" source="snippets/pipelines_1/Program.cs" id="snippet":::

[PipeScheduler.ThreadPool](xref:System.IO.Pipelines.PipeScheduler.ThreadPool) is the <xref:System.IO.Pipelines.PipeScheduler> implementation that queues callbacks to the thread pool. `PipeScheduler.ThreadPool` is the default and generally the best choice. [PipeScheduler.Inline](xref:System.IO.Pipelines.PipeScheduler.Inline) can cause unintended consequences such as deadlocks.

### Pipe reset

Reusing the `Pipe` object is often efficient. To reset the pipe, call <xref:System.IO.Pipelines.PipeReader> <xref:System.IO.Pipelines.Pipe.Reset*> when both the `PipeReader` and `PipeWriter` are complete.

## PipeReader

<xref:System.IO.Pipelines.PipeReader> manages memory on the caller's behalf. **Always** call <xref:System.IO.Pipelines.PipeReader.AdvanceTo*?displayProperty=nameWithType> after calling <xref:System.IO.Pipelines.PipeReader.ReadAsync*?displayProperty=nameWithType>. This lets the `PipeReader` know when the caller is done with the memory so that it can be tracked. The <xref:System.Buffers.ReadOnlySequence`1> returned from <xref:System.IO.Pipelines.PipeReader.ReadAsync*?displayProperty=nameWithType> is only valid until the call to <xref:System.IO.Pipelines.PipeReader.AdvanceTo*?displayProperty=nameWithType>. It's illegal to use <xref:System.Buffers.ReadOnlySequence`1> after calling <xref:System.IO.Pipelines.PipeReader.AdvanceTo*?displayProperty=nameWithType>.

<xref:System.IO.Pipelines.PipeReader.AdvanceTo*?displayProperty=nameWithType> takes two <xref:System.SequencePosition> arguments:

* The first argument determines how much memory was consumed.
* The second argument determines how much of the buffer was observed.

Marking data as consumed means that the pipe can return the memory to the underlying buffer pool. Marking data as observed controls what the next call to <xref:System.IO.Pipelines.PipeReader.ReadAsync*?displayProperty=nameWithType> does. Marking everything as observed means that the next call to <xref:System.IO.Pipelines.PipeReader.ReadAsync*?displayProperty=nameWithType> won't return until there's more data written to the pipe. Any other value makes the next call to <xref:System.IO.Pipelines.PipeReader.ReadAsync*?displayProperty=nameWithType> return immediately with the observed *and* unobserved data, but not data that has already been consumed.

### Read streaming data scenarios

A couple of typical patterns emerge when reading streaming data:

* Given a stream of data, parse a single message.
* Given a stream of data, parse all available messages.

These examples use the `TryParseLines` method for parsing messages from a <xref:System.Buffers.ReadOnlySequence`1>. `TryParseLines` parses a single message and updates the input buffer to trim the parsed message from the buffer. `TryParseLines` isn't part of .NET; it's a user-written method used in the following sections.

```csharp
bool TryParseLines(ref ReadOnlySequence<byte> buffer, out Message message);
```

### Read a single message

This code reads a single message from a `PipeReader` and returns it to the caller.

:::code language="csharp" source="snippets/pipelines_1/ReadSingleMsg.cs" id="snippet":::

The preceding code:

* Parses a single message.
* Updates the consumed `SequencePosition` and examined `SequencePosition` to point to the start of the trimmed input buffer.

The two `SequencePosition` arguments are updated because `TryParseLines` removes the parsed message from the input buffer. Generally, when parsing a single message from the buffer, the examined position should be one of the following:

* The end of the message.
* The end of the received buffer if no message was found.

The single message case has the most potential for errors. Passing the wrong values to *examined* might result in an out of memory exception or an infinite loop. For more information, see the [PipeReader common problems](#pipereader-common-problems) section in this article.

> [!IMPORTANT]
> `ReadSingleMessageAsync` doesn't call `PipeReader.CompleteAsync`. The caller is responsible for completing the `PipeReader`. Calling `PipeReader.CompleteAsync` inside `ReadSingleMessageAsync` signals that no more data can be read, which prevents reading subsequent messages.

### Read multiple messages

This code reads all messages from a `PipeReader` and calls `ProcessMessageAsync` on each.

:::code language="csharp" source="snippets/pipelines_1/MyConnection1.cs" id="snippet":::

Because `ProcessMessagesAsync` owns the complete message-reading loop, it calls <xref:System.IO.Pipelines.PipeReader.CompleteAsync*?displayProperty=nameWithType> when it's done. Unlike the single-message case, the caller doesn't need to complete the reader. `ProcessMessagesAsync` takes full ownership of the `PipeReader` lifetime.

### Cancellation

<xref:System.IO.Pipelines.PipeReader.ReadAsync*?displayProperty=nameWithType>:

* Supports passing a <xref:System.Threading.CancellationToken>.
* Throws an <xref:System.OperationCanceledException> if the `CancellationToken` is canceled while there's a read pending.
* Supports a way to cancel the current read operation via <xref:System.IO.Pipelines.PipeReader.CancelPendingRead*?displayProperty=nameWithType>, which avoids raising an exception. Calling `PipeReader.CancelPendingRead` causes the current or next call to <xref:System.IO.Pipelines.PipeReader.ReadAsync*?displayProperty=nameWithType> to return a <xref:System.IO.Pipelines.ReadResult> with `IsCanceled` set to `true`. This is useful for halting the existing read loop in a non-destructive and non-exceptional way.

:::code language="csharp" source="snippets/pipelines_1/MyConnection.cs" id="snippet":::

### PipeReader common problems

* Passing the wrong values to `consumed` or `examined` might result in reading already read data.
* Passing `buffer.End` as examined might result in:

  * Stalled data
  * An eventual out-of-memory (OOM) exception if data isn't consumed. For example, `PipeReader.AdvanceTo(position, buffer.End)` when processing a single message at a time from the buffer.

* Passing the wrong values to `consumed` or `examined` might result in an infinite loop. For example, `PipeReader.AdvanceTo(buffer.Start)` if `buffer.Start` hasn't changed causes the next call to <xref:System.IO.Pipelines.PipeReader.ReadAsync*?displayProperty=nameWithType> to return immediately before new data arrives.
* Passing the wrong values to `consumed` or `examined` might result in infinite buffering (eventual OOM).
* Using <xref:System.Buffers.ReadOnlySequence`1> after calling <xref:System.IO.Pipelines.PipeReader.AdvanceTo*?displayProperty=nameWithType> might result in memory corruption (use after free).
* Failing to call <xref:System.IO.Pipelines.PipeReader.Complete*>/<xref:System.IO.Pipelines.PipeReader.CompleteAsync*> might result in a memory leak.
* Checking <xref:System.IO.Pipelines.ReadResult.IsCompleted?displayProperty=nameWithType> and exiting the reading logic before processing the buffer results in data loss. The loop exit condition should be based on `ReadResult.Buffer.IsEmpty` and `ReadResult.IsCompleted`. Doing this incorrectly could result in an infinite loop.

#### Problematic code

❌ **Data loss**

The `ReadResult` can return the final segment of data when `IsCompleted` is set to `true`. Not reading that data before exiting the read loop results in data loss.

[!INCLUDE [pipelines-do-not-use-1](../../../includes/pipelines-do-not-use-1.md)]

:::code language="csharp" source="snippets/pipelines_1/DoNotUse.cs" id="snippet":::

[!INCLUDE [pipelines-do-not-use-2](../../../includes/pipelines-do-not-use-2.md)]

❌ **Infinite loop**

The following logic might result in an infinite loop if the `Result.IsCompleted` is `true` but there's never a complete message in the buffer.

[!INCLUDE [pipelines-do-not-use-1](../../../includes/pipelines-do-not-use-1.md)]

:::code language="csharp" source="snippets/pipelines_1/DoNotUse.cs" id="snippet2":::

[!INCLUDE [pipelines-do-not-use-2](../../../includes/pipelines-do-not-use-2.md)]

Here's another piece of code with the same problem. It's checking for a non-empty buffer before checking `ReadResult.IsCompleted`. Because it's in an `else if`, it loops forever if there's never a complete message in the buffer.

[!INCLUDE [pipelines-do-not-use-1](../../../includes/pipelines-do-not-use-1.md)]

:::code language="csharp" source="snippets/pipelines_1/DoNotUse.cs" id="snippet3":::

[!INCLUDE [pipelines-do-not-use-2](../../../includes/pipelines-do-not-use-2.md)]

❌ **Unresponsive application**

Unconditionally calling <xref:System.IO.Pipelines.PipeReader.AdvanceTo*?displayProperty=nameWithType> with `buffer.End` in the `examined` position might result in the application becoming unresponsive when parsing a single message. The next call to <xref:System.IO.Pipelines.PipeReader.AdvanceTo*?displayProperty=nameWithType> won't return until:

* There's more data written to the pipe.
* And the new data wasn't previously examined.

[!INCLUDE [pipelines-do-not-use-1](../../../includes/pipelines-do-not-use-1.md)]

:::code language="csharp" source="snippets/pipelines_1/DoNotUse.cs" id="snippet4":::

[!INCLUDE [pipelines-do-not-use-2](../../../includes/pipelines-do-not-use-2.md)]

❌ **Out of Memory (OOM)**

With the following conditions, this code keeps buffering until an <xref:System.OutOfMemoryException> occurs:

* There's no maximum message size.
* The data returned from the `PipeReader` doesn't make a complete message. For example, the other side is writing a large message (for example, a 4-GB message).

[!INCLUDE [pipelines-do-not-use-1](../../../includes/pipelines-do-not-use-1.md)]

:::code language="csharp" source="snippets/pipelines_1/DoNotUse.cs" id="snippet5":::

[!INCLUDE [pipelines-do-not-use-2](../../../includes/pipelines-do-not-use-2.md)]

❌ **Memory Corruption**

When writing helpers that read the buffer, copy any returned payload before calling <xref:System.IO.Pipelines.PipeWriter.Advance*>. The following example returns memory that the `Pipe` has discarded and might reuse it for the next operation (read/write).

[!INCLUDE [pipelines-do-not-use-1](../../../includes/pipelines-do-not-use-1.md)]

:::code language="csharp" source="snippets/pipelines_1/DoNotUse.cs" id="snippetMessage":::

:::code language="csharp" source="snippets/pipelines_1/DoNotUse.cs" id="snippet6":::

[!INCLUDE [pipelines-do-not-use-2](../../../includes/pipelines-do-not-use-2.md)]

## PipeWriter

The <xref:System.IO.Pipelines.PipeWriter> manages buffers for writing on the caller's behalf. `PipeWriter` implements [`IBufferWriter<byte>`](xref:System.Buffers.IBufferWriter`1). `IBufferWriter<byte>` provides access to buffers to perform writes without extra buffer copies.

:::code language="csharp" source="snippets/pipelines_1/MyPipeWriter.cs" id="snippet":::

The previous code:

* Requests a buffer of at least 5 bytes from the `PipeWriter` using <xref:System.IO.Pipelines.PipeWriter.GetMemory*>.
* Writes bytes for the ASCII string `"Hello"` to the returned `Memory<byte>`.
* Calls <xref:System.IO.Pipelines.PipeWriter.Advance*> to indicate how many bytes were written to the buffer.
* Flushes the `PipeWriter`, which sends the bytes to the underlying device.

The previous method of writing uses the buffers provided by the `PipeWriter`. It also could use <xref:System.IO.Pipelines.PipeWriter.WriteAsync*?displayProperty=nameWithType>, which:

* Copies the existing buffer to the `PipeWriter`.
* Calls <xref:System.IO.Pipelines.PipeWriter.GetSpan*>, <xref:System.IO.Pipelines.PipeWriter.Advance*> as appropriate, and calls <xref:System.IO.Pipelines.PipeWriter.FlushAsync*>.

:::code language="csharp" source="snippets/pipelines_1/MyPipeWriter.cs" id="snippet2":::

### Cancellation

<xref:System.IO.Pipelines.PipeWriter.FlushAsync*> supports passing a <xref:System.Threading.CancellationToken>. Passing a `CancellationToken` results in an `OperationCanceledException` if the token is canceled while there's a flush pending. <xref:System.IO.Pipelines.PipeWriter.FlushAsync*?displayProperty=nameWithType> supports a way to cancel the current flush operation via <xref:System.IO.Pipelines.PipeWriter.CancelPendingFlush*?displayProperty=nameWithType> without raising an exception. Calling `PipeWriter.CancelPendingFlush` causes the current or next call to <xref:System.IO.Pipelines.PipeWriter.FlushAsync*?displayProperty=nameWithType> or `PipeWriter.WriteAsync` to return a <xref:System.IO.Pipelines.FlushResult> with `IsCanceled` set to `true`. This is useful for halting the yielding flush in a non-destructive and non-exceptional way.

### PipeWriter common problems

* <xref:System.IO.Pipelines.PipeWriter.GetSpan*> and <xref:System.IO.Pipelines.PipeWriter.GetMemory*> return a buffer with at least the requested amount of memory. **Don't** assume exact buffer sizes.
* Successive calls aren't guaranteed to return the same buffer or the same-sized buffer.
* A new buffer must be requested after calling <xref:System.IO.Pipelines.PipeWriter.Advance*> to continue writing more data. The previously acquired buffer can't be written to.
* Calling <xref:System.IO.Pipelines.PipeWriter.GetMemory*> or <xref:System.IO.Pipelines.PipeWriter.GetSpan*> while there's an incomplete call to <xref:System.IO.Pipelines.PipeWriter.FlushAsync*> isn't safe.
* Calling <xref:System.IO.Pipelines.PipeWriter.Complete*> or <xref:System.IO.Pipelines.PipeWriter.CompleteAsync*> while there's unflushed data might result in memory corruption.

## Tips for PipeReader and PipeWriter

Use these tips to successfully use the <xref:System.IO.Pipelines> classes:

* Always complete the [PipeReader](xref:System.IO.Pipelines.PipeReader.Complete*?displayProperty=nameWithType) and [PipeWriter](xref:System.IO.Pipelines.PipeWriter.Complete*?displayProperty=nameWithType), including an exception where applicable.
* Always call <xref:System.IO.Pipelines.PipeReader.AdvanceTo*?displayProperty=nameWithType> after calling <xref:System.IO.Pipelines.PipeReader.ReadAsync*?displayProperty=nameWithType>.
* Periodically `await` <xref:System.IO.Pipelines.PipeWriter.FlushAsync*?displayProperty=nameWithType> while writing, and always check <xref:System.IO.Pipelines.FlushResult.IsCompleted?displayProperty=nameWithType>. Abort writing if `IsCompleted` is `true`, as that indicates the reader is completed and no longer cares about what is written.
* Call <xref:System.IO.Pipelines.PipeWriter.FlushAsync*?displayProperty=nameWithType> after writing something that you want the `PipeReader` to have access to.
* Don't call `FlushAsync` if the reader can't start until `FlushAsync` finishes, as that might cause a deadlock.
* Ensure that only one context "owns" a `PipeReader` or `PipeWriter` or accesses them. These types aren't thread-safe.
* Never access a <xref:System.IO.Pipelines.ReadResult.Buffer*?displayProperty=nameWithType> after calling <xref:System.IO.Pipelines.PipeReader.AdvanceTo*?displayProperty=nameWithType> or completing the `PipeReader`.

## IDuplexPipe

<xref:System.IO.Pipelines.IDuplexPipe> is a contract for types that support both reading and writing. For example, a network connection is represented by an `IDuplexPipe`.

Unlike `Pipe`, which contains a `PipeReader` and a `PipeWriter`, `IDuplexPipe` represents a single side of a full duplex connection. What you write to the `PipeWriter` won't be read from the `PipeReader`.

## Streams

When reading or writing stream data, you typically read data using a de-serializer and write data using a serializer. Most of these read and write stream APIs have a `Stream` parameter. To make it easier to integrate with these existing APIs, `PipeReader` and `PipeWriter` expose an <xref:System.IO.Pipelines.PipeReader.AsStream*> method. <xref:System.IO.Pipelines.PipeWriter.AsStream*> returns a `Stream` implementation around the `PipeReader` or `PipeWriter`.

### Stream example

Create `PipeReader` and `PipeWriter` instances using the static `Create` methods given a <xref:System.IO.Stream> object and optional corresponding creation options.

The <xref:System.IO.Pipelines.StreamPipeReaderOptions> allow for control over the creation of the `PipeReader` instance with the following parameters:

- <xref:System.IO.Pipelines.StreamPipeReaderOptions.BufferSize?displayProperty=nameWithType> is the minimum buffer size in bytes used when renting memory from the pool, and defaults to `4096`.
- <xref:System.IO.Pipelines.StreamPipeReaderOptions.LeaveOpen?displayProperty=nameWithType> flag determines whether or not the underlying stream is left open after the `PipeReader` completes, and defaults to `false`.
- <xref:System.IO.Pipelines.StreamPipeReaderOptions.MinimumReadSize?displayProperty=nameWithType> represents the threshold of remaining bytes in the buffer before a new buffer is allocated, and defaults to `1024`.
- <xref:System.IO.Pipelines.StreamPipeReaderOptions.Pool?displayProperty=nameWithType> is the `MemoryPool<byte>` used when allocating memory, and defaults to `null`.

The <xref:System.IO.Pipelines.StreamPipeWriterOptions> allow for control over the creation of the `PipeWriter` instance with the following parameters:

- <xref:System.IO.Pipelines.StreamPipeWriterOptions.LeaveOpen?displayProperty=nameWithType> flag determines whether or not the underlying stream is left open after the `PipeWriter` completes, and defaults to `false`.
- <xref:System.IO.Pipelines.StreamPipeWriterOptions.MinimumBufferSize?displayProperty=nameWithType> represents the minimum buffer size to use when renting memory from the <xref:System.IO.Pipelines.StreamPipeWriterOptions.Pool>, and defaults to `4096`.
- <xref:System.IO.Pipelines.StreamPipeWriterOptions.Pool?displayProperty=nameWithType> is the `MemoryPool<byte>` used when allocating memory, and defaults to `null`.

> [!IMPORTANT]
> When creating `PipeReader` and `PipeWriter` instances using the `Create` methods, consider the `Stream` object lifetime. If you need access to the stream after the reader or writer is done with it, set the `LeaveOpen` flag to `true` on the creation options. Otherwise, the stream is closed.

This code demonstrates creating `PipeReader` and `PipeWriter` instances using the `Create` methods from a stream.

:::code language="csharp" source="snippets/pipelines_2/Program.cs":::

The application uses a <xref:System.IO.StreamReader> to read the *lorem-ipsum.txt* file as a stream, and it must end with a blank line. The <xref:System.IO.FileStream> is passed to <xref:System.IO.Pipelines.PipeReader.Create*?displayProperty=nameWithType>, which instantiates a `PipeReader` object. The console application then passes its standard output stream to <xref:System.IO.Pipelines.PipeWriter.Create*?displayProperty=nameWithType> using <xref:System.Console.OpenStandardOutput?displayProperty=nameWithType>. The example supports [cancellation](#cancellation).
