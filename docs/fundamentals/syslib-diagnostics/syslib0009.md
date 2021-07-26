---
title: SYSLIB0009 warning
description: Learn about the obsoletions that generate compile-time warning SYSLIB0009.
ms.date: 10/20/2020
---

# SYSLIB0009: The AuthenticationManager Authenticate and PreAuthenticate methods are not supported

The following APIs are marked obsolete, starting in .NET 5. Use of these APIs generates warning `SYSLIB0009` at compile time and throws a <xref:System.PlatformNotSupportedException> at run time.

- <xref:System.Net.AuthenticationManager.Authenticate%2A?displayProperty=nameWithType>
- <xref:System.Net.AuthenticationManager.PreAuthenticate%2A?displayProperty=nameWithType>

## Workarounds

Implement <xref:System.Net.IAuthenticationModule>, which has methods that were previously called by <xref:System.Net.AuthenticationManager.Authenticate%2A?displayProperty=nameWithType>.

<!-- Include adds ## Suppress warnings (H2 heading) -->
[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
