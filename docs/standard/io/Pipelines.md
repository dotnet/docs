---
title: "I/O pipelines in .NET"
ms.date: "10/01/2019"
ms.technology: dotnet-standard
dev_langs:
  - "csharp"
  - "vb"
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

- [What problem does it solve?](#what-problem-does-it-solve)
- [Pipe](#pipe)
    - [Basic usage](#basic-usage)
    - [Backpressure and flow control](#backpressure-and-flow-control)
    - [PipeScheduler](#pipescheduler)
    - [Reset](#reset)
- [PipeReader](#pipereader)
    - [Scenarios](#scenarios)
    - [Cancellation](#cancellation)
    - [Gotchas](#gotchas)
- [PipeWriter](#pipewriter)
    - [Scenarios](#)
    - [Cancellation](#cancellation)
    - [Gotchas](#)
- [IDuplexPipe](#iduplexpipe)
- [Streams](#streams)

`System.IO.Pipelines` is a new library that is designed to make it easier to do high performance IO in .NET. It’s a library targeting .NET Standard that works on all .NET implementations.

## What problem does System.IO.Pipelines solve?

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

```csharp
async Task ProcessLinesAsync(NetworkStream stream)
{
    byte[] buffer = ArrayPool<byte>.Shared.Rent(1024);
    var bytesBuffered = 0;
    var bytesConsumed = 0;

    while (true)
    {
        // Calculate the amount of bytes remaining in the buffer
        var bytesRemaining = buffer.Length - bytesBuffered;

        if (bytesRemaining == 0)
        {
            // Double the buffer size and copy the previously buffered data into the new buffer
            var newBuffer = ArrayPool<byte>.Shared.Rent(buffer.Length * 2);
            Buffer.BlockCopy(buffer, 0, newBuffer, 0, buffer.Length);
            // Return the old buffer to the pool
            ArrayPool<byte>.Shared.Return(buffer);
            buffer = newBuffer;
            bytesRemaining = buffer.Length - bytesBuffered;
        }

        var bytesRead = await stream.ReadAsync(buffer, bytesBuffered, bytesRemaining);
        if (bytesRead == 0)
        {
            // EOF
            break;
        }
        
        // Keep track of the amount of buffered bytes
        bytesBuffered += bytesRead;
        
        do
        {
            // Look for a EOL in the buffered data
            linePosition = Array.IndexOf(buffer, (byte)'\n', bytesConsumed, bytesBuffered - bytesConsumed);

            if (linePosition >= 0)
            {
                // Calculate the length of the line based on the offset
                var lineLength = linePosition - bytesConsumed;

                // Process the line
                ProcessLine(buffer, bytesConsumed, lineLength);

                // Move the bytesConsumed to skip past the line we consumed (including \n)
                bytesConsumed += lineLength + 1;
            }
        }
        while (linePosition >= 0);
    }
}
```

The preceding code is complex, and doesn't address all the problems identified. High-performance networking usually means writing very complex code in order to maximize performance. **System.IO.Pipelines** was designed to make writing this type of code easier.

## Pipe

The <xref:System.IO.Pipelines.Pipe> class can be used to create a `PipeWriter/PipeReader` pair. All data written into the `PipeWriter` is available in the `PipeReader`:

```csharp
var pipe = new Pipe();
PipeReader reader = pipe.Reader;
PipeWriter reader = pipe.Writer;
```

### Pipe basic usage

```csharp
async Task ProcessLinesAsync(Socket socket)
{
    var pipe = new Pipe();
    Task writing = FillPipeAsync(socket, pipe.Writer);
    Task reading = ReadPipeAsync(pipe.Reader);

    return Task.WhenAll(reading, writing);
}

async Task FillPipeAsync(Socket socket, PipeWriter writer)
{
    const int minimumBufferSize = 512;

    while (true)
    {
        // Allocate at least 512 bytes from the PipeWriter.
        Memory<byte> memory = writer.GetMemory(minimumBufferSize);
        try
        {
            int bytesRead = await socket.ReceiveAsync(memory, SocketFlags.None);
            if (bytesRead == 0)
            {
                break;
            }
            // Tell the PipeWriter how much was read from the Socket.
            writer.Advance(bytesRead);
        }
        catch (Exception ex)
        {
            LogError(ex);
            break;
        }

        // Make the data available to the PipeReader.
        FlushResult result = await writer.FlushAsync();

        if (result.IsCompleted)
        {
            break;
        }
    }

    // Tell the PipeReader that there's no more data.
    writer.Complete();
}

async Task ReadPipeAsync(PipeReader reader)
{
    while (true)
    {
        ReadResult result = await reader.ReadAsync();
        ReadOnlySequence<byte> buffer = result.Buffer;

        while (TryReadLine(ref buffer, out ReadOnlySequence<byte> line))
        {
            // Process the line.
            ProcessLine(line);
        }

        // Tell the PipeReader how much of the buffer has been consumed.
        reader.AdvanceTo(buffer.Start, buffer.End);

        // Stop reading if there's no more data.
        if (result.IsCompleted)
        {
            break;
        }
    }

    // Mark the PipeReader as complete.
    reader.Complete();
}

bool TryReadLine(ref ReadOnlySequence<byte> buffer, out ReadOnlySequence<byte> buffer)
{
    // Look for a EOL in the buffer.
    SequencePosition? position = buffer.PositionOf((byte)'\n');

    if (position == null)
    {
        buffer = default;
        return false;
    }
    
    // Skip the line and the \n
    buffer = buffer.Slice(buffer.GetPosition(1, position.Value));
    return true;
}
```

There are 2 loops:

- `FillPipeAsync` reads from the `Socket` and writes into the `PipeWriter`.
- `ReadPipeAsync` reads from the `PipeReader` and parses incoming lines.

There are no explicit buffers allocated. All buffer management is delegated to the `PipeReader`/`PipeWriter` implementations. This makes it easier for consuming code to focus solely on the business logic instead of complex buffer management.

In the first loop, `PipeWriter.GetMemory(int)`:

* Is called to get memory from the underlying writer.
* `PipeWriter.Advance(int)` is called to tell the `PipeWriter` how much data was written to the buffer. 
* `PipeWriter.FlushAsync` is called to make the data available to the `PipeReader`.

In the second loop, the `PipeReader` consumes the buffers written to the `PipeWriter`. The buffers come from the Socket. The call to `PipeReader.ReadAsync`:

* Returns a `ReadResult` which contains two important pieces of information:

  * The data that was read in the form of `ReadOnlySequence<byte>`.
  * A boolean `IsCompleted` that indicates if the end of data (EOF) has been reached. 

After finding the end of line (EOL) delimiter and parsing the line:

* The logic slices the buffer to skip what's already processed and then we call `PipeReader.AdvanceTo` to tell the `PipeReader` how much data we have consumed and examined.

In the second loop, the `PipeReader` consumes the buffers written to the `PipeWriter`. The buffers come from the Socket. The call to `PipeReader.ReadAsync` returns a `ReadResult` which contains two important pieces of information, the data that was read in the form of `ReadOnlySequence<byte>` and a boolean `IsCompleted` that indicates if we've reached the end of data (EOF). 
After finding the end of line (EOL) delimiter and parsing the line, the logic slices the buffer to skip what we've already processed and then we call `PipeReader.AdvanceTo` to tell the `PipeReader` how much data we have consumed and examined.

At the end of each of the loops, we complete both the reader and the writer. This lets the underlying Pipe release all of the memory it allocated.

### Backpressure and flow control

In a perfect world, reading & parsing work as a team: the writing thread consumes the data from the network and puts it in buffers while the parsing thread is responsible for constructing the appropriate data structures. Normally, parsing will take more time than just copying blocks of data from the network. As a result, the reading thread can easily overwhelm the parsing thread. The result is that the reading thread will have to either slow down or allocate more memory to store the data for the parsing thread. For optimal performance, there is a balance between frequent pauses and allocating more memory.

To solve this problem, the `Pipe` has two settings to control the flow of data, the `PauseWriterThreshold` and the `ResumeWriterThreshold`. The `PauseWriterThreshold` determines how much data should be buffered before calls to PipeWriter.FlushAsync pauses. The `ResumeWriterThreshold` controls how much the reader has to observe before writing can resume.

![image](https://user-images.githubusercontent.com/95136/64408565-ee3af580-d03b-11e9-9e8a-5b9bc56d592b.png)

`PipeWriter.FlushAsync` returns an incomplete `ValueTask<FlushResult>` when the amount of data in the `Pipe` crosses `PauseWriterThreshold` and completes said ValueTask when it becomes lower than `ResumeWriterThreshold`. Two values are used to prevent thrashing around the limit.

#### Examples

```csharp
// The Pipe will start returning incomplete tasks from FlushAsync until the reader examines at least 5 bytes
var options = new PipeOptions(pauseWriterThreshold: 10, resumeWriterThreshold: 5);
var pipe = new Pipe(options);
```

### [PipeScheduler](/dotnet/api/system.io.pipelines.pipescheduler?view=dotnet-plat-ext-2.1)

Usually when using async/await, asynchronous code resumes on either on a `TaskScheduler` or on the current `SynchronizationContext`.

When doing IO it's very important to have fine-grained control over where that IO is performed so that one can take advantage of CPU caches more effectively, which is critical for high-performance applications like web servers. The `PipeScheduler` gives users control over where asynchronous callbacks run. By default, the current `SynchronizationContext` will be respected and if there is none, it will use the thread pool to run callbacks.

#### Examples

```csharp

public static void Main(string[] args)
{
    var writeScheduler = new SingleThreadPipeScheduler();
    var readScheduler = new SingleThreadPipeScheduler();

    // Tell the Pipe what schedulers to use, we also disable the SynchronizationContext 
    var options = new PipeOptions(readerScheduler: readScheduler, writerScheduler: writeScheduler, useSynchronizationContext: false);
    var pipe = new Pipe(options);
}

// This is a sample scheduler that async callbacks on a single dedicated thread
public class SingleThreadPipeScheduler : PipeScheduler
{
    private readonly BlockingCollection<(Action<object> Action, object State)> _queue = new BlockingCollection<(Action<object> Action, object State)>();
    private readonly Thread _thread;

    public SingleThreadPipeScheduler()
    {
        _thread = new Thread(DoWork);
        _thread.Start();
    }

    private void DoWork()
    {
        foreach (var item in _queue.GetConsumingEnumerable())
        {
            item.Action(item.State);
        }
    }

    public override void Schedule(Action<object> action, object state)
    {
        _queue.Add((action, state));
    }
}
```

### Reset

`Pipe` is a large class, as such it may make sense to reuse the object. To make this possible there's a [`Reset`](/dotnet/api/system.io.pipelines.pipe.reset?view=dotnet-plat-ext-2.1) method that can be used when both the `PipeReader` and `PipeWriter` are complete.

## [PipeReader](/dotnet/api/system.io.pipelines.pipereader?view=dotnet-plat-ext-2.1)

The `PipeReader` manages memory on the caller's behalf. Because of this, it's important to **always** call `PipeReader.AdvanceTo` after calling `PipeReader.ReadAsync`. This lets the `PipeReader` know when the caller is done with the memory so that it can be tracked appropriately. The `ReadOnlySequence<byte>` returned from `PipeReader.ReadAsync` is only valid until the call the `PipeReader.AdvanceTo`. This means that it's illegal to use it after calling `PipeReader.AdvanceTo` and doing so may result in invalid/undocumented/broken behavior. 

`PipeReader.AdvanceTo` takes two `SequencePosition` arguments. The first one determines how much memory was consumed and the second determines how much of the buffer was observed. Marking data as consumed means that the pipe can clean the memory up (return it to the underlying buffer pool etc), while marking data as observed controls what the next call to `PipeReader.ReadAsync` will do. Marking everything as observed means that the next call to `PipeReader.ReadAsync` will not return until there's more data written to the pipe. Any other value will make the next call to `PipeReader.ReadAsync` return immediately with the unobserved data.

### Scenarios

There are a couple of typical patterns that emerge when trying to read streaming data:
- Given a stream of data, parse a single message
- Given a stream of data, parse all available messages

The following examples will use the following method for parsing messages from a `ReadOnlySequence<byte>`. This method will parse a single message and update the input buffer to trim the parsed message from the buffer.

```csharp
bool TryParseMessage(ref ReadOnlySequence<byte> buffer, out Message message);
```

#### Reading a single message

The following code reads a single message from a `PipeReader` and returns it to the caller.

```csharp
async ValueTask<Message> ReadSingleMessageAsync(PipeReader reader, CancellationToken cancellationToken = default)
{
    while (true)
    {
        ReadResult result = await reader.ReadAsync(cancellationToken);
        ReadOnlySequence<byte> buffer = result.Buffer;
        
        // In the event that we don't parse any message successfully, mark consumed as nothing
        // and examined as the entire buffer.
        SequencePosition consumed = buffer.Start;
        SequencePosition examined = buffer.End;
        
        try
        {
            if (TryParseMessage(ref buffer, out Message message))
            {
                // We successfully parsed a single message so mark the start as the parsed buffer as consumed
                // TryParseMessage trims the buffer to point to the data after the message was parsed
                consumed = buffer.Start;
                
                // Examined is marked the same as consumed here so that the next call to ReadSingleMessageAsync
                // will process the next message if there is one
                examined = consumed;

                return message;
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
            reader.AdvanceTo(consumed, examined);
        }
    }
    
    return null;
}
```

The code above parses a single message and updates the consumed `SequencePosition` and examined `SequencePosition` to point to the start of the trimmed input buffer. This is because `TryParseMessage` removes the parsed message from the input buffer. Generally, when parsing a single message from the buffer, the examined position should be the end of the message or the end of the received buffer if no message was found.

The single message case has the most potential for errors. Passing the wrong values to *examined* can result in an OOM or infinite loop (see the [gotchas](#) section below).

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

### Gotchas

- Passing the wrong values to consumed/examined may result in reading already read data (for e.g. passing a `SequencePosition` that was already processed)
- Passing `buffer.End` as examined may result in stalled data, and possibly an eventual OOM if data is not consumed. (for example, `PipeReader.AdvanceTo(position, buffer.End)` when processing a single message at a time from the buffer.)
- Passing the wrong values to consumed/examined may result in an infinite loop. (for example, `PipeReader.AdvanceTo(buffer.Start)` if `buffer.Start` hasn't changed will cause the next call to `PipeReader.ReadAsync` to return immediately before new data arrives)
- Passing the wrong values to consumed/examined may result in inifinite buffering (eventual OOM). (for example, `PipeReader.AdvanceTo(buffer.Start, buffer.End)` unconditionally when processing a single message at a time from the buffer)
- Using the `ReadOnlySequence<byte>` after calling `PipeReader.AdvanceTo` may result in memory corruption (use after free).
- Failing to call `PipeReader.Complete/CompleteAsync` may result in a memory leak.
- Checking `ReadResult.IsCompleted` and exiting the reading logic before processing the buffer will result in data loss. The loop exit condition should be based on `ReadResult.Buffer.IsEmpty` and `ReadResult.IsCompleted`. Doing this in the wrong order could result in an infinite loop.

#### Code samples

These code samples will result in data loss, hangs, potential security issues (depending on where they are used) and should **NOT** be copied. They exist solely for illustration of the gotchas mentioned above.

❌ **Data loss**

The `ReadResult` can return the final segment of data when `IsCompleted` is set to true. Not reading that data before exiting the read loop will result in data loss.

```csharp
// These code samples will result in data loss, hangs, security issues and should **NOT** be copied. They exists solely for illustration of the gotchas mentioned above.
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
// These code samples will result in data loss, hangs, security issues and should **NOT** be copied. They exists solely for illustration of the gotchas mentioned above.
```

❌ **Infinite loop**

The below logic may result in an infinite loop if the `Result.IsCompleted` is true but there's never a complete message in the buffer.

```csharp
// These code samples will result in data loss, hangs, security issues and should **NOT** be copied. They exists solely for illustration of the gotchas mentioned above.
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
// These code samples will result in data loss, hangs, security issues and should **NOT** be copied. They exists solely for illustration of the gotchas mentioned above.
```

Here's another piece of code with the same problem. It's checking for a non-empty buffer before checking `ReadResult.IsCompleted`, but since it's in an `else if`, it will loop forever if there's never a complete message in the buffer.

```csharp
// These code samples will result in data loss, hangs, security issues and should **NOT** be copied. They exists solely for illustration of the gotchas mentioned above.
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
// These code samples will result in data loss, hangs, security issues and should **NOT** be copied. They exists solely for illustration of the gotchas mentioned above.
```

❌ **Unexpected Hang**

Unconditionally calling `PipeReader.AdvanceTo` with `buffer.End` in the examined position may result in hangs when parsing a single message. The next call to `PipeReader.AdvanceTo` will not return until there's more data written to the pipe, that was not previously examined.

```csharp
// These code samples will result in data loss, hangs, security issues and should **NOT** be copied. They exists solely for illustration of the gotchas mentioned above.
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
// These code samples will result in data loss, hangs, security issues and should **NOT** be copied. They exists solely for illustration of the gotchas mentioned above.
```

❌ **Out of Memory**

If there's no maximum message size and the data returned from the `PipeReader` does not make a complete message (because the other side is writing a large message e.g 4GB) the logic below will keep buffering until an `OutOfMemoryException` occurs.

```csharp
// These code samples will result in data loss, hangs, security issues and should **NOT** be copied. They exists solely for illustration of the gotchas mentioned above.
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

❌ **Memory Corruption**

When writing helpers that read the buffer, any returned payload should be copied before calling Advance. The following example will return memory that the `Pipe` has discarded and may reuse it for the next operation (read/write).

```csharp
public class Message
{
   public ReadOnlySequence<byte> CorruptedPayload { get; set; }
}

// These code samples will result in data loss, hangs, security issues and should **NOT** be copied. They exists solely for illustration of the gotchas mentioned above.
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

## [PipeWriter](/dotnet/api/system.io.pipelines.pipewriter?view=dotnet-plat-ext-2.1)

The `PipeWriter` manages buffers for writing on the caller's behalf. `PipeWriter` implements the [`IBufferWriter<byte>`](/dotnet/api/system.buffers.ibufferwriter-1?view=netstandard-2.1) which makes it possible to get access to buffers in order to perform writes without additional buffer copies.

```csharp
async Task WriteHelloAsync(PipeWriter writer, CanceallationToken cancellationToken = default)
{
    // Request at least 5 bytes from the PipeWriter
    Span<byte> span = writer.GetSpan(5);
    ReadOnlySpan<char> helloSpan = "Hello".AsSpan();
    
    // Write directly into the buffer
    int written = Encoding.ASCII.GetBytes(helloSpan, span);
    
    // Tell the writer how many bytes we wrote
    writer.Advance(written);
    
    await writer.FlushAsync(cancellationToken);
}
```

The preceding method requests a buffer of at least 5 bytes from the `PipeWriter` using `GetSpan(5)`. It then writes bytes for the ASCII string "Hello" to the returned `Span<byte>`. It then calls `Advance(written)` to indicate how many bytes were written to the buffer. Flushing the `PipeWriter` pushes the bytes to the underlying device.

This method of writing will use the buffers provided by the `PipeWriter` but you can also use the [`PipeWriter.WriteAync`](/dotnet/api/system.io.pipelines.pipewriter.writeasync?view=dotnet-plat-ext-3.0)  method to copy an existing buffer to the `PipeWriter`. This will do the work of calling `GetSpan` and `Advance` as appropriate and will also call `PipeWriter.FlushAsync`.

```csharp
async Task WriteHelloAsync(PipeWriter writer, CanceallationToken cancellationToken = default)
{
    byte[] helloBytes = Encoding.ASCII.GetBytes("Hello");
    
    // Write helloBytes to the writer, there's no need to call Advance here (Write does that)
    await writer.WriteAsync(helloBytes, cancellationToken);
}
```

### Cancellation

`PipeWriter.FlushAsync` supports passing a `CancellationToken` which will result in an `OperationCanceledException` if the token is cancelled while there's a flush pending. It also supports a way to cancel the current flush operation via `PipeWriter.CancelPendingFlush` without raising an exception. Calling this method will return a `FlushResult` with `IsCanceled` set to true. This can be extremely useful for halting the yielding flush in a non-destructive and non-exceptional way.

### Gotchas

- `GetSpan` and `GetMemory` return a buffer with at least the requested amount of memory. Don't assume exact buffer sizes.
- There is no guarantee that successive calls will return the same buffer or the same-sized buffer.
- You must request a new buffer after calling `Advance` to continue writing more data; you cannot write to a previously acquired buffer.
- Calling `GetMemory` or `GetSpan` while there's an incomplete call to `FlushAsync` is not safe.
- Calling `Complete` or `CompleteAsync` while there's unflushed data can result in memory corruption.

## [IDuplexPipe](/dotnet/api/system.io.pipelines.iduplexpipe?view=dotnet-plat-ext-2.1)

The `IDuplexPipe` is a contract for types that support both reading and writing. For example, a network connection would be represented by an `IDuplexPipe`.

## Streams

When reading streaming data it is very common to read data using a de-serializer or write data using a serializer. Most of these APIs take `Stream` today. In order to make it easier to integrate with these existing APIs `PipeReader` and `PipeWriter` expose an `AsStream` which will return a `Stream` implementation around the `PipeReader` or `PipeWriter`. 
