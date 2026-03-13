---
title: Networking config settings
description: Learn about runtime settings that configure networking for .NET apps.
ms.date: 03/13/2026
ai-usage: ai-assisted
---
# Runtime configuration options for networking

## HTTP/2 protocol

- Configures whether support for the HTTP/2 protocol is enabled.
- If you omit this setting, support for the HTTP/2 protocol is enabled. This is equivalent to setting the value to `true`.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Net.Http.SocketsHttpHandler.Http2Support` | `false` - disabled<br/>`true` - enabled |
| **Environment variable** | `DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_HTTP2SUPPORT` | `0` - disabled<br/>`1` - enabled |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

## HTTP/3 protocol

- Configures whether support for the HTTP/3 protocol is enabled.
- In .NET 6, HTTP/3 is disabled by default and must be enabled explicitly. Starting in .NET 7, HTTP/3 is enabled by default.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Net.SocketsHttpHandler.Http3Support` | `false` - disabled (default in .NET 6)<br/>`true` - enabled |
| **Environment variable** | `DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_HTTP3SUPPORT` | `0` - disabled<br/>`1` - enabled |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

## SPN creation in HttpClient (.NET 6 and later)

- Impacts generation of [service principal names](/windows/win32/ad/service-principal-names) (SPN) for Kerberos and NTLM authentication when `Host` header is missing and the target isn't running on the default port.
- .NET 6 and later versions don't include the port in the SPN by default. However, the behavior is configurable.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Net.Http.UsePortInSpn` | `true` - includes port number in SPN, for example, `HTTP/host:port`<br/>`false` - doesn't include port in SPN, for example, `HTTP/host` |
| **Environment variable** | `DOTNET_SYSTEM_NET_HTTP_USEPORTINSPN` | `1` - includes port number in SPN, for example, `HTTP/host:port`<br/>`0` - doesn't include port in SPN, for example, `HTTP/host` |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

## HTTP/2 dynamic window scaling

- Configures whether the HTTP/2 dynamic window scaling algorithm is disabled for flow control. The algorithm is enabled by default.
- When set to `true`, the dynamic window scaling algorithm is disabled.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Net.SocketsHttpHandler.Http2FlowControl.DisableDynamicWindowSizing` | `false` - enabled (default)<br/>`true` - disabled |
| **Environment variable** | `DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_HTTP2FLOWCONTROL_DISABLEDYNAMICWINDOWSIZING` | `0` - enabled (default)<br/>`1` - disabled |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

## HTTP/2 stream receive window size

- Configures the maximum size of the HTTP/2 stream receive window.
- Defaults to 16 MB. The value can't be less than 65,535.

| | Setting name | Values |
| - | - | - |
| **Environment variable** | `DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_FLOWCONTROL_MAXSTREAMWINDOWSIZE` | Integer (default: 16 MB; minimum: 65,535) |

## HTTP/2 stream window scale threshold

- Configures the multiplier used for the HTTP/2 stream window scale threshold. This multiplier controls how aggressively the receive window grows. Higher values result in a more conservative window growth, which reduces peak throughput. The value can't be less than 0.
- Defaults to 1.0.

| | Setting name | Values |
| - | - | - |
| **Environment variable** | `DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_FLOWCONTROL_STREAMWINDOWSCALETHRESHOLDMULTIPLIER` | Float (default: 1.0; minimum: 0) |

## HTTP activity propagation

Configures whether distributed tracing activity propagation is enabled for <xref:System.Net.Http.HttpClient>. When enabled, outgoing HTTP requests propagate trace context headers (such as `traceparent`) for distributed tracing tools like OpenTelemetry.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Net.Http.EnableActivityPropagation` | `true` - enabled (default)<br/>`false` - disabled |
| **Environment variable** | `DOTNET_SYSTEM_NET_HTTP_ENABLEACTIVITYPROPAGATION` | `1` - enabled (default)<br/>`0` - disabled |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

## Socket inline completions

Configures whether socket continuations are allowed to run on the event thread instead of being dispatched to the <xref:System.Threading.ThreadPool?displayProperty=nameWithType>. Enabling this setting can improve performance in some scenarios. However, it might degrade performance if expensive work holds the I/O thread for longer than needed.

> [!NOTE]
> Test to make sure enabling this setting helps performance in your specific scenario.

| | Setting name | Values |
| - | - | - |
| **Environment variable** | `DOTNET_SYSTEM_NET_SOCKETS_INLINE_COMPLETIONS` | `0` - disabled (default)<br/>`1` - enabled |

## Socket thread count

Configures the number of threads used for socket I/O. When not overridden, the value is calculated based on processor count and architecture. Use this setting for extreme loads only.

| | Setting name | Values |
| - | - | - |
| **Environment variable** | `DOTNET_SYSTEM_NET_SOCKETS_THREAD_COUNT` | Integer |

## IPv6

Configures whether Internet Protocol version 6 (IPv6) is disabled.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Net.DisableIPv6` | `false` - enabled (default)<br/>`true` - disabled |
| **Environment variable** | `DOTNET_SYSTEM_NET_DISABLEIPV6` | `0` - enabled (default)<br/>`1` - disabled |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

## UseSocketsHttpHandler

Configures whether <xref:System.Net.Http.HttpClient> uses <xref:System.Net.Http.SocketsHttpHandler> or the older HTTP handler implementations. When set to `false`, <xref:System.Net.Http.HttpClientHandler> is used instead.

> [!NOTE]
> Starting in .NET 5, this setting is no longer available. <xref:System.Net.Http.SocketsHttpHandler> is the only HTTP handler available.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Net.Http.UseSocketsHttpHandler` | `true` - use <xref:System.Net.Http.SocketsHttpHandler> (default)<br/>`false` - use <xref:System.Net.Http.HttpClientHandler> |
| **Environment variable** | `DOTNET_SYSTEM_NET_HTTP_USESOCKETSHTTPHANDLER` | `1` - use <xref:System.Net.Http.SocketsHttpHandler> (default)<br/>`0` - use <xref:System.Net.Http.HttpClientHandler> |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]
