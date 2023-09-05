---
title: Customize SNI in HTTP requests
description: Learn How to control Server Name Indication TLS extension in HTTP requests.
author: rzikm
ms.author: radekzikmund
ms.date: 9/5/2023
---

# Customize SNI in HTTP requests

When negotiating an HTTPS connection, a TLS connection needs to be established first. As part of the TLS handshake, the client sends a domain name of the server it is connecting to in one of the TLS extensions. When hosting multiple (virtual) servers on the same machine, this feature of TLS protocol allows distinguishing which of these servers clients are connecting to and configure TLS settings, such as the server certificate, accordingly.

When making a HTTP request using `HttpClient`, the implementation automatically selects value for the SNI extension based on the URL the client is connecting to. For scenarios which require more manual control of the extension, you can use one of the following ways.

## Host header

Host HTTP header performs similar function as the SNI extension in TLS. It lets target server distinguish among requests for multiple host names on a single IP address. `HttpClient` will automatically fill in the Host header using the request URI. However, you can also set its value manually, and `HttpClient` will also use the new value in the SNI extension. You can use either `HttpRequestMessage.Headers.Host` or `HttpClient.DefaultRequestHeaders.Host` to achieve this effect.

```csharp
using HttpClient client = new();

client.DefaultRequestHeaders.Host = "www.microsoft.com";

using var response = await client.GetAsync("https://127.0.0.1:5001/");

System.Console.WriteLine(response);
```

> [!NOTE]
> This method will not allow you to avoid sending SNI altogether when connecting to a URL with a hostname. If the header is set to empty string, `HttpClient` will use the hostname from the URL instead.

> [!NOTE]
> Customizing the Host header affects server certificate validation. By default, client will expect the server certificate to match the hostname in the Host header.

## Manual SslStream authentication via ConnectCallback

A more complicated, but more powerful option is to use the `SocketsHttpHandler.ConnectCallback`. Since .NET 7, it is possible to return authenticated `SslStream` and thus customise how the TLS connection is being established. Inside the callback, arbitrary `SslClientAuthenticationOptions` can be used to perform client-side authentication.

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
