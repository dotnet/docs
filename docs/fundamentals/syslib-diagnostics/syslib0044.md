---
title: SYSLIB0044 warning - AssemblyName.CodeBase and AssemblyName.EscapedCodeBase are obsolete
description: Learn about the obsoletion of AssemblyName.CodeBase and AssemblyName.EscapedCodeBase that generates compile-time warning SYSLIB0044.
ms.date: 11/07/2022
f1_keywords:
  - syslib0044
---
# SYSLIB0044: AssemblyName.CodeBase and AssemblyName.EscapedCodeBase are obsolete

The following properties are marked as obsolete, starting in .NET 7. Using them in code generates warning `SYSLIB0044` at compile time.

- <xref:System.Reflection.AssemblyName.CodeBase?displayProperty=nameWithType>
- <xref:System.Reflection.AssemblyName.EscapedCodeBase?displayProperty=nameWithType>

## Workaround

Use <xref:System.Reflection.Assembly.Location?displayProperty=nameWithType> instead.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0044

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0044
```

To suppress all the `SYSLIB0044` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0044</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).

## See also

- [SYSLIB0012: Assembly.CodeBase and Assembly.EscapedCodeBase are obsolete](syslib0012.md)
