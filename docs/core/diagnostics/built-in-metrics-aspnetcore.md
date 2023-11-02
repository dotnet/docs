---
title: ASP.NET Core metrics
description: Review the metrics available for ASP.NET Core
ms.topic: reference
ms.date: 11/02/2023
---

# ASP.NET Core metrics

This article describes the metrics built-in for ASP.NET Core produced using the
<xref:System.Diagnostics.Metrics?displayProperty=nameWithType> API. For a listing of metrics based on the older [EventCounters](event-counters.md) API,
see [here](available-counters.md).

- [Meter: `Microsoft.AspNetCore.HeaderParsing`](#meter-microsoftaspnetcoreheaderparsing)
  - [Instrument: `aspnetcore.header_parsing.parse_errors`](#instrument-aspnetcoreheader_parsingparse_errors)
  - [Instrument: `aspnetcore.header_parsing.cache_accesses`](#instrument-aspnetcoreheader_parsingcache_accesses)
- [Meter: `Microsoft.AspNetCore.Hosting`](#meter-microsoftaspnetcorehosting)
  - [Instrument: `http.server.request.duration`](#instrument-httpserverrequestduration)
  - [Instrument: `http.server.active_requests`](#instrument-httpserveractive_requests)
- [Meter: `Microsoft.AspNetCore.Routing`](#meter-microsoftaspnetcorerouting)
  - [Instrument: `aspnetcore.routing.match_attempts`](#instrument-aspnetcoreroutingmatch_attempts)
- [Meter: `Microsoft.AspNetCore.Diagnostics`](#meter-microsoftaspnetcorediagnostics)
  - [Instrument: `aspnetcore.diagnostics.exceptions`](#instrument-aspnetcorediagnosticsexceptions)
- [Meter: `Microsoft.AspNetCore.RateLimiting`](#meter-microsoftaspnetcoreratelimiting)
  - [Instrument: `aspnetcore.rate_limiting.active_request_leases`](#instrument-aspnetcorerate_limitingactive_request_leases)
  - [Instrument: `aspnetcore.rate_limiting.request_lease.duration`](#instrument-aspnetcorerate_limitingrequest_leaseduration)
  - [Instrument: `aspnetcore.rate_limiting.queued_requests`](#instrument-aspnetcorerate_limitingqueued_requests)
  - [Instrument: `aspnetcore.rate_limiting.request.time_in_queue`](#instrument-aspnetcorerate_limitingrequesttime_in_queue)
  - [Instrument: `aspnetcore.rate_limiting.requests`](#instrument-aspnetcorerate_limitingrequests)
- [Meter: `Microsoft.AspNetCore.Server.Kestrel`](#meter-microsoftaspnetcoreserverkestrel)
  - [Instrument: `kestrel.active_connections`](#instrument-kestrelactive_connections)
  - [Instrument: `kestrel.connection.duration`](#instrument-kestrelconnectionduration)
  - [Instrument: `kestrel.rejected_connections`](#instrument-kestrelrejected_connections)
  - [Instrument: `kestrel.queued_connections`](#instrument-kestrelqueued_connections)
  - [Instrument: `kestrel.queued_requests`](#instrument-kestrelqueued_requests)
  - [Instrument: `kestrel.upgraded_connections`](#instrument-kestrelupgraded_connections)
  - [Instrument: `kestrel.tls_handshake.duration`](#instrument-kestreltls_handshakeduration)
  - [Instrument: `kestrel.active_tls_handshakes`](#instrument-kestrelactive_tls_handshakes)
- [Meter: `Microsoft.AspNetCore.Http.Connections`](#meter-microsoftaspnetcorehttpconnections)
  - [Instrument: `signalr.server.connection.duration`](#instrument-signalrserverconnectionduration)
  - [Instrument: `signalr.server.active_connections`](#instrument-signalrserveractive_connections)

## Meter: `Microsoft.AspNetCore.HeaderParsing`

### Instrument: `aspnetcore.header_parsing.parse_errors`

| Name | Instrument Type | Unit (UCUM) | Description |
|--|--|--|--|
| `aspnetcore.header_parsing.parse_errors` | Counter | `{parse_error}` | Number of errors that occurred when parsing HTTP request headers. |

| Attribute | Type | Description | Examples | Presence |
|--|--|--|--|--|
| `aspnetcore.header_parsing.header.name` | string | The header name. | `Content-Type` | Always |
| `error.type` | string | The error message. | `Unable to parse media type value.` | Always |

Available starting in: .NET 8.0.

### Instrument: `aspnetcore.header_parsing.cache_accesses`

The metric is emitted only for HTTP request header parsers that support caching.

| Name | Instrument Type | Unit (UCUM) | Description |
| ---- | --------------- | ----------- | ----------- |
| `aspnetcore.header_parsing.cache_accesses` | Counter | `{cache_access}` | Number of times a cache storing parsed header values was accessed. |

| Attribute | Type | Description | Examples | Presence |
|---|---|---|---|---|
| `aspnetcore.header_parsing.header.name` | string | The header name. | `Content-Type` | Always |
| `aspnetcore.header_parsing.cache_access.type` | string | A value indicating whether the header's value was found in the cache or not. | `Hit`; `Miss` | Always |

`aspnetcore.header_parsing.cache_access.type` is one of the following:

| Value | Description |
|---|---|
| `Hit` | The header's value was found in the cache. |
| `Miss` | The header's value wasn't found in the cache. |

Available starting in: .NET 8.0.

## Meter: `Microsoft.AspNetCore.Hosting`

### Instrument: `http.server.request.duration`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `http.server.request.duration` | Histogram | `s` | Measures the duration of inbound HTTP requests. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `http.route` | string | The matched route. | `{controller}/{action}/{id?}` | If it's available. |
| `error.type` | string | Describes a class of error the operation ended with. | `timeout`; `name_resolution_error`; `500` | If request has ended with an error. |
| `http.request.method` | string | HTTP request method. | `GET`; `POST`; `HEAD` | Always |
| `http.response.status_code` | int | [HTTP response status code](https://tools.ietf.org/html/rfc7231#section-6). | `200` | If one was sent. |
| `network.protocol.name` | string | [OSI application layer](https://osi-model.com/application-layer/) or non-OSI equivalent. | `amqp`; `http`; `mqtt` | Always |
| `network.protocol.version` | string | Version of the protocol specified in `network.protocol.name`. | `3.1.1` | Always |
| `url.scheme` | string | The [URI scheme](https://www.rfc-editor.org/rfc/rfc3986#section-3.1) component identifying the used protocol. | `http`; `https` | Always |
| `aspnetcore.request.is_unhandled` | boolean | True when the request wasn't handled by the application pipeline. | `true` | If the request was unhandled. |

The time used to handle an inbound HTTP request as measured at the hosting layer of ASP.NET Core. The time measurement starts once the underlying web host has:

- Sufficiently parsed the HTTP request headers on the inbound network stream to identify the new request.
- Initialized the context data structures such as the <xref:Microsoft.AspNetCore.Http.HttpContext>.

The time ends when:

- The ASP.NET Core handler pipeline is finished executing.
- All response data has been sent.
- The context data structures for the request are being disposed.

<!-- Once we migrate this doc to https://github.com/dotnet/AspNetCore.Docs we can remove the following version info -->
Available staring in: ASP.NET Core 8.0

### Instrument: `http.server.active_requests`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `http.server.active_requests` | UpDownCounter | `{request}` | Measures the number of concurrent HTTP requests that are currently in-flight. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `http.request.method` | string | HTTP request method. [1] | `GET`; `POST`; `HEAD` | Always |
| `url.scheme`| string | The [URI scheme](https://www.rfc-editor.org/rfc/rfc3986#section-3.1) component identifying the used protocol. | `http`; `https` | Always |

Available staring in: ASP.NET Core 8.0

## Meter: `Microsoft.AspNetCore.Routing`

### Instrument: `aspnetcore.routing.match_attempts`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `aspnetcore.routing.match_attempts` | Counter | `{match_attempt}` | Number of requests that were attempted to be matched to an endpoint. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `aspnetcore.routing.match_status` | string | Match result | `success`; `failure` | Always |
| `aspnetcore.routing.is_fallback_route` | boolean | A value that indicates whether the matched route is a fallback route. | `True` | If a route was successfully matched. |
| `http.route` | string | The matched route | `{controller}/{action}/{id?}` | If a route was successfully matched. |

Available staring in: ASP.NET Core 8.0

## Meter: `Microsoft.AspNetCore.Diagnostics`

### Instrument: `aspnetcore.diagnostics.exceptions`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `aspnetcore.diagnostics.exceptions` | Counter | `{exception}` | Number of exceptions caught by exception handling middleware. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `aspnetcore.diagnostics.exception.result` | string | ASP.NET Core exception middleware handling result | `handled`; `unhandled` | Always |
| `aspnetcore.diagnostics.handler.type` | string | Full type name of the [`IExceptionHandler`](/dotnet/api/microsoft.aspnetcore.diagnostics.iexceptionhandler) implementation that handled the exception. | `Contoso.MyHandler` | If the exception was handled by this handler. |
| `exception.type` | string | The full name of exception type. | `System.OperationCanceledException`; `Contoso.MyException` | Always |

`aspnetcore.diagnostics.exception.result` is one of the following:

| Value  | Description |
|---|---|
| `handled` | Exception was handled by the exception handling middleware. |
| `unhandled` | Exception wasn't handled by the exception handling middleware. |
| `skipped` | Exception handling was skipped because the response had started. |
| `aborted` | Exception handling didn't run because the request was aborted. |

Available staring in: ASP.NET Core 8.0

## Meter: `Microsoft.AspNetCore.RateLimiting`

### Instrument: `aspnetcore.rate_limiting.active_request_leases`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `aspnetcore.rate_limiting.active_request_leases` | UpDownCounter | `{request}` | Number of requests that are currently active on the server that hold a rate limiting lease. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `aspnetcore.rate_limiting.policy` | string | Rate limiting policy name. | `fixed`; `sliding`; `token` | If the matched endpoint for the request had a rate-limiting policy. |

Available staring in: ASP.NET Core 8.0

### Instrument: `aspnetcore.rate_limiting.request_lease.duration`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `aspnetcore.rate_limiting.request_lease.duration` | Histogram | `s` | The duration of the rate limiting lease held by requests on the server. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `aspnetcore.rate_limiting.policy` | string | Rate limiting policy name. | `fixed`; `sliding`; `token` | If the matched endpoint for the request had a rate-limiting policy. |

Available staring in: ASP.NET Core 8.0

### Instrument: `aspnetcore.rate_limiting.queued_requests`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `aspnetcore.rate_limiting.queued_requests` | UpDownCounter | `{request}` | Number of requests that are currently queued waiting to acquire a rate limiting lease. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `aspnetcore.rate_limiting.policy` | string | Rate limiting policy name. | `fixed`; `sliding`; `token` | If the matched endpoint for the request had a rate-limiting policy. |

Available staring in: ASP.NET Core 8.0

### Instrument: `aspnetcore.rate_limiting.request.time_in_queue`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `aspnetcore.rate_limiting.request.time_in_queue` | Histogram | `s` | The time a request spent in a queue waiting to acquire a rate limiting lease. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `aspnetcore.rate_limiting.policy` | string | Rate limiting policy name. | `fixed`; `sliding`; `token` | If the matched endpoint for the request had a rate-limiting policy. |
| `aspnetcore.rate_limiting.result` | string | The rate limiting result shows whether lease was acquired or contains a rejection reason. | `acquired`; `request_canceled` | Always |

`aspnetcore.rate_limiting.result` is one of the following:

| Value  | Description |
|---|---|
| `acquired` | Lease was acquired |
| `endpoint_limiter` | Lease request was rejected by the endpoint limiter |
| `global_limiter` | Lease request was rejected by the global limiter |
| `request_canceled` | Lease request was canceled |

Available staring in: ASP.NET Core 8.0

### Instrument: `aspnetcore.rate_limiting.requests`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `aspnetcore.rate_limiting.requests` | Counter | `{request}` | Number of requests that tried to acquire a rate limiting lease. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `aspnetcore.rate_limiting.policy` | string | Rate limiting policy name. | `fixed`; `sliding`; `token` | If the matched endpoint for the request had a rate-limiting policy. |
| `aspnetcore.rate_limiting.result` | string | The rate limiting result shows whether lease was acquired or contains a rejection reason. | `acquired`; `request_canceled` | Always |

`aspnetcore.rate_limiting.result` is one of the following:

| Value  | Description |
|---|---|
| `acquired` | Lease was acquired |
| `endpoint_limiter` | Lease request was rejected by the endpoint limiter |
| `global_limiter` | Lease request was rejected by the global limiter |
| `request_canceled` | Lease request was canceled |

Available staring in: ASP.NET Core 8.0

## Meter: `Microsoft.AspNetCore.Server.Kestrel`

### Instrument: `kestrel.active_connections`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `kestrel.active_connections` | UpDownCounter | `{connection}` | Number of connections that are currently active on the server. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `network.transport` | string | [OSI transport layer](https://osi-model.com/transport-layer/) or [inter-process communication method](https://en.wikipedia.org/wiki/Inter-process_communication). | `tcp`; `unix` | Always |
| `network.type`| string | [OSI network layer](https://osi-model.com/network-layer/) or non-OSI equivalent. | `ipv4`; `ipv6` | If the transport is `tcp` or `udp`. |
| `server.address` | string | Server address domain name if available without reverse DNS lookup;  otherwise, IP address or Unix domain socket name. | `example.com` | Always |
| `server.port`| int | Server port number | `80`; `8080`; `443` | If the transport is `tcp` or `udp`. |

Available staring in: ASP.NET Core 8.0

### Instrument: `kestrel.connection.duration`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `kestrel.connection.duration` | Histogram | `s` | The duration of connections on the server. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `error.type` | string | The full name of exception type. | `System.OperationCanceledException`; `Contoso.MyException` | If an exception was thrown. |
| `network.protocol.name` | string | [OSI application layer](https://osi-model.com/application-layer/) or non-OSI equivalent. | `http`; `web_sockets` | Always |
| `network.protocol.version` | string | Version of the protocol specified in `network.protocol.name`. | `1.1`; `2` | Always |
| `network.transport` | string | [OSI transport layer](https://osi-model.com/transport-layer/) or [inter-process communication method](https://en.wikipedia.org/wiki/Inter-process_communication). | `tcp`; `unix` | Always |
| `network.type` | string | [OSI network layer](https://osi-model.com/network-layer/) or non-OSI equivalent. | `ipv4`; `ipv6` | If the transport is `tcp` or `udp`. |
| `server.address` | string | Server address domain name if available without reverse DNS lookup;  otherwise, IP address or Unix domain socket name. | `example.com` | Always |
| `server.port` | int | Server port number | `80`; `8080`; `443` | If the transport is `tcp` or `udp`. |
| `tls.protocol.version` | string | TLS protocol version. | `1.2`; `1.3` | If the connection is secured with TLS. |

Available staring in: ASP.NET Core 8.0

### Instrument: `kestrel.rejected_connections`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `kestrel.rejected_connections` | Counter | `{connection}` | Number of connections rejected by the server. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `network.transport`| string | [OSI transport layer](https://osi-model.com/transport-layer/) or [inter-process communication method](https://en.wikipedia.org/wiki/Inter-process_communication). | `tcp`; `unix` | Always |
| `network.type` | string | [OSI network layer](https://osi-model.com/network-layer/) or non-OSI equivalent. | `ipv4`; `ipv6` | If the transport is `tcp` or `udp`. |
| `server.address`| string | Server address domain name if available without reverse DNS lookup;  otherwise, IP address or Unix domain socket name. | `example.com` | Always |
| `server.port` | int | Server port number | `80`; `8080`; `443` | If the transport is `tcp` or `udp`. |

Connections are rejected when the currently active count exceeds the value configured with `MaxConcurrentConnections`.

Available staring in: ASP.NET Core 8.0

### Instrument: `kestrel.queued_connections`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `kestrel.queued_connections` | UpDownCounter | `{connection}` | Number of connections that are currently queued and are waiting to start. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `network.transport` | string | [OSI transport layer](https://osi-model.com/transport-layer/) or [inter-process communication method](https://en.wikipedia.org/wiki/Inter-process_communication). | `tcp`; `unix` | Always |
| `network.transport` | string | [OSI network layer](https://osi-model.com/network-layer/) or non-OSI equivalent. | `ipv4`; `ipv6` | If the transport is `tcp` or `udp`. |
| `server.address` | string | Server address domain name if available without reverse DNS lookup;  otherwise, IP address or Unix domain socket name. | `example.com` | Always |
| `server.port` | int | Server port number | `80`; `8080`; `443` | If the transport is `tcp` or `udp`. |

Available staring in: ASP.NET Core 8.0

### Instrument: `kestrel.queued_requests`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `kestrel.queued_requests` | UpDownCounter | `{request}` | Number of HTTP requests on multiplexed connections (HTTP/2 and HTTP/3) that are currently queued and are waiting to start. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `network.protocol.name` | string | [OSI application layer](https://osi-model.com/application-layer/) or non-OSI equivalent. | `http`; `web_sockets` | Always |
| `network.protocol.version` | string | Version of the protocol specified in `network.protocol.name`. | `1.1`; `2` | Always |
| `network.transport` | string | [OSI transport layer](https://osi-model.com/transport-layer/) or [inter-process communication method](https://en.wikipedia.org/wiki/Inter-process_communication). | `tcp`; `unix` | Always |
| `network.transport` | string | [OSI network layer](https://osi-model.com/network-layer/) or non-OSI equivalent. | `ipv4`; `ipv6` | If the transport is `tcp` or `udp`. |
| `server.address` | string | Server address domain name if available without reverse DNS lookup;  otherwise, IP address or Unix domain socket name. | `example.com` | Always |
| `server.port` | int | Server port number | `80`; `8080`; `443` | If the transport is `tcp` or `udp`. |

Available staring in: ASP.NET Core 8.0

### Instrument: `kestrel.upgraded_connections`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `kestrel.upgraded_connections` | UpDownCounter | `{connection}` | Number of connections that are currently upgraded (WebSockets). |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `network.transport` | string | [OSI transport layer](https://osi-model.com/transport-layer/) or [inter-process communication method](https://en.wikipedia.org/wiki/Inter-process_communication). | `tcp`; `unix` | Always |
| `network.transport` | string | [OSI network layer](https://osi-model.com/network-layer/) or non-OSI equivalent. | `ipv4`; `ipv6` | If the transport is `tcp` or `udp`. |
| `server.address` | string | Server address domain name if available without reverse DNS lookup;  otherwise, IP address or Unix domain socket name. | `example.com` | Always |
| `server.port` | int | Server port number | `80`; `8080`; `443` | If the transport is `tcp` or `udp`. |

The counter only tracks HTTP/1.1 connections.

Available staring in: ASP.NET Core 8.0

### Instrument: `kestrel.tls_handshake.duration`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `kestrel.tls_handshake.duration` | Histogram | `s` | The duration of TLS handshakes on the server. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `error.type` | string | The full name of exception type. | `System.OperationCanceledException`; `Contoso.MyException` | If an exception was thrown. |
| `network.transport` | string | [OSI transport layer](https://osi-model.com/transport-layer/) or [inter-process communication method](https://en.wikipedia.org/wiki/Inter-process_communication). | `tcp`; `unix` | Always |
| `network.transport` | string | [OSI network layer](https://osi-model.com/network-layer/) or non-OSI equivalent. | `ipv4`; `ipv6` | If the transport is `tcp` or `udp`. |
| `server.address` | string | Server address domain name if available without reverse DNS lookup;  otherwise, IP address or Unix domain socket name. | `example.com` | Always |
| `server.port` | int | Server port number | `80`; `8080`; `443` | If the transport is `tcp` or `udp`. |
| `tls.protocol.version` | string | TLS protocol version. | `1.2`; `1.3` | If the connection is secured with TLS. |

Available staring in: ASP.NET Core 8.0

### Instrument: `kestrel.active_tls_handshakes`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `kestrel.active_tls_handshakes` | UpDownCounter | `{handshake}` | Number of TLS handshakes that are currently in progress on the server. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `network.transport` | string | [OSI transport layer](https://osi-model.com/transport-layer/) or [inter-process communication method](https://en.wikipedia.org/wiki/Inter-process_communication). | `tcp`; `unix` | Always |
| `network.transport` | string | [OSI network layer](https://osi-model.com/network-layer/) or non-OSI equivalent. | `ipv4`; `ipv6` | If the transport is `tcp` or `udp`. |
| `server.address` | string | Server address domain name if available without reverse DNS lookup;  otherwise, IP address or Unix domain socket name. | `example.com` | Always |
| `server.port` | int | Server port number | `80`; `8080`; `443` | If the transport is `tcp` or `udp`. |

Available staring in: ASP.NET Core 8.0

## Meter: `Microsoft.AspNetCore.Http.Connections`

### Instrument: `signalr.server.connection.duration`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `signalr.server.connection.duration` | Histogram | `s` | The duration of connections on the server. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `signalr.connection.status` | string | SignalR HTTP connection closure status. | `app_shutdown`; `timeout` | Always |
| `signalr.transport` | string | [SignalR transport type](https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/docs/specs/TransportProtocols.md) | `web_sockets`; `long_polling` | Always |

`signalr.connection.status` is one of the following:

| Value  | Description |
|---|---|
| `normal_closure` | The connection was closed normally. |
| `timeout` | The connection was closed due to a timeout. |
| `app_shutdown` | The connection was closed because the app is shutting down. |

`signalr.transport` is one of the following:

| Value  | Protocol |
|---|---|
| `server_sent_events` | [server-sent events](https://developer.mozilla.org/docs/Web/API/Server-sent_events/Using_server-sent_events)  |
| `long_polling` | [Long Polling](/archive/msdn-magazine/2012/april/cutting-edge-long-polling-and-signalr) |
| `web_sockets` | [WebSocket](https://datatracker.ietf.org/doc/html/rfc6455) |

Available staring in: ASP.NET Core 8.0

### Instrument: `signalr.server.active_connections`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `signalr.server.active_connections` | UpDownCounter | `{connection}` | Number of connections that are currently active on the server. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `signalr.connection.status` | string | SignalR HTTP connection closure status. | `app_shutdown`; `timeout` | Always |
| `signalr.transport` | string | [SignalR transport type](https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/docs/specs/TransportProtocols.md) | `web_sockets`; `long_polling` | Always |

`signalr.connection.status` is one of the following:

| Value  | Description |
|---|---|
| `normal_closure` | The connection was closed normally. |
| `timeout` | The connection was closed due to a timeout. |
| `app_shutdown` | The connection was closed because the app is shutting down. |

`signalr.transport` is one of the following:

| Value  | Description |
|---|---|
| `server_sent_events` | ServerSentEvents protocol |
| `long_polling` | LongPolling protocol |
| `web_sockets` | WebSockets protocol |

Available staring in: ASP.NET Core 8.0
