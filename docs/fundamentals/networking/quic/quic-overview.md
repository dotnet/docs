---
title: QUIC support in .NET
description: Learn about the support for QUIC protocol in .NET.
ms.date: 03/15/2023
helpviewer_keywords:
  - "protocols, QUIC"
  - "sending data, QUIC"
  - "QUIC"
  - "receiving data, QUIC"
  - "application protocols, QUIC"
  - "Internet, QUIC"
---
# QUIC protocol

QUIC is a network transport layer protocol standardized in [RFC 9000](https://www.rfc-editor.org/rfc/rfc9000). It uses UDP as an underlying protocol and it's inherently secure as it mandates TLS 1.3 usage. For more information, see [RFC 9001](https://www.rfc-editor.org/rfc/rfc9001). Another interesting difference from well-known transport protocols such as TCP and UDP is that it has stream multiplexing built-in on the transport layer. This allows having multiple, concurrent, independent data streams that don't affect each other.

QUIC itself doesn't define any semantics for the exchanged data as it's a transport protocol. It's rather used in application layer protocols, for example in [HTTP/3](https://www.rfc-editor.org/rfc/rfc9114) or in [SMB over QUIC](/windows-server/storage/file-server/smb-over-quic). It can also be used for any custom-defined protocol.

The protocol offers many advantages over TCP with TLS, here are a few:

- Faster connection establishment as it doesn't require as many round trips as TCP with TLS on top.
- Avoidance of head-of-line blocking problem where one lost packet doesn't block data of all the other streams.

On the other hand, there are potential disadvantages to consider when using QUIC. As a newer protocol, its adoption is still growing and limited. Apart from that, QUIC traffic may be even blocked by some networking components.

## QUIC in .NET

The QUIC implementation was introduced in .NET 5 as the `System.Net.Quic` library. However, up until .NET 7.0 the library was strictly internal and served only as an implementation of HTTP/3. With .NET 7, the library was made public thus exposing its APIs.

> [!NOTE]
> In .NET 7.0, the APIs are published as [preview features](https://github.com/dotnet/designs/blob/main/accepted/2021/preview-features/preview-features.md).

From the implementation perspective, `System.Net.Quic` depends on [MsQuic](https://github.com/microsoft/msquic), the native implementation of QUIC protocol. As a result, `System.Net.Quic` platform support and dependencies are inherited from `MsQuic` and documented in [HTTP/3 Platform dependencies](../../../core/extensions/httpclient-http3.md#platform-dependencies). In short, the `MsQuic` library is shipped as part of .NET for Windows. But for Linux, `libmsquic` must be manually installed via an appropriate package manager. For the other platforms, it's still possible to build `MsQuic` manually, whether against SChannel or OpenSSL, and use it with `System.Net.Quic`. However, these scenarios are not part of our testing matrix and unforeseen problems might occur.

## API overview

<xref:System.Net.Quic> brings three major classes that enable the usage of QUIC protocol:

- <xref:System.Net.Quic.QuicListener> - server side class for accepting incoming connections.
- <xref:System.Net.Quic.QuicConnection> - QUIC connection, corresponding to [RFC 9000 Section 5](https://www.rfc-editor.org/rfc/rfc9000#section-5).
- <xref:System.Net.Quic.QuicStream> - QUIC stream, corresponding to [RFC 9000 Section 2](https://www.rfc-editor.org/rfc/rfc9000#section-2).

But before using these classes, your code should check whether QUIC is currently supported, as `libmsquic` might be missing, or TLS 1.3 might not be supported. For that, both `QuicListener` and `QuicConnection` expose a static property `IsSupported`:

```csharp
if (QuicListener.IsSupported)
{
    // Use QuicListener
}
else
{
    // Fallback/Error
}

if (QuicConnection.IsSupported)
{
    // Use QuicConnection
}
else
{
    // Fallback/Error
}
```

These properties will report the same value, but that might change in the future. It's recommended to check <xref:System.Net.Quic.QuicListener.IsSupported> for server-scenarios and <xref:System.Net.Quic.QuicConnection.IsSupported> for the client ones.

### `QuicListener`

<xref:System.Net.Quic.QuicListener> represents a server side class that accepts incoming connections from the clients. The listener is constructed and started with a static method <xref:System.Net.Quic.QuicListener.ListenAsync(System.Net.Quic.QuicListenerOptions,System.Threading.CancellationToken)>. The method accepts an instance of <xref:System.Net.Quic.QuicListenerOptions> class with all the settings necessary to start the listener and accept incoming connections. After that, listener is ready to hand out connections via <xref:System.Net.Quic.QuicListener.AcceptConnectionAsync(System.Threading.CancellationToken)>. Connections returned by this method are always fully connected, meaning that the TLS handshake is finished and the connection is ready to be used. Finally, to stop listening and release all resources, <xref:System.Net.Quic.QuicListener.DisposeAsync> must be called.

Consider the following `QuicListener` example code:

```csharp
using System.Net.Quic;

// First, check if QUIC is supported.
if (!QuicListener.IsSupported)
{
    Console.WriteLine("QUIC is not supported, check for presence of libmsquic and support of TLS 1.3.");
    return;
}

// Share configuration for each incoming connection.
// This represents the minimal configuration necessary.
var serverConnectionOptions = new QuicServerConnectionOptions
{
    // Used to abort stream if it's not properly closed by the user.
    // See https://www.rfc-editor.org/rfc/rfc9000#section-20.2
    DefaultStreamErrorCode = 0x0A, // Protocol-dependent error code.

    // Used to close the connection if it's not done by the user.
    // See https://www.rfc-editor.org/rfc/rfc9000#section-20.2
    DefaultCloseErrorCode = 0x0B, // Protocol-dependent error code.

    // Same options as for server side SslStream.
    ServerAuthenticationOptions = new SslServerAuthenticationOptions
    {
        // List of supported application protocols, must be the same or subset of QuicListenerOptions.ApplicationProtocols.
        ApplicationProtocols = new List<SslApplicationProtocol>() { "protocol-name" },
        // Server certificate, it can also be provided via ServerCertificateContext or ServerCertificateSelectionCallback.
        ServerCertificate = serverCertificate
    }
};

// Initialize, configure the listener and start listening.
var listener = await QuicListener.ListenAsync(new QuicListenerOptions
{
    // Listening endpoint, port 0 means any port.
    ListenEndPoint = new IPEndPoint(IPAddress.Loopback, 0),
    // List of all supported application protocols by this listener.
    ApplicationProtocols = new List<SslApplicationProtocol>() { "protocol-name" },
    // Callback to provide options for the incoming connections, it gets called once per each connection.
    ConnectionOptionsCallback = (_, _, _) => ValueTask.FromResult(serverConnectionOptions)
});

// Accept and process the connections.
while (isRunning)
{
    // Accept will propagate any exceptions that occurred during the connection establishment,
    // including exceptions thrown from ConnectionOptionsCallback, caused by invalid QuicServerConnectionOptions or TLS handshake failures.
    var connection = await listener.AcceptConnectionAsync();

    // Process the connection...
}

// When finished, dispose the listener.
await listener.DisposeAsync();
```

For more information about how the `QuicListener` was designed, see the [API proposal](https://github.com/dotnet/runtime/issues/67560).

### `QuicConnection`

<xref:System.Net.Quic.QuicConnection> is a class used for both server and client side QUIC connections. Server side connections are created internally by the listener and handed out via <xref:System.Net.Quic.QuicListener.AcceptConnectionAsync(System.Threading.CancellationToken)>. Client side connections must be opened and connected to the server. As with the listener, there's a static method <xref:System.Net.Quic.QuicConnection.ConnectAsync(System.Net.Quic.QuicClientConnectionOptions,System.Threading.CancellationToken)> that instantiates and connects the connection. It accepts an instance of <xref:System.Net.Quic.QuicClientConnectionOptions>, an analogous class to <xref:System.Net.Quic.QuicServerConnectionOptions>. After that, the work with the connection doesn't differ between client and server. It can open outgoing streams and accept incoming ones. It also provides properties with information about the connection, like <xref:System.Net.Quic.QuicConnection.LocalEndPoint>, <xref:System.Net.Quic.QuicConnection.RemoteEndPoint>, or <xref:System.Net.Quic.QuicConnection.RemoteCertificate>.

When the work with the connection is done, it needs to be closed and disposed. QUIC protocol mandates using an application layer code for immediate closure, see [RFC 9000 Section 10.2](https://www.rfc-editor.org/rfc/rfc9000#section-10.2). For that, <xref:System.Net.Quic.QuicConnection.CloseAsync(System.Int64,System.Threading.CancellationToken)> with application layer code can be called or if not, <xref:System.Net.Quic.QuicConnection.DisposeAsync> will use the code provided in <xref:System.Net.Quic.QuicConnectionOptions.DefaultCloseErrorCode>. Either way, <xref:System.Net.Quic.QuicConnection.DisposeAsync> must be called at the end of the work with the connection to fully release all the associated resources.

Consider the following `QuicConnection` example code:

```csharp
using System.Net.Quic;

// First, check if QUIC is supported.
if (!QuicConnection.IsSupported)
{
    Console.WriteLine("QUIC is not supported, check for presence of libmsquic and support of TLS 1.3.");
    return;
}

// This represents the minimal configuration necessary to open a connection.
var clientConnectionOptions = new QuicClientConnectionOptions
{
    // End point of the server to connect to.
    RemoteEndPoint = listener.LocalEndPoint,

    // Used to abort stream if it's not properly closed by the user.
    // See https://www.rfc-editor.org/rfc/rfc9000#section-20.2
    DefaultStreamErrorCode = 0x0A, // Protocol-dependent error code.

    // Used to close the connection if it's not done by the user.
    // See https://www.rfc-editor.org/rfc/rfc9000#section-20.2
    DefaultCloseErrorCode = 0x0B, // Protocol-dependent error code.

    // Optionally set limits for inbound streams.
    MaxInboundUnidirectionalStreams = 10,
    MaxInboundBidirectionalStreams = 100,

    // Same options as for client side SslStream.
    ClientAuthenticationOptions = new SslClientAuthenticationOptions
    {
        // List of supported application protocols.
        ApplicationProtocols = new List<SslApplicationProtocol>() { "protocol-name" }
    }
};

// Initialize, configure and connect to the server.
var connection = await QuicConnection.ConnectAsync(clientConnectionOptions);

Console.WriteLine($"Connected {connection.LocalEndPoint} --> {connection.RemoteEndPoint}");

// Open a bidirectional (can both read and write) outbound stream.
var outgoingStream = await connection.OpenOutboundStreamAsync(QuicStreamType.Bidirectional);

// Work with the outgoing stream ...

// To accept any stream on a client connection, at least one of MaxInboundBidirectionalStreams or MaxInboundUnidirectionalStreams of QuicConnectionOptions must be set.
while (isRunning)
{
    // Accept an inbound stream.
    var incomingStream = await connection.AcceptInboundStreamAsync();

    // Work with the incoming stream ...
}

// Close the connection with the custom code.
await connection.CloseAsync(0x0C);

// Dispose the connection.
await connection.DisposeAsync();
```

or more information about how the `QuicConnection` was designed, see the [API proposal](https://github.com/dotnet/runtime/issues/68902).

### `QuicStream`

<xref:System.Net.Quic.QuicStream> is the actual type that is used to send and receive data in QUIC protocol. It derives from ordinary <xref:System.IO.Stream> and can be used as such, but it also offers several features that are specific to QUIC protocol. Firstly, a QUIC stream can either be unidirectional or bidirectional, see [RFC 9000 Section 2.1](https://www.rfc-editor.org/rfc/rfc9000#section-2.1). A bidirectional stream is able to send and receive data on both sides, whereas unidirectional stream can only write from the initiating side and read on the accepting one. Each peer can limit how many concurrent stream of each type is willing to accept, see <xref:System.Net.Quic.QuicConnectionOptions.MaxInboundBidirectionalStreams> and <xref:System.Net.Quic.QuicConnectionOptions.MaxInboundUnidirectionalStreams>.

Another particularity of QUIC stream is ability to explicitly close the writing side in the middle of work with the stream, see <xref:System.Net.Quic.QuicStream.CompleteWrites> or <xref:System.Net.Quic.QuicStream.WriteAsync(System.ReadOnlyMemory{System.Byte},System.Boolean,System.Threading.CancellationToken)> overload with `completeWrites` argument. Closing of the writing side lets the peer know that no more data will arrive, yet the peer still can continue sending (in case of a bidirectional stream). This is useful in scenarios like HTTP request/response exchange when the client sends the request and closes the writing side to let the server know that this is the end of the request content. Server is still able to send the response after that, but knows that no more data will arrive from the client. And for erroneous cases, either writing or reading side of the stream can be aborted, see <xref:System.Net.Quic.QuicStream.Abort(System.Net.Quic.QuicAbortDirection,System.Int64)>. The behavior of the individual methods for each stream type is summarized in the following table (note that both client and server can open and accept streams):

| Method | Peer opening stream | Peer accepting stream |
| --- | --- | --- |
| `CanRead` | _bidirectional_: `true`<br/> _unidirectional_: `false` | `true` |
| `CanWrite` | `true` | _bidirectional_: `true`<br/> _unidirectional_: `false` |
| `ReadAsync` | _bidirectional_: reads data<br/> _unidirectional_: `InvalidOperationException` | reads data |
| `WriteAsync` | sends data => peer read returns the data | _bidirectional_: sends data => peer read returns the data<br/> _unidirectional_: `InvalidOperationException` |
| `CompleteWrites` | closes writing side => peer read returns 0 | _bidirectional_: closes writing side => peer read returns 0<br/> _unidirectional_: no-op |
| `Abort(QuicAbortDirection.Read)` | _bidirectional_: [STOP_SENDING](https://www.rfc-editor.org/rfc/rfc9000#section-19.5) => peer write throws `QuicException(QuicError.OperationAborted)`<br/> _unidirectional_: no-op | [STOP_SENDING](https://www.rfc-editor.org/rfc/rfc9000#section-19.5) => peer write throws `QuicException(QuicError.OperationAborted)`|
| `Abort(QuicAbortDirection.Write)` | [RESET_STREAM](https://www.rfc-editor.org/rfc/rfc9000#section-19.4) => peer read throws `QuicException(QuicError.OperationAborted)` | _bidirectional_: [RESET_STREAM](https://www.rfc-editor.org/rfc/rfc9000#section-19.4) => peer read throws `QuicException(QuicError.OperationAborted)`<br/> _unidirectional_: no-op |

On top of these methods, `QuicStream` offers two specialized properties to get notified whenever either reading or writing side of the stream has been closed: <xref:System.Net.Quic.QuicStream.ReadsClosed> and <xref:System.Net.Quic.QuicStream.WritesClosed>. Both return a `Task` that completes with its corresponding side getting closed, whether it be success or abort, in which case the `Task` will contain appropriate exception. These properties are useful when the user code needs to know about stream side getting closed without issuing call to `ReadAsync` or `WriteAsync`.

Finally, when the work with the stream is done, it needs to be disposed with <xref:System.Net.Quic.QuicStream.DisposeAsync>. The dispose will make sure that both reading and/or writing side - depending on the stream type - is closed. If stream hasn't been properly read till the end, dispose will issue an equivalent of `Abort(QuicAbortDirection.Read)`. However, if stream writing side hasn't been closed, it will be gracefully closed as it would be with `CompleteWrites`. The reason for this difference is to make sure that scenarios working with an ordinary `Stream` behave as expected and lead to a successful path. Consider the following example:

```csharp
// Work done with all different types of streams.
async Task WorkWithStreamAsync(Stream stream)
{
    // This will dispose the stream at the end of the scope.
    await using (stream)
    {
        // Simple echo, read data and send them back.
        byte[] buffer = new byte[1024];
        int count = 0;
        // The loop stops when read returns 0 bytes as is common for all streams.
        while ((count = await stream.ReadAsync(buffer)) > 0)
        {
            await stream.WriteAsync(buffer.AsMemory(0, count));
        }
    }
}

// Open a QuicStream and pass to the common method.
var quicStream = await connection.OpenOutboundStreamAsync(QuicStreamType.Bidirectional);
await WorkWithStreamAsync(quicStream);
```

The sample usage of `QuicStream` in client scenario:

```csharp
// Consider connection from the connection example, open a bidirectional stream.
await using var stream = await connection.OpenStreamAsync(QuicStreamType.Bidirectional, cancellationToken);

// Send some data.
await stream.WriteAsync(data, cancellationToken);
await stream.WriteAsync(data, cancellationToken);

// End the writing-side together with the last data.
await stream.WriteAsync(data, endStream: true, cancellationToken);
// Or separately.
stream.CompleteWrites();

// Read data until the end of stream.
while (await stream.ReadAsync(buffer, cancellationToken) > 0)
{
    // Handle buffer data...
}

// DisposeAsync called by await using at the top.
```

And the sample usage of `QuicStream` in server scenario:

```csharp
// Consider connection from the connection example, accept a stream.
await using var stream = await connection.AcceptStreamAsync(cancellationToken);

if (stream.Type != QuicStreamType.Bidirectional)
{
    Console.WriteLine($"Expected bidirectional stream, got {stream.Type}");
    return;
}

// Read the data.
while (stream.ReadAsync(buffer, cancellationToken) > 0)
{
    // Handle buffer data...

    // Client completed the writes, the loop might be exited now without another ReadAsync.
    if (stream.ReadsCompleted.IsCompleted)
    {
        break;
    }
}

// Listen for Abort(QuicAbortDirection.Read) from the client.
var writesClosedTask = WritesClosedAsync(stream);
async ValueTask WritesClosedAsync(QuicStream stream)
{
    try
    {
        await stream.WritesClosed;
    }
    catch (Exception ex)
    {
        // Handle peer aborting our writing side ...
    }
}

// DisposeAsync called by await using at the top.
```

For more information about how the `QuicsStream` was designed, see the [API proposal](https://github.com/dotnet/runtime/issues/69675).

## See also

- [Networking in .NET](../overview.md)
- [HTTP/3 with HttpClient](../../../core/extensions/httpclient-http3.md)
- <xref:System.Net.Quic>
- <xref:System.Net.Quic.QuicListener>
- <xref:System.Net.Quic.QuicConnection>
- <xref:System.Net.Quic.QuicStream>
