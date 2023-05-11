---
title: SYSLIB0012 warning
description: Learn about the obsoletions that generate compile-time warning SYSLIB0012.
ms.date: 10/20/2020
---
# SYSLIB0012: Assembly.CodeBase and Assembly.EscapedCodeBase are obsolete

The following APIs are marked as obsolete, starting in .NET 5. Using them in code generates warning `SYSLIB0012` at compile time.

- <xref:System.Reflection.Assembly.CodeBase?displayProperty=nameWithType>
- <xref:System.Reflection.Assembly.EscapedCodeBase?displayProperty=nameWithType>

## Workarounds

Use <xref:System.Reflection.Assembly.Location?displayProperty=nameWithType> instead.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0012

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0012
```

To suppress all the `SYSLIB0012` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0012</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).

## See also

- [SYSLIB0044](syslib0044.md)
