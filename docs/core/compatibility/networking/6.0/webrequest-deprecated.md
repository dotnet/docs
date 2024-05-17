---
title: "Breaking change: WebRequest, WebClient, and ServicePoint are obsolete"
description: Learn about the breaking change in .NET 6 where WebRequest, WebClient, and ServicePoint are deprecated in favor of HttpClient.
ms.date: 04/26/2021
---
# WebRequest, WebClient, and ServicePoint are obsolete

<xref:System.Net.WebRequest>, <xref:System.Net.WebClient>, and <xref:System.Net.ServicePoint> classes are marked as obsolete and generate a `SYSLIB0014` warning at compile time.

## Version introduced

6.0

## Change description

<xref:System.Net.WebRequest>, <xref:System.Net.WebClient>, and <xref:System.Net.ServicePoint> classes were added to .NET Core in version 2.0 for backward compatibility. However, they introduced several runtime breaking changes, for example, `WebRequest.GetRequestStream` allocates memory for the whole response, and `WebClient.CancelAsync` doesn't always cancel immediately.

Starting in .NET 6, the <xref:System.Net.WebRequest>, <xref:System.Net.WebClient>, and <xref:System.Net.ServicePoint> classes are deprecated. The classes are still available, but they're not recommended for new development. To reduce the number of analyzer warnings, only construction methods are decorated with the <xref:System.ObsoleteAttribute> attribute.

## Recommended action

Use the <xref:System.Net.Http.HttpClient?displayProperty=fullName> class instead.

For FTP, since <xref:System.Net.Http.HttpClient> doesn't support it, we recommend using a third-party library.

## Affected APIs

- <xref:System.Net.WebRequest>
- <xref:System.Net.HttpWebRequest>
- <xref:System.Net.FtpWebRequest>
- <xref:System.Net.WebClient>
- <xref:System.Net.ServicePoint>

<!--

### Affected APIs

- `T:System.Net.WebRequest`
- `T:System.Net.HttpWebRequest`
- `T:System.Net.FtpWebRequest`
- `T:System.Net.WebClient`
- `T:System.Net.ServicePoint`

### Category

Networking

-->
