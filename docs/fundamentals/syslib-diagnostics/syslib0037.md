---
title: SYSLIB0037 warning - AssemblyName members HashAlgorithm, ProcessorArchitecture, and VersionCompatibility are obsolete
description: Learn about the obsoletion of some AssemblyName properties that generates compile-time warning SYSLIB0037.
ms.date: 01/13/2022
---
# SYSLIB0037: AssemblyName members HashAlgorithm, ProcessorArchitecture, and VersionCompatibility are obsolete

The following <xref:System.Reflection.AssemblyName?displayProperty=fullName> properties are marked as obsolete, starting in .NET 7. Using these APIs in code generates warning `SYSLIB0037` at compile time.

- <xref:System.Reflection.AssemblyName.HashAlgorithm>
- <xref:System.Reflection.AssemblyName.ProcessorArchitecture>
- <xref:System.Reflection.AssemblyName.VersionCompatibility>

These properties are not a proper part of an <xref:System.Reflection.AssemblyName> instance. They don't roundtrip through <xref:System.Reflection.AssemblyName> string representation, and they are ignored by the assembly loader in .NET Core.

## Workaround

Don't use these members in scenarios where it was expected for the values to be round-tripped through the string representation of the <xref:System.Reflection.AssemblyName>.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
