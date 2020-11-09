---
title: SYSLIB0012 warning
description: Learn about the obsoletions that generate compile-time warning SYSLIB0012.
ms.topic: reference
ms.date: 10/20/2020
---
# SYSLIB0012: Assembly.CodeBase and Assembly.EscapedCodeBase are obsolete

The following APIs are marked as obsolete, starting in .NET 5.0. Using them in code generates warning `SYSLIB0012` at compile time.

- <xref:System.Reflection.Assembly.CodeBase?displayProperty=nameWithType>
- <xref:System.Reflection.Assembly.EscapedCodeBase?displayProperty=nameWithType>

## Workaround

Use <xref:System.Reflection.Assembly.Location?displayProperty=nameWithType> instead.

## Suppress the warning

It's recommended that you use the [workaround](#workaround). However, if you cannot change your code, you can suppress the warning through a `#pragma` directive or a `<NoWarn>` project setting. For examples, see [Suppress warnings](syslib-obsoletions.md#suppress-warnings).
