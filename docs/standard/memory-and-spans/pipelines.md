---
title: "Pipelines"
ms.date: "01/18/2019"
ms.technology: dotnet-standard
helpviewer_keywords: 
  - "Pipe"
  - "IDuplexPipe"
  - "DuplexPipe"
  - "Duplex Connection"
author: "KPixel"
#ms.author: "TODO"
---
# Pipelines

## Who would be interested in this tutorial

.NET Core has been improving a lot in high-performance applications. One of the key scenarios has been to make it as fast and efficient as possible to run a website, and more generally network-based applications.

.NET Core 2.1 introduces a new primitive called Span and builds a new way to read and write data on top of it.
Kestrel and SignalR are two libraries built on top of this new API.

If you are just planning to use these libraries, you do not need to read this article. However, if you want to understand how they work internally, or write your own low-level library, this article is for you.
We will introduces three layers: System primitives (`Span`, `Memory`), Pipelines (`Pipe`, `DuplexPipe`), Connections (`ConnectionContext`, `ConnectionHandler`).

## Quick introduction to the primitives Span and Memory

The general idea behind `Span` and `Memory` is to create a structure as fast as an array, but a lot more versatile.
What matters most about them, in this context, is that they allow us to write fast and efficient code where we allocate as little memory as possible and avoid copying data unnecessarily.

Practical example: You have the byte array `{ 0, 1, 2, 3, 4 }`. You want to write it while skipping `2`. Without Span, you would end up allocating two new arrays `{ 0, 1 }` and `{ 3, 4 }`.
However, with Span, you can do:

```C#
Span<byte> bytes = new byte[] { 0, 1, 2, 3, 4 };
var part1 = bytes.Slice(0, 2); // == { 0, 1 }
var part2 = bytes.Slice(3, 2); // == { 3, 4 }
```

Here, part1 and part2 are not new arrays, they are re-using the original array.

For more technical details, please read:

- https://msdn.microsoft.com/en-us/magazine/mt814808.aspx
- https://github.com/dotnet/corefxlab/blob/master/docs/specs/span.md
- https://github.com/dotnet/corefxlab/blob/master/docs/specs/memory.md
- Upcoming Span doc: https://github.com/dotnet/docs/issues/4400
- Upcoming Memory doc: https://github.com/dotnet/docs/issues/4823

## Understanding System.IO.Pipelines

We can use <xref:System.Span%601> and <xref:System.Memory%601> to implement various message-passing patterns.
A simple example is a `Pipe`.

For more technical details, please read:

- https://github.com/dotnet/corefxlab/blob/master/docs/specs/pipelines-io.md
- https://github.com/dotnet/corefx/tree/master/src/System.IO.Pipelines/src/System/IO/Pipelines

