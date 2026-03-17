---
title: Networking config settings
description: Learn about runtime settings that configure networking for .NET apps.
ms.date: 03/16/2026
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

- Starting in .NET 7, HTTP/3 is enabled by default.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Net.SocketsHttpHandler.Http3Support` | `false` - disabled <br/>`true` - enabled |
| **Environment variable** | `DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_HTTP3SUPPORT` | `0` - disabled<br/>`1` - enabled |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

## SPN creation in HttpClient (.NET 6 and later)

- Impacts generation of [service principal names](/windows/win32/ad/service-principal-names) (SPN) for Kerberos and NTLM authentication when `Host` header is missing and the target isn't running on the default port.
- .NET 6 and later versions don't include the port in the SPN by default. However, the behavior is configurable.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Net.Http.UsePortInSpn` | `true` - include port number in SPN, for example, `HTTP/host:port`<br/>`false` - don't include port in SPN, for example, `HTTP/host` |
| **Environment variable** | `DOTNET_SYSTEM_NET_HTTP_USEPORTINSPN` | `1` - include port number in SPN, for example, `HTTP/host:port`<br/>`0` - don't include port in SPN, for example, `HTTP/host` |

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
- Defaults to 16 MB. Values below 65,535 are clamped to 65,535. There's no hard upper limit, but increasing this setting beyond the default is only beneficial on networks that are both high throughput and high latency.

| | Setting name | Values |
| - | - | - |
| **Environment variable** | `DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_FLOWCONTROL_MAXSTREAMWINDOWSIZE` | Integer (default: 16 MB; minimum: 65,535) |

## HTTP/2 stream window scale threshold

- Configures the multiplier that controls how aggressively the HTTP/2 stream-receive window grows. Higher values result in a more conservative window growth, which reduces peak throughput.
- Defaults to 1.0. Values below 0 are reset to the default. There's no hard upper limit, but values much above the default progressively limit per-request throughput.

> [!NOTE]
> This setting is intended for advanced diagnostics and internal tuning. Most developers don't need to change it.

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

## Pending connection timeout on request completion

Configures the timeout (in milliseconds) for completing a pending connection attempt after its initiating HTTP request finishes. When a connection is still being established after the request completes, this timeout determines how long to wait before abandoning the connection attempt.

- Defaults to `5000` (5 seconds).
- Set to `-1` to wait indefinitely until the connection completes.
- Set to `0` to cancel the pending connection immediately when the request completes.
- There's no hard upper limit, but very large values are impractical.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Net.SocketsHttpHandler.PendingConnectionTimeoutOnRequestCompletion` | Integer (default: `5000`) |
| **Environment variable** | `DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_PENDINGCONNECTIONTIMEOUTONREQUESTCOMPLETION` | Integer (default: `5000`) |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

## Proxy pre-authentication

When enabled, <xref:System.Net.Http.SocketsHttpHandler> proactively sends `Basic` proxy authentication credentials on the first request instead of waiting for a `407` challenge response from the proxy. This is useful for proxies that don't send `407` challenge responses.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Net.Http.SocketsHttpHandler.ProxyPreAuthenticate` | `false` - disabled (default)<br>`true` - enabled |
| **Environment variable** | `DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_PROXYPREAUTHENTICATE` | `0` - disabled (default)<br>`1` - enabled |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

## Maximum connections per server

Configures the maximum number of simultaneous TCP connections that <xref:System.Net.Http.SocketsHttpHandler> opens to a single server. The handler ignores values less than `1` and uses the default.

- Defaults to unlimited (`int.MaxValue`).

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Net.SocketsHttpHandler.MaxConnectionsPerServer` | Integer (default: unlimited) |
| **Environment variable** | `DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_MAXCONNECTIONSPERSERVER` | Integer (default: unlimited) |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

## Socket inline completions

Configures whether socket continuations are allowed to run on the event thread instead of being dispatched to the <xref:System.Threading.ThreadPool?displayProperty=nameWithType>. Enabling this setting can improve performance in some scenarios. However, it might degrade performance if expensive work holds the I/O thread for longer than needed.

> [!NOTE]
> Test to make sure enabling this setting helps performance in your specific scenario.

| | Setting name | Values |
| - | - | - |
| **Environment variable** | `DOTNET_SYSTEM_NET_SOCKETS_INLINE_COMPLETIONS` | `0` - disabled (default)<br/>`1` - enabled |

## Socket thread count

Configures the number of threads used for socket I/O. When not overridden, the value is calculated based on processor count and architecture. Practical values are in the range `[1, ProcessorCount]`. Values outside this range aren't rejected but are unlikely to improve performance.

> [!NOTE]
> This setting is intended for extreme load scenarios. Most developers don't need to change it.

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

## TLS session resumption

Control whether TLS session resumption disables TLS session resumption for <xref:System.Net.Security.SslStream>. Session resumption allows TLS reconnections to skip a full handshake by reusing previously negotiated session parameters, which reduces latency.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Net.Security.DisableTlsResume` | `false` - enabled (default)<br>`true` - disabled |
| **Environment variable** | `DOTNET_SYSTEM_NET_SECURITY_DISABLETLSRESUME` | `0` - enabled (default)<br>`1` - disabled |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

## Server AIA downloads

When enabled, the TLS client automatically downloads intermediate certificates from Authority Information Access (AIA) extension URLs in server certificates. This allows the client to build a complete certificate chain even when the server doesn't send the full chain.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Net.Security.EnableServerAiaDownloads` | `false` - disabled (default)<br>`true` - enabled |
| **Environment variable** | `DOTNET_SYSTEM_NET_SECURITY_ENABLESERVERAIADOWNLOADS` | `0` - disabled (default)<br>`1` - enabled |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

## QUIC configuration caching

Disables caching of MsQuic configuration objects. When enabled (default), the system caches and reuses configuration objects across connections, which reduces the overhead of TLS and QUIC setup for repeated connections with the same parameters.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Net.Quic.DisableConfigurationCache` | `false` - caching enabled (default)<br>`true` - caching disabled |
| **Environment variable** | `DOTNET_SYSTEM_NET_QUIC_DISABLE_CONFIGURATION_CACHE` | `0` - caching enabled (default)<br>`1` - caching disabled |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

## App-local MsQuic (Windows)

When enabled, the QUIC implementation uses the MsQuic library from the application directory instead of the system-provided library bundled with the .NET assembly.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Net.Quic.AppLocalMsQuic` | `false` - use system MsQuic (default)<br>`true` - use app-local MsQuic |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]

## HttpListener kernel response buffering (Windows)

When enabled, <xref:System.Net.HttpListener> buffers response data in the kernel via HTTP.sys. Kernel buffering can significantly improve throughput over high-latency connections for applications that use synchronous I/O or asynchronous I/O with at most one outstanding write at a time. Don't enable this setting for applications with multiple concurrent outstanding writes.

> [!NOTE]
> Enabling kernel response buffering can result in higher CPU and memory usage by HTTP.sys.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Net.HttpListener.EnableKernelResponseBuffering` | `false` - disabled (default)<br>`true` - enabled |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]
