---
title: WebSockets support in .NET
description: Learn how to web sockets with the ClientWebSockets in .NET.
author: greenEkatherine
ms.date: 10/27/2022
ms.topic: article
---

# WebSockets support in .NET

The WebSocket protocol enables two-way communication between a client and a remote host. The <xref:System.Net.WebSockets.ClientWebSocket?displayProperty=fullName> exposes the ability to establish WebSocket connection via an opening handshake, it is created and sent by the `ConnectAsync` method.

## Differences in HTTP/1.1 and HTTP/2 WebSockets

WebSockets over HTTP/1.1 uses a single TCP connection, therefore it is managed by connection-wide headers, for more information, see [RFC 6455](https://www.rfc-editor.org/rfc/rfc6455). Consider the following example of how to establish WebSocket over HTTP/1.1:

```c#
Uri uri = new("ws://corefx-net-http11.azurewebsites.net/WebSocket/EchoWebSocket.ashx");

using ClientWebSocket ws = new();
await ws.ConnectAsync(uri, default);

var bytes = new byte[1024];
var result = await ws.ReceiveAsync(bytes, default);
string res = Encoding.UTF8.GetString(bytes, 0, result.Count);

await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client closed", default);
```

A different approach must be taken with HTTP/2 due to its multiplexing nature. WebSockets are established per stream, for more information, see [RFC 8441](https://www.rfc-editor.org/rfc/rfc8441). With HTTP/2 it is possible to use one connection for multiple web socket streams together with ordinary HTTP streams and extend HTTP/2's more efficient use of the network to WebSockets. There is a special overload of <xref:System.Net.WebSockets.ClientWebSocket.ConnectAsync(System.Uri,System.Net.Http.HttpMessageInvoker,System.Threading.CancellationToken)> which accepts an <xref:System.Net.Http.HttpMessageInvoker> to allow reusing existing pooled connections:

```c#
using SocketsHttpHandler handler = new();
using ClientWebSocket ws = new();
await ws.ConnectAsync(uri, new HttpMessageInvoker(handler), cancellationToken);
```

## Set up HTTP version and policy

By default, `ClientWebSocket` uses HTTP/1.1 to send an opening handshake and allows downgrade. In .NET 7 web sockets over HTTP/2 are available. It can be changed before calling `ConnectAsync`:

```c#
using SocketsHttpHandler handler = new();
using ClientWebSocket ws = new();

ws.Options.HttpVersion = HttpVersion.Version20;
ws.Options.HttpVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;

await ws.ConnectAsync(uri, new HttpMessageInvoker(handler), cancellationToken);
```

## Incompatible options

`ClientWebSocket` has properties <xref:System.Net.WebSockets.ClientWebSocketOptions?displayProperty=fullName> that the user can set up before the connection is established. However, when `HttpMessageInvoker` is provided, it also has these properties. To avoid ambiguity, in that case, properties should be set on `HttpMessageInvoker`, and `ClientWebSocketOptions` should have default values. Otherwise, if `ClientWebSocketOptions` are changed, overload of `ConnectAsync` will throw an <xref:System.ArgumentException>.

```c#
using HttpClientHandler handler = new()
{
    CookieContainer = cookies;
    UseCookies = cookies != null;
    ServerCertificateCustomValidationCallback = remoteCertificateValidationCallback;
    Credentials = useDefaultCredentials
        ? CredentialCache.DefaultCredentials
        : credentials;
};
if (proxy is null)
{
    handler.UseProxy = false;
}
else
{
    handler.Proxy = proxy;
}
if (clientCertificates?.Count > 0)
{
    handler.ClientCertificates.AddRange(clientCertificates);
}
HttpMessageInvoker invoker = new(handler);
using ClientWebSocket cws = new();
await cws.ConnectAsync(uri, invoker, cancellationToken);
```

## Compression

The WebSocket protocol supports per-message deflate as defined in [RFC 7692](https://tools.ietf.org/html/rfc7692#section-7). It is controlled by <xref:System.Net.WebSockets.ClientWebSocketOptions.DangerousDeflateOptions?displayProperty=fullName>. When present, the options are sent to the server during the handshake phase. If the server supports per-message-deflate and the options are accepted, the `ClientWebSocket` instance will be created with compression enabled by default for all messages.

```c#
using ClientWebSocket ws = new()
{
    Options =
    {
        DangerousDeflateOptions = new WebSocketDeflateOptions()
        {
            ClientMaxWindowBits = 10,
            ServerMaxWindowBits = 10
        }
    }
};
```

> [!IMPORTANT]
> Before using compression, please be aware that enabling it makes the application subject to CRIME/BREACH type of attacks, for more information, see [CRIME](https://en.wikipedia.org/wiki/CRIME) and [BREACH](https://en.wikipedia.org/wiki/BREACH). It is strongly advised to turn off compression when sending data containing secrets by specifying the `DisableCompression` flag for such messages.

## Keep-Alive strategies

On **.NET 8** and earlier, the only available Keep-Alive strategy is _Unsolicited PONG_. This strategy is enough to keep the underlying TCP connection from idling out. However, in a case when a remote host becomes unresponsive (for example, a remote server crashes), the only way to detect such situations with Unsolicited PONG is to depend on the TCP timeout.

**.NET 9** introduced the long-desired _PING/PONG_ Keep-Alive strategy, complementing the existing `KeepAliveInterval` setting with the new `KeepAliveTimeout` setting. Starting with .NET 9, the Keep-Alive strategy is selected as follows:

1. Keep-Alive is **OFF**, if
    - `KeepAliveInterval` is `TimeSpan.Zero` or `Timeout.InfiniteTimeSpan`
2. **Unsolicited PONG**, if
    - `KeepAliveInterval` is a positive finite `TimeSpan`, -AND-
    - `KeepAliveTimeout` is `TimeSpan.Zero` or `Timeout.InfiniteTimeSpan`
3. **PING/PONG**, if
    - `KeepAliveInterval` is a positive finite `TimeSpan`, -AND-
    - `KeepAliveTimeout` is a positive finite `TimeSpan`

The default `KeepAliveTimeout` value is `Timeout.InfiniteTimeSpan`, so the default Keep-Alive behavior remains consistent between .NET versions.

If you use `ClientWebSocket`, the default <xref:System.Net.WebSockets.ClientWebSocketOptions.KeepAliveInterval?displayProperty=nameWithType> value is <xref:System.Net.WebSockets.WebSocket.DefaultKeepAliveInterval?displayProperty=nameWithType> (typically 30 seconds). That means, `ClientWebSocket` has the Keep-Alive ON by default, with Unsolicited PONG as the default strategy.

If you want to switch to the PING/PONG strategy, overriding <xref:System.Net.WebSockets.ClientWebSocketOptions.KeepAliveTimeout?displayProperty=nameWithType> is enough:

```csharp
var ws = new ClientWebSocket();
ws.Options.KeepAliveTimeout = TimeSpan.FromSeconds(20);
await ws.ConnectAsync(uri, cts.Token);
```

For a basic `WebSocket`, the Keep-Alive is OFF by default. If you want to use the PING/PONG strategy, both <xref:System.Net.WebSockets.WebSocketCreationOptions.KeepAliveInterval?displayProperty=nameWithType> and <xref:System.Net.WebSockets.WebSocketCreationOptions.KeepAliveTimeout?displayProperty=nameWithType> need to be set:

```csharp
var options = new WebSocketCreationOptions()
{
    KeepAliveInterval = WebSocket.DefaultKeepAliveInterval,
    KeepAliveTimeout = TimeSpan.FromSeconds(20)
};
var ws = WebSocket.CreateFromStream(stream, options);
```

If the Unsolicited PONG strategy is used, PONG frames are used as a unidirectional heartbeat. They sent regularly with `KeepAliveInterval` intervals, regardless whether the remote endpoint is communicating or not.

In case the PING/PONG strategy is active, a PING frame is sent after `KeepAliveInterval` time passed since the _last communication_ from the remote endpoint. Each PING frame contains an integer token to pair with the expected PONG response. If no PONG response arrived after `KeepAliveTimeout` elapsed, the remote endpoint is deemed unresponsive, and the WebSocket connection is automatically aborted.

```csharp
var ws = new ClientWebSocket();
ws.Options.KeepAliveInterval = TimeSpan.FromSeconds(10);
ws.Options.KeepAliveTimeout = TimeSpan.FromSeconds(10);
await ws.ConnectAsync(uri, cts.Token);

// NOTE: There must be an outstanding read at all times to ensure
// incoming PONGs are processed
var result = await _webSocket.ReceiveAsync(buffer, cts.Token);
```

If the timeout elapses, an outstanding `ReceiveAsync` throws an `OperationCanceledException`:

```txt
System.OperationCanceledException: Aborted
 ---> System.AggregateException: One or more errors occurred. (The WebSocket didn't receive a Pong frame in response to a Ping frame within the configured KeepAliveTimeout.) (Unable to read data from the transport connection: The I/O operation has been aborted because of either a thread exit or an application request..)
 ---> System.Net.WebSockets.WebSocketException (0x80004005): The WebSocket didn't receive a Pong frame in response to a Ping frame within the configured KeepAliveTimeout.
   at System.Net.WebSockets.ManagedWebSocket.KeepAlivePingHeartBeat()
...
```

### Keep Reading To Process PONGs

> [!NOTE]
> Currently, `WebSocket` ONLY processes incoming frames while there's a `ReceiveAsync` pending.

> [!IMPORTANT]
> If you want to use Keep-Alive Timeout, it's _crucial_ that PONG responses are _promptly processed_. Even if the remote endpoint is alive and properly sends the PONG response, but the `WebSocket` isn't processing the incoming frames, the Keep-Alive mechanism can issue a "false-positive" Abort. This problem can happen if the PONG frame is never picked up from the transport stream before the timeout elapsed.

To avoid tearing up good connections, users are advised to maintain a pending read on all WebSockets that have Keep-Alive Timeout configured.
