---
title: SYSLIB0025 warning
description: Learn about the obsoletion of SuppressIldasmAttribute that generates compile-time warning SYSLIB0025.
ms.date: 06/21/2021
f1_keywords:
  - syslib0025
---
# SYSLIB0025: SuppressIldasmAttribute is obsolete

The <xref:System.Runtime.CompilerServices.SuppressIldasmAttribute> type is marked as obsolete, starting in .NET 6. Using it in code generates warning `SYSLIB0025` at compile time. [IL Disassembler (ildasm.exe)](../../framework/tools/ildasm-exe-il-disassembler.md) no longer supports this attribute.

## Workarounds

None.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0025

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0025
```

To suppress all the `SYSLIB0025` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0025</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
