---
title: SYSLIB0019 warning
description: Learn about the RuntimeEnvironment obsoletions that generate compile-time warning SYSLIB0019.
ms.topic: reference
ms.date: 04/24/2021
---
# SYSLIB0019: Some RuntimeEnvironment APIs are obsolete

The following APIs are marked as obsolete, starting in .NET 6. Using them in code generates warning `SYSLIB0019` at compile time.

- <xref:System.Runtime.InteropServices.RuntimeEnvironment.SystemConfigurationFile> property
- <xref:System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeInterfaceAsIntPtr> method
- <xref:System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeInterfaceAsObject> method

These APIs throw a <xref:System.PlatformNotSupportedException> at run time.

## Workarounds

None.

[!INCLUDE [suppress-syslib-warning](../../../../includes/suppress-syslib-warning.md)]
