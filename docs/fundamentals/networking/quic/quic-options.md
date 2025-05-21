---
title: QUIC configuration options in .NET
description: Learn details about the configuration for QUIC protocol in .NET.
ms.date: 01/11/2025
ms.topic: article
---
# QUIC configuration options

The <xref:System.Net.Quic> library uses options classes to configure the protocol objects (<xref:System.Net.Quic.QuicListener> and <xref:System.Net.Quic.QuicConnection>) before their construction and initialization. There are three different options classes to do that:

- <xref:System.Net.Quic.QuicListenerOptions>: to configure <xref:System.Net.Quic.QuicListener> before starting with <xref:System.Net.Quic.QuicListener.ListenAsync(System.Net.Quic.QuicListenerOptions,System.Threading.CancellationToken)?displayProperty=nameWithType>
- <xref:System.Net.Quic.QuicClientConnectionOptions>: to configure outgoing <xref:System.Net.Quic.QuicConnection> before establishing it via <xref:System.Net.Quic.QuicConnection.ConnectAsync(System.Net.Quic.QuicClientConnectionOptions,System.Threading.CancellationToken)?displayProperty=nameWithType>
- <xref:System.Net.Quic.QuicServerConnectionOptions>: to configure incoming <xref:System.Net.Quic.QuicConnection> before being handed out from <xref:System.Net.Quic.QuicListener.AcceptConnectionAsync(System.Threading.CancellationToken)?displayProperty=nameWithType>

All of the options classes can be set up incrementally, meaning that they don't require any of their properties to be initialized via constructor and can be set up independently. But the moment they're used to configure a new listener or a connection, the options are validated and an appropriate type of  <xref:System.ArgumentException> is thrown for any missing mandatory values or misconfigured ones. For example, if mandatory <xref:System.Net.Quic.QuicConnectionOptions.DefaultStreamErrorCode?displayProperty=nameWithType> isn't set, calling <xref:System.Net.Quic.QuicConnection.ConnectAsync(System.Net.Quic.QuicClientConnectionOptions,System.Threading.CancellationToken)> throws <xref:System.ArgumentOutOfRangeException>.

## QuicListenerOptions

<xref:System.Net.Quic.QuicListenerOptions> are used in <xref:System.Net.Quic.QuicListener.ListenAsync(System.Net.Quic.QuicListenerOptions,System.Threading.CancellationToken)?displayProperty=nameWithType> when starting a new <xref:System.Net.Quic.QuicListener>. The individual configuration properties are:

