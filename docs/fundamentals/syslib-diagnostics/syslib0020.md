---
title: SYSLIB0020 warning
description: Learn about the IgnoreNullValues obsoletion that generates compile-time warning SYSLIB0020.
ms.date: 04/24/2021
f1_keywords:
  - syslib0020
---
# SYSLIB0020: IgnoreNullValues is obsolete

The <xref:System.Text.Json.JsonSerializerOptions.IgnoreNullValues?displayProperty=nameWithType> property is marked as obsolete, starting in .NET 6. Using it in code generates warning `SYSLIB0020` at compile time.

## Workarounds

To ignore null values when serializing, set <xref:System.Text.Json.JsonSerializerOptions.DefaultIgnoreCondition> to <xref:System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull?displayProperty=nameWithType>. For more information, see <https://github.com/dotnet/runtime/issues/39152>.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0020

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0020
```

To suppress all the `SYSLIB0020` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0020</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
