---
title: "URI query redaction in IHttpClientFactory logs"
description: Learn about the breaking change in networking in .NET 9 where the IHttpClientFactory implementation scrubs query strings in logs to enhance privacy.
ms.date: 11/5/2024
ai-usage: ai-assisted
---

# URI query and fragment redaction in IHttpClientFactory logs

In .NET 9, the default implementation of <xref:System.Net.Http.IHttpClientFactory> has been modified to scrub query strings when logging URI information. This change enhances privacy by preventing the logging of potentially sensitive information contained in query strings while keeping the performance costs of the redaction minimal. For scenarios where logging query strings is necessary and deemed safe, you can override this behavior.

## Version introduced

.NET 9 Preview 7

## Previous behavior

Previously, the default implementation of `IHttpClientFactory` logging included query strings in the messages passed to <xref:Microsoft.Extensions.Logging.ILogger>, which could inadvertently expose sensitive information.

## New behavior

The messages passed to <xref:Microsoft.Extensions.Logging.ILogger> now have the query and fragment part replaced by a `*` character.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The primary reason for this change is to enhance privacy by reducing the risk of sensitive information being logged inadvertently. Query strings often contain sensitive data and excluding them from logs by default helps protect this information. To keep the implementation simple and efficient, the fragment part is also scrubbed.

## Recommended action

If your application relies on logging query strings and you're confident that it's safe to do so, you can enable query string logging globally by setting an AppContext switch in one of three ways:

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
> This switch also disables query string redaction in `HttpClient` EventSource events. For more information, see [URI query redaction in HttpClient EventSource events](query-redaction-events.md).

## Affected APIs

- <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient*?displayProperty=fullName>
