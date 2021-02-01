---
title: SYSLIB0008 warning
description: Learn about the obsoletion that generates compile-time warning SYSLIB0008.
ms.topic: reference
ms.date: 10/20/2020
---
# SYSLIB0008: CreatePdbGenerator is not supported

The <xref:System.Runtime.CompilerServices.DebugInfoGenerator.CreatePdbGenerator?displayProperty=nameWithType> API is marked obsolete, starting in .NET 5.0. Using this API generates warning `SYSLIB0008` at compile time.

## Suppress the warning

If you cannot change your code, you can suppress the warning through a `#pragma` directive or a `<NoWarn>` project setting. For examples, see [Suppress warnings](../syslib-obsoletions.md#suppress-warnings).
