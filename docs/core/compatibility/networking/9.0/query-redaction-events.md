---
title: "URI query redaction in HttpClient EventSource events"
description: "Learn about the breaking change in networking in .NET 9 where HttpClient EventSource events scrub query strings by default to enhance privacy."
ms.date: 11/5/2024
ai-usage: ai-assisted
ms.topic: article
---

# URI query and fragment redaction in HttpClient EventSource events

In .NET 9, the default behavior of <xref:System.Diagnostics.Tracing.EventSource> events emitted by <xref:System.Net.Http.HttpClient> and <xref:System.Net.Http.SocketsHttpHandler> (`EventSource` name: `System.Net.Http`) has been modified to scrub the query and fragment part of the URI. This change enhances privacy by preventing the logging of potentially sensitive information contained in query strings while keeping the performance costs of the redaction minimal. If necessary, you can override this behavior.

## Version introduced

.NET 9 Preview 7

## Previous behavior

Previously, events emitted by `HttpClient` and `SocketsHttpHandler` included query string information, which could inadvertently expose sensitive information.

## New behavior

With the change in [dotnet/runtime#104741](https://github.com/dotnet/runtime/pull/104741), the query and fragment part are replaced by a `*` character in `HttpClient` and `SocketsHttpHandler` events, by default. This change affects specific events and parameters, such as `pathAndQuery` in `RequestStart` and `redirectUri` in `Redirect`.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The primary reason for this change was to enhance privacy by reducing the risk of sensitive information being logged inadvertently. Query strings often contain sensitive data, and redacting them from logs by default helps protect this information. To keep the implementation simple and efficient, the fragment part is also scrubbed.

## Recommended action

If you need query string information when consuming `HttpClient` or `SocketsHttpHandler` events and you're confident that it's safe to do so, you can enable query string logging globally by setting an AppContext switch in one of three ways:

- In the project file.

  ```xml
  <ItemGroup>
    <RuntimeHostConfigurationOption Include="System.Net.Http.DisableUriRedaction" Value="true" />
  </ItemGroup>
  ```

- In the *runtimeconfig.json* file.

  ```json
  {
      "runtimeOptions": {
          "configProperties": {
              "System.Net.Http.DisableUriRedaction": true
          }
      }
  }
  ```

- Through an environment variable.

  Set `DOTNET_SYSTEM_NET_HTTP_DISABLEURIREDACTION` to `true` or 1.

Otherwise, no action is required, and the default behavior will help enhance the privacy aspects of your application.

> [!NOTE]
> This switch also disables query string redaction in the default `IHttpClientFactory` logs. For more information, see [URI query redaction in IHttpClientFactory logs](query-redaction-logs.md).

## Affected APIs

- [System.Net.Http.SocketsHttpHandler.Send](xref:System.Net.Http.HttpMessageHandler.Send(System.Net.Http.HttpRequestMessage,System.Threading.CancellationToken))
- [System.Net.Http.SocketsHttpHandler.SendAsync](xref:System.Net.Http.HttpMessageHandler.SendAsync(System.Net.Http.HttpRequestMessage,System.Threading.CancellationToken))