Note: Do not confuse this API with the [TPL version also called Pipelines](https://msdn.microsoft.com/en-us/library/ff963548.aspx). 

### Pipe

![Pipe](media/pipelines/pipe.png)

A <xref:System.IO.Pipelines.Pipe%601> is a class that [a Producer can use to send data to a Consumer](https://en.wikipedia.org/wiki/Producer–consumer_problem) (one-way).
Conceptually, it looks a lot like a [Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream).

Although creating a new Pipe is simple, "closing" it properly is not. You must call `Complete()` on its `Writer` and `Reader`. This will gracefully end the `Receive()` and `Send()` loops (if you have them).

### Simple Pipe sample

```C#
var pipe = new Pipe();

// Producer
pipe.Writer.Write(new ReadOnlySpan<byte>(new byte[] { 0, 1, 2, 3 }));
await pipe.Writer.WriteAsync(new ReadOnlyMemory<byte>(new byte[] { 4, 5, 6, 7 }));

// Consumer
var result = await pipe.Reader.ReadAsync(); // == { 0, 1, 2, 3, 4, 5, 6, 7 }
Console.Out.WriteLine($"{result.Buffer.Length}"); // 8
```

### The `Receive()` loop

Receiving data from a Pipe requires a specific loop that should always be respected.

```C#
private static async Task ReceiveFromPipeLoop(PipeReader pipeReader)
{
    try
    {
        while (true)
        {
            var result = await pipeReader.ReadAsync();
            var buffer = result.Buffer;

            try
            {
                if (result.IsCanceled)
                {
                    break;
                }
                if (!buffer.IsEmpty)
                {
                    Console.Out.WriteLine($"Received {buffer.Length} bytes.");
                }
                else if (result.IsCompleted)
                {
                    break;
                }
            }
            finally
            {
                pipeReader.AdvanceTo(buffer.End);
            }
        }
    }
    finally
    {
        pipeReader.Complete();
    }
}
```

Reading from the Pipe returns a buffer that contains the data. This buffer can also indicate if the Pipe has been canceled or completed (i.e. closed).

Note that this loop can be more complex if you need to buffer the data.

### Pipes in ASP.NET Core 2.1+

If the Producer acquires the data that it sends through a network connection, it could do (pseudo-code): `var data = await network.ReceiveAsync(); await pipe.Writer.WriteAsync(data);`

However, new APIs have been added to .NET Core 2.1 (especially in the network stacks) so that it can do: `var memory = pipe.Writer.GetMemory(); await network.ReceiveAsync(memory);`
Here, the network connection writes its data straight into the pipe.

In ASP.NET Core, such a Producer can be called a Transport (Refer to the section "Duplex Connection").

### Introducing IDuplexPipe

![DuplexPipe](media/pipelines/duplexpipe.png)

With a `Pipe`, data flows one-way: One party sends data (the Producer), and the other party receives data (the Consumer).
If you want the data to flow both ways, that is, for both parties to be able to send and receive data from each other, you need DuplexPipes.

A `DuplexPipe` is an endpoint for a party to be a Producer and a Consumer at the same time. It holds the writer of one `Pipe` and the read of another `Pipe`.

A simple example where you would need DuplexPipes is for a [Request/Response pattern](https://en.wikipedia.org/wiki/Request–response).

### Creating a pair of DuplexPipes

![Pair of DuplexPipes](media/pipelines/duplexpipe-pair.png)

A pair is required so each party gets a complementary `DuplexPipe` that represents half of each of the two Pipes.

You typically won't need to implement the <xref:System.IO.Pipelines.IDuplexPipe%601> interface yourself. Instead, you can copy the default implementation provided by [Kestrel](https://github.com/aspnet/AspNetCore/blob/master/src/Servers/Kestrel/Core/src/Internal/DuplexPipe.cs) or by [SignalR](https://github.com/aspnet/AspNetCore/blob/master/src/SignalR/common/Shared/DuplexPipe.cs) (they are identical).

```C#
var pair = DuplexPipe.CreateConnectionPair(PipeOptions.Default, PipeOptions.Default);

// Producer
pair.Transport.Output.Write(new byte[] { 0, 1, 2, 3 });
await pair.Transport.Output.WriteAsync(new ReadOnlyMemory<byte>(new byte[] { 4, 5, 6, 7 }));

// Consumer
var result = await pair.Application.Input.ReadAsync(); // == { 0, 1, 2, 3, 4, 5, 6, 7 }
Console.Out.WriteLine($"{result.Buffer.Length}"); // 8
```

This code is functionally identical to the one in the section "Simple Pipe sample"; however, it illustrates the names changes that occur with DuplexPipe.

### Duplex Connection

When using DuplexPipes to implement a network connection, the convention is to call the parties: Transport and Application.

The Transport is the DuplexPipe used to write (outgoing) data to the network and the Application is the DuplexPipe used by the network connection to write incoming data.

Note: For the Transport party, "Send" and "Receive" can mean two things: The Transport receives data from the network and sends it to the Application. And it receives data from the Application and sends it to the network.
In this tutorial, since we are focused on the pipelines, we use Send and Receive as meaning to/from the Application. However, in actual code, those words may be used for to/from the network.

These parties belong to a network node. So, in a connection between two nodes, Node A and Node B, you will have:

![Duplex Connection](media/pipelines/duplex-connection.png)

Node A is connected to Node B through their Transports.

Most of the time, Node A will be a computer or smartphone, and Node B will be a Server.
For example: In Kestrel (and other HTTP servers), Node A is the user's browser, Node B is the Kestrel server, and they are connected through a TCP connection. In SignalR, they are instead connected through WebSockets.

## Pipelines usage in Microsoft.AspNetCore.Connections

TODO

ConnectionContext holds the pair of DuplexPipes and is typically created by a Connection that uses the Transport DuplexPipe internally.
ConnectionHandler uses the Application DuplexPipe.
