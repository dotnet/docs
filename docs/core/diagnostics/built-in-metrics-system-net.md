---
title: System.Net metrics
description: Review the metrics available for System.Net
ms.topic: reference
ms.date: 9/21/2023
---

# System.Net metrics

This article describes the networking metrics built-in for <xref:System.Net> produced using the
<xref:System.Diagnostics.Metrics?displayProperty=nameWithType> API. For a listing of metrics based on the alternate [EventCounters](event-counters.md) API, see [Well-known EventCounters in .NET](available-counters.md).

> [!TIP]
> For more information about how to collect, report, enrich, and test System.Net metrics, see [Networking metrics in .NET](../../fundamentals/networking/telemetry/metrics.md).

## `System.Net.NameResolution`

The `System.Net.NameResolution` metrics report DNS name resolution from <xref:System.Net.Dns>:

- [`dns.lookup.duration`](#metric-dnslookupduration)

##### Metric: `dns.lookup.duration`

| Name     | Instrument Type | Unit | Description    |
| -------- | --------------- | ----------- | -------------- |
| [`dns.lookup.duration`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-dns-metrics/#metric-dnslookupduration) | Histogram | `s` | Measures the time taken to perform a DNS lookup. |

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

When using OpenTelemetry, the default buckets for this metric are set to [ 0.005, 0.01, 0.025, 0.05, 0.075, 0.1, 0.25, 0.5, 0.75, 1, 2.5, 5, 7.5, 10 ].

Available starting in: .NET 8

## `System.Net.Http`

The `System.Net.Http` metrics report HTTP request and connection information from <xref:System.Net.Http>:

- [`http.client.open_connections`](#metric-httpclientopen_connections)
- [`http.client.connection.duration`](#metric-httpclientconnectionduration)
- [`http.client.request.duration`](#metric-httpclientrequestduration)
- [`http.client.request.time_in_queue`](#metric-httpclientrequesttime_in_queue)
- [`http.client.active_requests`](#metric-httpclientactive_requests)

##### Metric: `http.client.open_connections`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| [`http.client.open_connections`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-http-metrics/#metric-httpclientopen_connections) | UpDownCounter | `{connection}` | Number of outbound HTTP connections that are currently active or idle on the client |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `http.connection.state` | string | State of HTTP connection in the HTTP connection pool. | `active`; `idle` | Always |
| `network.protocol.version` | string | Version of the HTTP protocol used. | `1.1`; `2` | Always |
| `server.address` | string | Host identifier of the ["URI origin"](https://www.rfc-editor.org/rfc/rfc9110.html#name-uri-origin) HTTP request is sent to. | `example.com` | Always |
| `server.port` | int | Port identifier of the ["URI origin"](https://www.rfc-editor.org/rfc/rfc9110.html#name-uri-origin) HTTP request is sent to. | `80`; `8080`; `443` | If not default (`80` for `http` scheme, `443` for `https`) |
| `network.peer.address` | string | Peer IP address of the socket connection. | `10.5.3.2` | Always |
| `url.scheme` | string | The [URI scheme](https://www.rfc-editor.org/rfc/rfc3986#section-3.1) component identifying the used protocol. | `http`; `https`; `ftp` | Always |

<xref:System.Net.Http.HttpClient>, when configured to use the default <xref:System.Net.Http.SocketsHttpHandler>, maintains a cached pool of network connections for sending HTTP messages. This metric counts how many connections are currently in the pool. Active connections are handling active requests. Active connects could be transmitting data or awaiting the client or server. Idle connections aren't handling any requests, but are left open so that future requests can be handled more quickly.

Available starting in: .NET 8

##### Metric: `http.client.connection.duration`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| [`http.client.connection.duration`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-http-metrics/#metric-httpclientconnectionduration) | Histogram | `s` | The duration of successfully established outbound HTTP connections. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `network.protocol.version` | string | Version of the HTTP protocol used. | `1.1`; `2` | Always |
| `server.address` | string | Host identifier of the ["URI origin"](https://www.rfc-editor.org/rfc/rfc9110.html#name-uri-origin) HTTP request is sent to. | `example.com` | Always |
| `server.port` | int | Port identifier of the ["URI origin"](https://www.rfc-editor.org/rfc/rfc9110.html#name-uri-origin) HTTP request is sent to. | `80`; `8080`; `443` | If not default (`80` for `http` scheme, `443` for `https`) |
| `network.peer.address` | string | IP address of the socket connection. | `10.5.3.2` | Always |
| `url.scheme` | string | The [URI scheme](https://www.rfc-editor.org/rfc/rfc3986#section-3.1) component identifying the used protocol. | `http`; `https`; `ftp` | Always |

This metric is only captured when <xref:System.Net.Http.HttpClient> is configured to use the default <xref:System.Net.Http.SocketsHttpHandler>.

As this metric is tracking the connection duration, and ideally http connections are used for multiple requests, the buckets should be longer than those used for request durations. For example, using [ 0.01, 0.02, 0.05, 0.1, 0.2, 0.5, 1, 2, 5, 10, 30, 60, 120, 300 ] provides an upper bucket of 5 mins.

Available starting in: .NET 8

##### Metric: `http.client.request.duration`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| [`http.client.request.duration`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-http-metrics/#metric-httpserverrequestduration) | Histogram | `s` | The duration of outbound HTTP requests. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `error.type` | string | Request failure reason: one of the [HTTP request errors](xref:System.Net.Http.HttpRequestError) in snake_case, or a full exception type, or an HTTP 4xx/5xx status code. | `System.Threading.Tasks.TaskCanceledException`; `name_resolution_error`; `secure_connection_error` ; `404` | If request has failed. |
| `http.request.method` | string | HTTP request method. | `GET`; `POST`; `HEAD`; `_OTHER` [2] | Always |
| `http.response.status_code` | int | [HTTP response status code](https://tools.ietf.org/html/rfc7231#section-6). | `200` | If response was received. |
| `network.protocol.version` | string | Version of the HTTP protocol used. | `1.1`; `2` | If response was received. |
| `server.address` | string | Host identifier of the ["URI origin"](https://www.rfc-editor.org/rfc/rfc9110.html#name-uri-origin) HTTP request is sent to. | `example.com` | Always |
| `server.port` | int | Port identifier of the ["URI origin"](https://www.rfc-editor.org/rfc/rfc9110.html#name-uri-origin) HTTP request is sent to. | `80`; `8080`; `443` | Depends on .NET version. [3] |
| `url.scheme` | string | The [URI scheme](https://www.rfc-editor.org/rfc/rfc3986#section-3.1) component identifying the used protocol. | `http`; `https`; `ftp` | Always |

**[1] `error.type`:** If the request has failed, the value is set to one of the following:

- An exception name with type, for example, <xref:System.Threading.Tasks.TaskCanceledException>.
- A status code that indicates a client or server error, for example, `500`.
- If an <xref:System.Net.Http.HttpRequestException> occurred with an <xref:System.Net.Http.HttpRequestError> other than `Unknown`, the enum value in snake case, for example, `name_resolution_error`.

**[2] `http.request.method`:** `http.request.method`:** The value contains the method name, if the method is one of the well-known methods listed in [RFC9110](https://www.rfc-editor.org/rfc/rfc9110.html#name-methods); otherwise the value is `_OTHER`. The user-provided method names will be mapped to known names in a case-insensitive manner. For example, if the user provides the name `GeT`, it will be mapped to `GET`.

**[3] `server.port`:** The Presence of the value is version-dependent:

- *.NET 8*: Present if not default (`80` for `http` scheme, `443` for `https`)
- *.NET 9+*: Always present

HTTP client request duration measures the time the underlying client handler takes to complete the request. Completing the request includes the time up to reading response headers from the network stream. It doesn't include the time spent reading the response body.

When using OpenTelemetry, the default buckets for this metric are set to [ 0.005, 0.01, 0.025, 0.05, 0.075, 0.1, 0.25, 0.5, 0.75, 1, 2.5, 5, 7.5, 10 ].

Available starting in: .NET 8

> [!TIP]
> [Enrichment](../../fundamentals/networking/telemetry/metrics.md#enrichment) is possible for this metric.

##### Metric: `http.client.request.time_in_queue`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| [`http.client.request.time_in_queue`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-http-metrics/#metric-httpclientrequesttime_in_queue) | Histogram | `s` | The amount of time requests spent on a queue waiting for an available connection. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `http.request.method` | string | HTTP request method. | `GET`; `POST`; `HEAD` | Always |
| `network.protocol.version` | string | Version of the HTTP protocol used. | `1.1`; `2` | Always |
| `server.address` | string | Host identifier of the ["URI origin"](https://www.rfc-editor.org/rfc/rfc9110.html#name-uri-origin) HTTP request is sent to. | `example.com` | Always |
| `server.port` | int | Port identifier of the ["URI origin"](https://www.rfc-editor.org/rfc/rfc9110.html#name-uri-origin) HTTP request is sent to. | `80`; `8080`; `443` | If not default (`80` for `http` scheme, `443` for `https`) |
| `url.scheme` | string | The [URI scheme](https://www.rfc-editor.org/rfc/rfc3986#section-3.1) component identifying the used protocol. | `http`; `https`; `ftp` | Always |

<xref:System.Net.Http.HttpClient>, when configured to use the default <xref:System.Net.Http.SocketsHttpHandler>, sends HTTP requests using a pool of network connections. If all connections are busy handling other requests, new requests are placed in a queue and wait until a network connection is available for use. This instrument measures the amount of time HTTP requests spend waiting in that queue, prior to anything being sent across the network.

Available starting in: .NET 8

##### Metric: `http.client.active_requests`

| Name     | Instrument Type | Unit (UCUM) | Description    |
| -------- | --------------- | ----------- | -------------- |
| [`http.client.active_requests`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-http-metrics/#metric-httpserveractive_requests) | UpDownCounter | `{request}` | Number of active HTTP requests. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `http.request.method` | string | HTTP request method. | `GET`; `POST`; `HEAD` | Always |
| `server.address` | string | Host identifier of the ["URI origin"](https://www.rfc-editor.org/rfc/rfc9110.html#name-uri-origin) HTTP request is sent to. | `example.com` | Always |
| `server.port` | int | Port identifier of the ["URI origin"](https://www.rfc-editor.org/rfc/rfc9110.html#name-uri-origin) HTTP request is sent to. | `80`; `8080`; `443` | If not default (`80` for `http` scheme, `443` for `https`) |
| `url.scheme` | string | The [URI scheme](https://www.rfc-editor.org/rfc/rfc3986#section-3.1) component identifying the used protocol. | `http`; `https`; `ftp` | Always |

This metric counts how many requests are considered active. Requests are active for the same time period that is measured by the [http.client.request.duration](#metric-httpclientrequestduration) instrument.

Available starting in: .NET 8
