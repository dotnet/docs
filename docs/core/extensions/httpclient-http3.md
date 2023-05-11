---
title: Use HTTP/3 with HttpClient
description: Learn how to use the HttpClient to access HTTP/3 servers in .NET
author: IEvangelist
ms.author: samsp
ms.date: 03/13/2023
---

# Use HTTP/3 with HttpClient

[HTTP/3](https://www.rfc-editor.org/rfc/rfc9114.html) is the third and recently standardized major version of HTTP. HTTP/3 uses the same semantics as HTTP/1.1 and HTTP/2: the same request methods, status codes, and message fields apply to all versions. The differences are in the underlying transport. Both HTTP/1.1 and HTTP/2 use TCP as their transport. HTTP/3 uses a transport technology developed alongside HTTP/3 called [QUIC](https://www.rfc-editor.org/rfc/rfc9000.html).

HTTP/3 and QUIC have a number of benefits compared to HTTP/1.1 and HTTP/2:

- Faster response time of the first request. QUIC and HTTP/3 negotiate the connection in fewer round-trips between the client and the server. The first request reaches the server faster.
- Improved experience when there is connection packet loss. HTTP/2 multiplexes multiple requests via one TCP connection. Packet loss on the connection affects all requests. This problem is called "head-of-line blocking". Because QUIC provides native multiplexing, lost packets only impact the requests where data has been lost.
- Supports transitioning between networks. This feature is useful for mobile devices where it is common to switch between WIFI and cellular networks as a mobile device changes location. Currently, HTTP/1.1 and HTTP/2 connections fail with an error when switching networks. An app or web browser must retry any failed HTTP requests. HTTP/3 allows the app or web browser to seamlessly continue when a network changes. `HttpClient` and Kestrel do not support network transitions in .NET 7. It may be available in a future release.

> [!IMPORTANT]
>
> Apps configured to take advantage of HTTP/3 should be designed to also support HTTP/1.1 and HTTP/2. If issues are identified in HTTP/3, we recommend disabling HTTP/3 until the issues are resolved in a future release of .NET.

## HttpClient settings

The HTTP version can be configured by setting `HttpRequestMessage.Version` to 3.0. However, because not all routers, firewalls, and proxies properly support HTTP/3, we recommend configuring HTTP/3 together with HTTP/1.1 and HTTP/2. In HttpClient, this can be done by specifying:

- `HttpRequestMessage.Version` to 1.1.
- `HttpRequestMessage.VersionPolicy` to `HttpVersionPolicy.RequestVersionOrHigher`.

## Platform dependencies

HTTP/3 uses QUIC as its transport protocol. The .NET implementation of HTTP/3 uses [MsQuic](https://github.com/microsoft/msquic) to provide QUIC functionality. If the platform that HttpClient is running on doesn't have all the requirements for HTTP/3 then it's disabled.

### Windows

- Windows 11, Windows Server 2022, or later. (Earlier Windows versions are missing the cryptographic APIs required to support QUIC.)

On Windows, msquic.dll is distributed as part of the .NET runtime, and no additional steps are required to install it.

### Linux

- OpenSSL 1.1

On Linux, libmsquic is published via Microsoft's official Linux package repository packages.microsoft.com. To consume it, it must be added manually. For more information, see [Linux Software Repository for Microsoft Products](/windows-server/administration/linux-package-repository-for-microsoft-software). After configuring the package feed, it is installed via the package manager of your distro, for example, for Ubuntu:

```bash
sudo apt install libmsquic
```

> [!NOTE]
> .NET 7 is only compatible with 2.1+ versions of libmsquic.

### macOS

HTTP/3 is not currently supported on macOS but may be available in a future release.

## Using HttpClient

The following code example uses [top-level statements](../../csharp/fundamentals/program-structure/top-level-statements.md) and demonstrates how to specify HTTP3 in the request:

:::code language="csharp" source="snippets/http/http3/Program.cs":::

## HTTP/3 Support in .NET 6

In .NET 6, HTTP/3 is available as a _preview feature_ because the HTTP/3 specification was not yet finalized. Behavioral or performance problems may exist in HTTP/3 with .NET 6. For more information on preview features, see [the preview features specification](https://github.com/dotnet/designs/blob/main/accepted/2021/preview-features/preview-features.md#are-preview-features-supported).

To enable HTTP/3 support in .NET 6, include the following in the project file to enable HTTP/3 with HttpClient:

```xml
<ItemGroup>
    <RuntimeHostConfigurationOption Include="System.Net.SocketsHttpHandler.Http3Support" Value="true" />
</ItemGroup>
```

Alternatively, you can call <xref:System.AppContext.SetSwitch%2A?displayProperty=fullName> from your app code, or set the `DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_HTTP3SUPPORT` environment variable to `true`.

The reason for requiring a configuration flag for HTTP/3 is to protect apps from future breakage when using version policy `RequestVersionOrHigher`. When calling a server that currently uses HTTP/1.1 and HTTP/2, if the server later upgrades to HTTP/3, the client would try to use HTTP/3 and potentially be incompatible as the standard is not final and therefore may change after .NET 6 is released.

 .NET 6 is only compatible with the 1.9.x versions of libmsquic. Libmsquic 2.x is not compatible with .NET 6 due to breaking changes in the library. Libmsquic will receive updates to 1.9.x when needed to incorporate security fixes.

## HTTP/3 Server

HTTP/3 is supported by ASP.NET with the Kestrel server in .NET 6 (preview) and .NET 7 (fully supported). For more information, see [use HTTP/3 with the ASP.NET Core Kestrel web server][http3Kestrel].

## Public test servers

Cloudflare hosts a site for HTTP/3 which can be used to test the client against at [https://cloudflare-quic.com/](https://cloudflare-quic.com/)

## See also

- <xref:System.Net.Http.HttpClient>
- [HTTP/3 support in Kestrel][http3Kestrel]
- [QUIC support in .NET](../../fundamentals/networking/quic/quic-overview.md)

[http3Kestrel]: /aspnet/core/fundamentals/servers/kestrel/http3
