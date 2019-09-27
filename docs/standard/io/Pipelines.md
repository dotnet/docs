---
title: "I/O pipelines in .NET"
ms.date: "10/01/2019"
ms.technology: dotnet-standard
dev_langs:
  - "csharp"
helpviewer_keywords:
  - "asynchronous I/O"
  - "synchronous I/O"
  - "streams, asynchronous streams"
  - "I/O [.NET Framework], asynchronous I/O"
ms.assetid: dbdd55ee-d6b9-4f9e-bad0-ab0edd4457f7
author: "mairaw"
ms.author: "mairaw"
---
# System.IO.Pipelines

<!--  This is auto generated
- [What problem does it solve?](#solve)
- [Pipe](#pipe)
    - [Basic usage](#pbu)
    - [Backpressure and flow control](#backpressure-and-flow-control)
    - [PipeScheduler](#pipescheduler)
    - [Reset](#reset)
- [PipeReader](#pipereader)
    - [Scenarios](#scenarios)
    - [Cancellation](#cancellation)
    - [Common problems](#gotchas)
- [PipeWriter](#pipewriter)
    - [Scenarios](#)
    - [Cancellation](#cancellation)
    - [Gotchas](#)
- [IDuplexPipe](#iduplexpipe)
- [Streams](#streams)
- -->

`System.IO.Pipelines` is a new library that is designed to make it easier to do high performance IO in .NET. It’s a library targeting .NET Standard that works on all .NET implementations.

<a name="solve"></a>

## What problem does System.IO.Pipelines solve

Apps that parse streaming data are composed of boilerplate code having many corner cases. The boilerplate/corner case code is complex and difficult to maintain.

System.IO.Pipelines was architected to:

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

- The entire message (end of line) might not be received in a single call to `ReadAsync`.
- It's ignoring the result of `stream.ReadAsync`.  `stream.ReadAsync` returns how much data was read.
- It doesn't handle the case where multiple lines are read in a single `ReadAsync` call.

To fix the preceding problems, the following changes are required:

- Buffer the incoming data until a new line is found.
- Parse all of the lines returned in the buffer.
- It's possible that the line is bigger than 1KiB (1024 bytes). The code needs to resize the input buffer a complete line is found.

  - If the buffer is re-sized, more buffer copies are made as longer lines appear in the input.
  - To reduce wasted space, compact the buffer used for reading lines.
- Consider using buffer pooling to avoid allocating memory repeatedly.
- The following code address some of these problems:


The preceding code is complex and doesn't address all the problems identified. High-performance networking usually means writing very complex code in order to maximize performance. **System.IO.Pipelines** was designed to make writing this type of code easier.

## Pipe

The <xref:System.IO.Pipelines.Pipe> class can be used to create a `PipeWriter/PipeReader` pair. All data written into the `PipeWriter` is available in the `PipeReader`:

[!code-csharp[](media/pipelines/code/Pipe.cs?name=snippet2)]

<a name="pbu"></a>

### Pipe basic usage

[!code-csharp[](media/pipelines/code/Pipe.cs?name=snippet)]

There are 2 loops:

- `FillPipeAsync` reads from the `Socket` and writes to the `PipeWriter`.
- `ReadPipeAsync` reads from the `PipeReader` and parses incoming lines.

There are no explicit buffers allocated. All buffer management is delegated to the `PipeReader` and `PipeWriter` implementations. Delegating buffer management makes it easier for consuming code to focus solely on the business logic.

In the first loop`:

* `PipeWriter.GetMemory(int)` is called to get memory from the underlying writer.
* `PipeWriter.Advance(int)` is called to tell the `PipeWriter` how much data was written to the buffer.
* <xref:System.IO.Pipelines.PipeWriter.FlushAsync*> is called to make the data available to the `PipeReader`.

In the second loop, the `PipeReader` consumes the buffers written by `PipeWriter`. The buffers come from the Socket. The call to `PipeReader.ReadAsync`:

* Returns a `ReadResult` which contains two important pieces of information:

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
* The reading thread will have to either slow down or allocate more memory to store the data for the parsing thread.

For optimal performance, there is a balance between frequent pauses and allocating more memory.

To solve the preceding problem, the `Pipe` has two settings to control the flow of data:

* `PauseWriterThreshold`: Determines how much data should be buffered before calls to <xref:System.IO.Pipelines.PipeWriter.FlushAsync*> pauses.
* `ResumeWriterThreshold`: Determines how much data should be buffered before calls to `PipeWriter.FlushAsync` pauses.

The `ResumeWriterThreshold` controls how much the reader has to observe before writing can resume.

![diagram with ResumeWriterThreshold and PauseWriterThreshold](media/pipelines/resume-pause.png)

<xref:System.IO.Pipelines.PipeWriter.FlushAsync*>:

* Returns an incomplete `ValueTask<FlushResult>` when the amount of data in the `Pipe` crosses `PauseWriterThreshold`.
* Completes `ValueTask<FlushResult>` when it becomes lower than `ResumeWriterThreshold`.

Two values are used to prevent rapid cycling if one value was used.

#### Examples

```csharp
// The Pipe will start returning incomplete tasks from FlushAsync until
// the reader examines at least 5 bytes.
var options = new PipeOptions(pauseWriterThreshold: 10, resumeWriterThreshold: 5);
var pipe = new Pipe(options);
```

### PipeScheduler

<xref:System.IO.Pipelines.PipeScheduler>

Typically when using `async` amd `await`, asynchronous code resumes on either on a <xref:System.Threading.Tasks.TaskScheduler> or on the current  <xref:System.Threading.SynchronizationContext>.

When doing IO, it's important to have fine-grained control over where that IO is performed. This control allows taking advantage of CPU caches effectively. Efficient caching is critical for high-performance apps like web servers. <xref:System.IO.Pipelines.PipeScheduler> provides control over where asynchronous callbacks run. By default:

* The current `SynchronizationContext` will be used.
* If there is no `SynchronizationContext`, it will use the thread pool to run callbacks.

#### Examples

[!code-csharp[](media/pipelines/code/Program.cs?name=snippet)]

### Pipe reset

It's frequently efficient to reuse the Pipe object. To reset the pipe, call <xref:System.IO.Pipelines.PipeReader> <xref:System.IO.Pipelines.Pipe.Reset*> when both the `PipeReader` and `PipeWriter` are complete.

## PipeReader

<xref:System.IO.Pipelines.PipeReader> manages memory on the caller's behalf. **Always** call <xref:System.IO.Pipelines.PipeReader.AdvanceTo*> after calling `PipeReader.ReadAsync`. This lets the `PipeReader` know when the caller is done with the memory so that it can be tracked. The `ReadOnlySequence<byte>` returned from `PipeReader.ReadAsync` is only valid until the call the `PipeReader.AdvanceTo`:

* It's illegal to use `ReadOnlySequence<byte>` after calling `PipeReader.AdvanceTo`.
* Using `ReadOnlySequence<byte>` after calling `PipeReader.AdvanceTo` is undefined.

`PipeReader.AdvanceTo` takes two `SequencePosition` arguments:

* The first argument determines how much memory was consumed.
* The second argument determines how much of the buffer was observed.

<!-- What about <xref:System.IO.Pipelines.PipeReader.AdvanceTo*> that takes 1 arg? -->

Marking data as consumed means that the pipe can return the memory to the underlying buffer pool. Marking data as observed controls what the next call to `PipeReader.ReadAsync` does. Marking everything as observed means that the next call to `PipeReader.ReadAsync` will not return until there's more data written to the pipe. Any other value will make the next call to `PipeReader.ReadAsync` return immediately with the unobserved data.

### Scenarios

There are a couple of typical patterns that emerge when trying to read streaming data:

- Given a stream of data, parse a single message.
- Given a stream of data, parse all available messages.

The following examples use the `TryParseMessage` method for parsing messages from a `ReadOnlySequence<byte>`. This method will parse a single message and update the input buffer to trim the parsed message from the buffer.

```csharp
bool TryParseMessage(ref ReadOnlySequence<byte> buffer, out Message message);
```

#### Reading a single message

The following code reads a single message from a `PipeReader` and returns it to the caller.

[!code-csharp[](media/pipelines/code/ReadSingleMsg.cs?name=snippet)]

The preceding code:

* Parses a single message.
* Updates the consumed `SequencePosition` and examined `SequencePosition` to point to the start of the trimmed input buffer.

The two `SequencePosition` arguments are updated because `TryParseMessage` removes the parsed message from the input buffer. Generally, when parsing a single message from the buffer, the examined position should be one of the following:

* The end of the message.
* The end of the received buffer if no message was found.

The single message case has the most potential for errors. Passing the wrong values to *examined* can result in an out of memory exception or and infinite loop. For more information, see the [PipeReader common problems](#gotchas) section in this document.

#### Reading multiple messages

The code below reads all messages from a `PipeReader` and calls `ProcessMessageAsync` on each.

```csharp
async Task ProcessMessagesAsync(PipeReader reader, CancellationToken cancellationToken = default)
{
    try
    {
        while (true)
        {
            ReadResult result = await reader.ReadAsync(cancellationToken);
            ReadOnlySequence<byte> buffer = result.Buffer;

            try
            {
                // Process all messages from the buffer, modifying the input buffer on each iteration
                while (TryParseMessage(ref buffer, out Message message))
                {
                    await ProcessMessageAsync(message);
                }

                // There's no more data to be processed
                if (result.IsCompleted)
                {
                    if (buffer.Length > 0)
                    {
                        // We have an incomplete message and there's no more data to process
                        throw new InvalidDataException("Incomplete message!");
                    }
                    break;
                }
            }
            finally
            {
                // Since we're processing all messages in the buffer, we can use the remaining buffer's Start and End
                // position to determine consumed and examined
                reader.AdvanceTo(buffer.Start, buffer.End);
            }
        }
    }
    finally
    {
        await reader.CompleteAsync();
    }
}
```

### Cancellation

`PipeReader.ReadAsync` supports passing a `CancellationToken` which will result in an `OperationCanceledException` if the token is cancelled while there's a read pending. It also supports a way to cancel the current read operation via `PipeReader.CancelPendingRead` which avoids raising an exception. Calling this method will return a `ReadResult` with `IsCanceled` set to true. This can be extremely useful for halting the existing read loop in a non-destructive and non-exceptional way.

```csharp
public class MyConnection
{
    private PipeReader reader;
    
    public MyConnection(PipeReader reader)
    {
        this.reader = reader;
    }
    
    public void Abort()
    {
        // Cancel the pending read so the the process loop ends without an exception
        reader.CancelPendingRead();
    }
    
    public async Task ProcessMessagesAsync()
    {
        try
        {
            while (true)
            {
                ReadResult result = await reader.ReadAsync();
                ReadOnlySequence<byte> buffer = result.Buffer;

                try
                {
                    if (result.IsCanceled)
                    {
                        // The read was canceled, we can quit without reading the existing data
                        break;
                    }

                    // Process all messages from the buffer, modifying the input buffer on each iteration
                    while (TryParseMessage(ref buffer, out Message message))
                    {
                        await ProcessMessageAsync(message);
                    }

                    // There's no more data to be processed
                    if (result.IsCompleted)
                    {
                        break;
                    }
                }
                finally
                {
                    // Since we're processing all messages in the buffer, we can use the remaining buffer's Start and End
                    // position to determine consumed and examined
                    reader.AdvanceTo(buffer.Start, buffer.End);
                }
            }
        }
        finally
        {
            await reader.CompleteAsync();
        }
    }
}
```

<a name="gotchas"></a>

### PipeReader common problems

- Passing the wrong values to consumed/examined may result in reading already read data (for e.g. passing a `SequencePosition` that was already processed)
- Passing `buffer.End` as examined may result in stalled data, and possibly an eventual OOM if data is not consumed. (for example, `PipeReader.AdvanceTo(position, buffer.End)` when processing a single message at a time from the buffer.)
- Passing the wrong values to consumed/examined may result in an infinite loop. (for example, `PipeReader.AdvanceTo(buffer.Start)` if `buffer.Start` hasn't changed will cause the next call to `PipeReader.ReadAsync` to return immediately before new data arrives)
- Passing the wrong values to consumed/examined may result in inifinite buffering (eventual OOM). (for example, `PipeReader.AdvanceTo(buffer.Start, buffer.End)` unconditionally when processing a single message at a time from the buffer)
- Using the `ReadOnlySequence<byte>` after calling `PipeReader.AdvanceTo` may result in memory corruption (use after free).
- Failing to call `PipeReader.Complete/CompleteAsync` may result in a memory leak.
- Checking `ReadResult.IsCompleted` and exiting the reading logic before processing the buffer will result in data loss. The loop exit condition should be based on `ReadResult.Buffer.IsEmpty` and `ReadResult.IsCompleted`. Doing this in the wrong order could result in an infinite loop.

#### Code samples

[!INCLUDE[](media/pipelines/do-not-use-include1.md)]

❌ **Data loss**

The `ReadResult` can return the final segment of data when `IsCompleted` is set to true. Not reading that data before exiting the read loop will result in data loss.

```csharp
Environment.FailFast("This code is terrible, don't use it!");
while (true)
{
    ReadResult result = await reader.ReadAsync(cancellationToken);
    ReadOnlySequence<byte> dataLossBuffer = result.Buffer;
    
    if (result.IsCompleted)
    {
        break;
    }
    
    Process(ref dataLossBuffer, out Message message);
    
    reader.AdvanceTo(dataLossBuffer.Start, dataLossBuffer.End);
}
```

[!INCLUDE[](media/pipelines/do-not-use-include2.md)]

❌ **Infinite loop**

The following logic may result in an infinite loop if the `Result.IsCompleted` is true but there's never a complete message in the buffer.

[!INCLUDE[](media/pipelines/do-not-use-include1.md)]

```csharp
Environment.FailFast("This code is terrible, don't use it!");
while (true)
{
    ReadResult result = await reader.ReadAsync(cancellationToken);
    ReadOnlySequence<byte> infiniteLoopBuffer = result.Buffer;
    if (result.IsCompleted && infiniteLoopBuffer.IsEmpty)
    {
        break;
    }
    
    Process(ref infiniteLoopBuffer, out Message message);
    
    reader.AdvanceTo(infiniteLoopBuffer.Start, infiniteLoopBuffer.End);
}
```
[!INCLUDE[](media/pipelines/do-not-use-include2.md)]

Here's another piece of code with the same problem. It's checking for a non-empty buffer before checking `ReadResult.IsCompleted`, but since it's in an `else if`, it will loop forever if there's never a complete message in the buffer.

[!INCLUDE[](media/pipelines/do-not-use-include1.md)]

```csharp
Environment.FailFast("This code is terrible, don't use it!");
while (true)
{
    ReadResult result = await reader.ReadAsync(cancellationToken);
    ReadOnlySequence<byte> infiniteLoopBuffer = result.Buffer;
    
    if (!infiniteLoopBuffer.IsEmpty)
    {
        Process(ref infiniteLoopBuffer, out Message message);
    }
    else if (result.IsCompleted)
    {
        break;
    }
    
    reader.AdvanceTo(infiniteLoopBuffer.Start, infiniteLoopBuffer.End);
}
```
[!INCLUDE[](media/pipelines/do-not-use-include2.md)]

❌ **Unexpected Hang**

Unconditionally calling `PipeReader.AdvanceTo` with `buffer.End` in the examined position may result in hangs when parsing a single message. The next call to `PipeReader.AdvanceTo` will not return until there's more data written to the pipe, that was not previously examined.

[!INCLUDE[](media/pipelines/do-not-use-include1.md)]

```csharp
Environment.FailFast("This code is terrible, don't use it!");
while (true)
{    
    ReadResult result = await reader.ReadAsync(cancellationToken);
    ReadOnlySequence<byte> hangBuffer = result.Buffer;
    
    Process(ref hangBuffer, out Message message);
    
    if (result.IsCompleted)
    {
        break;
    }
    
    reader.AdvanceTo(hangBuffer.Start, hangBuffer.End);
    
    if (message != null)
    {
        return message;
    }
}
```
[!INCLUDE[](media/pipelines/do-not-use-include2.md)]

❌ **Out of Memory**

If there's no maximum message size and the data returned from the `PipeReader` does not make a complete message (because the other side is writing a large message e.g 4GB) the logic below will keep buffering until an `OutOfMemoryException` occurs.

[!INCLUDE[](media/pipelines/do-not-use-include1.md)]

```csharp
Environment.FailFast("This code is terrible, don't use it!");
while (true)
{
    ReadResult result = await reader.ReadAsync(cancellationToken);
    ReadOnlySequence<byte> thisCouldOutOfMemory = result.Buffer;
    
    Process(ref thisCouldOutOfMemory, out Message message);
    
    if (result.IsCompleted)
    {
        break;
    }
    
    reader.AdvanceTo(thisCouldOutOfMemory.Start, thisCouldOutOfMemory.End);
    
    if (message != null)
    {
        return message;
    }
}
```

[!INCLUDE[](media/pipelines/do-not-use-include1.md)]

❌ **Memory Corruption**

When writing helpers that read the buffer, any returned payload should be copied before calling Advance. The following example will return memory that the `Pipe` has discarded and may reuse it for the next operation (read/write).

[!INCLUDE[](media/pipelines/do-not-use-include1.md)]

```csharp
public class Message
{
   public ReadOnlySequence<byte> CorruptedPayload { get; set; }
}

Environment.FailFast("This code is terrible, don't use it!");
while (true)
{
    ReadResult result = await reader.ReadAsync(cancellationToken);
    ReadOnlySequence<byte> buffer = result.Buffer;
    
    ReadHeader(ref buffer, out int length);
    
    if (length > 0)
    {
        message = new Message 
        {
            // Slice the payload from the existing buffer
            CorruptedPayload = buffer.Slice(0, length);
        };
        
        buffer = buffer.Slice(length);
    }
    
    if (result.IsCompleted)
    {
        break;
    }
    
    reader.AdvanceTo(buffer.Start, buffer.End);
    
    if (message != null)
    {
        // This code is broken since we called reader.AdvanceTo() with a position *after* the buffer we captured
        return message;
    }
}
```

[!INCLUDE[](media/pipelines/do-not-use-include2.md)]

## PipeWriter

The <xref:System.IO.Pipelines.PipeWriter> manages buffers for writing on the caller's behalf. `PipeWriter` implements [`IBufferWriter<byte>`](/dotnet/api/system.buffers.ibufferwriter-1). `IBufferWriter<byte>` makes it possible to get access to buffers in order to perform writes without additional buffer copies.

[!code-csharp[](media/pipelines/code/MyPipeWriter.cs?name=snippet)]

The preceding code:

* Requests a buffer of at least 5 bytes from the `PipeWriter` using `GetSpan(5)`. 
* Writes bytes for the ASCII string "Hello" to the returned `Span<byte>`.
* Calls `Advance(written)` to indicate how many bytes were written to the buffer.
* Flushes the `PipeWriter`, which sends the bytes to the underlying device.

The preceding method of writing uses the buffers provided by the `PipeWriter`. Alternatively,[PipeWriter.WriteAync](xref:System.IO.Pipelines.PipeWriter.WriteAsync*):

* Copies the existing buffer to the `PipeWriter`.
* Calls `GetSpan`, `Advance` as appropriate and calls `PipeWriter.FlushAsync`.

[!code-csharp[](media/pipelines/code/MyPipeWriter.cs?name=snippe2)]

zz
```csharp
async Task WriteHelloAsync(PipeWriter writer, CanceallationToken cancellationToken = default)
{
    byte[] helloBytes = Encoding.ASCII.GetBytes("Hello");
    
    // Write helloBytes to the writer, there's no need to call Advance here (Write does that)
    await writer.WriteAsync(helloBytes, cancellationToken);
}
```

### Cancellation

<xref:System.IO.Pipelines.PipeWriter.FlushAsync*> supports passing a `CancellationToken`. Passing a `CancellationToken` results in an `OperationCanceledException` if the token is cancelled while there's a flush pending. `PipeWriter.FlushAsync` supports a way to cancel the current flush operation via `PipeWriter.CancelPendingFlush` without raising an exception. Calling `PipeWriter.CancelPendingFlush` returns a `FlushResult` with `IsCanceled` set to `true`. This can be extremely useful for halting the yielding flush in a non-destructive and non-exceptional way.

<a name="pwcm"></a>

### PipeWriter common problems

- `GetSpan` and `GetMemory` return a buffer with at least the requested amount of memory. Don't assume exact buffer sizes.
- There is no guarantee that successive calls will return the same buffer or the same-sized buffer.
- A new buffer must be requested after calling `Advance` to continue writing more data. The previously acquired buffer cannot be written to.
- Calling `GetMemory` or `GetSpan` while there's an incomplete call to `FlushAsync` is not safe.
- Calling `Complete` or `CompleteAsync` while there's unflushed data can result in memory corruption.

## IDuplexPipe

The <xref:System.IO.Pipelines.IDuplexPipe> is a contract for types that support both reading and writing. For example, a network connection would be represented by an `IDuplexPipe`.

## Streams

When reading or writing stream data you typically read data using a de-serializer and write data using a serializer. Most of these read/write stream APIs have a `Stream` parameter. In order to make it easier to integrate with these existing APIs, `PipeReader` and `PipeWriter` expose an `AsStream`.  `AsStream` returns a `Stream` implementation around the `PipeReader` or `PipeWriter`.
