---
title: "Breaking change: Blazor server: Disable LongPolling fallback transport"
description: "Learn about the breaking change in ASP.NET Core 6.0 where LongPolling is not used as a fallback transport when WebSockets aren't available."
ms.date: 08/12/2021
no-loc: [ Blazor, WebSocket, LongPolling ]
---
# Blazor server: Disable long polling fallback transport

> [!NOTE]
> This breaking change will be reverted in ASP.NET Core 6.0 RC 2.

Prior to .NET 6, *LongPolling* was a fallback transport utilized when WebSockets weren't available. The LongPolling fallback can lead to a degraded user experience, so it has been removed. Both the client and server now support only WebSockets by default.

## Version introduced

ASP.NET Core 6.0 RC 1

## Old behavior

If WebSockets are unavailable for a circuit (for example, due to network issues or browser incompatibility), LongPolling is used instead.

## New behavior

The following table shows the error message you'll receive for each combination of client and server configurations.

| Client | Server | Message |
|---|---|---|
| WS (without browser WS support) | WebSockets | `Unable to connect, please ensure you are using an updated browser that supports WebSockets.` |
| WS (with WS connection being rejected) | WebSockets | `Unable to connect, please ensure WebSockets are available. A VPN or proxy may be blocking the connection.` |
| WS | LongPolling | `An unhandled error has occurred.` Console Error: `Unable to initiate a SignalR connection to the server. This might be because the server is not configured to support WebSockets. To troubleshoot this, visit https://aka.ms/blazor-server-websockets-error.` |
| LongPolling | WebSockets | `An unhandled error has occurred.` |

## Reason for change

This change was made to improve the overall end-user experience by enforcing WebSocket use.

## Recommended action

Ensure WebSockets are functioning as expected with your application. If you must use LongPolling, you can enable it by making the following client and server side changes.

### Server side

In `Startup.cs`, replace `endpoints.MapBlazorHub()` with:

```c#
endpoints.MapBlazorHub(configureOptions: options => 
{ 
    options.Transports = HttpTransportType.WebSockets | HttpTransportType.LongPolling; 
});
```

### Client side

In `Pages/_Layout.cshtml`, update the `blazor.server.js` script tag to include the `autostart="false"` attribute:

```html
<script src="_framework/blazor.server.js" autostart="false"></script>
```

Below the `blazor.server.js` script tag, add the following snippet. The supported <xref:Microsoft.AspNetCore.Http.Connections.HttpTransportType> fields are <xref:Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets?displayProperty=nameWithType> (`1`) and <xref:Microsoft.AspNetCore.Http.Connections.HttpTransportType.LongPolling?displayProperty=nameWithType> (`4`).

```html
<script>
    (function start() {
        Blazor.start({
            configureSignalR: builder => builder.withUrl('_blazor', 1 | 4) // WebSockets and LongPolling
        });
    })()
</script>
```

## Affected APIs

None.
