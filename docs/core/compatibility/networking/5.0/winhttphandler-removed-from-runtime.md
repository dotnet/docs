---
title: "Breaking change: WinHttpHandler removed from .NET runtime"
description: Learn about the breaking change in .NET 5 where WinHttpHandler was removed from the .NET runtime.
ms.date: 10/18/2020
---
# WinHttpHandler removed from .NET runtime

The `WinHttpHandler` class was removed from the *System.Net.Http.dll* assembly. It's now available only as an out-of-band (OOB) [NuGet package](https://www.nuget.org/packages/System.Net.Http.WinHttpHandler/).

## Version introduced

5.0

## Change description

In previous .NET versions, the <xref:System.Net.Http.WinHttpHandler> class is available as part of the core .NET libraries. Starting in .NET 5, the <xref:System.Net.Http.WinHttpHandler> class is only available as a separately installed [NuGet package](https://www.nuget.org/packages/System.Net.Http.WinHttpHandler/).

## Recommended action

Install the [System.Net.Http.WinHttpHandler NuGet package](https://www.nuget.org/packages/System.Net.Http.WinHttpHandler/). Or, if you don't require WinHTTP-specific features, use <xref:System.Net.Http.SocketsHttpHandler> instead.

## Affected APIs

- <xref:System.Net.Http.WinHttpHandler?displayProperty=fullName>

<!--

### Affected APIs

- `T:System.Net.Http.WinHttpHandler`

### Category

Networking

-->
