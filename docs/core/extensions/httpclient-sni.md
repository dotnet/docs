---
title: Customize SNI in HTTP requests
description: Learn How to control Server Name Indication TLS extension in HTTP requests.
author: rzikm
ms.author: radekzikmund
ms.date: 9/5/2023
---

# Customize SNI in HTTP requests

When negotiating an HTTPS connection, a TLS connection needs to be established first. As part of the TLS handshake, the client sends the domain name of the server it's connecting to in one of the TLS extensions. When hosting multiple (virtual) servers on the same machine, this feature of the TLS protocol allows clients to distinguish which of these servers they're connecting to and to configure TLS settings, such as the server certificate, accordingly.

When making an HTTP request using `HttpClient`, the implementation automatically selects a value for the server name indication (SNI) extension based on the URL the client is connecting to. For scenarios that require more manual control of the extension, you can use one of the following approaches.

## Host header

Host HTTP header performs a similar function as the SNI extension in TLS. It lets the target server distinguish among requests for multiple host names on a single IP address. `HttpClient` automatically fills in the Host header using the request URI. However, you can also set its value manually, and `HttpClient` will also use the new value in the SNI extension. You can use either `HttpRequestMessage.Headers.Host` or `HttpClient.DefaultRequestHeaders.Host` to achieve this effect.

```csharp
using HttpClient client = new();

client.DefaultRequestHeaders.Host = "www.microsoft.com";

using var response = await client.GetAsync("https://127.0.0.1:5001/");

System.Console.WriteLine(response);
```

> [!NOTE]
> This method doesn't allow you to avoid sending SNI altogether when connecting to a URL with a hostname. If the header is set to empty string, `HttpClient` uses the hostname from the URL instead.

> [!NOTE]
> Customizing the Host header affects server certificate validation. By default, client will expect the server certificate to match the hostname in the Host header.

## Manual SslStream authentication via ConnectCallback

A more complicated, but also more powerful, option is to use the `SocketsHttpHandler.ConnectCallback`. Since .NET 7, it is possible to return an authenticated `SslStream` and thus customize how the TLS connection is established. Inside the callback, arbitrary `SslClientAuthenticationOptions` options can be used to perform client-side authentication.

```csharp
var handler = new SocketsHttpHandler
{
    ConnectCallback = async (context, cancellationToken) =>
    {
        var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        await socket.ConnectAsync(context.DnsEndPoint, cancellationToken);

        var sslStream = new SslStream(new NetworkStream(socket));
        await sslStream.AuthenticateAsClientAsync(new SslClientAuthenticationOptions
        {
            TargetHost = context.DnsEndPoint.Host,

        }, cancellationToken);

        return sslStream;
    }
};

using HttpClient client = new(handler);

using var response = await client.GetAsync("https://www.microsoft.com");

System.Console.WriteLine(response);
```
