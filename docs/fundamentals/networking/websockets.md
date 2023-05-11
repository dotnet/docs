---
title: WebSockets support in .NET
description: Learn how to web sockets with the ClientWebSockets in .NET.
author: greenEkatherine
ms.date: 10/27/2022
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
