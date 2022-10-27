---
title: WebSockets support in .NET
description: Learn how to web sockets with the ClientWebSockets in .NET.
author: greenEkatherine
ms.author: esokolov
ms.date: 10/27/2022
---

# WebSockets support in .NET

The WebSocket Protocol enables two-way communication between a client to a remote host that has opted-in to communications from that code. The <xref:System.Net.WebSockets.ClientWebSocket?displayProperty=fullName> exposes the ability to establish WebSocket connection via an opening handshake: it is created and sent by `ConnectAsync` method.

## HTTP/2 vs HTTP/1.1 WebSockets

WebSockets over HTTP/1.1 uses a single TCP connection, therefore it is managed by connection-wide headers (see [RFC 6455](https://www.rfc-editor.org/rfc/rfc6455)). Here is an example of how to establish WebSocket over HTTP/1.1:

```c#
ClientWebSocket ws = new();
ws.ConnectAsync(uri, cancellationToken);
```

A different approach must be taken with HTTP/2 due to its multiplexing nature: here, WebSockets are established per stream (see [RFC 8441](https://www.rfc-editor.org/rfc/rfc8441)). With HTTP/2 it is possible to use one connection for multiple web socket streams together with ordinary HTTP streams and extends HTTP/2's more efficient use of the network to WebSockets. There is a special overload of `ConnectAsync` which accepts `HttpMessageInvoker` to allow reusing existing pooled connections:

```c#
var handler = new SocketsHttpHandler();
ClientWebSocket ws = new();
ws.ConnectAsync(uri, new HttpMessageInvoker(handler), cancellationToken);
```

## How to set up HTTP version and policy

By default, `ClientWebSocket` uses HTTP/1.1 to send an opening handshake and allows downgrade. It can be changed before calling `ConnectAsync`:

```c#
ClientWebSocket ws = new();

ws.Options.HttpVersion = HttpVersion.Version20;
ws.Options.HttpVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;

ws.ConnectAsync(uri, new HttpMessageInvoker(handler), cancellationToken);
```

## Incompatible options

`ClientWebSocket` has properties <xref:System.Net.WebSockets.ClientWebSocketOptions?displayProperty=fullName> that the user can set up before the connection is established. However, when `HttpMessageInvoker` is provided, it also has these properties. To avoid ambiguity, in that case, properties should be set on `HttpMessageInvoker`, and `ClientWebSocketOptions` should have default values. Otherwise, if `ClientWebSocketOptions` are changed, overload of `ConnectAsync` will throw an <xref:System.ArgumentException>.

## Compression

WebSocket supports per-message deflate as defined in [RFC 7692](https://tools.ietf.org/html/rfc7692#section-7). It is controlled by <xref:System.Net.WebSockets.ClientWebSocketOptions.DangerousDeflateOptions?displayProperty=fullName>. When present, the options are sent to the server during the handshake phase. If the server supports per-message-deflate and the options are accepted, the `WebSocket` instance will be created with compression enabled by default for all messages.

> [!IMPORTANT]
> Before using it, please be aware that enabling compression makes the application subject to CRIME/BREACH type of attacks. It is strongly advised to turn off compression when sending data containing secrets by specifying `DisableCompression` flag for such messages.
