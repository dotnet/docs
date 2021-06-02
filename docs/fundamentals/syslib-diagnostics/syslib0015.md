---
title: SYSLIB0015 warning
description: Learn about the obsoletion of DisablePrivateReflectionAttribute that generates compile-time warning SYSLIB0015.
ms.date: 04/24/2021
---
# SYSLIB0015: DisablePrivateReflectionAttribute is obsolete

Starting in .NET 6, the <xref:System.Runtime.CompilerServices.DisablePrivateReflectionAttribute?displayProperty=nameWithType> type is marked as obsolete. This attribute has no effect in .NET Core 2.1 and later apps. Using it in code generates warning `SYSLIB0015` at compile time for .NET 6 and later apps.

For more information, see <https://github.com/dotnet/runtime/issues/11811>.

## Workarounds

None.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
