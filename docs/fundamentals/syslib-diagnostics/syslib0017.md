---
title: SYSLIB0017 warning
description: Learn about the obsoletion of strong-name signing-related APIS that generates compile-time warning SYSLIB0017.
ms.date: 04/24/2021
---
# SYSLIB0017: Strong-name signing is not supported and throws PlatformNotSupportedException

The following APIS are marked as obsolete, starting in .NET 6. Using them in code generates warning `SYSLIB0017` at compile time. These APIs throw a <xref:System.PlatformNotSupportedException> at run time.

- <xref:System.Reflection.AssemblyName.KeyPair?displayProperty=nameWithType>
- <xref:System.Reflection.StrongNameKeyPair>

For more information, see <https://github.com/dotnet/runtime/issues/50529>.

## Workarounds

None.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
