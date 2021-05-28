---
title: SYSLIB0024 warning
description: Learn about the AppDomain-related obsoletions that generate compile-time warning SYSLIB0024.
ms.date: 05/18/2021
---
# SYSLIB0024: Creating and unloading AppDomains is not supported and throws an exception

The <xref:System.AppDomain.CreateDomain(System.String)?displayProperty=nameWithType> and <xref:System.AppDomain.Unload(System.AppDomain)?displayProperty=nameWithType> methods are marked as obsolete, starting in .NET 6. Using them in code generates warning `SYSLIB0024` at compile time and throws an exception at run time.

## Workarounds

None.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
