---
title: SYSLIB0019 warning
description: Learn about the RuntimeEnvironment obsoletions that generate compile-time warning SYSLIB0019.
ms.date: 04/24/2021
f1_keywords:
  - syslib0019
---
# SYSLIB0019: Some RuntimeEnvironment APIs are obsolete

The following APIs are marked as obsolete, starting in .NET 6. Using them in code generates warning `SYSLIB0019` at compile time.

- <xref:System.Runtime.InteropServices.RuntimeEnvironment.SystemConfigurationFile?displayProperty=nameWithType> property
- <xref:System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeInterfaceAsIntPtr(System.Guid,System.Guid)?displayProperty=nameWithType> method
- <xref:System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeInterfaceAsObject(System.Guid,System.Guid)?displayProperty=nameWithType> method

These APIs always throw a <xref:System.PlatformNotSupportedException> at run time.

## Workarounds

None.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0019

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0019
```

To suppress all the `SYSLIB0019` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0019</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
