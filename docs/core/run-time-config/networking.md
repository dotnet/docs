---

---
# Run-time configuration options for networking

## HTTP/2 protocol

- Configures whether support for the HTTP/2 protocol is enabled.
- Disabled by default.
- Introduced in .NET Core 3.0.

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| "System.Net.Http.SocketsHttpHandler.Http2Support" | true<br/><br/>false | `DOTNET_SYSTEM_NET_HTTP_SOCKETSHTTPHANDLER_HTTP2SUPPORT` | 0 - disabled<br/><br/>1 - enabled |

## Sockets HTTP handler

- Configures whether high-level networking APIs, such as <xref:System.Net.Http.HttpClient>, use <xref:System.Net.Http.SocketsHttpHandler?displayProperty=nameWithType> or the implementation of <xref:System.Net.Http.HttpClientHandler?displayProperty=nameWithType> that's based on [libcurl](https://curl.haxx.se/libcurl/).
- The default is to use <xref:System.Net.Http.SocketsHttpHandler?displayProperty=nameWithType>.
- You can configure this setting programmatically by calling the <xref:System.AppContext.SetSwitch%2A?displayProperty=nameWithType> method.

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| "System.Net.Http.UseSocketsHttpHandler" | true<br/><br/>false | `DOTNET_SYSTEM_NET_HTTP_USESOCKETSHTTPHANDLER` | 0 - enables the use of <xref:System.Net.Http.HttpClientHandler> <br/><br/>1 - enables the use of <xref:System.Net.Http.SocketsHttpHandler> |
