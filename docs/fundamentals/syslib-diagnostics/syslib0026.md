---
title: SYSLIB0026 warning
description: Learn about the obsoletion of mutable X509 certificate APIs that generates compile-time warning SYSLIB0026.
ms.date: 06/21/2021
---
# SYSLIB0026: X509Certificate and X509Certificate2 are immutable

The following mutable x509 certificate APIs are marked as obsolete, starting in .NET 6. Using these APIs in code generates warning `SYSLIB0026` at compile time.

- <xref:System.Security.Cryptography.X509Certificates.X509Certificate.%23ctor>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate.Import%2A?displayProperty=nameWithType>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.%23ctor>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.Import%2A?displayProperty=nameWithType>

## Workarounds

None.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
