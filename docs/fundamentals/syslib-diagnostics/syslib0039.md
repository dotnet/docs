---
title: SYSLIB0039 warning - SslProtocols.Tls and SslProtocols.Tls11 are obsolete
description: Learn about the obsoletion of the SslProtocols.Tls and SslProtocols.Tls11 enumeration fields that generates compile-time warning SYSLIB0039.
ms.date: 03/17/2022
---
# SYSLIB0039: SslProtocols.Tls and SslProtocols.Tls11 are obsolete

<xref:System.Security.Authentication.SslProtocols.Tls?displayProperty=nameWithType> and <xref:System.Security.Authentication.SslProtocols.Tls11?displayProperty=nameWithType> are marked as obsolete, starting in .NET 7. Using these enumeration fields in code generates warning `SYSLIB0039` at compile time.

## Workaround

Use a higher TLS protocol version, or use <xref:System.Security.Authentication.SslProtocols.None?displayProperty=nameWithType> to defer to system defaults.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
