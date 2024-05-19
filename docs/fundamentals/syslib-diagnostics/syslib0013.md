---
title: SYSLIB0013 warning
description: Learn about the EscapeUriString obsoletion that generates compile-time warning SYSLIB0013.
ms.date: 04/24/2021
f1_keywords:
  - syslib0013
---
# SYSLIB0013: EscapeUriString is obsolete

The <xref:System.Uri.EscapeUriString(System.String)?displayProperty=nameWithType> API is marked as obsolete, starting in .NET 6. Using it in code generates warning `SYSLIB0013` at compile time.

<xref:System.Uri.EscapeUriString(System.String)?displayProperty=nameWithType> can corrupt the Uri string in some cases.

For more information, see <https://github.com/dotnet/runtime/issues/31387>.

## Workarounds

Use <xref:System.Uri.EscapeDataString(System.String)?displayProperty=nameWithType> for query string components instead.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0013

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0013
```

To suppress all the `SYSLIB0013` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0013</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
