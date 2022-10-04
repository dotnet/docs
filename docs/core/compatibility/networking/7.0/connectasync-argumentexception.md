---
title: "Breaking change: ClientWebSocket.ConnectAsync throws new exception"
description: Learn about the .NET 7 breaking change in networking where ClientWebSocket.ConnectAsync throws ArgumentException on incompatible options.
ms.date: 10/04/2022
---
# ClientWebSocket.ConnectAsync throws new exception

Support for WebSockets over HTTP/2 was added in .NET 7 RC 1. As part of that change, a new overload of `ConnectAsync` was introduced that accepts an `HttpMessageInvoker` to allow reusing existing pooled connections.

This breaking change fixes two issues related to user input validation:

- Existing options available on <xref:System.Net.WebSockets.ClientWebSocketOptions> (for example, `Proxy` and `RemoteCertificateValidationCallback`) were silently ignored if a custom `HttpMessageInvoker` was also specified. This change makes it so that if any incompatible options are set and an invoker is specified, an exception is thrown. This behavior gives the developer a clear signal of what must be changed.

- A developer attempting to utilize the new feature could fall into a performance trap. The point of WebSockets over HTTP/2 is the ability to multiplex `WebSocket` streams over a single transport connection. If you change the <xref:System.Net.Http.HttpRequestMessage.Version> or <xref:System.Net.Http.HttpRequestMessage.VersionPolicy> to allow for HTTP/2 but don't specify an invoker, the implementation uses the requested protocol but always opens a new connection for each `WebSocket`. This behavior eliminates the benefit of the feature. To get the full benefit of HTTP/2, you must specify the invoker instance that should be reused by passing it to `ConnectAsync`. This change makes it so that an exception is thrown if HTTP/2 is requested but no invoker is specified.

## Previous behavior

In .NET 7 RC 1, the <xref:System.Net.WebSockets.ClientWebSocket.ConnectAsync(System.Uri,System.Net.Http.HttpMessageInvoker,System.Threading.CancellationToken)> overload silently ignored the following <xref:System.Net.WebSockets.ClientWebSocketOptions>: `UseDefaultCredentials`, `Credentials`, `Proxy`, `ClientCertificates`, `RemoteCertificateValidationCallback`, and `Cookies`.

The <xref:System.Net.WebSockets.ClientWebSocket.ConnectAsync(System.Uri,System.Threading.CancellationToken)> overload accepted the options if <xref:System.Net.WebSockets.ClientWebSocketOptions.HttpVersion> or <xref:System.Net.WebSockets.ClientWebSocketOptions.HttpVersionPolicy> was set to allow HTTP/2. However, this configuration lead to poor performance and defeated the purpose of the feature.

## New behavior

In .NET 7 RC 2, <xref:System.Net.WebSockets.ClientWebSocket.ConnectAsync(System.Uri,System.Net.Http.HttpMessageInvoker,System.Threading.CancellationToken)> throws an <xref:System.ArgumentException> if any of the following <xref:System.Net.WebSockets.ClientWebSocketOptions> are set: `UseDefaultCredentials`, `Credentials`, `Proxy`, `ClientCertificates`, `RemoteCertificateValidationCallback`, or `Cookies`.

The <xref:System.Net.WebSockets.ClientWebSocket.ConnectAsync(System.Uri,System.Threading.CancellationToken)> overload throws an <xref:System.ArgumentException> if <xref:System.Net.WebSockets.ClientWebSocketOptions.HttpVersion> or <xref:System.Net.WebSockets.ClientWebSocketOptions.HttpVersionPolicy> is set to allow HTTP/2.

## Version introduced

.NET 7 RC 2

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

This change was made to raise awareness and propose a solution to the user in the exception message instead of silently ignoring incompatible options.

## Recommended action

If you want to use WebSockets over HTTP/2, use the <xref:System.Net.WebSockets.ClientWebSocket.ConnectAsync(System.Uri,System.Net.Http.HttpMessageInvoker,System.Threading.CancellationToken)> overload instead of <xref:System.Net.WebSockets.ClientWebSocket.ConnectAsync(System.Uri,System.Threading.CancellationToken)> and pass a custom invoker to use for multiplexing.

If you want to pass a custom invoker to a `WebSocket` and at the same time set `UseDefaultCredentials`, `Credentials`, `Proxy`, `ClientCertificates`, `RemoteCertificateValidationCallback`, or `Cookies`, don't set them on <xref:System.Net.WebSockets.ClientWebSocketOptions>. Instead, set these options on the `HttpMessageInvoker` instance's underlying `HttpMessageHandler`. For example:

```csharp
var handler = new HttpClientHandler();
handler.CookieContainer = cookies;
handler.UseCookies = cookies != null;
handler.ServerCertificateCustomValidationCallback = remoteCertificateValidationCallback;
handler.Credentials = useDefaultCredentials ?
    CredentialCache.DefaultCredentials :
    credentials;
if (proxy == null)
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
var invoker = new HttpMessageInvoker(handler);

var cws = new ClientWebSocket();
await cws.ConnectAsync(uri, invoker, cancellationToken);
```

## Affected APIs

- <xref:System.Net.WebSockets.ClientWebSocket.ConnectAsync(System.Uri,System.Net.Http.HttpMessageInvoker,System.Threading.CancellationToken)?displayProperty=fullName>
- <xref:System.Net.WebSockets.ClientWebSocket.ConnectAsync(System.Uri,System.Threading.CancellationToken)?displayProperty=fullName> (only when <xref:System.Net.WebSockets.ClientWebSocketOptions.HttpVersion> or <xref:System.Net.WebSockets.ClientWebSocketOptions.HttpVersionPolicy> is set to allow HTTP/2)
