---
title: SYSLIB0012 compiler warning
description: Learn about the obsoletion that generates compiler warning SYSLIB0012.
ms.topic: reference
ms.date: 10/20/2020
---
# SYSLIB0012: Assembly.CodeBase and Assembly.EscapedCodeBase are obsolete

The following APIs are marked as obsolete, starting in .NET 5.0. Using them in code generates warning `SYSLIB0012` at compile time.

- <xref:System.Reflection.Assembly.CodeBase?displayProperty=nameWithType>
- <xref:System.Reflection.Assembly.EscapedCodeBase?displayProperty=nameWithType>

Workaround

Use <xref:System.Reflection.Assembly.Location?displayProperty=nameWithType> instead.
