---
title: "HttpClientFactory uses SocketsHttpHandler as primary handler"
description: Learn about the breaking change in networking in .NET 9 where HttpClientFactory now uses SocketsHttpHandler as the default primary handler.
ms.date: 11/5/2024
---

# HttpClientFactory uses SocketsHttpHandler as primary handler

`HttpClientFactory` allows you to configure an <xref:System.Net.Http.HttpMessageHandler> pipeline for named and typed <xref:System.Net.Http.HttpClient> objects. The inner-most handler, or the one that actually sends the request on the wire, is called a *primary handler*. If not configured, this handler was previously always an <xref:System.Net.Http.HttpClientHandler>. While the default primary handler is an implementation detail, there were users who depended on it. For example, some users cast the primary handler to `HttpClientHandler` to set properties like <xref:System.Net.Http.HttpClientHandler.ClientCertificates>, <xref:System.Net.Http.HttpClientHandler.UseCookies>, and <xref:System.Net.Http.HttpClientHandler.UseProxy>.

With this change, the default primary handler is a <xref:System.Net.Http.SocketsHttpHandler> on platforms that support it. On other platforms, for example, .NET Framework, <xref:System.Net.Http.HttpClientHandler> continues to be used.

`SocketsHttpHandler` now also has the <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionLifetime> property preset to match the <xref:Microsoft.Extensions.Http.HttpClientFactoryOptions.HandlerLifetime> value. (It reflects the latest value, if `HandlerLifetime` was configured by the user).

## Version introduced

.NET 9 Preview 6

## Previous behavior

The default primary handler was `HttpClientHandler`. Casting it to `HttpClientHandler` to update the properties happened to work.

```csharp
services.AddHttpClient("test")
    .ConfigurePrimaryHttpMessageHandler((h, _) =>
    {
        ((HttpClientHandler)h).UseCookies = false;
    });

// This worked.
var client = httpClientFactory.CreateClient("test");
```

## New behavior

On platforms where `SocketsHttpHandler` is supported, the default primary handler is now `SocketsHttpHandler` with `PooledConnectionLifetime` set to the `HandlerLifetime` value. Casting it to `HttpClientHandler` to update the properties throws an <xref:System.InvalidCastException>.

For example, the same code from the [Previous behavior](#previous-behavior) section now throws an <xref:System.InvalidCastException>:

> System.InvalidCastException: Unable to cast object of type 'System.Net.Http.SocketsHttpHandler' to type 'System.Net.Http.HttpClientHandler'.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

One of the most common problems `HttpClientFactory` users run into is when a `Named` or `Typed` client erroneously gets captured in a singleton service, or, in general, stored somewhere for a period of time that's longer than the specified <xref:Microsoft.Extensions.Http.HttpClientFactoryOptions.HandlerLifetime>. Because `HttpClientFactory` can't rotate such handlers, they might end up not respecting DNS changes.

This problem can be mitigated by using <xref:System.Net.Http.SocketsHttpHandler>, which has an option to control <xref:System.Net.Http.SocketsHttpHandler.PooledConnectionLifetime>. Similarly to <xref:Microsoft.Extensions.Http.HttpClientFactoryOptions.HandlerLifetime>, the pooled connection lifetime allows regularly recreating connections to pick up DNS changes, but on a lower level. A client with `PooledConnectionLifetime` set up can be safely used as a singleton.

It is, unfortunately, easy and seemingly "intuitive" to inject a `Typed` client into a singleton. But it's hard to have any kind of check or analyzer to make sure `HttpClient` isn't captured when it wasn't supposed to be captured. It's also hard to troubleshoot the resulting issues. So as a preventative measure&mdash;to minimize the potential impact of erroneous usage patterns&mdash;the `SocketsHttpHandler` mitigation is now applied by default.

This change only affects cases when the client wasn't configured by the end user to use a custom <xref:Microsoft.Extensions.Http.HttpMessageHandlerBuilder.PrimaryHandler> (for example, via <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigurePrimaryHttpMessageHandler``1(Microsoft.Extensions.DependencyInjection.IHttpClientBuilder)>).

## Recommended action

There are three options to work around the breaking change:

- Explicitly specify and configure a primary handler for each of your clients:

  ```csharp
  services.AddHttpClient("test")
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler() { UseCookies = false });
  ```

- Overwrite the default primary handler for all clients using <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.ConfigureHttpClientDefaults(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Action{Microsoft.Extensions.DependencyInjection.IHttpClientBuilder})>:

  ```csharp
  services.ConfigureHttpClientDefaults(b =>
    b.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler() { UseCookies = false }));
  ```

- In the configuration action, check for both `HttpClientHandler` and `SocketsHttpHandler`:

  ```csharp
  services.AddHttpClient("test")
    .ConfigurePrimaryHttpMessageHandler((h, _) =>
    {
        if (h is HttpClientHandler hch)
        {
            hch.UseCookies = false;
        }

        if (h is SocketsHttpHandler shh)
        {
            shh.UseCookies = false;
        }
    });
  ```

## Affected APIs

- <xref:Microsoft.Extensions.Http.HttpMessageHandlerBuilder.PrimaryHandler?displayProperty=fullName>
- <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigurePrimaryHttpMessageHandler(Microsoft.Extensions.DependencyInjection.IHttpClientBuilder,System.Action{System.Net.Http.HttpMessageHandler,System.IServiceProvider})?displayProperty=fullName>
