---
title: Networking config settings
description: Learn about run-time settings that configure networking for .NET apps.
ms.date: 11/27/2019
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

## SPN creation in HttpClient (.NET 6 and later)

- Impacts generation of [service principal names](/windows/win32/ad/service-principal-names) (SPN) for Kerberos and NTLM authentication when `Host` header is missing and target is not running on default port.
- .NET 6 and later versions don't include the port in the SPN, but the behavior is configurable.

| | Setting name | Values |
| - | - | - |
| **runtimeconfig.json** | `System.Net.Http.UsePortInSpn` | `true` - includes port number in SPN, for example, `HTTP/host:port`<br/>`false` - does not include port in SPN, for example, `HTTP/host` |
| **Environment variable** | `DOTNET_SYSTEM_NET_HTTP_USEPORTINSPN` | `1` - includes port number in SPN, for example, `HTTP/host:port`<br/>`0` - does not include port in SPN, for example, `HTTP/host` |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]
