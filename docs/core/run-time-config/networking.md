---
title: Networking config settings
description: Learn about run-time settings that configure networking for .NET Core apps.
ms.date: 11/27/2019
ms.topic: reference
---
# Runtime configuration options for networking

## HTTP/2 protocol

- Configures whether support for the HTTP/2 protocol is enabled.

- Introduced in .NET Core 3.0.

- .NET Core 3.0 only: If you omit this setting, support for the HTTP/2 protocol is disabled. This is equivalent to setting the value to `false`.

- .NET Core 3.1 and .NET 5+: If you omit this setting, support for the HTTP/2 protocol is enabled. This is equivalent to setting the value to `true`.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Net.Http.SocketsHttpHandler.Http2Support` | `false` - disabled<br/>`true` - enabled |
| **Environment variable** | `DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_HTTP2SUPPORT` | `0` - disabled<br/>`1` - enabled |

## SPN creation in HttpClient (.NET 6 and later)

- Impacts generation of [service principal names](/windows/win32/ad/service-principal-names) (SPN) for Kerberos and NTLM authentication when `Host` header is missing and target is not running on default port.
- .NET Core 2.x and 3.x do not include port in SPN.
- .NET Core 5.x does include port in SPN
- .NET 6 and later versions don't include the port, but the behavior is configurable.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Net.Http.UsePortInSpn` | `true` - includes port number in SPN, for example, `HTTP/host:port`<br/>`false` - does not include port in SPN, for example, `HTTP/host` |
| **Environment variable** | `DOTNET_SYSTEM_NET_HTTP_USEPORTINSPN` | `1` - includes port number in SPN, for example, `HTTP/host:port`<br/>`0` - does not include port in SPN, for example, `HTTP/host` |

## UseSocketsHttpHandler (.NET Core 2.1-3.1 only)

- Configures whether <xref:System.Net.Http.HttpClientHandler?displayProperty=nameWithType> uses <xref:System.Net.Http.SocketsHttpHandler?displayProperty=nameWithType> or older HTTP protocol stacks (<xref:System.Net.Http.WinHttpHandler> on Windows and `CurlHandler`, an internal class implemented on top of [libcurl](https://curl.haxx.se/libcurl/), on Linux).

  > [!NOTE]
  > You may be using high-level networking APIs instead of directly instantiating the <xref:System.Net.Http.HttpClientHandler> class. This setting also affects which HTTP protocol stack is used by high-level networking APIs, including <xref:System.Net.Http.HttpClient> and [HttpClientFactory](/previous-versions/aspnet/hh995280(v=vs.118)).

- If you omit this setting, <xref:System.Net.Http.HttpClientHandler> uses <xref:System.Net.Http.SocketsHttpHandler>. This is equivalent to setting the value to `true`.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Net.Http.UseSocketsHttpHandler` | `true` - enables the use of <xref:System.Net.Http.SocketsHttpHandler><br/>`false` - enables the use of <xref:System.Net.Http.WinHttpHandler> on Windows or [libcurl](https://curl.haxx.se/libcurl/) on Linux |
| **Environment variable** | `DOTNET_SYSTEM_NET_HTTP_USESOCKETSHTTPHANDLER` | `1` - enables the use of <xref:System.Net.Http.SocketsHttpHandler><br/>`0` - enables the use of <xref:System.Net.Http.WinHttpHandler> on Windows or [libcurl](https://curl.haxx.se/libcurl/) on Linux |

> [!NOTE]
> Starting in .NET 5, the `System.Net.Http.UseSocketsHttpHandler` setting is no longer available.

## Latin1 headers (.NET Core 3.1 only)

- This switch allows relaxing the HTTP header validation, enabling <xref:System.Net.Http.SocketsHttpHandler> to send ISO-8859-1 (Latin-1) encoded characters in headers.

- If you omit this setting, an attempt to send a non-ASCII character will result in <xref:System.Net.Http.HttpRequestException>. This is equivalent to setting the value to `false`.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Net.Http.SocketsHttpHandler.AllowLatin1Headers` | `false` - disabled<br/>`true` - enabled |
| **Environment variable** | `DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_ALLOWLATIN1HEADERS` | `0` - disabled<br/>`1` - enabled |

> [!NOTE]
> This option is only available in .NET Core 3.1 since version 3.1.9, and not in previous or later versions. In .NET 5 we recommend using <xref:System.Net.Http.SocketsHttpHandler.RequestHeaderEncodingSelector>.
