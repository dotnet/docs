---
title: "HttpClient metrics report `server.port` unconditionally"
description: Learn about the breaking change in networking in .NET 9 where HttpClient metrics now report the `server.port` attribute unconditionally to maintain compliance with Open Telemetry standards.
ms.date: 11/5/2024
---

# HttpClient metrics report `server.port` unconditionally

When [HttpClient metrics](../../../../fundamentals/networking/telemetry/metrics.md) were added in .NET 8, `server.port` was introduced as a [`Conditionally Required`](https://opentelemetry.io/docs/specs/semconv/general/attribute-requirement-level/#conditionally-required) attribute in accordance with the state of the standard at that time. Being conditionally required meant that the port was only reported if it did not match the default port of the corresponding protocol (80 for HTTP, 443 for HTTPS). However, the standard [requirement level of the attribute](https://opentelemetry.io/docs/specs/semconv/http/http-spans/#http-client) has since been changed to `Required`.

To maintain compliance with the Open Telemetry standard while keeping the instrument's behaviors consistent with each other, the instruments `http.client.request.duration`, `http.client.connection.duration`, and `http.client.open_connections` have been changed to unconditionally report the `server.port` attribute.

This change can break existing queries in monitoring software like Prometheus.

## Version introduced

.NET 9 Preview 7

## Previous behavior

`http.client.request.duration`, `http.client.connection.duration`, and `http.client.open_connections` reported the `server.port` attribute only if it did not match the corresponding protocol's default port (80 for HTTP, 443 for HTTPS).

## New behavior

The `server.port` attribute is now unconditionally reported by the instruments `http.client.request.duration`, `http.client.connection.duration`, and `http.client.open_connections`.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The change maintains compliance with the [Open Telemetry specification](https://opentelemetry.io/docs/specs/semconv/http/http-spans/#http-client) while keeping `HttpClient` instruments consistent with each other.

## Recommended action

No action is needed if you don't rely on [HttpClient metrics](../../../../fundamentals/networking/telemetry/metrics.md). If you use the `http.client.request.duration`, `http.client.connection.duration`, or `http.client.open_connections` instruments, this change might break existing queries in monitoring software like Prometheus.

## Affected APIs

- `System.Net.Http.SocketsHttpHandler.Send(System.Net.Http.HttpRequestMessage,System.Threading.CancellationToken)`
- `System.Net.Http.SocketsHttpHandler.SendAsync(System.Net.Http.HttpRequestMessage,System.Threading.CancellationToken)`
- <xref:System.Net.Http.HttpClientHandler.Send(System.Net.Http.HttpRequestMessage,System.Threading.CancellationToken)?displayProperty=fullName>
- <xref:System.Net.Http.HttpClientHandler.SendAsync(System.Net.Http.HttpRequestMessage,System.Threading.CancellationToken)?displayProperty=fullName>
