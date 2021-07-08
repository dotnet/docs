---
title: SYSLIB0005 warning
description: Learn about the obsoletion that generates compile-time warning SYSLIB0005.
ms.date: 10/20/2020
---
# SYSLIB0005: The global assembly cache (GAC) is not supported

.NET Core and .NET 5 and later versions eliminate the concept of the global assembly cache (GAC) that was present in .NET Framework. To help steer developers away from these APIs, some GAC-related APIs are marked as obsolete, starting in .NET 5. Using these APIs generates warning `SYSLIB0005` at compile time.

The following GAC-related APIs are marked obsolete:

- <xref:System.Reflection.Assembly.GlobalAssemblyCache?displayProperty=nameWithType>

  Libraries and apps should not use the <xref:System.Reflection.Assembly.GlobalAssemblyCache> API to make determinations about run-time behavior, as it always returns `false` in .NET Core and .NET 5+.

## Workarounds

If your application queries the <xref:System.Reflection.Assembly.GlobalAssemblyCache> property, consider removing the call. If you use the <xref:System.Reflection.Assembly.GlobalAssemblyCache> value to choose between an "assembly in the GAC"-flow vs. an "assembly not in the GAC"-flow at run time, reconsider whether the flow still makes sense for a .NET 5+ application.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]

## See also

- [Global assembly cache](../../framework/app-domains/gac.md)
