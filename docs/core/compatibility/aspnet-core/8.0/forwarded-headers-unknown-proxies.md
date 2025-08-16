---
title: "Breaking change: Forwarded Headers Middleware ignores X-Forwarded-* headers from unknown proxies"
description: Learn about the breaking change in ASP.NET Core 8.0.17 where Forwarded Headers Middleware now ignores headers from proxies that are not explicitly configured as trusted.
ms.date: 01/16/2025
---
# Forwarded Headers Middleware ignores X-Forwarded-* headers from unknown proxies

Starting in ASP.NET Core 8.0.17 and 9.0.6, the Forwarded Headers Middleware ignores all `X-Forwarded-*` headers from proxies that are not explicitly configured as trusted. This change was made for security hardening, as the proxy and IP lists weren't being applied in all cases.

## Version introduced

ASP.NET Core 8.0.17

## Previous behavior

Previously, the middleware, when not configured to use `X-Forwarded-For`, would process `X-Forwarded-Prefix`, `X-Forwarded-Proto`, and `X-Forwarded-Host` headers from any source, potentially allowing malicious or misconfigured proxies/clients to spoof these headers and affect your application's understanding of client information.

## New behavior

With this change, only headers sent by known, trusted proxies (as configured via <xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersOptions.KnownProxies> and <xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersOptions.KnownNetworks>) are processed. Headers from unknown sources are ignored.

This can cause behavior like infinite redirects if you're using the HTTPS redirection middleware and using TLS termination in your proxy. Or authentication to fail if using TLS termination and expecting an HTTPS request.

## Type of breaking change

This change affects [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The change was made for security hardening, as the proxy and IP lists weren't being applied in all cases.

## Recommended action

**Review your deployment topology:** Ensure that all legitimate proxy servers in front of your app are properly added to `KnownProxies` or `KnownNetworks` in your <xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersOptions> configuration.

```csharp
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    KnownProxies = { IPAddress.Parse("YOUR_PROXY_IP") }
});
```

Or, for a network:

```csharp
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    KnownNetworks = { new IPNetwork(IPAddress.Parse("YOUR_NETWORK_IP"), PREFIX_LENGTH) }
});
```

**If you wish to enable previous behavior:** You may need to relax your configuration, but this is **not recommended** due to security risks. You can do this by clearing the `KnownNetworks` and `KnownProxies` lists in <xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersOptions> to allow any proxy or network to forward these headers.

You can also set the `ASPNETCORE_FORWARDEDHEADERS_ENABLED` environment variable to `true`, which clears the lists and enables `ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto`.

For applications targeting .NET 9.0 or less, you can set the `Microsoft.AspNetCore.HttpOverrides.IgnoreUnknownProxiesWithoutFor` [AppContext](/dotnet/fundamentals/runtime-libraries/system-appcontext) switch to `"true"` or `1` to get back to the previous behavior. Alternatively, set the `MICROSOFT_ASPNETCORE_HTTPOVERRIDES_IGNORE_UNKNOWN_PROXIES_WITHOUT_FOR` environment variable.

> [!NOTE]
> In cloud environments, the proxy IP(s) can change over the lifetime of the app and `ASPNETCORE_FORWARDEDHEADERS_ENABLED` is sometimes used to make forwarded headers work.

## Affected APIs

- <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersExtensions.UseForwardedHeaders*?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersOptions?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersOptions.KnownProxies?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersOptions.KnownNetworks?displayProperty=fullName>

## See also

- [Configure ASP.NET Core to work with proxy servers and load balancers](/aspnet/core/host-and-deploy/proxy-load-balancer)
