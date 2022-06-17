---
title: SYSLIB0016 warning
description: Learn about the GetContextInfo obsoletion that generates compile-time warning SYSLIB0016.
ms.date: 04/24/2021
---
# SYSLIB0016: GetContextInfo() is obsolete

The <xref:System.Drawing.Graphics.GetContextInfo?displayProperty=nameWithType> method that takes no arguments is marked as obsolete, starting in .NET 6. Using it in code generates warning `SYSLIB0016` at compile time.

For more information, see <https://github.com/dotnet/runtime/issues/47880>.

## Workarounds

For better performance and fewer allocations, use the <xref:System.Drawing.Graphics.GetContextInfo%2A?displayProperty=nameWithType> overloads that accept arguments:

- <xref:System.Drawing.Graphics.GetContextInfo(System.Drawing.PointF@)?displayProperty=fullName>
- <xref:System.Drawing.Graphics.GetContextInfo(System.Drawing.PointF@,System.Drawing.Region@)?displayProperty=fullName>

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0016

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0016
```

To suppress all the `SYSLIB0016` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0016</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
