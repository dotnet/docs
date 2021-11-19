---
title: SYSLIB0014 warning
description: Learn about the System.Net obsoletions that generate compile-time warning SYSLIB0014.
ms.date: 04/24/2021
---
# SYSLIB0014: WebRequest, HttpWebRequest, ServicePoint, WebClient are obsolete

The following APIs are marked as obsolete, starting in .NET 6. Using them in code generates warning `SYSLIB0014` at compile time.

- <xref:System.Net.WebRequest.%23ctor>
- <xref:System.Net.WebRequest.Create%2A?displayProperty=fullName>
- <xref:System.Net.WebRequest.CreateHttp%2A?displayProperty=fullName>
- <xref:System.Net.WebRequest.CreateDefault(System.Uri)?displayProperty=fullName>
- <xref:System.Net.HttpWebRequest.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)>
- <xref:System.Net.ServicePointManager.FindServicePoint%2A?displayProperty=fullName>
- <xref:System.Net.WebClient.%23ctor>

## Workarounds

Use <xref:System.Net.Http.HttpClient> instead.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]

## See also

- [WebRequest, WebClient, and ServicePoint are obsolete](../../core/compatibility/networking/6.0/webrequest-deprecated.md)
