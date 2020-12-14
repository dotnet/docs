---
title: SYSLIB0009 warning
description: Learn about the obsoletions that generate compile-time warning SYSLIB0009.
ms.topic: reference
ms.date: 10/20/2020
---
# SYSLIB0009: The AuthenticationManager Authenticate and PreAuthenticate methods are not supported

The following APIs are marked obsolete, starting in .NET 5.0. Use of these APIs generates warning `SYSLIB0009` at compile time.

- <xref:System.Net.AuthenticationManager.Authenticate%2A?displayProperty=nameWithType>
- <xref:System.Net.AuthenticationManager.PreAuthenticate%2A?displayProperty=nameWithType>

## Suppress the warning

If you cannot change your code, you can suppress the warning through a `#pragma` directive or a `<NoWarn>` project setting. For examples, see [Suppress warnings](../syslib-obsoletions.md#suppress-warnings).