- [ApplicationProtocols](#applicationprotocols)
- [ConnectionOptionsCallback](#connectionoptionscallback)
- [ListenBacklog](#listenbacklog)
- [ListenEndPoint](#listenendpoint)

### ApplicationProtocols

<xref:System.Net.Quic.QuicListenerOptions.ApplicationProtocols> define the application protocols accepted by the server ([RFC 7301 - ALPN](https://www.rfc-editor.org/rfc/rfc7301.html)). It can contain multiple values for different protocols that can be unrelated. In the process of accepting a new connection, listener can narrow down or select one specific protocol for each incoming connection, see <xref:System.Net.Quic.QuicListenerOptions.ConnectionOptionsCallback?displayProperty=nameWithType>. **This property is mandatory and must contains at least one value.**

### ConnectionOptionsCallback

 <xref:System.Net.Quic.QuicListenerOptions.ConnectionOptionsCallback> is a delegate to choose <xref:System.Net.Quic.QuicServerConnectionOptions> for an incoming connection. The function is given a partially initialized instance of <xref:System.Net.Quic.QuicConnection> and <xref:System.Net.Security.SslClientHelloInfo> containing the server name requested by the client ([RFC 6066 - SNI](https://www.rfc-editor.org/rfc/rfc6066.html#section-3)). The delegate is invoked for each incoming connection. It can return different options based on the provided client info or it can safely return the same instance of the options every time. The delegate purpose and shape is intentionally similar to <xref:System.Net.Security.ServerOptionsSelectionCallback> used in <xref:System.Net.Security.SslStream.AuthenticateAsServerAsync(System.Net.Security.ServerOptionsSelectionCallback,System.Object,System.Threading.CancellationToken)?displayProperty=nameWithType>. **This property is mandatory.**

### ListenBacklog

<xref:System.Net.Quic.QuicListenerOptions.ListenBacklog> determines how many incoming connections can be held by the listener before additional ones start being refused. Every attempt to establish a connection counts, even when it fails or when the connection gets shut down while waiting in the queue. Ongoing processes to establish a new connection count towards this limit as well. Connections or connection attempts are counted until they're retrieved via <xref:System.Net.Quic.QuicListener.AcceptConnectionAsync(System.Threading.CancellationToken)?displayProperty=nameWithType>. The purpose of the backlog limit is to prevent servers from being overwhelmed by more incoming connections than they can process. **This property is optional, default value is 512.**

### ListenEndPoint

<xref:System.Net.Quic.QuicListenerOptions.ListenEndPoint> contains the IP address and port on which the listener will accept new connections. Due to underlying implementation, `MsQuic`, the listener, always binds to a dual-stack wildcard socket regardless of what's specified here. This can lead to some unexpected behaviors, especially in comparison with ordinary TCP sockets like in HTTP/1.1 and HTTP/2 cases. For more information, see [QUIC Troubleshooting Guide](quic-troubleshooting.md). **This property is mandatory.**

## QuicConnectionOptions

<xref:System.Net.Quic.QuicConnectionOptions> options are shared between <xref:System.Net.Quic.QuicClientConnectionOptions> and <xref:System.Net.Quic.QuicServerConnectionOptions>. It's an abstract base class and can't be used on its own. It contains these properties:

- [DefaultCloseErrorCode](#defaultcloseerrorcode)
- [DefaultStreamErrorCode](#defaultstreamerrorcode)
- [HandshakeTimeout](#handshaketimeout)
- [IdleTimeout](#idletimeout)
- [InitialReceiveWindowSizes](#initialreceivewindowsizes)
- [KeepAliveInterval](#keepaliveinterval)
- [MaxInboundBidirectionalStreams](#maxinboundbidirectionalstreams)
- [MaxInboundUnidirectionalStreams](#maxinboundunidirectionalstreams)
- [StreamCapacityCallback](#streamcapacitycallback)

### DefaultCloseErrorCode

<xref:System.Net.Quic.QuicConnectionOptions.DefaultCloseErrorCode> is used when the connection is disposed without calling <xref:System.Net.Quic.QuicConnection.CloseAsync(System.Int64,System.Threading.CancellationToken)?displayProperty=nameWithType>. It's required by QUIC protocol to provide an application-level reason for closing a connection ([RFC 9000 - Connection Close](https://www.rfc-editor.org/rfc/rfc9000.html#name-connection_close-frames)). <xref:System.Net.Quic.QuicConnection> has no way to force application code to call <xref:System.Net.Quic.QuicConnection.CloseAsync(System.Int64,System.Threading.CancellationToken)> before disposing the connection. In such case, the connection needs to know what error code to use. **This property is mandatory.**

### DefaultStreamErrorCode

<xref:System.Net.Quic.QuicConnectionOptions.DefaultStreamErrorCode> is used when a stream is disposed before all the data is read. When receiving data over QUIC stream, an application can either consume all the data or, if not, it needs to abort its reading side. And similarly to connection closing, QUIC protocol requires an application-level reason for aborting the reading side ([RFC 9000 - Stop Sending](https://www.rfc-editor.org/rfc/rfc9000.html#name-stop_sending-frames)). **This property is mandatory.**

### HandshakeTimeout

<xref:System.Net.Quic.QuicConnectionOptions.HandshakeTimeout> sets the time limit in which the connection must be fully established; otherwise, it gets aborted. It's possible to set this value to <xref:System.Threading.Timeout.InfiniteTimeSpan> but it's discouraged. Connection attempts might hang indefinitely and there are no means to clear them apart from stopping the <xref:System.Net.Quic.QuicListener>. **This property is optional, default value is 10 seconds.**

### IdleTimeout

If the connection is inactive for more than the specified <xref:System.Net.Quic.QuicConnectionOptions.IdleTimeout>, it gets disconnected. This option is part of the QUIC protocol specification ([RFC 9000 - Idle Timeout](https://www.rfc-editor.org/rfc/rfc9000.html#name-idle-timeout)) and is sent to the peer during connection handshake. The connection then takes the smaller of it and the peer's idle timeouts and uses that. Thus the connection can get closed on idle timeout sooner than what this option was set to. **This property is optional, default value is based on MsQuic, which is 30 seconds.**

### InitialReceiveWindowSizes

<xref:System.Net.Quic.QuicConnectionOptions.InitialReceiveWindowSizes> specifies a set of values limiting how much data, initially, can be received by the connection and/or the stream. QUIC protocol defines a mechanism to limit how much data can be sent over the individual streams as well as cumulatively for the whole connection ([RFC 9000 - Data Flow Control](https://www.rfc-editor.org/rfc/rfc9000.html#name-data-flow-control)). These limits only apply before the application starts consuming the data. After that, `MsQuic` continually adjusts the receive window's size based on how fast the application reads them. This property is of <xref:System.Net.Quic.QuicReceiveWindowSizes> type, which contains these options:

- <xref:System.Net.Quic.QuicReceiveWindowSizes.Connection>: cumulative limit for received data across all streams belonging to this connection.
- <xref:System.Net.Quic.QuicReceiveWindowSizes.LocallyInitiatedBidirectionalStream>: limit for received data on an outgoing bidirectional stream.
- <xref:System.Net.Quic.QuicReceiveWindowSizes.RemotelyInitiatedBidirectionalStream>: limit for received data on an incoming bidirectional stream.
- <xref:System.Net.Quic.QuicReceiveWindowSizes.UnidirectionalStream>: limit for received data on an incoming unidirectional stream.

These values must be a non-negative integer that's a power of 2; this is an inherited limitation from `MsQuic`. Setting any of these values to 0 essentially means that no data will ever be received by the specific stream or a connection as a whole. **This property is optional, default values are 64 KB for a stream and 64 MB for a connection.**

### KeepAliveInterval

<xref:System.Net.Quic.QuicConnectionOptions.KeepAliveInterval> determines if and how often PING frames are sent to keep the connection active and prevent it being closed on <xref:System.Net.Quic.QuicConnectionOptions.IdleTimeout> ([RFC 9000 - PING Frames](https://www.rfc-editor.org/rfc/rfc9000.html#name-ping-frames)). If setting this property, consider recommendation from [RFC 9000 - Deferring Idle Timeout](https://www.rfc-editor.org/rfc/rfc9000.html#name-deferring-idle-timeout). Setting the value too low might negatively impact the performance. Also, setting the property too close to idle timeout might still lead to connection closures. **This property is optional, default value is <xref:System.Threading.Timeout.InfiniteTimeSpan> meaning no PINGs will be sent.**

### MaxInboundBidirectionalStreams

<xref:System.Net.Quic.QuicConnectionOptions.MaxInboundBidirectionalStreams> determines the maximum number of concurrently active bidirectional streams that the connection is willing to accept. Note that this differs from how QUIC specification defines handling concurrency ([RFC 9000 - Controlling Concurrency](https://www.rfc-editor.org/rfc/rfc9000.html#name-controlling-concurrency)). The QUIC protocol counts the streams cumulatively, over the connection lifetime, and uses an ever-increasing limit to determine the overall number of streams accepted by the connection, including already closed streams ([RFC 9000 - MAX_STREAMS Frames](https://www.rfc-editor.org/rfc/rfc9000.html#frame-max-streams)). This property simplifies this so that the application only specifies the concurrent stream limit and `MsQuic` takes care of translating this limit to the corresponding `MAX_STREAMS` frames. **This property is optional, default value is 0 for client connections and 100 for server connections.**

### MaxInboundUnidirectionalStreams

<xref:System.Net.Quic.QuicConnectionOptions.MaxInboundUnidirectionalStreams> determines the maximum number of concurrently active unidirectional streams that the connection is willing to accept. Note that this differs from how QUIC specification defines handling stream concurrency ([RFC 9000 - Controlling Concurrency](https://www.rfc-editor.org/rfc/rfc9000.html#name-controlling-concurrency)). The QUIC protocol counts the streams cumulatively, over the connection lifetime, and uses an ever-increasing limit to determine the overall number of streams accepted by the connection, including already closed streams ([RFC 9000 - MAX_STREAMS Frames](https://www.rfc-editor.org/rfc/rfc9000.html#frame-max-streams)). This property simplifies this so that the application only specifies the concurrent stream limit and `MsQuic` takes care of translating this limit to the corresponding `MAX_STREAMS` frames. **This property is optional, default value is 0 for client connections and 10 for server connections.**

### StreamCapacityCallback

<xref:System.Net.Quic.QuicConnectionOptions.StreamCapacityCallback> is a callback that's invoked whenever the peer releases a new stream capacity via `MAX_STREAMS` and as a result, the current capacity is above 0. The values provided in the callback arguments are capacity increments, meaning that the sum of all values from the callback will equal the last value received from `MAX_STREAMS` ([RFC 9000 - MAX_STREAMS Frames](https://www.rfc-editor.org/rfc/rfc9000.html#frame-max-streams)). This callback was designed to support <xref:System.Net.Http.SocketsHttpHandler.EnableMultipleHttp3Connections?displayProperty=nameWithType> functionality and comes with several caveats:

- It's up to the application to keep track of all opening and opened streams to know the actual capacity at any time.
- The callback might be called in parallel, so it's up to the application to properly handle synchronization around stream counting.
- The first invocation (with the initial capacity) might happen before <xref:System.Net.Quic.QuicConnection> instance is handed out via either <xref:System.Net.Quic.QuicConnection.ConnectAsync(System.Net.Quic.QuicClientConnectionOptions,System.Threading.CancellationToken)?displayProperty=nameWithType> or <xref:System.Net.Quic.QuicListener.AcceptConnectionAsync(System.Threading.CancellationToken)?displayProperty=nameWithType>.

The following simplified scenario captures the behavior of stream opening and the callback:

1. Client initiates connection to the server via:

   ```csharp
   var client = await QuicConnection.ConnectAsync(new QuicClientConnectionOptions
   {
       ...
       StreamCapacityCallback = (connection, args) =>
           Console.WriteLine($"{connection} stream capacity increased by: unidi += {args.UnidirectionalIncrement}, bidi += {args.BidirectionalIncrement}")
   };
   ```

2. Server sends initial settings to client with the stream limit `2` for unidirectional streams and `0` for bidirectional.
3. The client's `StreamCapacityCallback` is called and prints:

   ```text
   [conn][0x58575BF805B0] stream capacity increased by: unidi += 2, bidi += 0
   ```

4. The client call to `ConnectAsync` returns with `[conn][0x58575BF805B0]` connection.
5. The client attempts to open a few streams:

   ```csharp
   var stream1 = await connection.OpenOutboundStreamAsync(QuicStreamType.Unidirectional);
   var stream2 = await connection.OpenOutboundStreamAsync(QuicStreamType.Unidirectional);
   // The following call will get suspended because the stream's limit has been reached.
   var taskStream3 = connection.OpenOutboundStreamAsync(QuicStreamType.Unidirectional);
   ```

6. The client finishes and closes the first two streams:

   ```csharp
   await stream1.WriteAsync(data, completeWrites: true);
   await stream1.DisposeAsync();
   await stream2.WriteAsync(data, completeWrites: true);
   await stream2.DisposeAsync();
   Console.WriteLine($"Stream 3 {(taskStream3.IsCompleted ? "opened" : "pending")}");
   ```

7. The client prints:

   ```text
   Stream 3 pending
   ```

8. The server releases additional capacity of `2` after processing the first two streams.
9. Two things happen on the client. First, a third stream is opened:

   ```csharp
   var stream3 = await taskStream3;
   ```

   Then, the client's `StreamCapacityCallback` is called again and prints:

   ```text
   [conn][0x58575BF805B0] stream capacity increased by: unidi += 2, bidi += 0
   ```

**This property is optional.**

## QuicServerConnectionOptions

<xref:System.Net.Quic.QuicServerConnectionOptions> options are specific for a server-side connection. Apart from inherited properties from <xref:System.Net.Quic.QuicConnectionOptions>, it contains the following:

- [ServerAuthenticationOptions](#serverauthenticationoptions)

### ServerAuthenticationOptions

<xref:System.Net.Quic.QuicServerConnectionOptions.ServerAuthenticationOptions> contains TLS settings for the server connection. The options are the same as used in <xref:System.Net.Security.SslStream.AuthenticateAsServer(System.Net.Security.SslServerAuthenticationOptions)?displayProperty=nameWithType> and <xref:System.Net.Security.SslStream.AuthenticateAsServerAsync(System.Net.Security.SslServerAuthenticationOptions,System.Threading.CancellationToken)?displayProperty=nameWithType>. For the QUIC server, <xref:System.Net.Security.SslServerAuthenticationOptions> is valid if:

- At least one of the following properties returns a valid certificate: <xref:System.Net.Security.SslServerAuthenticationOptions.ServerCertificateSelectionCallback>, <xref:System.Net.Security.SslServerAuthenticationOptions.ServerCertificateContext>, <xref:System.Net.Security.SslServerAuthenticationOptions.ServerCertificate>.
- At least one application protocol is defined in <xref:System.Net.Security.SslServerAuthenticationOptions.ApplicationProtocols>.
- If changed, <xref:System.Net.Security.SslServerAuthenticationOptions.EncryptionPolicy> is not set to <xref:System.Net.Security.EncryptionPolicy.NoEncryption> (default is <xref:System.Net.Security.EncryptionPolicy.RequireEncryption>).
- If set, <xref:System.Net.Security.SslServerAuthenticationOptions.CipherSuitesPolicy> contains at least one of the following: <xref:System.Net.Security.TlsCipherSuite.TLS_AES_128_GCM_SHA256>, <xref:System.Net.Security.TlsCipherSuite.TLS_AES_256_GCM_SHA384>, <xref:System.Net.Security.TlsCipherSuite.TLS_CHACHA20_POLY1305_SHA256> (default is `null` and lets `MsQuic` use all QUIC-compatible cypher suites supported by the OS).

**This property is mandatory and must meet the listed conditions.**

## QuicClientConnectionOptions

<xref:System.Net.Quic.QuicClientConnectionOptions> options are specific to a client-side connection. Apart from inherited properties from <xref:System.Net.Quic.QuicConnectionOptions>, it contains the following:

- [ClientAuthenticationOptions](#clientauthenticationoptions)
- [LocalEndPoint](#localendpoint)
- [RemoteEndPoint](#remoteendpoint)

### ClientAuthenticationOptions

<xref:System.Net.Quic.QuicClientConnectionOptions.ClientAuthenticationOptions> contains the TLS setting for the client connection. The options are the same as used in <xref:System.Net.Security.SslStream.AuthenticateAsClient(System.Net.Security.SslClientAuthenticationOptions)?displayProperty=nameWithType> and <xref:System.Net.Security.SslStream.AuthenticateAsClientAsync(System.Net.Security.SslClientAuthenticationOptions,System.Threading.CancellationToken)?displayProperty=nameWithType>. For the QUIC client, <xref:System.Net.Security.SslClientAuthenticationOptions> is valid if:

- At least one application protocol is defined in <xref:System.Net.Security.SslServerAuthenticationOptions.ApplicationProtocols>.
- If changed, <xref:System.Net.Security.SslServerAuthenticationOptions.EncryptionPolicy> isn't set to <xref:System.Net.Security.EncryptionPolicy.NoEncryption> (default is <xref:System.Net.Security.EncryptionPolicy.RequireEncryption>).
- If set, <xref:System.Net.Security.SslServerAuthenticationOptions.CipherSuitesPolicy> contains at least one of the following: <xref:System.Net.Security.TlsCipherSuite.TLS_AES_128_GCM_SHA256>, <xref:System.Net.Security.TlsCipherSuite.TLS_AES_256_GCM_SHA384>, <xref:System.Net.Security.TlsCipherSuite.TLS_CHACHA20_POLY1305_SHA256> (default is `null` and lets `MsQuic` use all QUIC compatible cypher suites supported by the OS).

**This property is mandatory and must meet the listed conditions.**

### LocalEndPoint

<xref:System.Net.Quic.QuicClientConnectionOptions.LocalEndPoint> contains the IP address and port to which the client connection will bind. If not specified, the OS assigns an IP address and a port. **This property is optional.**

### RemoteEndPoint

<xref:System.Net.Quic.QuicClientConnectionOptions.RemoteEndPoint> can either be <xref:System.Net.DnsEndPoint> or <xref:System.Net.IPEndPoint> of the peer to which the connection is being established. If it's a <xref:System.Net.DnsEndPoint>, the first IP address returned by <xref:System.Net.Dns.GetHostAddressesAsync(System.String,System.Threading.CancellationToken)?displayProperty=nameWithType> is used. **This property is mandatory.**
