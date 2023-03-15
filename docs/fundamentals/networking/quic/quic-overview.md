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
# QUIC

QUIC is a new, transport layer protocol. It has been recently standardized in [RFC 9000](https://www.rfc-editor.org/rfc/rfc9000). It uses UDP as an underlying protocol and it's inherently secure as it mandates TLS 1.3 usage, see [RFC 9001](https://www.rfc-editor.org/rfc/rfc9001). Another interesting difference from well-known transport protocols such as TCP and UDP is that it has stream multiplexing built-in on the transport layer. This allows having multiple, concurrent, independent data streams that do not affect each other.

QUIC itself doesn't define any semantics for the exchanged data as it's a transport protocol. It's rather used in application layer protocols, for example in [HTTP/3](https://www.rfc-editor.org/rfc/rfc9114) or in [SMB over QUIC](https://learn.microsoft.com/windows-server/storage/file-server/smb-over-quic). It can also be used for any custom defined protocol.

The protocol offers many advantages over TCP with TLS. For instance, faster connection establishment as it doesn't require as many round trips as TCP with TLS on top. Or avoidance of head-of-line blocking problem where one lost packet doesn't block data of all the other streams. On the other hand, there are disadvantages that come with using QUIC. As it is a new protocol, its adoption is still growing and is limited. Apart from that, QUIC traffic might be even blocked by some networking components.

## QUIC in .NET

We introduced QUIC implementation in .NET 5 in `System.Net.Quic` library. However, up until .NET 7.0 the library was strictly internal and served only for our own implementation of HTTP/3. With .NET 7, we made the library public and we exposed its APIs.

> [!NOTE]
>
> For now, the APIs are published with [preview feature](https://github.com/dotnet/designs/blob/main/accepted/2021/preview-features/preview-features.md).

From the implementation perspective, `System.Net.Quic` depends on [MsQuic](https://github.com/microsoft/msquic), native implementation of QUIC protocol. As a result, `System.Net.Quic` platform support and dependencies are inherited from MsQuic and documented in [HTTP/3 Platform dependencies](https://learn.microsoft.com/dotnet/core/extensions/httpclient-http3#platform-dependencies). In short, MsQuic library is shipped as part of .NET for Windows. But for Linux, `libmsquic` must be manually installed via an appropriate package manager. For the other platforms, it is still possible to build MsQuic manually, whether against SChannel or OpenSSL, and use it with `System.Net.Quic`. However, these scenarios are not part of our testing matrix and unforeseen problems might occur.

## API Overview

[`System.Net.Quic`](https://learn.microsoft.com/dotnet/api/system.net.quic?view=net-7.0) brings three major classes that enable usage of QUIC protocol:
- `QuicListener` - server side class for accepting incoming connections.
- `QuicConnection` - QUIC connection, corresponding to [RFC 9000 Section 5](https://www.rfc-editor.org/rfc/rfc9000#section-5).
- `QuicStream` - QUIC stream, corresponding to [RFC 9000 Section 2](https://www.rfc-editor.org/rfc/rfc9000#section-2).

But before any usage of these classes, user code should check whether QUIC is currently supported, as `libmsquic` might be missing, or TLS 1.3 might not be supported. For that, both `QuicListener` and `QuicConnection` expose a static property `IsSupported`:
```C#
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
Note that, at the moment both these properties are in sync and will report the same value, but that might change in the future. So we recommend to check [`QuicListener.IsSupported`](https://learn.microsoft.com/dotnet/api/system.net.quic.quiclistener.issupported?view=net-7.0) for server-scenarios and [`QuicConnection.IsSupported`](https://learn.microsoft.com/dotnet/api/system.net.quic.quicconnection.issupported?view=net-7.0) for the client ones.

### QuicListener

[`QuicListener`](https://learn.microsoft.com/dotnet/api/system.net.quic.quiclistener?view=net-7.0) represents a server side class that accepts incoming connections from the clients. The listener is constructed and started with a static method [`QuicListener.ListenAsync`](https://learn.microsoft.com/dotnet/api/system.net.quic.quiclistener.listenasync?view=net-7.0). The method accepts an instance of [`QuicListenerOptions`](https://learn.microsoft.com/dotnet/api/system.net.quic.quiclisteneroptions?view=net-7.0) class with all the settings necessary to start the listener and accept incoming connections. After that, listener is ready to hand out connections via [`AcceptConnectionAsync`](https://learn.microsoft.com/dotnet/api/system.net.quic.quiclistener.acceptconnectionasync?view=net-7.0). Connections returned by this method are always fully connected, meaning that the TLS handshake is finished and the connection is ready to be used. Finally, to stop listening and release all resources, [`DisposeAsync`](https://learn.microsoft.com/dotnet/api/system.net.quic.quiclistener.disposeasync?view=net-7.0) must be called.

The sample usage of `QuicListener`:
```C#
using System.Net.Quic;

// First, check if QUIC is supported.
if (!QuicListener.IsSupported)
{
    Console.WriteLine("QUIC is not supported, check for presence of libmsquic and support of TLS 1.3.");
    return;
}

// We want the same configuration for each incoming connection, so we prepare the connection options upfront and reuse them.
// This represents the minimal configuration necessary.
var serverConnectionOptions = new QuicServerConnectionOptions()
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
var listener = await QuicListener.ListenAsync(new QuicListenerOptions()
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

More details about how this class was designed can be found in the `QuicListener` API Proposal ([dotnet/runtime#67560](https://github.com/dotnet/runtime/issues/67560)).

### QuicConnection

[`QuicConnection`](https://learn.microsoft.com/dotnet/api/system.net.quic.quicconnection?view=net-7.0) is a class used for both server and client side QUIC connections. Server side connections are created internally by the listener and handed out via [`QuicListener.AcceptConnectionAsync`](https://learn.microsoft.com/dotnet/api/system.net.quic.quiclistener.acceptconnectionasync?view=net-7.0). Client side connections must be opened and connected to the server. As with the listener, there's a static method [`QuicConnection.ConnectAsync`](https://learn.microsoft.com/dotnet/api/system.net.quic.quicconnection.connectasync?view=net-7.0) that instantiates and connects the connection. It accepts an instance of [`QuicClientConnectionOptions`](https://learn.microsoft.com/dotnet/api/system.net.quic.quicclientconnectionoptions?view=net-7.0), an analogous class to [`QuicServerConnectionOptions`](https://learn.microsoft.com/dotnet/api/system.net.quic.quicserverconnectionoptions?view=net-7.0). After that, the work with the connection doesn't differ between client and server. It can open outgoing streams and accept incoming ones. It also provides properties with information about the connection, like [`LocalEndPoint`](https://learn.microsoft.com/dotnet/api/system.net.quic.quicconnection.localendpoint?view=net-7.0), [`RemoteEndPoint`](https://learn.microsoft.com/dotnet/api/system.net.quic.quicconnection.remoteendpoint?view=net-7.0), or [`RemoteCertificate`](https://learn.microsoft.com/dotnet/api/system.net.quic.quicconnection.remotecertificate?view=net-7.0).

When the work with the connection is done, it needs to be closed and disposed. QUIC protocol mandates using an application layer code for immediate closure, see [RFC 9000 Section 10.2](https://www.rfc-editor.org/rfc/rfc9000#section-10.2). For that, [`CloseAsync`](https://learn.microsoft.com/dotnet/api/system.net.quic.quicconnection.closeasync?view=net-7.0) with application layer code can be called or if not, [`DisposeAsync`](https://learn.microsoft.com/dotnet/api/system.net.quic.quicconnection.disposeasync?view=net-7.0) will use the code provided in [`QuicConnectionOptions.DefaultCloseErrorCode`](https://learn.microsoft.com/dotnet/api/system.net.quic.quicconnectionoptions.defaultcloseerrorcode?view=net-7.0#system-net-quic-quicconnectionoptions-defaultcloseerrorcode). Either way, [`DisposeAsync`](https://learn.microsoft.com/dotnet/api/system.net.quic.quicconnection.disposeasync?view=net-7.0) must be called at the end of the work with the connection to fully release all the associated resources.

The sample usage of `QuicConnection`:
```C#
using System.Net.Quic;

// First, check if QUIC is supported.
if (!QuicConnection.IsSupported)
{
    Console.WriteLine("QUIC is not supported, check for presence of libmsquic and support of TLS 1.3.");
    return;
}

// This represents the minimal configuration necessary to open a connection.
var clientConnectionOptions = new QuicClientConnectionOptions()
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
    ClientAuthenticationOptions = new SslClientAuthenticationOptions()
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

More details about how this class was designed can be found in the `QuicConnection` API Proposal ([dotnet/runtime#68902](https://github.com/dotnet/runtime/issues/68902)).

### QuicStream

[`QuicStream`](https://learn.microsoft.com/dotnet/api/system.net.quic.quicstream?view=net-7.0) is the actual type that is used to send and receive data in QUIC protocol. It derives from ordinary [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream?view=net-7.0) and can be used as such, but it also offers several features that are specific to QUIC protocol. Firstly, a QUIC stream can either be unidirectional or bidirectional, see [RFC 9000 Section 2.1](https://www.rfc-editor.org/rfc/rfc9000#section-2.1). A bidirectional stream is able to send and receive data on both sides, whereas unidirectional stream can only write from the initiating side and read on the accepting one. Each peer can limit how many concurrent stream of each type is willing to accept, see [`QuicConnectionOptions.MaxInboundBidirectionalStreams`](https://learn.microsoft.com/dotnet/api/system.net.quic.quicconnectionoptions.maxinboundbidirectionalstreams?view=net-7.0) and [`QuicConnectionOptions.MaxInboundUnidirectionalStreams`](https://learn.microsoft.com/dotnet/api/system.net.quic.quicconnectionoptions.maxinboundunidirectionalstreams?view=net-7.0).

Another particularity of QUIC stream is ability to explicitly close the writing side in the middle of work with the stream, see [`CompleteWrites`](https://learn.microsoft.com/dotnet/api/system.net.quic.quicstream.completewrites?view=net-7.0) or [`WriteAsync`](https://learn.microsoft.com/dotnet/api/system.net.quic.quicstream.writeasync?view=net-7.0#system-net-quic-quicstream-writeasync(system-readonlymemory((system-byte))-system-boolean-system-threading-cancellationtoken)) overload with `completeWrites` argument. Closing of the writing side lets the peer know that no more data will arrive, yet the peer still can continue sending (in case of a bidirectional stream). This is useful in scenarios like HTTP request/response exchange when the client sends the request and closes the writing side to let the server know that this is the end of the request content. Server is still able to send the response after that, but knows that no more data will arrive from the client. And for erroneous cases, either writing or reading side of the stream can be aborted, see [`Abort`](https://learn.microsoft.com/dotnet/api/system.net.quic.quicstream.abort?view=net-7.0). The behavior of the individual methods for each stream type is summarized in the following table (note that both client and server can open and accept streams):

|            | Peer opening stream  | Peer accepting stream  |
| -          | -       | -       |
| `CanRead`  | _bidirectional_: `true`<br/> _unidirectional_: `false` | `true`  |
| `CanWrite` | `true`  | _bidirectional_: `true`<br/> _unidirectional_: `false` |
| `ReadAsync` | _bidirectional_: reads data<br/> _unidirectional_: `InvalidOperationException` | reads data |
| `WriteAsync` | sends data => peer read returns the data | _bidirectional_: sends data => peer read returns the data<br/> _unidirectional_: `InvalidOperationException`  |
| `CompleteWrites` | closes writing side => peer read returns 0 | _bidirectional_: closes writing side => peer read returns 0<br/> _unidirectional_: no-op |
| `Abort(QuicAbortDirection.Read)` | _bidirectional_: [STOP_SENDING](https://www.rfc-editor.org/rfc/rfc9000#section-19.5) => peer write throws `QuicException(QuicError.OperationAborted)`<br/> _unidirectional_: no-op | [STOP_SENDING](https://www.rfc-editor.org/rfc/rfc9000#section-19.5) => peer write throws `QuicException(QuicError.OperationAborted)`|
| `Abort(QuicAbortDirection.Write)` | [RESET_STREAM](https://www.rfc-editor.org/rfc/rfc9000#section-19.4) => peer read throws `QuicException(QuicError.OperationAborted)` | _bidirectional_: [RESET_STREAM](https://www.rfc-editor.org/rfc/rfc9000#section-19.4) => peer read throws `QuicException(QuicError.OperationAborted)`<br/> _unidirectional_: no-op |

On top of these methods, `QuicStream` offers two specialized properties to get notified whenever either reading or writing side of the stream has been closed: [`ReadsClosed`](https://learn.microsoft.com/dotnet/api/system.net.quic.quicstream.readsclosed?view=net-7.0) and [`WritesClosed`](https://learn.microsoft.com/dotnet/api/system.net.quic.quicstream.writesclosed?view=net-7.0). Both return a `Task` that completes with its corresponding side getting closed, whether it be success or abort, in which case the `Task` will contain appropriate exception. These properties are useful when the user code needs to know about stream side getting closed without issuing call to `ReadAsync` or `WriteAsync`.

Finally, when the work with the stream is done, it needs to be disposed with [`DisposeAsync`](https://learn.microsoft.com/dotnet/api/system.net.quic.quicstream.disposeasync?view=net-7.0). The dispose will make sure that both reading and/or writing side - depending on the stream type - is closed. If stream hasn't been properly read till the end, dispose will issue an equivalent of `Abort(QuicAbortDirection.Read)`. However, if stream writing side hasn't been closed, it will be gracefully closed as it would be with `CompleteWrites`. The reason for this difference is to make sure that scenarios working with an ordinary `Stream` behave as expected and lead to a successful path. Consider the following example:
```C#
// Work done with all different types of streams.
async Task WorkWithStream(Stream stream)
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
await WorkWithStream(quicStream);

```

The sample usage of `QuicStream` in client scenario:
```C#
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
```C#
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

More details about how this class was designed can be found in the `QuicStream` API Proposal ([dotnet/runtime#69675](https://github.com/dotnet/runtime/issues/69675)).

## See also

- [Networking in .NET](../overview.md)
- [HTTP/3 with HttpClient](../../../core/extensions/httpclient-http3.md)
- <xref:System.Net.Quic>
- <xref:System.Net.Quic.QuicListener>
- <xref:System.Net.Quic.QuicConnection>
- <xref:System.Net.Quic.QuicStream>