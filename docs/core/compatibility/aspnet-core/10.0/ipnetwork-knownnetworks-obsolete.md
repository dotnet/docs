---
title: "Breaking change: IPNetwork and ForwardedHeadersOptions.KnownNetworks are obsolete"
description: Learn about the breaking change in ASP.NET Core 10.0 where IPNetwork and ForwardedHeadersOptions.KnownNetworks have been obsoleted in favor of System.Net.IPNetwork and KnownIPNetworks.
ms.date: 08/08/2025
ai-usage: ai-assisted
ms.custom: https://github.com/aspnet/Announcements/issues/523
---
# IPNetwork and ForwardedHeadersOptions.KnownNetworks are obsolete

<xref:Microsoft.AspNetCore.HttpOverrides.IPNetwork> and <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownNetworks?displayProperty=nameWithType> have been marked as obsolete in favor of using <xref:System.Net.IPNetwork> and <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownIPNetworks?displayProperty=nameWithType>.

## Version introduced

.NET 10 Preview 7

## Previous behavior

Developers could use <xref:Microsoft.AspNetCore.HttpOverrides.IPNetwork> and <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownNetworks?displayProperty=nameWithType> to configure known networks for the forwarded headers middleware:

```csharp
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    KnownNetworks.Add(new(IPAddress.Loopback, 8))
});
```

## New behavior

If you use the obsolete APIs in your code, you'll get warning `ASPDEPR005` at compile time:

> warning ASPDEPR005: Please use KnownIPNetworks instead. For more information, visit https://aka.ms/aspnet/deprecate/005.

Use the <xref:System.Net.IPNetwork> type and <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownIPNetworks?displayProperty=nameWithType> property instead:

```csharp
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    KnownIPNetworks.Add(new(IPAddress.Loopback, 8))
});
```

## Type of breaking change

This change affects [source compatibility](../../categories.md#source-compatibility).

## Reason for change

<xref:System.Net.IPNetwork> has replaced the <xref:Microsoft.AspNetCore.HttpOverrides.IPNetwork> type that was implemented for <xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersMiddleware>.

## Recommended action

Change to using <xref:System.Net.IPNetwork> and <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownIPNetworks?displayProperty=nameWithType>.

## Affected APIs

- <xref:Microsoft.AspNetCore.HttpOverrides.IPNetwork?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownNetworks?displayProperty=fullName>