---
title: SYSLIB0008 warning
description: Learn about the obsoletion that generates compile-time warning SYSLIB0008.
ms.date: 10/20/2020
f1_keywords:
  - syslib0008
---
# SYSLIB0008: CreatePdbGenerator is not supported

The <xref:System.Runtime.CompilerServices.DebugInfoGenerator.CreatePdbGenerator?displayProperty=nameWithType> API is marked obsolete, starting in .NET 5. Using this API generates warning `SYSLIB0008` at compile time and throws a <xref:System.PlatformNotSupportedException> at run time.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0008

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0008
```

To suppress all the `SYSLIB0008` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0008</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
