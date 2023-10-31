---
title: System.Net Metrics
description: Review the metrics available for System.Net
ms.topic: reference
ms.date: 9/21/2023
---

# System.Net Metrics

This article describes the networking metrics built-in for <xref:System.Net> produced using the
<xref:System.Diagnostics.Metrics?displayProperty=nameWithType> API. For a listing of metrics based on the alternate [EventCounters](event-counters.md) API, see [Well-known EventCounters in .NET](available-counters.md).

- [Meter: `System.Net.NameResolution`](#meter-systemnetnameresolution) - Metrics for DNS lookups
  * [Instrument: `dns.lookup.duration`](#instrument-dnslookupduration)
- [Meter: `System.Net.Http`](#meter-systemnethttp) - Metrics for outbound networking requests using HttpClient
  * [Instrument: `http.client.open_connections`](#instrument-httpclientopen_connections)
  * [Instrument: `http.client.connection.duration`](#instrument-httpclientconnectionduration)
  * [Instrument: `http.client.request.duration`](#instrument-httpclientrequestduration)
  * [Instrument: `http.client.request.time_in_queue`](#instrument-httpclientrequesttime_in_queue)
  * [Instrument: `http.client.active_requests`](#instrument-httpclientactive_requests)

## Meter: `System.Net.NameResolution`

### Instrument: `dns.lookup.duration`

| Name     | Instrument Type | Unit | Description    |
| -------- | --------------- | ----------- | -------------- |
| `dns.lookup.duration` | Histogram | `s` | Measures the time taken to perform a DNS lookup. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `dns.question.name` | string | The name being queried. | `www.example.com`; `dot.net` | Always |
| `error.type` | string | A well-known error string or the full type name of an exception that occurred. | `host_not_found`; `System.Net.Sockets.SocketException` | If an error occurred |

This metric measures the time take to make DNS requests. These requests can occur by calling methods on
<xref:System.Net.Dns> or indirectly within higher level APIs on types such as <xref:System.Net.Http.HttpClient>.

Most errors when doing a DNS lookup throw a <xref:System.Net.Sockets.SocketException>. To better disambiguate the common error cases, socket exceptions with specific <xref:System.Net.Sockets.SocketException.SocketErrorCode> are given explicit error names in `error.type`:

| SocketErrorCode | `error.type` |
| --------------- | ------------ |
| <xref:System.Net.Sockets.SocketError.HostNotFound> | host_not_found |
| <xref:System.Net.Sockets.SocketError.TryAgain> | try_again |
| <xref:System.Net.Sockets.SocketError.AddressFamilyNotSupported> | address_family_not_supported |
| <xref:System.Net.Sockets.SocketError.NoRecovery> | no_recovery |

Socket exceptions with any other `SocketError` value are reported as `System.Net.Sockets.SocketException`.

Available starting in: .NET 8

## Meter: `System.Net.Http`

### Instrument: `http.client.open_connections`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `http.client.open_connections` | UpDownCounter | `{connection}` | Number of outbound HTTP connections that are currently active or idle on the client |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `http.connection.state` | string | State of HTTP connection in the HTTP connection pool. | `active`; `idle` | Always |
| `network.protocol.version` | string | Version of the application layer protocol used. | `1.1`; `2` | Always |
| `server.address` | string | Host identifier of the ["URI origin"](https://www.rfc-editor.org/rfc/rfc9110.html#name-uri-origin) HTTP request is sent to. | `example.com` | Always |
| `server.port` | int | Port identifier of the ["URI origin"](https://www.rfc-editor.org/rfc/rfc9110.html#name-uri-origin) HTTP request is sent to. | `80`; `8080`; `443` | If not default (`80` for `http` scheme, `443` for `https`) |
| `network.peer.address` | string | Peer IP address of the socket connection. | `10.5.3.2` | Always |
| `url.scheme` | string | The [URI scheme](https://www.rfc-editor.org/rfc/rfc3986#section-3.1) component identifying the used protocol. | `http`; `https`; `ftp` | Always |

<xref:System.Net.Http.HttpClient>, when configured to use the default <xref:System.Net.Http.SocketsHttpHandler>, maintains a cached pool of network connections for sending HTTP messages. This metric counts how many connections are currently in the pool. Active connections are handling active requests. Active connects could be transmitting data or awaiting the client or server. Idle connections aren't handling any requests, but are left open so that future requests can be handled more quickly.

Available starting in: .NET 8

### Instrument: `http.client.connection.duration`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `http.client.connection.duration` | Histogram | `s` | The duration of successfully established outbound HTTP connections. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `network.protocol.version` | string | Version of the application layer protocol used. | `1.1`; `2` | Always |
| `server.address` | string | Host identifier of the ["URI origin"](https://www.rfc-editor.org/rfc/rfc9110.html#name-uri-origin) HTTP request is sent to. | `example.com` | Always |
| `server.port` | int | Port identifier of the ["URI origin"](https://www.rfc-editor.org/rfc/rfc9110.html#name-uri-origin) HTTP request is sent to. | `80`; `8080`; `443` | If not default (`80` for `http` scheme, `443` for `https`) |
| `network.peer.address` | string | IP address of the socket connection. | `10.5.3.2` | Always |
| `url.scheme` | string | The [URI scheme](https://www.rfc-editor.org/rfc/rfc3986#section-3.1) component identifying the used protocol. | `http`; `https`; `ftp` | Always |

This metric is only captured when <xref:System.Net.Http.HttpClient> is configured to use the default <xref:System.Net.Http.SocketsHttpHandler>.

Available starting in: .NET 8

### Instrument: `http.client.request.duration`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `http.client.request.duration` | Histogram | `s` | The duration of outbound HTTP requests. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `http.error.reason` | string | Request failure reason: one of [HTTP Request errors](https://github.com/dotnet/runtime/blob/c430570a01c103bc7f117be573f37d8ce8a129b8/src/libraries/System.Net.Http/src/System/Net/Http/HttpRequestError.cs), or a full exception type, or an HTTP 4xx/5xx status code. | `System.Threading.Tasks.TaskCanceledException`; `name_resolution_error`; `secure_connection_error` ; `404` | If request has failed. |
| `http.request.method` | string | HTTP request method. | `GET`; `POST`; `HEAD` | Always |
| `http.response.status_code` | int | [HTTP response status code](https://tools.ietf.org/html/rfc7231#section-6). | `200` | If one was received. |
| `network.protocol.version` | string | Version of the application layer protocol used. | `1.1`; `2` | Always |
| `server.address` | string | Host identifier of the ["URI origin"](https://www.rfc-editor.org/rfc/rfc9110.html#name-uri-origin) HTTP request is sent to. | `example.com` | Always |
| `server.port` | int | Port identifier of the ["URI origin"](https://www.rfc-editor.org/rfc/rfc9110.html#name-uri-origin) HTTP request is sent to. | `80`; `8080`; `443` | If not default (`80` for `http` scheme, `443` for `https`) |
| `url.scheme` | string | The [URI scheme](https://www.rfc-editor.org/rfc/rfc3986#section-3.1) component identifying the used protocol. | `http`; `https`; `ftp` | Always |

HTTP client request duration measures the time the underlying client handler takes to complete the request. Completing the request includes the time up to reading response headers from the network stream. It doesn't include the time spent reading the response body.

Available starting in: .NET 8

### Instrument: `http.client.request.time_in_queue`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `http.client.request.time_in_queue` | Histogram | `s` | The amount of time requests spent on a queue waiting for an available connection. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `http.request.method` | string | HTTP request method. | `GET`; `POST`; `HEAD` | Always |
| `network.protocol.version` | string | Version of the application layer protocol used. | `1.1`; `2` | Always |
| `server.address` | string | Host identifier of the ["URI origin"](https://www.rfc-editor.org/rfc/rfc9110.html#name-uri-origin) HTTP request is sent to. | `example.com` | Always |
| `server.port` | int | Port identifier of the ["URI origin"](https://www.rfc-editor.org/rfc/rfc9110.html#name-uri-origin) HTTP request is sent to. | `80`; `8080`; `443` | If not default (`80` for `http` scheme, `443` for `https`) |
| `url.scheme` | string | The [URI scheme](https://www.rfc-editor.org/rfc/rfc3986#section-3.1) component identifying the used protocol. | `http`; `https`; `ftp` | Always |

<xref:System.Net.Http.HttpClient>, when configured to use the default <xref:System.Net.Http.SocketsHttpHandler>, sends HTTP requests using a pool of network connections. If all connections are busy handling other requests, new requests are placed in a queue and wait until a network connection is available for use. This instrument measures the amount of time HTTP requests spend waiting in that queue, prior to anything being sent across the network.

Available starting in: .NET 8

### Instrument: `http.client.active_requests`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| `http.client.active_requests` | UpDownCounter | `{request}` | Number of active HTTP requests. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `http.request.method` | string | HTTP request method. | `GET`; `POST`; `HEAD` | Always |
| `network.protocol.version` | string | Version of the application layer protocol used. | `1.1`; `2` | Always |
| `server.address` | string | Host identifier of the ["URI origin"](https://www.rfc-editor.org/rfc/rfc9110.html#name-uri-origin) HTTP request is sent to. | `example.com` | Always |
| `server.port` | int | Port identifier of the ["URI origin"](https://www.rfc-editor.org/rfc/rfc9110.html#name-uri-origin) HTTP request is sent to. | `80`; `8080`; `443` | If not default (`80` for `http` scheme, `443` for `https`) |
| `url.scheme` | string | The [URI scheme](https://www.rfc-editor.org/rfc/rfc3986#section-3.1) component identifying the used protocol. | `http`; `https`; `ftp` | Always |

This metric counts how many requests are considered active. Requests are active for the same time period that is measured by the [http.client.request.duration](#instrument-httpclientrequestduration) instrument.

Available starting in: .NET 8
